using System.IO;
using System.Text;

namespace SzovSzerk
{
    static class FileSaver
    {
        public static void SaveData(string filename, string text)
        {
            string[] lines = text.Split('\n');

            //StreamWriter sw = new StreamWriter(filename);
            //foreach (string line in lines)
            //{
            //    sw.WriteLine(line);
            //}
            //sw.Flush();
            //sw.Close();

            using (StreamWriter sw = new StreamWriter(filename))
            {

                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }

        public static bool LoadData(string filename, out string text)
        {
            string line;
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    sb.Append(line);
                    sb.Append('\n');
                }
            }
            text = sb.ToString();
            return true;

        }

    }
}
