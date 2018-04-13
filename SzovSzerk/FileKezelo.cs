using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SzovSzerk
{
    class FileKezelo
    {
        public static void SaveData(string patch, string text)
        {
            string[] lines = text.Split('\n');
            using (StreamWriter sw = new StreamWriter(patch)) // Erőforrás felszabadítás
            {
                foreach (string item in lines)
                {
                    sw.WriteLine(lines);
                }
            }
        }
        public static void LoadData(string patch,out string text)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(patch))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    sb.Append(line);
                    sb.Append("\n");
                }
            }
            text = sb.ToString();
        }
    }
}
