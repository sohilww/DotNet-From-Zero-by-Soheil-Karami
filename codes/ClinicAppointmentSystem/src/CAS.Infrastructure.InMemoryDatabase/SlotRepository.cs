using CAS.Domain.DoctorAggregate.Repositories;
using CAS.Domain.SlotAggregate;

namespace CAS.Infrastructure.InMemoryDatabase;

public class SlotRepository : ISlotRepository
{
    static List<Slot> _slots = new List<Slot>();
    public async Task CreateSlots(IReadOnlyList<Slot> slots, CancellationToken cancellationToken)
    {
        _slots.AddRange(slots);
    }
}