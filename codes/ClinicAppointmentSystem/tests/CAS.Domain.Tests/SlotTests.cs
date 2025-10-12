using CAS.Domain.DoctorAggregate;
using CAS.Domain.SlotAggregate;
using FluentAssertions;

namespace CAS.Domain.Tests;

public class SlotTests
{
    [Fact]
    public void should_create_slot_properly()
    {
        var slotId = SlotId.Generate();
        var startDate = DateTime.Now;
        var endDate = DateTime.Now;
        var doctorId=DoctorId.Generate();
        var slot = new Slot(slotId, startDate,endDate,doctorId);
        
        slot.Id.Should().Be(slotId);
        slot.StartDateTime.Should().Be(startDate);
        slot.EndDateTime.Should().Be(endDate);
        slot.DoctorId.Should().Be(doctorId);
    }
}