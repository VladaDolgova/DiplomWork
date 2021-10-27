using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовая_2.Controllers;
using Курсовая_2.Models;

namespace Курсовая_2._0.Controllers
{
    public class Statistic
    {
        OpenedFile ReadenFile = new OpenedFile();
        StreammReader reader = new StreammReader();
        public int CountOfSymbols(string fileName, string symbols)
        {
            int count = 0;

            ReadenFile.FilesLines = reader.Collector(fileName).ToList();

            foreach (string[] line in reader.Collector(fileName))
            {
                string oneLine = String.Join(" ", line);
                if (oneLine.Contains(symbols))
                {
                    count += 1;
                }
            }
            return count;
        }
        public int CountOfRows(string fileName)
        {
            int count = 0;
            ReadenFile.FilesLines = reader.Collector(fileName).ToList();
            foreach (string[] line in reader.Collector(fileName))
            {
                count += 1;
            }
            return count;
        }
        public int CountOfColumns(string fileName)
        {
            int count = 0;
            ReadenFile.FilesLines = reader.Collector(fileName).ToList();
            count = ReadenFile.FilesLines.First().Length;
            return count;
        }
        public int CountOfCells(string fileName)
        {
            int count = CountOfColumns(fileName) * CountOfRows(fileName);
            return count;
        }
    }
}