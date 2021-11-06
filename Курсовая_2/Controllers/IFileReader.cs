using System.Collections.Generic;

namespace Курсовая_2.Controllers
{
    public interface IFileReader
    {
        IEnumerable<string[]> Collector(string fileName);
    }
}
