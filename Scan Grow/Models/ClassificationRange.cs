using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ScanGrow
{
    public class ClassificationRange
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GreaterOrEqual { get; set; }
        public decimal LessThan { get; set; }


        public static List<ClassificationRange> ImportClassificationRanges(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = new List<ClassificationRange>();
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var record = new ClassificationRange
                    {
                        Id = csv.Context.Row,
                        Name = csv.GetField<string>("Name"),
                        GreaterOrEqual = csv.GetField<decimal>("GreaterOrEqual"),
                        LessThan = csv.GetField<decimal>("LessThan")

                    };
                    records.Add(record);
                }
                return records;
            }
        }
    }

    
}
