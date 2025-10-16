using CAS.Domain.SlotAggregate;

namespace CAS.Domain.DoctorAggregate.Repositories;

public interface ISlotRepository
{
    Task CreateSlots(IReadOnlyList<Slot>  slots, CancellationToken cancellationToken);
}