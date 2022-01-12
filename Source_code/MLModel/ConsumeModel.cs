using System;
using System.Collections.Generic;
using Microsoft.ML;
using ML.Model;

namespace ML.Model
{
    public class ConsumeModel
    {
        private static PredictionEngine<ModelInput, ModelOutput> predEngine;

        public static void Init()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            string modelPath = AppDomain.CurrentDomain.BaseDirectory + "MLModel.zip";
            ITransformer mlModel = mlContext.Model.Load(modelPath, out _);
            predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        public static ModelOutput Predict(ModelInput input)
        {
            // Use model to make prediction on input data
            ModelOutput result = predEngine.Predict(input);
            predEngine.Dispose();
            return result;
        }
       
        public static List<TensorResult> BatchPredict(List<ModelInput> input)
        {
            List<TensorResult> TrResults = new List<TensorResult>();
            // Use model to make prediction on input data
            for (int i=0; i < input.Count; i++)
            {
                ModelOutput result = predEngine.Predict(input[i]);
                Single s = 0;
                for (int i2 = 0; i2 < result.Score.Length; i2++)
                {
                    if (result.Score[i2] > s) { s = result.Score[i2]; }
                }
                double ConfidenceScore = Convert.ToDouble(s);
                TensorResult tr = new TensorResult()
                {
                    ScanId = input[i].ScanId,
                    Prediction =result.Prediction,
                    Score = ConfidenceScore,
                    AllScores = result.Score,
                    FileName = System.IO.Path.GetFileName(input[i].ImageSource),
                    WellName = input[i].WellName
                };
                TrResults.Add(tr);
            }
            predEngine.Dispose();
            return TrResults;
        }
    }
}
