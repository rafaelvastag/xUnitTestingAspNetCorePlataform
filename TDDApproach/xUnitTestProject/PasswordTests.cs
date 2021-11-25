using System;
using TDDApproach;
using Xunit;

namespace xUnitTestProject
{
    public class PasswordTests
    {
        [Fact]
        [Trait("Category","Password")]
        public void Validate_GivenLongerThan8Chars_ReturnTrue()
        {
            var testTarget = new DefaultPasswordValidator();
            var password = MakeRandomString(7)+"A";

            var validationResult = testTarget.Validate(password);

            Assert.True(validationResult);
        }

        [Fact]
        [Trait("Category", "Password")]
        public void Validate_GivenShorterThan8Chars_ReturnFalse()
        {
            var testTarget = new DefaultPasswordValidator();
            var password = MakeRandomString(3);

            var validationResult = testTarget.Validate(password);

            Assert.False(validationResult);
        }

        [Fact]
        [Trait("Category", "Password")]
        public void Validate_GivenNoUpperCase_ReturnFalse()
        {
            var testTarget = new DefaultPasswordValidator();
            var password = MakeRandomString(3);

            var validationResult = testTarget.Validate(password);

            Assert.False(validationResult);
        }

        [Fact]
        [Trait("Category", "Password")]
        public void Validate_GivenOneUpperCase_ReturnTrue()
        {
            var testTarget = new DefaultPasswordValidator();
            var password = MakeRandomString(7) + "A";

            var validationResult = testTarget.Validate(password);

            Assert.True(validationResult);
        }

        private string MakeRandomString(int length)
        {
            string result = "";

            for (int i = 1; i <= length; i++)
            {
                result += "a";
            }
            return result;
        }
    }
}
