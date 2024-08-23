using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Taskly
{
    public class SettingsFileHandling
    {
            public void Save(int LangIndex, int ThemeIndex)
            {
                string filePath = GlobalSettings.SettingsFilePath;

                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                    {
                        writer.Write(LangIndex);
                        writer.Write(ThemeIndex);
                    }
            }

            public (int LangIndex,int ThemeIndex) Load()
            {
                string filePath = GlobalSettings.SettingsFilePath;

                if (!File.Exists(filePath))
                {
                    return (0, 0); // Default values if the file does not exist
                }

                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    int int1 = reader.ReadInt32();
                    int int2 = reader.ReadInt32();
                    return (int1, int2);
                }
            }

    }
}
