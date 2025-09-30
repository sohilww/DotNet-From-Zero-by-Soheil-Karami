using Framework.Domain;

namespace CAS.Domain;
public class Patient : AggregateRoot<PatientId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public ContactInfo ContactInfo { get; private set; }

    public List<Appointment> Appointments { get; private set; } = new();

    public Patient(PatientId id, string firstName, string lastName, ContactInfo contactInfo)
        : base(id)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        ContactInfo = contactInfo ?? throw new ArgumentNullException(nameof(contactInfo));
    }

    public void AddAppointment(Appointment appointment)
    {
        if (appointment == null) throw new ArgumentNullException(nameof(appointment));
        Appointments.Add(appointment);
    }
}
