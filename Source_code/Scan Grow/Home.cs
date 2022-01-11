using DNTScanner.Core;
using ML.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ScanGrow
{
    public partial class Home : Form
    {
        public string WorkingDirectory = "";
        public List<Scanner> ScanModels = new List<Scanner>();
        private Scanner SelectedScanner = new Scanner();
        public Home()
        {
            InitializeComponent();

            ScanWorker.DoWork += ScanWorker_DoWork;
            ScanWorker.RunWorkerCompleted += ScanWorker_RunWorkerCompleted;
            MlWorker.DoWork += MlWorker_DoWork;
            MlWorker.RunWorkerCompleted += MlWorker_RunWorkerCompleted;
            Workflow.DoWork += WorkFlow_DoWork;
            //Load ML Model
            ConsumeModel.Init();
            SearchForScanners();
            lbSession.Text = Guid.NewGuid().ToString();
            PanelAdvanced.Visible = false;
        }

        private void MlWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OfflineButtonEnable();
        }



        private void WorkFlow_DoWork(object sender, DoWorkEventArgs e)
        {
            string FileName = e.Argument.ToString();

            if (cbFlipImage.Checked)
            {
                ImageUtils.FlipImage(FileName);
            }

            ProcessWells.CutWells(FileName, true);
         
            MlWorker.RunWorkerAsync();
        }

        private void SearchForScanners()
        {
            try
            {   // Finding the first connected scanner to the system
                var Scanners = SystemDevices.GetScannerDevices();
                var FirstScanner = Scanners.FirstOrDefault();
                if (FirstScanner == null)
                {
                    cbScanner.Text = "No Scanner Detected";
                }
                else
                {
                    foreach (var S in Scanners)
                    {
                        Scanner Sc = new Scanner()
                        {
                            Name = S.Name,
                            Id = S.Id,
                            Resolutions = S.SupportedResolutions.ToList<int>(),
                        };
                        ScanModels.Add(Sc);
                    }

                    cbScanner.DataSource = ScanModels;
                    cbScanner.DisplayMember = "Name";
                    cbScanner.ValueMember = "Id";
                    cbResolution.DataSource = SelectedScanner.Resolutions;
                }
            }
            catch { }
        }

        private void MlWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] subdirectories = Directory.GetDirectories(WorkingDirectory);
            List<TensorResult> Results = new List<TensorResult>();
            List<TensorResult> PreviousResults = new List<TensorResult>();
            List<ModelInput> Batch = new List<ModelInput>();
            List<ModelInput> PreviouslyRun = new List<ModelInput>();
            List<ModelInput> ToProcessBatch = new List<ModelInput>();

            foreach (var s in subdirectories)
            {
                List<string> Files = ImageUtils.GetImageFilesFromDirectory(s);
                for (int i = 0; i < Files.Count; i++)
                {
                    string FName = Path.GetFileNameWithoutExtension(Files[i]);
                    var Name = FName.Split('_');
                    int SId = Convert.ToInt32(Name[0]);
                    DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(Files[i]));
                    ModelInput Mi = new ModelInput()
                    {
                        ImageSource = Files[i],
                        WellName = dir.Name,
                        ScanId = SId
                    };

                    Batch.Add(Mi);
                }
            }


            if (Batch.Count > 0)
            {
                if (File.Exists(@"data_" + lbSession.Text + ".json"))
                {
                    string previousJson = System.IO.File.ReadAllText(@"data_" + lbSession.Text + ".json");
                    PreviousResults = JsonConvert.DeserializeObject<List<TensorResult>>(previousJson);

                    if (PreviousResults != null)
                    {
                        foreach (var r in PreviousResults)
                        {
                            ModelInput Mi = new ModelInput()
                            {
                                ImageSource = r.FileName,
                                WellName = r.WellName,
                                ScanId = r.ScanId
                            };

                            PreviouslyRun.Add(Mi);
                        }
                    }
                }
                if (PreviouslyRun.Count != 0)
                {
                    ToProcessBatch = Batch.Where(b => !PreviouslyRun.Any(t => t.WellName == b.WellName && t.ScanId == b.ScanId)).ToList();
                }
                else { ToProcessBatch = Batch; }

                Results = ConsumeModel.BatchPredict(ToProcessBatch);

                if (PreviousResults != null)
                {
                    foreach (var r in PreviousResults)
                    {
                        Results.Add(r);
                    }
                }

                string json = JsonConvert.SerializeObject(Results.OrderBy(x => x.ScanId));
                System.IO.File.WriteAllText(@"data_" + lbSession.Text + ".json", json);

            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (WorkingDirectory == "")
            {
                MessageBox.Show("Select Working Directory", "Working Directory Not Selected", MessageBoxButtons.OK);
            }
            else
            {
                string j = cbScanner.SelectedValue.ToString() + "," + "300" + ',' + nudIntervalMinutes.Value.ToString() + ',' + nudNumberOfImages.Value.ToString();
                ScanWorker.RunWorkerAsync(j);
            }

        }
        private readonly BackgroundWorker ScanWorker = new BackgroundWorker();
        private readonly BackgroundWorker MlWorker = new BackgroundWorker();
        private readonly BackgroundWorker Workflow = new BackgroundWorker();

        private void StartButtonDisable()
        {

            try
            {
                if (btnStart.InvokeRequired)
                {
                    btnStart.Invoke(new Action(StartButtonDisable));
                    return;
                }

                btnStart.Enabled = false;
                btnStart.Text = "Processing...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void StartButtonEnable()
        {
            try
            {
                if (btnStart.InvokeRequired)
                {
                    btnStart.Invoke(new Action(StartButtonEnable));
                    return;
                }

                btnStart.Text = "Start";
                btnStart.Enabled = true;
                btnStart.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OfflineButtonEnable()
        {
            try
            {
                if (btnOffline.InvokeRequired)
                {
                    btnOffline.Invoke(new Action(OfflineButtonEnable));
                    return;
                }
                btnOffline.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ScanWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            StartButtonDisable();
            Job j = new Job();
            string[] values = e.Argument.ToString().Split(',');
            j.ScannerId = values[0].ToString();
            j.Resolution = Convert.ToInt32(values[1].ToString());
            if (j.Resolution >= 301) { j.Resolution = 300; }
            int Interval = Convert.ToInt32(values[2].ToString());
            if (Interval >= 1) { Interval *= 60000; } else { Interval = 30000; }
            int NumberOfImages = Convert.ToInt32(values[3].ToString());

            if (NumberOfImages >= 2)
            {
                int i = 0;
                while (i < NumberOfImages)
                {
                    string ImageFileName = WorkingDirectory + "\\" + i.ToString() + ".tif";
                    WIAScanner.Scan(j.ScannerId, j.Resolution, ImageFileName);
                    Workflow.RunWorkerAsync(ImageFileName);
                    System.Threading.Thread.Sleep(Interval);

                    i++;
                }
            }
            else
            {
                string ImageFileName = WorkingDirectory + "\\" + "0.tif";
                WIAScanner.Scan(j.ScannerId, j.Resolution, ImageFileName);
                Workflow.RunWorkerAsync(ImageFileName);
            }
        }

        private void ScanWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Image Scanned");

            System.Threading.Thread.Sleep(10000);
            StartButtonEnable();
            MessageBox.Show("Run finished sucessfully", "Complete", MessageBoxButtons.OK);

        }

        private void CbScanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ScannerID = cbScanner.SelectedItem;
            SelectedScanner = ScanModels.Single(t => t == ScannerID);
        }

        private void Flip_Test_Click(object sender, EventArgs e)
        {
            ImageUtils.FlipImage(openFileDialog1.FileName);
        }

        private void Crop_Test_Click(object sender, EventArgs e)
        {
            ProcessWells.CutWells(openFileDialog1.FileName, false);
        }

        private void Btn_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = WorkingDirectory;
            openFileDialog1.Filter = "Tiff Image (*.tif)|*.tif";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();
            tbFileName.Text = openFileDialog1.FileName;
        }

        private void BtnTag_Click(object sender, EventArgs e)
        {
            var data = ReadExcel.ReadExcelWorkbook(openFileDialog2.FileName);
            foreach (var row in data)
            {
                var SourcePath = openFileDialog1.FileName;
                var FileName = System.IO.Path.GetFileNameWithoutExtension(SourcePath);
                var BasePath = System.IO.Path.GetDirectoryName(SourcePath);
                var Dir = row.WellName;
                var Path = BasePath + "\\" + Dir + "\\" + FileName + "_" + Dir + ".png";
                ImageUtils.TagImage(Path, row.Value.ToString());
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            var result = System.Windows.Forms.MessageBox.Show("Ensure The Source Image is selected in the dialog above, It must match the excel file name (excluding extension)", "Critical", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                openFileDialog2.InitialDirectory = "c:\\bin";
                openFileDialog2.Filter = "Excel (*.xlsx)|*.xlsx";
                openFileDialog2.FilterIndex = 2;
                openFileDialog2.RestoreDirectory = true;
                openFileDialog2.ShowDialog();
                tbExcel.Text = openFileDialog2.FileName;
            }
        }

        private void BtnTrainingImages_Click(object sender, EventArgs e)
        {
            if (tbWorkingDir.Text == "")
            {
                MessageBox.Show("Select Working Directory", "Working Directory Not Selected", MessageBoxButtons.OK);
            }
            else
            {
                var path = Path.GetFullPath(tbWorkingDir.Text);
                ProcessWells.CreateTrainingData(path);
            }
        }

        private void BtnRunModel_Click(object sender, EventArgs e)
        {
            if (WorkingDirectory == "")
            {
                MessageBox.Show("Select Working Directory", "Working Directory Not Selected", MessageBoxButtons.OK);
            }
            else
            {
                //MlWorker.RunWorkerAsync();
                ProcessWells.BulkCompareImages(tbWorkingDir.Text.ToString());
            }
        }

        private void BtnSequence_Click(object sender, EventArgs e)
        {
            //Flip
            ImageUtils.FlipImage(openFileDialog1.FileName);
            //Split
            ProcessWells.CutWells(openFileDialog1.FileName, false);
            //Build Excel Path
            string ExcelPath = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + ".xlsx";
            //Open Excel
            var data = ReadExcel.ReadExcelWorkbook(ExcelPath);
            //Tag Images
            foreach (var row in data)
            {
                var SourcePath = openFileDialog1.FileName;
                var FileName = System.IO.Path.GetFileNameWithoutExtension(SourcePath);
                var BasePath = System.IO.Path.GetDirectoryName(SourcePath);
                var Dir = row.WellName;
                var Path = BasePath + "\\" + Dir + "\\" + FileName + "_" + Dir + ".png";
                ImageUtils.TagImage(Path, row.Value.ToString());
            }
        }

        private void BtnShowGraphs_Click(object sender, EventArgs e)
        {
            Form GraphView = new ScanGrow.GraphView(lbSession.Text);
            GraphView.Show();
        }

        private void BtnAdvanced_Click(object sender, EventArgs e)
        {
            if (PanelAdvanced.Visible == true)
            {
                PanelAdvanced.Visible = false;
                this.Size = new System.Drawing.Size(426, 312);
                btnAdvanced.Text = "Show Advanced";
            }
            else
            {
                PanelAdvanced.Visible = true;
                this.Size = new System.Drawing.Size(993, 561);
                btnAdvanced.Text = "Hide Advanced";
            }
        }

        private void DeleteDataFiles()
        {
            string[] FilesToDelete = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "data_*.json").ToArray();
            foreach (var f in FilesToDelete)
            {
                File.Delete(f);
            }
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            string[] DataFiles = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "data_*.json").ToArray();
            if (DataFiles.Length >= 1)
            {
                var result = MessageBox.Show("Delete All Data Files? \nWARNING: This action can not be undone", "Delete All Data Files?", MessageBoxButtons.YesNo);
                if (result.ToString() == "Yes") { DeleteDataFiles(); }
            }
        }

        private void BtnWorkingDirectory_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialogWorkingDirectory1.ShowDialog();
            if (result.ToString() == "OK")
            {
                WorkingDirectory = folderBrowserDialogWorkingDirectory1.SelectedPath;
                Console.WriteLine(WorkingDirectory);
                tbWorkingDir.Text = WorkingDirectory;
                tbWorkingDir2.Text = WorkingDirectory;
                tbWorkingDir3.Text = WorkingDirectory;
                tbWorkingDir4.Text = WorkingDirectory;
            }
        }



        private void BTWFTest2_Click(object sender, EventArgs e)
        {

            if (tbWorkingDir.Text == "")
            {
                MessageBox.Show("Select Working Directory", "Working Directory Not Selected", MessageBoxButtons.OK);
            }
            else
            {


                if (File.Exists(WorkingDirectory + "\\0.tif"))
                {
                    string Path = WorkingDirectory;

                    ProcessWells.BulkCompareImages(Path);
                    MessageBox.Show("Test started, please wait until you are prompted to save the results", "Model Test Started", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("No image file to test, please ensure 0.tif exists in source directory", "Image not found", MessageBoxButtons.OK);
                }

            }
        }

        private void BtnWorkingDirectory2_Click(object sender, EventArgs e)
        {
            BtnWorkingDirectory_Click(sender, e);
        }

        private void BtnWorkingDirectory3_Click(object sender, EventArgs e)
        {
            BtnWorkingDirectory_Click(sender, e);
        }

        private void BtnWorkingDirectory4_Click(object sender, EventArgs e)
        {
            BtnWorkingDirectory_Click(sender, e);
        }

        private void BTNGroupImages_Click(object sender, EventArgs e)
        {
            BtnTrainingImages_Click(sender, e);

        }

        private void BtnOffline_Click(object sender, EventArgs e)
        {
            if (tbWorkingDir.Text == "")
            {
                MessageBox.Show("Please select a working directory");
            }
            else
            {
                btnOffline.Enabled = false;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();

                string ImageFileName = ofd.FileName;
                Workflow.RunWorkerAsync(ImageFileName);
            }
        }
    }
}