using FluentAssertions;
using Xunit;

namespace GiftWish.Tests
{
    public class SantaServiceTests
    {
        private readonly SantaService _service = new();

        [Fact]
        public void RequestIsApprovedForNiceChildWithFeasibleGift()
        {
            // var niceChild = new Child("Alice", "Thomas", 9, Behavior.Nice, new GiftRequest("Bicycle", true, Priority.NiceToHave));

            var niceChild = new ChildBuilder()
                .WithNice()
                .Build();
            _service.EvaluateRequest(niceChild).Should().BeTrue();
        }

        [Fact]
        public void RequestIsDeniedForNaughtyChild()
        {
            var naughtyChild = new ChildBuilder()
                .WithNaughty()
                .Build();
            _service.EvaluateRequest(naughtyChild).Should().BeFalse();
        }

        [Fact]
        public void RequestIsDeniedForNiceChildWithInfeasibleGift()
        {
            var niceChildWithInfeasibleGift = new ChildBuilder()
                .WithNice()
                .RequestIsInfeasible()
                .Build();
            
            _service.EvaluateRequest(niceChildWithInfeasibleGift).Should().BeFalse();
        }
    }

    public class GiftRequestBuilder
    {
        private const string Name = "Bicycle";
        private bool _isFeasible = true;
        private const Priority Priority = GiftWish.Priority.NiceToHave;

        public static implicit operator GiftRequest(GiftRequestBuilder builder)
        {
            return builder.Build();
        }

        public GiftRequestBuilder WithFeasibility(bool isFeasible)
        {
            _isFeasible = isFeasible;
            return this;
        }

        public GiftRequest Build()
        {
            return new GiftRequest(Name, _isFeasible, Priority);
        }
    }

    public class ChildBuilder
    {
        private Behavior _behavior;
        private bool _isFeasible = true;

        public ChildBuilder WithNice()
        {
            _behavior = Behavior.Nice;
            return this;
        }

        public Child Build()
        {
            var gift = new GiftRequestBuilder()
                .WithFeasibility(_isFeasible)
                .Build();
            return new Child("Alice", "Thomas", 9, _behavior, gift);
        }

        public ChildBuilder WithNaughty()
        {
            _behavior = Behavior.Naughty;
            return this;
        }

        public ChildBuilder RequestIsInfeasible()
        {
            _isFeasible = false;
            return this;
        }
    }
}