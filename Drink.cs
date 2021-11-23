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
        private List<string> _ingredientList = new ();
        private List<string> _measurementList = new ();

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

        public void AddIngredientAndMeasurement(string ingredient, string measurement)
        {
            _ingredientList.Add(ingredient);
            _measurementList.Add(measurement);
        }
    }
}
