using FluentAssertions;
using Xunit;

namespace Preparation.Tests
{
    public class SantaWorkshopServiceTests
    {
        private const string RecommendedAge = "recommendedAge";
        private readonly SantaWorkshopService _service = new();
        private readonly Bogus.Faker _faker = new();

        [Fact]
        public void PrepareGift_WithValidToy_ShouldInstantiateIt()
        {
            var gift = PrepareGift(GetValidWeight());
            gift.Should()
                .NotBeNull();
        }

        [Fact]
        public void RetrieveAttributeOnGift()
        {
            var gift = PrepareGift(GetValidWeight());
            gift.AddAttribute(RecommendedAge, "3");

            gift.RecommendedAge()
                .Should()
                .Be(3);
        }

        private double GetValidWeight() => _faker.Random.Double(0, 5);

        private Gift PrepareGift(double weight)
        {
            var giftName = _faker.Commerce.Product();
            var color = _faker.Commerce.Color();
            var material = _faker.Commerce.ProductMaterial();
            var gift = _service.PrepareGift(giftName, weight, color, material);
            return gift;
        }

        [Fact]
        public void FailsForATooHeavyGift()
        {
            var invalidWeight = _faker.Random.Double(6, double.MaxValue);

            var prepareGift = () => PrepareGift(invalidWeight);

            prepareGift.Should()
                .Throw<ArgumentException>()
                .WithMessage("Gift is too heavy for Santa's sleigh");
        }
    }
}