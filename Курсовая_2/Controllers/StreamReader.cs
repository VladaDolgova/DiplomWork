using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Курсовая_2.Controllers
{
    class StreammReader : IFileReader
    {
        public IEnumerable<string[]> Collector(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            // читает txt и csv
            if (extension != ".xlsx" && extension != ".xls")
            {
                var sr = new StreamReader(fileName, Encoding.Default);
                using (sr)
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        yield return line.Split(';');
                    }
                }
            }
        }

        public void Writer(string[] text, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default))
            {
                sw.WriteLine(text);
            }

            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.Default))
            {
                sw.WriteLine("Дозапись");
                foreach (string line in text)
                {
                    sw.Write(line);
                }
            }
        }
    }
}