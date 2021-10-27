using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Курсовая_2.Controllers
{
    public class GetFile
    {
        public static List<string> GetFiles(string filename)
        {
            var list = new List<string>();
            list.Add(filename);
            return list;
        }
    }
}