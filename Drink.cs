using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreathNDrinkClassLibrary
{
    public class Drink
    {
        private string _drinkId;
        private string _name;
        private bool _alcoholic;
        private string _instructions;
        private string _imgThumbUrl;
        private List<string> _ingredientList = new();
        private List<string> _measurementList = new();

        public string DrinkId
        {
            get
            {
                return _drinkId;
            }
            set
            {
                _drinkId = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public bool Alcoholic
        {
            get
            {
                return _alcoholic;
            }
            set
            {
                _alcoholic = value;
            }
        }

        public string Instructions
        {
            get
            {
                return _instructions;
            }
            set
            {
                _instructions = value;
            }
        }

        public string ImgThumbUrl
        {
            get
            {
                return _imgThumbUrl;
            }
            set
            {
                _imgThumbUrl = value;
            }
        }

        public List<string> IngredientList
        {
            get
            {
                return _ingredientList;
            }
            set
            {
            }
        }

        public List<string> MeasurementList
        {
            get
            {
                return _measurementList;
            }
            set
            {
            }
        }

        public double AlcoholPercentage
        {
            get
            {
                return CalculateAlcoholPercentage();
            }
            set
            {
            }
        }

        public void AddIngredientAndMeasurement(string ingredient, string measurement)
        {
            _ingredientList.Add(ingredient);
            _measurementList.Add(measurement);
        }

        private double CalculateAlcoholPercentage()
        {
            List<double> measurementsInMl = new();

            foreach (string measurement in _measurementList)
            {
                if (measurement != null)
                {
                    string[] strArray = measurement.Split(' ');
                    double value = 0.0;
                    string unit = "";
                    foreach (string component in strArray)
                    {
                        if (int.TryParse(component, out int result))
                            value += result;
                        else if (component.Equals("1/2"))
                            value += 0.5;
                        else if (component.ToLower().Equals("oz"))
                            unit = "oz";
                        else if (component.ToLower().Equals("cup"))
                            unit = "cup";
                        else if (component.ToLower().Equals("tsp"))
                            unit = "tsp";
                        else if (component.ToLower().Equals("tbsp"))
                            unit = "tbsp";
                    }

                    double amountInMl = 0.0;
                    switch (unit)
                    {
                        case "oz":
                            amountInMl = value * 28.41306;
                            break;
                        case "cup":
                            amountInMl = value * 284.1306;
                            break;
                        case "tsp":
                            amountInMl = value * 5.919388;
                            break;
                        case "tbsp":
                            amountInMl = value * 17.75816;
                            break;
                    }

                    measurementsInMl.Add(amountInMl);
                }
            }

            List<double> alcoholByVolList = new();
            foreach (string ingredient in _ingredientList)
            {
                double alcoholByVol = 0.0;
                switch (ingredient.ToLower())
                {
                    case "tequila":
                        alcoholByVol = 0.45;
                        break;
                    case "triple sec":
                        alcoholByVol = 0.3;
                        break;
                    case "light rum":
                        alcoholByVol = 0.4;
                        break;
                    default:
                        alcoholByVol = 0.0;
                        break;
                }

                alcoholByVolList.Add(alcoholByVol);
            }

            double totalVol = 0.0;
            foreach (double measurement in measurementsInMl)
            {
                totalVol += measurement;
            }

            double totalAlcVol = 0.0;
            int measurementNo = 0;
            foreach (double measurement in measurementsInMl)
            {
                double alcVol = measurement * alcoholByVolList[measurementNo];

                totalAlcVol += alcVol;

                measurementNo++;
            }

            return totalAlcVol / totalVol;
        }
    }
}
