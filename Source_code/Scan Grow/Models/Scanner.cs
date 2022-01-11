using System.Collections.Generic;

namespace ScanGrow
{
    public class Scanner
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<int> Resolutions { get; set; }
        public string ImagePath { get; set; }
    }
}
