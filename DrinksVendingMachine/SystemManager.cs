using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class SystemManager
    {
        DrinkManager drinkManager = new DrinkManager();
        public static void Engine()
        {
            menu(); 
        }
        private static void menu()
        {
            bool ok = true;
            while (ok)
            {
                showChooseOptions();
                choosingController(); 
            }
        }
        private static void showChooseOptions()
        {
            Console.WriteLine(
                "Inseret number between options:\n\n" +
                "1. Add hot Drink\n" +
                "2. Buy a drink\n" +
                "3. Update stocks\n" +
                "4. Delete drink\n" +
                "5. Show stock"
                );
        }
        private static void choosingController()
        {
            int choosenNumber = numberValidation();
            selectiveRouting(choosenNumber); 
        }

        private static int numberValidation()
        {
            bool ok = true;
            int number;

            while (ok)
            {
                if (int.TryParse(Console.ReadLine(), out number) && number >= 1 && number <= 5)
                {
                    Console.Clear();
                    return number;
                }
            }  
            return 0;
        }
        private static void selectiveRouting(int choosenNumber)
        {
            switch (choosenNumber)
            {
                case 1:
                    DrinkManager.AddHotDrink();
                    break; 
                case 2:
                     canBuyDrink();
                    break;
                case 3:
                    Stock.AddStock();
                    break;
                case 4:
                    canDeletDrink();
                    break;
                case 5:
                    Stock.ShowStocks();
                    break;
                default:
                    break;
            }
        }

        static private void canBuyDrink()
        {
            if(DrinkManager.HotDrinks.Count > 0) DrinkManager.BuyDrink();
            else Console.WriteLine("You are not added hot drink. \nAdd at least one drink.");
        }
        static private void canDeletDrink()
        {
            if (DrinkManager.HotDrinks.Count > 0) DrinkManager.DeleteDrink();
            else Console.WriteLine("You are not cant delete any drink. \nAdd at least one drink.");
        }



    }
}
