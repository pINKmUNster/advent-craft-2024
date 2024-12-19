using FakeItEasy;
using Xunit;

namespace Routine.Tests
{
    public class RoutineTests
    {
        [Fact]
        public void StartRoutine_With_FakeItEasy()
        {
            // Write a test using FakeItEasy library
            var emailService = A.Fake<IEmailService>();
            var scheduleService = A.Fake<IScheduleService>();
            var reindeerFeeder = A.Fake<IReindeerFeeder>();

            var schedule = new Schedule();
            A.CallTo(() => scheduleService.TodaySchedule()).Returns(schedule);
            
            var routine = new Routine(
                emailService,
                scheduleService,
                reindeerFeeder
            );
            routine.Start();
            
            // Assert That we received in order
            A.CallTo(() => scheduleService.TodaySchedule()).MustHaveHappenedOnceExactly();
            A.CallTo(() => scheduleService.OrganizeMyDay(A<Schedule>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => reindeerFeeder.FeedReindeers()).MustHaveHappenedOnceExactly();
            A.CallTo(() => emailService.ReadNewEmails()).MustHaveHappenedOnceExactly();
            A.CallTo(() => scheduleService.Continue()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void StartRoutine_With_Manual_Test_Doubles()
        {
            // Write a test using your own Test Double(s)
        }
    }
}