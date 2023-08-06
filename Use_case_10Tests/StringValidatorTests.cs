using Xunit;

namespace Use_case_10.Tests
{
    public class StringValidatorTests
    {
        [Theory()]
        [InlineData("aA1", "Failed min length check")]
        [InlineData("123456Aa+++", "Failed max length check")]
        [InlineData("aa1+aa", "Failed a capital letter  check")]
        [InlineData("AA1+AA", "Failed a lower letter  check")]
        [InlineData("aaA+aa", "Failed a digit check")]
        [InlineData("111aAaa", "Failed  a special char check")]
        [InlineData("aaaAA+A+", "Failed  a digit check")]
        [InlineData("aaa A+A+", "Failed no whitespace check")]
        [InlineData("a A+a A+", "Failed no whitespace check")]
        [InlineData("a a A+A+", "Failed no whitespace check")]
        public void ValidateTest_Invalid_Input_Returns_False(string str, string error)
        {
            // act
            bool result = new StringValidator(4,8).Validate(str);

            // assert
            Assert.False(result, error);
        }

        [Theory()]
        [InlineData("aA1+")]
        [InlineData("aA1+aaa")]
        [InlineData("aA1+1")]
        public void ValidateTest_Valid_Input_Returns_True(string str)
        {
            // act
            bool result = new StringValidator(4, 8).Validate(str);

            // assert
            Assert.True(result);
        }
    }
}