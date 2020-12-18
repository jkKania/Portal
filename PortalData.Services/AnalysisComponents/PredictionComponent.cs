using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.LinearRegression;
using PortalData.Models;
using PortalDataPresentation.ViewModels;

namespace PortalData.Services.AnalysisComponents
{
    public class PredictionComponent : IComputable
    {
        private ComputationResultVM _result { get; set; }
        public string Name { get { return "Prediction"; } }

        public void Analyze(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel)
        {
            var dates = measurements.Select(x => x.RecordCreateTime.ToOADate()).ToArray();

            DirectRegressionMethod regressionMethod = (DirectRegressionMethod)Enum.Parse(typeof(DirectRegressionMethod), viewmodel.regressionMethod);

            var polynomialCoefficients = Fit.Polynomial(dates,
                measurements.Select(y => y.Value).ToArray(), viewmodel.polynomialDegree, regressionMethod).ToList();

            var predictionDate = DateTime.Parse(viewmodel.predictionDate);
            var predictionResults = GetPredictionResults(predictionDate.ToOADate(), polynomialCoefficients);

            List<string> predictionDates = new List<string>(){ viewmodel.predictionDate };
            _result = new ComputationResultVM()
            {
                X_values = predictionDates,
                Y_values = predictionResults,
                Formula = ""
            };
        }
        private List<double> GetPredictionResults(double date, List<double> polynomialCoefficients)
        {
            List<double> predictionResults = new List<double>();
            double result = 0;

                for (int i = polynomialCoefficients.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                        result += polynomialCoefficients[i];
                    else
                        result += polynomialCoefficients[i] * Math.Pow(date, i);
                }

                predictionResults.Add(result);

            return predictionResults;
        }

        public ComputationResultVM GetResult()
        {
            return _result;
        }
    }
}