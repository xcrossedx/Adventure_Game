using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Onyx
{
    class SaveFile
    {
        public static void Check()
        {
            Program.hasSave = File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Save");
        }

        public static void Save()
        {

        }

        public static void load()
        {

        }
    }
}
