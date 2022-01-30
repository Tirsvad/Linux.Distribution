using System.Runtime.InteropServices;

namespace TirsvadCLI.Linux;
public class Distribution
{
    public static string DistributionName { get; } = "";
    public static string DistributionVersion { get; }  = "";

    static Distribution()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            /*
                Get linux distribution and version
            */
            foreach (string line in File.ReadAllLines("/etc/os-release"))
            {
                if (line.StartsWith("NAME"))
                {
                    DistributionName = line.Substring(5).Trim('"');
                }
                if (line.StartsWith("VERSION_ID"))
                {
                    DistributionVersion = line.Substring(11).Trim('"');
                }
            }
        }
    }
}
