using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class HotDrink
    {
        private string _drinkName;
        private bool _milkNeeded;
        private int _watarTemper;
        private string _capsuleType;
        private string _extras;

        public string DrinkName { get { return _drinkName; }}
        public bool MilkNeeded { get { return _milkNeeded; }}
        public int WatarTemper { get { return _watarTemper; }}
        public string CapsuleType { get { return _capsuleType; }}
        public string Extras { get { return _extras; }}


        public HotDrink(string drinkName, bool milkNeeded, int watarTemper, string capsuleType, string extras)
        {
            _drinkName = drinkName;
            _milkNeeded = milkNeeded;
            _watarTemper = watarTemper;
            _capsuleType = capsuleType;
            _extras = extras;
        }
    }
}
