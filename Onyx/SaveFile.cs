using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Onyx
{
    class SaveFile
    {
        private (int row, int col, int direction) worldPlayerLocation;
        private (int row, int col, int direction) secondaryPlayerLocation;

        private static string directoryPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Onyx";
        private static string saveFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Onyx\\Save.json";

        public static void Check()
        {
            Program.hasSave = File.Exists(saveFilePath);
        }

        private static SaveFile save = new SaveFile();

        public static void Save()
        {
            if (!Program.hasSave)
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.Create(saveFilePath);
            }

            GetSaveInfo();

            string stringSave = JsonConvert.SerializeObject(save, Formatting.Indented);

            File.WriteAllText(saveFilePath, stringSave);

            void GetSaveInfo()
            {

            }
        }

        public static void load()
        {
            string stringSave = File.ReadAllText(saveFilePath);

            save = (SaveFile)JsonConvert.DeserializeObject(stringSave);

            void SetLoadedInfo()
            {

            }
        }
    }
}
