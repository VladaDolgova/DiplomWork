using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_2.Controllers
{
    public interface IFileReader
    {
        IEnumerable<string[]> Collector(string fileName);
    }
}
