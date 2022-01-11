using CsvHelper;
using ML.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ScanGrow
{
    public static class ProcessWells
    {
        public static void CutWells(string imagePath, bool AddSampleData)
        {
            string CsvPath = "Configuration\\ImageMask.csv";
            var Wells = LoadWells(CsvPath);
            Image img = Image.FromFile(imagePath);
            string ParentFileName = Path.GetFileNameWithoutExtension(imagePath);
            string ParentFileDirectory = Path.GetDirectoryName(imagePath);
            foreach (Well W in Wells)
            {
                System.IO.Directory.CreateDirectory(ParentFileDirectory + "\\" + W.Row + W.Column);

                var im = ImageUtils.CropImage(img, W.X - 35, W.Y - 35, W.Width, W.Height);
                string FileName = ParentFileName + "_" + W.Row + W.Column + ".png";

                im.Save((ParentFileDirectory + "\\" + W.Row + W.Column + "\\" + FileName));
                if (AddSampleData)
                {
                    ProcessWells.AddSampleData(ParentFileDirectory + "\\" + W.Row + W.Column, ParentFileDirectory + "\\" + W.Row + W.Column + "\\" + FileName);
                }
            }
            img.Dispose();
        }

        public static void AddSampleData(string Directory, string SourceImagePath)
        {
            if (!File.Exists(Directory + "\\" + "samples.json"))
            {
                File.Create(Directory + "\\" + "samples.json").Dispose();
            }
            
            int Id;
            string Samples = System.IO.File.ReadAllText(Directory + "\\" + "samples.json");
            
            List<Well> wells = JsonConvert.DeserializeObject<List<Well>>(Samples);
            if(wells != null) { Id = wells.Count ; }
            else
            {
                Id = 0;
                wells = new List<Well>();
            }

            Well w = new Well()
            {
                Id = Id,
                SourceImagePath = SourceImagePath
            };
            wells.Add(w);
            string finalJson= JsonConvert.SerializeObject(wells);
            System.IO.File.WriteAllText(Directory + "\\" + "samples.json", finalJson);
        }


        public static List<Well> LoadWells(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = new List<Well>();
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var record = new Well
                    {
                        Id = csv.Context.Row,
                        Include = csv.GetField<bool>("Include"),
                        Row = csv.GetField<string>("Row"),
                        Column = csv.GetField<string>("Column"),
                        Y = csv.GetField<int>("Y"),
                        X = csv.GetField<int>("X"),
                        Width = csv.GetField<int>("Width"),
                        Height = csv.GetField<int>("Height")

                    };
                    records.Add(record);
                }
                return records;
            }
        }

        public static void CreateTrainingData(string path)
        {
            var SubDirs = Directory.EnumerateDirectories(path.ToString() + "\\");
            List<String> AllFiles = new List<string>();
            foreach (var d in SubDirs)
            {
                var Files = Directory.EnumerateFiles(d);

                foreach (var F in Files)
                {
                    var Ext =Path.GetExtension(F);
                    var FName = Path.GetFileNameWithoutExtension(F);
                    if (Ext == ".png" && FName.Contains('%'))
                    {
                        AllFiles.Add(F);
                    }  
                }
            }

            foreach (var F in AllFiles)
            {
                var directory = Path.GetDirectoryName(F);
                var filenameExtension = Path.GetFileName(F);
                var filename = Path.GetFileNameWithoutExtension(F);
                var split = filename.Split('%');
                var ns = split[1].Replace("_", "");  
                ns = ns.Replace("^", ".");
                decimal criticalValue = Convert.ToDecimal(ns);
                decimal l1 = Convert.ToDecimal("0.99");
                List<ClassificationRange> Crs = ClassificationRange.ImportClassificationRanges("Configuration\\ClassificationLevels.csv");
                foreach (var cr in Crs)
                {
                    Directory.CreateDirectory(path + "\\" + cr.Name);
                    if (criticalValue >= cr.GreaterOrEqual && criticalValue < cr.LessThan)
                    {
                        File.Copy(F, path + "\\" + cr.Name + "\\" + filenameExtension, true);
                    }

                }
            }
            System.Windows.MessageBox.Show("Training Images Processed");
        }

        public static void BulkCompareImages(string path) 
        {
            List<ModelInput> input = new List<ModelInput>();


            var SubDirs = Directory.EnumerateDirectories(path.ToString() + "\\");
            List<string> SubDirs2 = SubDirs.ToList();
            SubDirs2.Add(path);

            foreach (var d in SubDirs2)
            {
                var Files = Directory.EnumerateFiles(d);

                foreach (var F in Files)
                {
                    var Ext = Path.GetExtension(F);
                   
                    if (Ext == ".png")
                    {
                        ModelInput mi = new ModelInput()
                        {
                            ImageSource = F
                        };
                        input.Add(mi);
                    }
                }
            }

                List<TensorResult> results = ConsumeModel.BatchPredict(input);

            foreach (var r in results)
            {
                r.ActualClassification = 0;
                try
                {
                    var directory = Path.GetDirectoryName(r.FileName);
                    var filenameExtension = Path.GetFileName(r.FileName);
                    var filename = Path.GetFileNameWithoutExtension(r.FileName);
                    var split = filename.Split('%');
                    var ns = split[1].Replace("_", "");
                    ns = ns.Replace("^", ".");
                    decimal criticalValue = Convert.ToDecimal(ns);
                    List<ClassificationRange> Crs = ClassificationRange.ImportClassificationRanges("Configuration\\ClassificationLevels.csv");
                    foreach (var cr in Crs)
                    {
                        Directory.CreateDirectory(path + "\\" + cr.Name);
                        if (criticalValue >= cr.GreaterOrEqual && criticalValue < cr.LessThan)
                        {
                            r.ActualClassification = cr.Id - 1;
                        }

                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }       
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "csv file (*.csv)|*.csv"
            };
            sfd.ShowDialog();

            if(sfd.FileName != "")
            {
                using (var writer = new StreamWriter(sfd.FileName))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(results);
                }
                System.Windows.MessageBox.Show("Complete");
            }
            else
            {
                sfd.ShowDialog();
            }
        }

    }

}