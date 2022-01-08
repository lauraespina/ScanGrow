using LiveCharts;
using LiveCharts.Wpf;
using ML.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace ScanGrow
{
    public partial class GraphView : Form
    {
        public string SessionId ;

        public GraphView(string sessionId)
        {
            InitializeComponent();
            SessionId = sessionId;
            lbSessionId.Text = SessionId;
            lbDataFile.Text = "data_"+SessionId+".json";
            

        }

        private void GraphView_Load(object sender, EventArgs e)
        {      
          FillGraphs();
        }

        public void FillGraphs()
        {
            
            var c = GetChartList();
            foreach (var chart in c)
            {
                ClearGraphs(chart);
                string well = chart.Name.ToString();
                well = well.Replace("Chart", "");
                List<int> values = GetWellValues(well, lbDataFile.Text);



                List<double> av = new List<double>();

                
                int i = 0;
                foreach (var val in values)
                {
                    double a;
                    if(i < 1)
                    {
                        a = val;
                    }
                    else if(i+2 <= values.Count())
                    {
                        double Prev = Convert.ToDouble(values[i - 1]);
                        double Next = Convert.ToDouble(values[i + 1]);
                        a = (Prev + Next) / 2;

                    }
                    else
                    {
                        a = val;
                    }
                    i++;
                    av.Add(a);
                }



                

                if (cbValues.Checked == true && CbAverage.Checked == true)
                {
                    SeriesCollection data = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Name = "Values",Values = new ChartValues<int>(values) {},PointGeometrySize = 3
                        },

                        new LineSeries
                        {
                            Name = "Average",Values = new ChartValues<double>(av) {},PointGeometrySize = 0, Opacity = 100

                        }

                    };
                    chart.Series = data;
                }
                else if (cbValues.Checked == true && CbAverage.Checked == false)
                {
                    SeriesCollection data = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Name = "Values",Values = new ChartValues<int>(values) {},PointGeometrySize = 3
                        }

                    };
                    chart.Series = data;
                }
                else if (cbValues.Checked == false && CbAverage.Checked == false)
                {
                    ClearGraphs(chart);
                }
                else
                {
                    SeriesCollection data = new SeriesCollection
                    {
                     

                        new LineSeries
                        {
                            Name = "Average",Values = new ChartValues<double>(av) {},PointGeometrySize = 0, Opacity = 100

                        }

                    };
                    chart.Series = data;

                }





            }
        }

        private List<int> GetWellValues(string WellName, string DataFile)
        {
            List<int> values = new List<int>();
            List<TensorResult> wells = new List<TensorResult>();
            if (File.Exists(DataFile))
            {
                string Samples = System.IO.File.ReadAllText(DataFile);

                wells = JsonConvert.DeserializeObject<List<TensorResult>>(Samples);

                var q = from w in wells
                        where w.WellName == WellName
                        select w.PredictionInt;
                if (q != null)
                {
                    foreach (var res in q)
                    {
                        values.Add(res);
                    }
                }
            }
            return values;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            FillGraphs();
        }

        private void ClearGraphs(LiveCharts.WinForms.CartesianChart chartName)
        {
            
            chartName.DisableAnimations = true;
            chartName.Hoverable = false;
            chartName.DataTooltip = null;
            chartName.AxisX.Clear();
            chartName.AxisY.Clear();
            chartName.AxisY.Add(new Axis
            {
                Title = "Level",
                Labels = new[] { "0", "1", "2", "3", "4", "5", "6", "7" },
                MinValue = 1,
                MaxValue = 6
            });
            chartName.AxisX.Add(new Axis
            {
                Title = "Sample",
                MinValue = 0,
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    
                    Step = 2,
                    IsEnabled = false //disable it to make it invisible.
                }
            });

        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = lbDataFile.Text;
            saveFileDialog1.Filter = "JSON File | *.json";
            //var result = saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if (File.Exists(saveFileDialog1.FileName))
                {
                    File.Delete(saveFileDialog1.FileName);
                }
                File.Copy(lbDataFile.Text, saveFileDialog1.FileName);
            }
        }

        private void BtOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JSON File | *.json";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lbDataFile.Text = openFileDialog1.FileName;
               
                FillGraphs();
            }
        }

        #region ShameShameShame
        private List<LiveCharts.WinForms.CartesianChart> GetChartList()
        {
            List<LiveCharts.WinForms.CartesianChart> Charts = new List<LiveCharts.WinForms.CartesianChart>() {
            A1Chart,
            A2Chart,
            A3Chart,
            A4Chart,
            A5Chart,
            A6Chart,
            A7Chart,
            A8Chart,
            A9Chart,
            A10Chart,
            A11Chart,
            A12Chart,
            B1Chart,
            B2Chart,
            B3Chart,
            B4Chart,
            B5Chart,
            B6Chart,
            B7Chart,
            B8Chart,
            B9Chart,
            B10Chart,
            B11Chart,
            B12Chart,
            C1Chart,
            C2Chart,
            C3Chart,
            C4Chart,
            C5Chart,
            C6Chart,
            C7Chart,
            C8Chart,
            C9Chart,
            C10Chart,
            C11Chart,
            C12Chart,
            D1Chart,
            D2Chart,
            D3Chart,
            D4Chart,
            D5Chart,
            D6Chart,
            D7Chart,
            D8Chart,
            D9Chart,
            D10Chart,
            D11Chart,
            D12Chart,
            E1Chart,
            E2Chart,
            E3Chart,
            E4Chart,
            E5Chart,
            E6Chart,
            E7Chart,
            E8Chart,
            E9Chart,
            E10Chart,
            E11Chart,
            E12Chart,
            F1Chart,
            F2Chart,
            F3Chart,
            F4Chart,
            F5Chart,
            F6Chart,
            F7Chart,
            F8Chart,
            F9Chart,
            F10Chart,
            F11Chart,
            F12Chart,
            G1Chart,
            G2Chart,
            G3Chart,
            G4Chart,
            G5Chart,
            G6Chart,
            G7Chart,
            G8Chart,
            G9Chart,
            G10Chart,
            G11Chart,
            G12Chart,
            H1Chart,
            H2Chart,
            H3Chart,
            H4Chart,
            H5Chart,
            H6Chart,
            H7Chart,
            H8Chart,
            H9Chart,
            H10Chart,
            H11Chart,
            H12Chart,
            };

            return Charts;
        }

        #endregion

        private void BtnTableView_Click(object sender, EventArgs e)
        {
            Form TableView = new ScanGrow.TableView(lbDataFile.Text);
            TableView.Show();
        }

        private void CbAverage_CheckedChanged(object sender, EventArgs e)
        {
            FillGraphs();
        }

        private void CbValues_CheckedChanged(object sender, EventArgs e)
        {
            FillGraphs();
        }
    }
}
