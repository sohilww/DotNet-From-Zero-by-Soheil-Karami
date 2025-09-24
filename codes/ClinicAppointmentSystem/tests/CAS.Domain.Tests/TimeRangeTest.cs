using FluentAssertions;

namespace CAS.Domain.Tests
{
    public class TimeRangeTest
    {
        [Fact]
        public void Should_valid_end_time_after_start_time()
        {

            var startTime = new TimeOnly(12, 00);
            var endTime = new TimeOnly(16, 00);

            Action act = () => new TimeRange(startTime, endTime);

            act.Should().NotThrow();
        }


        [Theory]
        [InlineData("10:30", "11:30", true)]
        [InlineData("11:00", "13:00", false)]
        [InlineData("09:00", "11:00", false)]
        [InlineData("09:00", "13:00", false)]
        [InlineData("10:00", "12:00", false)]
        [InlineData("08:00", "09:00", false)]
        [InlineData("13:00", "14:00", false)]
        [InlineData("08:00", "10:00", false)]
        [InlineData("12:00", "13:00", false)]
        public void HasOverlap_Should_Return_Correct_Value_For_Various_Scenarios(
       string otherStartTimeStr, string otherEndTimeStr, bool expectedResult)
        {
            var mainRange = new TimeRange(new TimeOnly(10, 0), new TimeOnly(12, 0));
            var otherRange = new TimeRange(TimeOnly.Parse(otherStartTimeStr), TimeOnly.Parse(otherEndTimeStr));

            bool actualResult = mainRange.HasOverlapp(otherRange);

            actualResult.Should().Be(expectedResult);
        }
    }
}
