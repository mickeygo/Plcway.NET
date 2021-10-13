using Xunit;

namespace Plcway.Communication.Tests.Syntax
{
    public class Syntax_Tests
    {
        [Fact]
        public void Should_String_Span_Test()
        {
            var str = "123456789";

            var v1 = str[0..2];
            Assert.True(v1 == "12", v1);

            var v2 = str[^2]; // str[str.Length - 2]
            Assert.True(v2 == '8', v2.ToString());
            Assert.True(v2 == str[str.Length - 2], v2.ToString());
        }
    }
}
