using Xunit;
using TirsvadCLI.Linux;

namespace XUnit.Project;

public class ConstShouldBe
{
    [Fact]
    public void Catch_Empty_DistributionName()
    {
        Assert.NotEmpty(Distribution.DistributionName);
    }
    [Fact]
    public void Catch_Null_DistributionVersion()
    {
        Assert.NotNull(Distribution.DistributionVersion);
    }
}
