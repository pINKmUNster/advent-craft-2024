using FluentAssertions;
using Xunit;
using static System.IO.File;

namespace Delivery.Tests
{
    public class DeliveryShould
    {
        [Theory]
        [InlineData("1", 0)]
        [InlineData("2", 3)]
        [InlineData("3", -1)]
        [InlineData("4", 53)]
        [InlineData("5", -3)]
        [InlineData("6", 2920)]
        [InlineData("7", 1)]
        [InlineData("8", -1)]
        public void Return_Floor_Number_Based_On_Instructions(string fileName, int expectedFloor)
            => Building.WhichFloor(ReadAllText($"{fileName}.txt"))
                .Should()
                .Be(expectedFloor);

        [Fact]
        public void X()
        {
            var allText = ReadAllText($"6.txt");

            var length = allText.Length;
            var closing = allText.Where(t => t == ')').Count();
            var opening = allText.Where(t => t == '(').Count();
            var otherChar = length - closing - opening;
            var myResult = closing * 3 + opening * -2;
            myResult.Should().Be(2920);
        }
    }
}