using FluentAssertions;
using Xunit;

namespace Workshop.Tests
{
    public class WorkshopTest
    {
        private const string ToyName = "1 Super Nintendo";

        [Fact]
        public void CompletingAGiftShouldSetItsStatusToProduced()
        {
            var workshop = new Workshop();
            workshop.AddGift(new Gift(ToyName));

            var completedGift = workshop.CompleteGift(ToyName);

            completedGift.Should()
                .NotBeNull();
            completedGift.Status.Should()
                .Be(Status.Produced);
        }

        [Fact]
        public void CompletingANonExistingGiftShouldReturnNull()
        {
            var workshop = new Workshop();
            var completedGift = workshop.CompleteGift("NonExistingToy");
            
            completedGift.Should()
                .BeNull();
        }
    }
}