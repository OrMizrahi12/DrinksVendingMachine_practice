using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class PrepareDrink
    {
        public static void Prepare(HotDrink hotDrink)
        {
            Console.Clear();
            Console.WriteLine($"*********\nPreparation\n*********\n\n{hotDrink.DrinkName}");
            addingIngredients(hotDrink);
            addingHotWater(hotDrink);
            andStirring(hotDrink);
        }
        static void addingIngredients(HotDrink hotDrink)
        {
            Console.WriteLine($"1 ---> Add {hotDrink.CapsuleType}");
            if (hotDrink.MilkNeeded) Console.WriteLine("---> Adding milk");
        }

        static void addingHotWater(HotDrink hotDrink)
        {
            Console.WriteLine($"---> Adding whatar temper of {hotDrink.WatarTemper}");
        }
        static void andStirring(HotDrink hotDrink)
        {
            Console.WriteLine($"---> Stirring ---> your {hotDrink.DrinkName} is ready!");
        }
    }
}
