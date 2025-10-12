using CAS.Domain.DoctorAggregate;
using Framework.Domain;

namespace CAS.Domain.SlotAggregate;

public class Slot : AggregateRoot<SlotId>
{
    public DateTime StartDateTime { get;private set; }
    public DateTime EndDateTime { get;private set; }
    public DoctorId DoctorId { get;private set; }

    public Slot(SlotId id, DateTime startDate, DateTime endDate, DoctorId doctorId) : base(id)
    {
        StartDateTime = startDate;
        EndDateTime = endDate;
        DoctorId = doctorId;
    }

    
}