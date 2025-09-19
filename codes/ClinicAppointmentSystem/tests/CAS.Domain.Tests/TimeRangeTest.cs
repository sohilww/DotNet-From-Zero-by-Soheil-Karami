using FluentAssertions;

namespace CAS.Domain.Tests
{
    public class TimeRangeTests
    {
        [Fact]
        public void constructor_with_valid_times_should_create_time_range()
        {
            var timeRange = new TimeRange(new TimeOnly(9, 0), new TimeOnly(17, 0));

            timeRange.StartTime.Should().Be(new TimeOnly(9, 0));
            timeRange.EndTime.Should().Be(new TimeOnly(17, 0));
        }

        [Fact]
        public void constructor_when_end_time_before_start_time_should_throw_exception()
        {
            Action act = () => new TimeRange(new TimeOnly(17, 0), new TimeOnly(9, 0));

            act.Should().Throw<ArgumentException>().WithMessage("End time must be after start time.");
        }

        [Fact]
        public void constructor_when_end_time_equals_start_time_should_throw_exception()
        {
            Action act = () => new TimeRange(new TimeOnly(9, 0), new TimeOnly(9, 0));

            act.Should().Throw<ArgumentException>().WithMessage("End time must be after start time.");
        }


        [Fact]
        public void properties_should_be_read_only()
        {
            var timeRange = new TimeRange(new TimeOnly(9, 0), new TimeOnly(17, 0));

            typeof(TimeRange).GetProperty(nameof(TimeRange.StartTime))
                .CanWrite.Should().BeFalse();

            typeof(TimeRange).GetProperty(nameof(TimeRange.EndTime))
                .CanWrite.Should().BeFalse();
        }
    }
}