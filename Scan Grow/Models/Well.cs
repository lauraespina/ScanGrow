namespace ScanGrow
{
    public class Well
    {
        public int Id { get; set; }
        public string SourceImagePath { get; set; }
        public bool Include { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

}
