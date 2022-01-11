using ML.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanGrow
{
    public partial class TableView : Form
    {
        private string dataFile;
        public TableView(string DataFile)
        {
            InitializeComponent();
            dataFile = DataFile;
            BindDataSource(dataFile);
           
        }

        private void TableView_Load(object sender, EventArgs e)
        {

        }

        private void BindDataSource(string DataFile)
        {

            try
            {
                string Samples = System.IO.File.ReadAllText(DataFile);
                List<TensorResult> results = JsonConvert.DeserializeObject<List<TensorResult>>(Samples);
                dataGridView1.DataSource = results;
            }
            catch { }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            BindDataSource(dataFile);
        }
    }
}
