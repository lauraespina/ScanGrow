using System;

namespace ML.Model
{
    public class TensorResult
    {
        public int ScanId { get; set; }
        public string Prediction { get; set; }
        public int PredictionInt
        {
            get
            {
                int result = 99;
                if (this.Prediction == "Level1")
                {
                    result = 1;
                }
                if (this.Prediction == "Level2")
                {
                    result = 2;
                }

                if (this.Prediction == "Level3")
                {
                    result = 3;
                }
                if (this.Prediction == "Level4")
                {
                    result = 4;
                }
                if (this.Prediction == "Level5")
                {
                    result = 5;
                }
                if (this.Prediction == "Level6")
                {
                    result = 6;
                }

                return result;
            }
        }
        public double Score { get; set; }
        public Single[] AllScores { get; set; }
        public string FileName { get; set; }
        public string WellName { get; set; }
        public int ActualClassification { get; set; }

    }
}
