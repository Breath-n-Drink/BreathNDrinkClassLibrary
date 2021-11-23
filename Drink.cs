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
                        string[] stringArrayInArray = Array.Empty<string>();
                        if (int.TryParse(component, out int result))
                            value += result;
                        else if (component.Contains('/'))
                        {
                            stringArrayInArray = component.Split('/');
                            if (int.TryParse(stringArrayInArray[0], out int beforeSlash) && int.TryParse(stringArrayInArray[1], out int afterSlash))
                                value += beforeSlash / (double)afterSlash;
                        }
                        else if (component.Contains('-'))
                        {
                            stringArrayInArray = component.Split('-');
                            if (int.TryParse(stringArrayInArray[0], out int beforeDash) && int.TryParse(stringArrayInArray[1], out int afterDash))
                                value += beforeDash + (afterDash - beforeDash)/2;
                        }
                        else if (component.Contains('.'))
                        {
                            stringArrayInArray = component.Split('.');
                            if (int.TryParse(stringArrayInArray[0], out int beforeDot) && int.TryParse(stringArrayInArray[1], out int afterDot))
                                value += beforeDot + double.Parse("0." + afterDot);
                        }
                        else if (component.ToLower().Equals("oz"))
                            unit = "oz";
                        else if (component.ToLower().Equals("cup"))
                            unit = "cup";
                        else if (component.ToLower().Equals("tsp"))
                            unit = "tsp";
                        else if (component.ToLower().Equals("tbsp"))
                            unit = "tbsp";
                        else if (component.ToLower().Equals("juice"))
                            unit = "juice";
                        else if (component.ToLower().Equals("dash") || component.ToLower().Equals("dashes"))
                            unit = "dash";
                        else if (component.ToLower().Equals("cl"))
                            unit = "cl";
                    }

                    double amountInMl;
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
                        case "juice":
                            amountInMl = value * 71.03266;
                            break;
                        case "dash":
                            amountInMl = value * 1.0;
                            break;
                        case "cl":
                            amountInMl = value * 10.0;
                            break;
                        default:
                            amountInMl = 0.0;
                            break;
                    }

                    measurementsInMl.Add(amountInMl);
                }
            }

            List<double> alcoholByVolList = new();
            foreach (string ingredient in _ingredientList)
            {
                double alcoholByVol;
                switch (ingredient.ToLower())
                {
                    case "tequila":
                        alcoholByVol = 0.4;
                        break;
                    case "triple sec":
                        alcoholByVol = 0.4;
                        break;
                    case "light rum":
                        alcoholByVol = 0.375;
                        break;
                    case "gin":
                        alcoholByVol = 0.46;
                        break;
                    case "campari":
                        alcoholByVol = 0.25;
                        break;
                    case "sweet vermouth":
                        alcoholByVol = 0.16;
                        break;
                    case "vodka":
                        alcoholByVol = 0.4;
                        break;
                    case "angostura bitters":
                        alcoholByVol = 0.447;
                        break;
                    case "bourbon":
                        alcoholByVol = 0.482;
                        break;
                    case "apricot brandy":
                        alcoholByVol = 0.28;
                        break;
                    case "amaretto":
                        alcoholByVol = 0.28;
                        break;
                    case "southern comfort":
                        alcoholByVol = 0.35;
                        break;
                    case "sloe gin":
                        alcoholByVol = 0.28;
                        break;
                    case "orange bitters":
                        alcoholByVol = 0.4;
                        break;
                    case "yellow chartreuse":
                        alcoholByVol = 0.43;
                        break;
                    case "creme de cacao":
                        alcoholByVol = 0.245;
                        break;
                    case "blended whiskey":
                        alcoholByVol = 0.245;
                        break;
                    case "dry vermouth":
                        alcoholByVol = 0.18;
                        break;
                    case "blackberry brandy":
                        alcoholByVol = 0.35;
                        break;
                    case "kummel":
                        alcoholByVol = 0.38;
                        break;
                    case "dark rum":
                        alcoholByVol = 0.43;
                        break;
                    case "kahlua":
                        alcoholByVol = 0.2;
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
