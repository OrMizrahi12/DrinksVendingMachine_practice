using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class Stock
    {
        private static int _cups;
        private static int _maleOfMilk;
        private static int _maleOfSugar;   
        static Dictionary<string, int> _capsule = new Dictionary<string, int>();
        static Stock()
        {
            _cups = 10;
            _maleOfMilk = 10;
            _maleOfSugar = 10;
        }

        public static void AddStock()
        {
            chooseStock();
        }
        
        static private void chooseStock()
        {
            Console.WriteLine("What you want to add? Choos the number:");
            Console.WriteLine("1. Cups\n2. Male of milk\n3. Male of Sugar\n4. capsule");

            int number = inputValidation();
            setStock(number);
            ShowStocks();
            
        }
        static private int inputValidation()
        {
            bool ok = true;
            int number;
            while (ok)
            {
                string input = Console.ReadLine();

                if(int.TryParse(input, out number) && number > 0 && number <= 4)
                {
                    Console.Clear();
                    return int.Parse(input);
                }    
            }
            return 0;
        }
        static void setStock(int choosenNumber)
        {
            int countOfStock = coustStockValidation();
            switch (choosenNumber)
            {
                case 1: _cups += countOfStock; break;
                case 2: _maleOfMilk += countOfStock; break;
                case 3: _maleOfSugar += countOfStock; break;
                case 4: chooseCupsule(countOfStock,chooseCapsuleName()); break;
                default: break;
            }
        }
        static int coustStockValidation()
        {

            bool ok = true;
            int countResult;
            while (ok)
            {
                Console.WriteLine("what is the count you need?");
                string input = Console.ReadLine();

                if(int.TryParse(input, out countResult) && countResult > 0)
                {
                    Console.Clear();
                    return countResult;
                }
            }
            return 0;
        }
        static public void ShowStocks()
        {
           string stock = String.Format(
               $"Stock:\n1. Cups: {_cups}" +
               $"\n2. Male Of Milk: {_maleOfMilk}" +
               $"\n3. Male Of Sugar: {_maleOfSugar}" +
               $"\n4. Capsule:  "
               );
            Console.WriteLine(stock);
            showCapsuleStock();
        }
        private static void chooseCupsule(int count, string name)
        {
            if(_capsule.Count != 0)
               _capsule[name] = count;
            else
                Console.WriteLine("You dont have any cappsule.");
        }
        public static void AddCapsule(string capsueName)
        {
            _capsule.Add(capsueName, 0); 
        }
        private static string chooseCapsuleName()
        {
            if (_capsule.Count == 0) return null;
            int result = chooseCapsulNumberValidation();
            for (int i = 0; i < DrinkManager.HotDrinks.Count; i++)
                if(i == result)
                {
                    Console.Clear();
                    return DrinkManager.HotDrinks[i].CapsuleType;
                }
            return null;
        }

        private static void showCapsuleStock()
        {
            int i = 1;
            foreach (var item in _capsule)
            {
                Console.WriteLine($"{i}. {item.Key}, {item.Value}");
                i++;
            }
        }
        private static int chooseCapsulNumberValidation()
        {
            Console.WriteLine("Choose capsule by number:");
            showCapsuleStock(); 

            bool ok = true;
            int result;

            while (ok)
            {
                if (int.TryParse(Console.ReadLine(), out result) && result > 0 && result <= DrinkManager.HotDrinks.Count)
                {
                    Console.Clear();
                    return result - 1;
                }
            }
            return 0;
        }
        public static void DeleteCapsule(string key)
        {
            _capsule.Remove(key);
        }
    }
}
