using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Uitls.DetectionUtils
{
    class DetectionUtilInDirectoryForDifferentVersion : DetectionUtil
    {
        public override string Detect()
        {
            if (Directory.Exists(Path))
            {
                try
                {
                    double max = 0;
                    double version;
                    int index = -1;
                    string[] subDirectories = Directory.GetDirectories(Path);
                    for (int i = 0; i < subDirectories.Length; i++)
                    {
                        try
                        {
                            version = Convert.ToDouble(subDirectories[i].Substring(Path.Length));
                            if (version > max)
                            {
                                if (File.Exists(System.IO.Path.Combine(subDirectories[i], this.ExecutableFileName)))
                                {
                                    max = version;
                                    index = i;
                                }
                            }
                        }
                        catch
                        {
                            // ignore the exception
                        }
                    }

                    if (index != -1)
                    {
                        return System.IO.Path.Combine(subDirectories[index], this.ExecutableFileName);
                    }
                }
                catch (Exception ex)
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, ex.Message);
                }
            }
            return null;
        }
    }
}
