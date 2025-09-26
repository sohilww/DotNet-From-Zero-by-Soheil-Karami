using System.Reflection;

namespace Framework.Core;

public class EqualsBuilder
{
    private bool isEqual;

    public EqualsBuilder()
    {
        isEqual = true;
    }

    public static bool ReflectionEquals(Object lhs, Object rhs)
    {
        return ReflectionEquals(lhs, rhs, false, null);
    }

    public static bool ReflectionEquals(Object lhs, Object rhs, bool testTransients)
    {
        return ReflectionEquals(lhs, rhs, testTransients, null);
    }

    public static bool ReflectionEquals(Object lhs, Object rhs, bool testTransients, Type reflectUpToClass)
    {
        if (lhs == rhs)
        {
            return true;
        }
        if (lhs == null || rhs == null)
        {
            return false;
        }
        // Find the leaf class since there may be transients in the leaf 
        // class or in classes between the leaf and root.
        // If we are not testing transients or a subclass has no ivars, 
        // then a subclass can test equals to a superclass.
        Type lhsClass = lhs.GetType();
        Type rhsClass = rhs.GetType();
        Type testClass;
        if (lhsClass.IsInstanceOfType(rhs))
        {
            testClass = lhsClass;
            if (!rhsClass.IsInstanceOfType(lhs))
            {
                // rhsClass is a subclass of lhsClass
                testClass = rhsClass;
            }
        }
        else if (rhsClass.IsInstanceOfType(lhs))
        {
            testClass = rhsClass;
            if (!lhsClass.IsInstanceOfType(rhs))
            {
                // lhsClass is a subclass of rhsClass
                testClass = lhsClass;
            }
        }
        else
        {
            // The two classes are not related.
            return false;
        }
        EqualsBuilder equalsBuilder = new EqualsBuilder();
        try
        {
            ReflectionAppend(lhs, rhs, testClass, equalsBuilder, testTransients);
            while (testClass.BaseType != null && testClass != reflectUpToClass)
            {
                testClass = testClass.BaseType;
                ReflectionAppend(lhs, rhs, testClass, equalsBuilder, testTransients);
            }
        }
        catch (ArgumentException e)
        {
            // In this case, we tried to test a subclass vs. a superclass and
            // the subclass has ivars or the ivars are transient and 
            // we are testing transients.
            // If a subclass has ivars that we are trying to test them, we get an
            // exception and we know that the objects are not equal.
            return false;
        }
        return equalsBuilder.IsEquals();
    }

    private static void ReflectionAppend(
        Object lhs,
        Object rhs,
        Type clazz,
        EqualsBuilder builder,
        bool useTransients)
    {
        /*
         * In Java version of this ReflectionAppend, we have to call
         * AccessibleObject.setAccessible() right after class.GetFields() to
         * make non-public fields accessible. In C#, it is easier to do. We simply
         * add BindingFlags.NonPublic, which makes non-public fields accessible
         * (subject to security manager restrictions, of course).
         */
        FieldInfo[] fields = clazz.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        for (int i = 0; i < fields.Length && builder.isEqual; i++)
        {
            FieldInfo f = fields[i];
            //TODO:atrosin Revise:f.getName().indexOf('$')
            if ((f.Name.IndexOf('$') == -1)
                && (useTransients || !isTransient(f))
                && !f.IsStatic)
            {
                try
                {
                    builder.Append(f.GetValue(lhs), f.GetValue(rhs));
                }
                /*
                 * According to FieldInfo's documentation, getValue() can throw the
                 * following exceptions: TargetException, NotSupportedException,
                 * FieldAccessException and ArgumentException.
                 *
                 * TargetException is thrown if the field is non-static and obj is
                 * a null reference. In our case, the field is non-static (because of
                 * BindingFlags.Instance) but obj should never be null because of
                 * null checks in the calling method (i.e. reflectionEquals()).
                 * I guess we can just throw an unexpected exception.
                 *
                 * NotSupportedException is thrown if the field is marked Literal, but
                 * the field does not have one of the accepted literal types. Literal
                 * means that the field's value is a compile-time (static or early
                 * bound) constant. I think this exception can be just eaten because
                 * constants should always be equal in lhs and rhs and default value
                 * of isEqual is true.
                 *
                 * FieldAccessException is thrown if the caller does not have
                 * permission to access this field. If this code is fully trusted
                 * (not sure how to verify this), access restrictions are ignored.
                 * This means that private fields are accessible. If this code is not
                 * fully trusted, it can still access private fields if this code
                 * has been granted ReflectedPermission with the
                 * ReflectionPermisionFlag.RestrictedMemberAccess flag and if the
                 * grant set of the non-public members is restricted to the caller's
                 * grant set, or subset thereof. Whew, that's a mouthful to say!
                 * I guess it's best just to let FieldAccessException bubble up
                 * to callers so that user can grant permissions, if desired.
                 *
                 * Finally, ArgumentException is thrown if the method is neither
                 * declared nor inherited by the class of obj. This could happen
                 * if lhs is a subclass of rhs (or vice-versa) and the field is
                 * declared in the subclass. In Java, Field.get() would throw
                 * IllegalArgumentException in this case. In Java version of
                 * reflectionAppend(), IllegalArgumentException
                 * bubbles up to reflectionEquals(), where it is dealt with.
                 * It seems logical that use the same technique in the C#
                 * version. That is, we allow ArgumentException to bubble up
                 * to ReflectionEquals() and deal with it there.
                 */
                catch (TargetException te)
                {
                    throw new Exception("Unexpected TargetException", te);
                }
                catch (NotSupportedException nse)
                {
                    // eat it!
                }
                /* Don't catch FieldAccessException and ArgumentException so that
                 * they can bubble up to caller. Alternatively, we could catch and
                 * rethrow.
                 */
                //catch (FieldAccessException fae) { throw; }
                //catch (ArgumentException fae) { throw; }
            }
        }
    }

    public EqualsBuilder AppendSuper(bool superEquals)
    {
        if (isEqual == false)
        {
            return this;
        }
        isEqual = superEquals;
        return this;
    }

    public EqualsBuilder Append(Object lhs, Object rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        Type lhsClass = lhs.GetType();
        if (!lhsClass.IsArray)
        {
            //the simple case, not an array, just test the element
            isEqual = lhs.Equals(rhs);
        }
        else
        {
            EnsureArraysSameDemention(lhs, rhs);
            if (isEqual == false)
            {
                return this;
            }

            //'Switch' on type of array, to dispatch to the correct handler
            // This handles multi dimensional arrays
            if (lhs is long[])
            {
                Append((long[])lhs, rhs as long[]);
            }
            else if (lhs is int[])
            {
                Append((int[])lhs, rhs as int[]);
            }
            else if (lhs is short[])
            {
                Append((short[])lhs, rhs as short[]);
            }
            else if (lhs is char[])
            {
                Append((char[])lhs, rhs as char[]);
            }
            else if (lhs is byte[])
            {
                Append((byte[])lhs, rhs as byte[]);
            }
            else if (lhs is double[])
            {
                Append((double[])lhs, rhs as double[]);
            }
            else if (lhs is float[])
            {
                Append((float[])lhs, rhs as float[]);
            }
            else if (lhs is bool[])
            {
                Append((bool[])lhs, rhs as bool[]);
            }
            else if (lhs is object[])
            {
                Append((object[])lhs, rhs as object[]);
            }
            {
                // Not an simple array of primitives
                CompareArrays(lhs, rhs, 0, 0);
            }
        }
        return this;
    }


    private void EnsureArraysSameDemention(object lhs, object rhs)
    {
        bool isArray1 = lhs is Array;
        bool isArray2 = rhs is Array;

        if (isArray1 != isArray2)
        {
            isEqual = false;
            return;
        }

        Array array1 = (Array)lhs;
        Array array2 = (Array)lhs;

        if (array1.Rank != array2.Rank)
        {
            isEqual = false;
        }

        if (array1.Length != array2.Length)
        {
            isEqual = false;
        }
    }

    private void CompareArrays(object parray1, object parray2, int prank, int pindex)
    {
        if (isEqual == false)
        {
            return;
        }
        if (parray1 == parray2)
        {
            return;
        }
        if (parray1 == null || parray2 == null)
        {
            isEqual = false;
            return;
        }

        Array array1 = (Array)parray1;
        Array array2 = (Array)parray2;
        int rank1 = array1.Rank;
        int rank2 = array2.Rank;

        if (rank1 != rank2)
        {
            isEqual = false;
            return;
        }

        int size1 = array1.GetLength(prank);
        int size2 = array2.GetLength(prank);

        if (size1 != size2)
        {
            isEqual = false;
            return;
        }

        if (prank == rank1 - 1)
        {
            int index = 0;

            int min = pindex;
            int max = min + size1;


            var enumerator1 = array1.GetEnumerator();
            var enumerator2 = array2.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                if (isEqual == false)
                {
                    return;
                }
                enumerator2.MoveNext();


                if ((index >= min) && (index < max))
                {
                    object obj1 = enumerator1.Current;
                    object obj2 = enumerator2.Current;

                    bool isArray1 = obj1 is Array;
                    bool isArray2 = obj2 is Array;

                    if (isArray1 != isArray2)
                    {
                        isEqual = false;
                        return;
                    }

                    if (isArray1)
                    {
                        CompareArrays(obj1, obj2, 0, 0);
                    }
                    else
                    {
                        Append(obj1, obj2);
                    }
                }

                index++;
            }
        }
        else
        {
            int mux = 1;

            int currentRank = rank1 - 1;

            do
            {
                int sizeMux1 = array1.GetLength(currentRank);
                int sizeMux2 = array2.GetLength(currentRank);

                if (sizeMux1 != sizeMux2)
                {
                    isEqual = false;
                    return;
                }

                mux *= sizeMux1;
                currentRank--;
            } while (currentRank > prank);

            for (int i = 0; i < size1; i++)
            {
                Console.Write("{ ");
                CompareArrays(parray1, parray2, prank + 1, pindex + (i * mux));
                Console.Write("} ");
            }
        }
    }


    public EqualsBuilder Append(long lhs, long rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        isEqual = (lhs == rhs);
        return this;
    }

    public EqualsBuilder Append(int lhs, int rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        isEqual = (lhs == rhs);
        return this;
    }

    public EqualsBuilder Append(short lhs, short rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        isEqual = (lhs == rhs);
        return this;
    }

    public EqualsBuilder Append(char lhs, char rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        isEqual = (lhs == rhs);
        return this;
    }

    public EqualsBuilder Append(DateTime lhs, DateTime rhs)
    {
        var diff = lhs.Subtract(rhs).Seconds;
        isEqual = (Math.Abs(diff) == 0);
        return this;
    }

    public EqualsBuilder Append(byte lhs, byte rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        isEqual = (lhs == rhs);
        return this;
    }

    public EqualsBuilder Append(double lhs, double rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        // java: return append(Double.doubleToLongBits(lhs), Double.doubleToLongBits(rhs));
        return Append(BitConverter.DoubleToInt64Bits(lhs), BitConverter.DoubleToInt64Bits(rhs));
    }

    public EqualsBuilder Append(double lhs, double rhs, double epsilon)
    {
        if (isEqual == false)
        {
            return this;
        }
        isEqual = MathUtil.DoubleEqualTo(lhs, rhs, epsilon);
        return this;
    }

    public EqualsBuilder Append(float lhs, float rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        // java: return append(Float.floatToIntBits(lhs), Float.floatToIntBits(rhs));
        return Append(
            BitConverterUtil.SingleToInt32Bits(lhs),
            BitConverterUtil.SingleToInt32Bits(rhs));
    }

    public EqualsBuilder Append(float lhs, float rhs, float epsilon)
    {
        if (isEqual == false)
        {
            return this;
        }
        isEqual = MathUtil.FloatEqualTo(lhs, rhs, epsilon);
        return this;
    }

    public EqualsBuilder Append(bool lhs, bool rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        isEqual = (lhs == rhs);
        return this;
    }

    public EqualsBuilder Append(Object[] lhs, Object[] rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        if (lhs.Length != rhs.Length)
        {
            isEqual = false;
            return this;
        }
        for (int i = 0; i < lhs.Length && isEqual; ++i)
        {
            if (lhs[i] != null)
            {
                Type lhsClass = lhs[i].GetType();
                if (!lhsClass.IsInstanceOfType(rhs[i]))
                {
                    isEqual = false; //If the types don't match, not equal
                    break;
                }
            }
            Append(lhs[i], rhs[i]);
        }
        return this;
    }

    public EqualsBuilder Append(long[] lhs, long[] rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        if (lhs.Length != rhs.Length)
        {
            isEqual = false;
            return this;
        }
        for (int i = 0; i < lhs.Length && isEqual; ++i)
        {
            Append(lhs[i], rhs[i]);
        }
        return this;
    }

    public EqualsBuilder Append(int[] lhs, int[] rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        if (lhs.Length != rhs.Length)
        {
            isEqual = false;
            return this;
        }
        for (int i = 0; i < lhs.Length && isEqual; ++i)
        {
            Append(lhs[i], rhs[i]);
        }
        return this;
    }

    public EqualsBuilder Append(short[] lhs, short[] rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        if (lhs.Length != rhs.Length)
        {
            isEqual = false;
            return this;
        }
        for (int i = 0; i < lhs.Length && isEqual; ++i)
        {
            Append(lhs[i], rhs[i]);
        }
        return this;
    }

    public EqualsBuilder Append(char[] lhs, char[] rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        if (lhs.Length != rhs.Length)
        {
            isEqual = false;
            return this;
        }
        for (int i = 0; i < lhs.Length && isEqual; ++i)
        {
            Append(lhs[i], rhs[i]);
        }
        return this;
    }

    public EqualsBuilder Append(byte[] lhs, byte[] rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        if (lhs.Length != rhs.Length)
        {
            isEqual = false;
            return this;
        }
        for (int i = 0; i < lhs.Length && isEqual; ++i)
        {
            Append(lhs[i], rhs[i]);
        }
        return this;
    }

    public EqualsBuilder Append(double[] lhs, double[] rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        if (lhs.Length != rhs.Length)
        {
            isEqual = false;
            return this;
        }
        for (int i = 0; i < lhs.Length && isEqual; ++i)
        {
            Append(lhs[i], rhs[i]);
        }
        return this;
    }

    public EqualsBuilder Append(float[] lhs, float[] rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        if (lhs.Length != rhs.Length)
        {
            isEqual = false;
            return this;
        }
        for (int i = 0; i < lhs.Length && isEqual; ++i)
        {
            Append(lhs[i], rhs[i]);
        }
        return this;
    }

    public EqualsBuilder Append(bool[] lhs, bool[] rhs)
    {
        if (isEqual == false)
        {
            return this;
        }
        if (lhs == rhs)
        {
            return this;
        }
        if (lhs == null || rhs == null)
        {
            isEqual = false;
            return this;
        }
        if (lhs.Length != rhs.Length)
        {
            isEqual = false;
            return this;
        }
        for (int i = 0; i < lhs.Length && isEqual; ++i)
        {
            Append(lhs[i], rhs[i]);
        }
        return this;
    }

    public bool IsEquals()
    {
        return isEqual;
    }


    private static bool isTransient(FieldInfo fieldInfo)
    {
        return (fieldInfo.Attributes & FieldAttributes.NotSerialized) == FieldAttributes.NotSerialized;
    }
}