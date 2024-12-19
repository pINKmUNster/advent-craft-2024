using FluentAssertions;
using Xunit;

namespace EID.Tests
{
    public class EidValidatorTests
    {
        // We should test

        // First digit is 
        // 1 is a Sloubi
        // 2 is gagna 
        // 3 is catact
        // 2 & 3 digit is for the year (98 is for 1998)
        // 4, 5, 6 digits is for birth order 001,002,...
        // 7, 8 is control digits for example 67 because 67 is the result of
        // 198007 % 97 = 30
        // 97 - 30 = 67

        [Fact]
        public void A_First_Test()
            => 43.Should()
                .Be(42, "it is universal answer");


        public static TheoryData<string, string> InvalidScenario = new()
        {
            { null, "Cannot be null" },
            { string.Empty, "Cannot be empty" },
            { "2230", "Too short" },
            { "40000325555", "Too long" },
            { "40000325", "Incorrect Sex" },
            { "1ab14599", "Incorrect year" },
            { "1a414599", "Incorrect year" },
            { "19814x08", "Incorrect serial number" },
            { "19912378", "Incorrect control key" }
        };

        [Theory]
        [MemberData(nameof(InvalidScenario))]
        public void Eid_Is_Invalid(string invalidEid, string reason)
            => EidValidator.Validate(invalidEid).Should().BeFalse(reason);
    }
}