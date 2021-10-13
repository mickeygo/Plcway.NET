using Xunit;

namespace Plcway.Communication.Tests.Common
{
    public class Enum_Tests
    {
        [Fact]
        public void Should_Get_DescriptionAttribute_Test()
        {
            var v1 = $"{ErrorCode.Success.Desc()}";
            Assert.True(v1 == "[10000] Success", v1);
        }
    }
}
