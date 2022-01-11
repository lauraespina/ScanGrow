using ExcelDataReader;
using System.Collections.Generic;
using System.IO;

namespace ScanGrow
{
    public class ReadExcel
    {

        public static List<WellResult> ReadExcelWorkbook(string filePath)
        {
            List<WellResult> WellResults = new List<WellResult>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                   var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        FilterSheet = (tableReader, sheetIndex) => 
                        { 
                        if(sheetIndex == 0) { return false; } else {return true; }
                        },

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            EmptyColumnNamePrefix = "Column",
                            UseHeaderRow =true,
                            ReadHeaderRow = (rowReader) => {
                                rowReader.Read();
                            },
                            
                            FilterRow = (rowReader) => {
                                var hasData = false;
                                for (var i = 0; i < rowReader.FieldCount; i++)
                                {
                                    if (rowReader[i] == null || string.IsNullOrEmpty(rowReader[i].ToString()))
                                    {
                                        continue;
                                    }

                                    hasData = true;
                                    break;
                                }

                                return hasData;
                            },

                            FilterColumn = (rowReader, columnIndex) => {
                                return true;
                            }
                        }


                   }
                );
                    var dt = result.Tables[0];

                    for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                    {
                        WellResult wr = new WellResult
                        {
                            Value = dt.Rows[i][3].ToString(),
                            WellName = dt.Rows[i][1].ToString()
                        };
                        WellResults.Add(wr);
                    }
                }

                return WellResults;

            }

        }
    }
}
