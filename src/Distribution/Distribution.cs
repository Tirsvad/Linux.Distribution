using System.Runtime.InteropServices;

namespace TirsvadCLI.Linux;
public sealed class Distribution
{
    public string distributionName { get; set; } = "";
    public string distributionVersion { get; set; } = "";

    public Distribution()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            /*
                Get linux distrobution and version
            */
            foreach (string line in File.ReadAllLines("/etc/os-release"))
            {
                if (line.StartsWith("NAME"))
                {
                    this.distributionName = line.Substring(5).Trim('"');
                }
                if (line.StartsWith("VERSION_ID"))
                {
                    this.distributionVersion = line.Substring(11).Trim('"');
                }
            }
        }
    }

}
