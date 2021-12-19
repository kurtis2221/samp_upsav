using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace FileConfigManager
{
    class FCM
    {
        string cfgmark = "=";

        /// <summary>
        /// Change the "=" mark to something else if needed only 1 character will be read
        /// </summary>
        /// <param name="mark">A character that separates the data name and the data itself</param>
        public void SetMark(string mark)
        {
            cfgmark = mark[0].ToString();
        }

        /// <summary>
        /// Reading Data from a file
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The name of the data in the file</param>
        /// <returns>The value of the data</returns>
        public string ReadData(string filename, string data)
        {
            string line = null;
            int i = 0;
            while (true)
            {
                i += 1;
                line = GetLine(filename, i);
                if (line == null || line.Length <= 0) break;
                if (line[0].ToString() == "#") continue;

                if (!line.StartsWith(data + cfgmark)) continue;
                else if (line.StartsWith(data + cfgmark))
                    return line.Substring(data.Length + 1, line.Length - (data.Length + 1));
            }
            return null;
        }

        /// <summary>
        /// Checks if the data exist
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The name of the data in the file</param>
        /// <returns></returns>
        public bool CheckData(string filename, string data)
        {
            string line = null;
            int i = 0;
            while (true)
            {
                i += 1;
                line = GetLine(filename, i);
                if (line == null || line.Length <= 0) break;
                if (!line.StartsWith(data)) continue;
                else if (line.StartsWith(data)) return true;
            }
            return false;
        }

        /// <summary>
        /// Deleting the whole file, only use if you aren't using comments in original
        /// </summary>
        /// <param name="filename">The name of the file</param>
        public void DeleteData(string filename)
        {
            if (File.Exists(filename)) File.Delete(filename);
            File.Create(filename).Close();
        }

        /// <summary>
        /// Changing data without regenerating the whole file
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The data needed to be changed</param>
        /// <param name="value">The old value (use readdata)</param>
        /// <param name="newval">The new value</param>
        public void ChangeData(string filename, string data, string value, string newval)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string tmp = sr.ReadToEnd().Replace("\n" + data + cfgmark + value, "\n" + data + cfgmark + newval);
            sr.Close();
            fs.Close();
            fs = new FileStream(filename, FileMode.Truncate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(tmp);
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// Add new data if it isn't exist, need to be programmed before
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The name of the data needed to be added</param>
        /// <param name="value">The value</param>
        public void WriteData(string filename, string data, string value)
        {
            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(data + cfgmark + value);
            sw.Close();
            fs.Close();
        }

        string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName, Encoding.Default))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }
    }
}