using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreathNDrinkClassLibrary.Models;

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
        private BreathndrinkContext _context = new BreathndrinkContext();

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

        public double TotalVolume
        {
            get
            {
                return CalculateTotalVolume();
            }
            set
            {
            }
        }

        public double TotalAlcVolume
        {
            get
            {
                return CalculateAlcoholPercentage() * CalculateTotalVolume();
            }
            set
            {
            }
        }

        public double Rating
        {
            get
            {
                return CalculateRating();
            }
        }

        public void AddIngredientAndMeasurement(string ingredient, string measurement)
        {
            _ingredientList.Add(ingredient);
            _measurementList.Add(measurement);
        }



        private double CalculateAlcoholPercentage()
        {
            if (Alcoholic == false)
                return 0.0;

            List<double> measurementsInMl = ConvertListToMl();

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
                    case "vodka":
                    case "absolut vodka":
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
                    case "sweet vermouth":
                    case "vermouth":
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
                    case "galliano":
                        alcoholByVol = 0.423;
                        break;
                    case "grand marnier":
                        alcoholByVol = 0.4;
                        break;
                    case "baileys irish cream":
                        alcoholByVol = 0.17;
                        break;
                    case "creme de cassis":
                        alcoholByVol = 0.2;
                        break;
                    case "champagne":
                        alcoholByVol = 0.12;
                        break;
                    case "frangelico":
                        alcoholByVol = 0.2;
                        break;
                    case "151 proof rum":
                        alcoholByVol = 0.755;
                        break;
                    case "wild turkey":
                        alcoholByVol = 0.505;
                        break;
                    case "sambuca":
                        alcoholByVol = 0.38;
                        break;
                    case "whiskey":
                    case "whisky":
                        alcoholByVol = 0.43;
                        break;
                    case "peach schnapps":
                    case "strawberry schnapps":
                    case "peachtree schnapps":
                        alcoholByVol = 0.2;
                        break;
                    case "lager":
                        alcoholByVol = 0.05;
                        break;
                    case "cider":
                        alcoholByVol = 0.05;
                        break;
                    case "red wine":
                        alcoholByVol = 0.14;
                        break;
                    case "applejack":
                        alcoholByVol = 0.4;
                        break;
                    case "peach bitters":
                        alcoholByVol = 0.39;
                        break;
                    case "grain alcohol":
                        alcoholByVol = 0.95;
                        break;
                    case "vanilla vodka":
                        alcoholByVol = 0.375;
                        break;
                    case "beer":
                        alcoholByVol = 0.05;
                        break;
                    case "prosecco":
                        alcoholByVol = 0.11;
                        break;
                    case "lillet blanc":
                        alcoholByVol = 0.17;
                        break;
                    case "gold rum":
                        alcoholByVol = 0.4;
                        break;
                    case "pernod":
                        alcoholByVol = 0.4;
                        break;
                    case "rose":
                        alcoholByVol = 0.125;
                        break;
                    case "pastis":
                    case "ricard":
                        alcoholByVol = 0.45;
                        break;
                    case "peychaud bitters":
                        alcoholByVol = 0.35;
                        break;
                    case "brandy":
                        alcoholByVol = 0.4;
                        break;
                    case "cognac":
                        alcoholByVol = 0.4;
                        break;
                    case "cointreau":
                        alcoholByVol = 0.4;
                        break;
                    case "cherry brandy":
                        alcoholByVol = 0.25;
                        break;
                    case "goldschlager":
                        alcoholByVol = 0.25;
                        break;
                    case "white creme de menthe":
                        alcoholByVol = 0.24;
                        break;
                    case "creme de mure":
                        alcoholByVol = 0.18;
                        break;
                    case "rye whiskey":
                        alcoholByVol = 0.46;
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

            if (totalVol == 0.0)
                return -1.0;

            double totalAlcVol = 0.0;
            int measurementNo = 0;
            foreach (double measurement in measurementsInMl)
            {
                double alcVol = measurement * alcoholByVolList[measurementNo];

                totalAlcVol += alcVol;

                measurementNo++;
            }

            if (totalAlcVol == 0.0)
                return -1.0;

            return totalAlcVol / totalVol;
        }

        private double CalculateTotalVolume()
        {
            List<double> measurementsInMl = ConvertListToMl();

            double totalVol = 0.0;
            foreach (double measurement in measurementsInMl)
            {
                totalVol += measurement;
            }

            if (totalVol <= 20.0)
                return -1.0;

            return totalVol;
        }

        private List<double> ConvertListToMl()
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
                                value += beforeDash + (afterDash - beforeDash) / 2;
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
                        else if (component.ToLower().Equals("shot") || component.ToLower().Equals("shots"))
                            unit = "shot";
                        else if (component.ToLower().Equals("part") || component.ToLower().Equals("parts"))
                            unit = "part";
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
                        case "shot":
                            amountInMl = value * 44.0;
                            break;
                        case "part":
                            amountInMl = value * 1.0;
                            break;
                        default:
                            amountInMl = value * 1.0;
                            break;
                    }

                    measurementsInMl.Add(amountInMl);
                }
            }

            return measurementsInMl;
        }

        private double CalculateRating()
        {
            List<Ratings> ratings = _context.Ratings.Where(r => r.DrinkId.Equals(int.Parse(_drinkId))).ToList();
            
            int total = 0;
            foreach (Ratings rating in ratings)
            {
                total += rating.RatingValue;
            }

            return total / (double)ratings.Count;
        }
    }
}
