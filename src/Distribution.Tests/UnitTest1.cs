using System;
using Xunit;

using TirsvadCLI.Linux.Distribution;

namespace TirsvadCLI.Linux.Distribution.Tests;

public class ConstShouldBe
{
    [Fact]
    public void CatchEmptyDistributionName()
    {
        Assert.NotEmpty(Distribution.distributionName);
    }
    [Fact]
    public void CatchNullDistributionVersion()
    {
        Assert.NotNull(Distribution.distributionVersion);
    }
}