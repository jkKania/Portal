using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.LinearRegression;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization.Internal;
using PortalData.Models;
using PortalDataPresentation.ViewModels;

namespace PortalData.Services.AnalysisComponents
{
    public class TrendComponent : IComputable
    {
        private ComputationResultVM _result { get; set; }
        public string Name { get { return "Trend"; } }

        public void Analyze(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel)
        {
            var measurementDates = measurements.Select(x => x.RecordCreateTime.ToOADate()).ToArray();

            DirectRegressionMethod regressionMethod = (DirectRegressionMethod)Enum.Parse(typeof(DirectRegressionMethod), viewmodel.regressionMethod);

            var polynomialCoefficients = Fit.Polynomial(measurementDates,
                measurements.Select(y => y.Value).ToArray(), viewmodel.polynomialDegree, regressionMethod).ToList();

            var functionFormula = GetPolynomialFormula(polynomialCoefficients);

            var newDates = GenerateNewDates(measurementDates);

            var approximationResults = GetApproximationResults(newDates.ToArray(), polynomialCoefficients);

            _result = new ComputationResultVM()
            {
                X_values = measurementDates.Select(x => DateTime.FromOADate(x).ToString("yyyy-MM-dd HH:mm:ss")).ToList(),
                X2_values = newDates.Select(x => DateTime.FromOADate(x).ToString("yyyy-MM-dd HH:mm:ss")).ToList(),
                Y_values = measurements.Select(x => x.Value).ToList(),
                Y2_values = approximationResults,
                Formula = functionFormula
            };
        }

        private string GetPolynomialFormula(List<double> polynomialCoefficients)
        {
            string functionFormula = "y = ";
            for (int i = polynomialCoefficients.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                    functionFormula += polynomialCoefficients[i].ToString();
                else
                    functionFormula += polynomialCoefficients[i] + "x^" + i + "+";
            }

            return functionFormula;
        }

        private static List<double> GenerateNewDates(double[] dates)
        {
            var step = (dates.Max() - dates.Min()) / dates.Count();
            List<double> newDates = new List<double>();
            
            for (double i = dates.Min(); i < dates.Max(); i += step)
            {
                newDates.Add(i);
            }

            return newDates;
        }

        private List<double> GetApproximationResults(double[] dates, List<double> polynomialCoefficients)
        {
            List<double> approximationResults = new List<double>();
            double result = 0;

            foreach (var date in dates)
            {
                result = 0;
                for (int i = polynomialCoefficients.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                        result += polynomialCoefficients[i];
                    else
                        result += polynomialCoefficients[i] * Math.Pow(date, i);
                }

                approximationResults.Add(result);
            }

            return approximationResults;
        }

        public ComputationResultVM GetResult()
        {
            return _result;
        }
    }
}