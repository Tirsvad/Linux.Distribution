using System.Runtime.InteropServices;

namespace TirsvadCLI.Linux
{
    public class Distribution
    {
        public static string distributionName { get; } = "";
        public static string distributionVersion { get; } = "";

        static Distribution()
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
                        distributionName = line.Substring(5).Trim('"');
                    }
                    if (line.StartsWith("VERSION_ID"))
                    {
                        distributionVersion = line.Substring(11).Trim('"');
                    }
                }
            }
        }
    }
}
