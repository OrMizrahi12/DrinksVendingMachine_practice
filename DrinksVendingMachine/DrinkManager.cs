using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class DrinkManager
    {
       private static List<HotDrink>  hotDrinks = new List<HotDrink>();
       public static List<HotDrink> HotDrinks { get { return hotDrinks; } }

        public static void AddHotDrink()
        {
            string capsule;
            hotDrinks.Add
            (
                new HotDrink
                (
                  nameValidation("drink"),
                  defaineMilkSettingValidation(),
                  whatarTemperValidation(),
                  capsule = nameValidation("capsul"),
                  nameValidation("extras")
                )
            );
            Stock.AddCapsule(capsule);

        }
        public static void BuyDrink()
        {
            PrepareDrink.Prepare(chooseItemValidation());
        }

        public static void ShowHotDrink()
        {
            for (int i = 0; i < hotDrinks.Count; i++)
                Console.WriteLine($"{i + 1}. {hotDrinks[i].DrinkName}");
        }


        private static string nameValidation(string propertyType)
        {
            bool ok = true;
            string nameResult = string.Empty;
            while (ok)
            {
                if(propertyType == "drink" || propertyType == "capsul")
                {
                    Console.WriteLine($"What is the {propertyType} name?");
                    nameResult = Console.ReadLine();

                    if (nameResult == null || nameResult.Length < 1)
                        Console.WriteLine("Place, inseret a valid name.");
                    else return nameResult;
                }
                else if(propertyType == "extras")
                {
                    Console.WriteLine($"There is some extra? kinamon, etc.. if no, press Enter witout write.");
                    return Console.ReadLine();
                }
            }
            return nameResult;
        }
        private static bool defaineMilkSettingValidation()
        {
            bool ok = true;
            string input;
            int numberResult;
            while (ok)
            {
                Console.WriteLine("Your drink is need milk?\n1 - Yes\n0 - No");
                input = Console.ReadLine();

                if (int.TryParse(input, out numberResult))
                {
                    if (numberResult == 0) return false;
                    else if (numberResult == 1) return true;
                    else Console.WriteLine("Inseret valid number 1/0");
                }
                else Console.WriteLine("Inseret Only numbers.");
            }
            return false;
        }
        private static int whatarTemperValidation()
        {
            bool ok = true;
            string input;
            int temperResult;
            while (ok)
            {
                Console.WriteLine("What is the temperature of the water? 50 - 100");
                input = Console.ReadLine();

                if (int.TryParse(input, out temperResult) && temperResult >= 50 && temperResult <= 100)
                    return temperResult;
                else Console.WriteLine("Inseret Only numbers 50 - 100");
            }
            return 0; 
        }
        public static void DeleteDrink()
        {
            HotDrink drinkToRemove = chooseItemValidation();
            if (drinkToRemove != null)
            {
                hotDrinks.Remove(drinkToRemove);
                Stock.DeleteCapsule(drinkToRemove.CapsuleType); 
            } 
        }

        private static HotDrink chooseItemValidation()
        {
            int index = 1;
          
            foreach (var item in hotDrinks)
            {
                Console.WriteLine($"{index}. {item.DrinkName}");
                index++;
            }
         
            int result = chooseNumberValidation();
         
            for (int i = 0; i < hotDrinks.Count; i++)
                if (i == result - 1)
                    return hotDrinks[i];
            
            return null;
        }
        private static int chooseNumberValidation() 
        {
            bool ok = true;
            string input;
            int removingNumber;
            while (ok)
            {
                
                input = Console.ReadLine();

                if (int.TryParse(input, out removingNumber) && removingNumber >= 1 && removingNumber <= hotDrinks.Count)
                    return removingNumber;
                else Console.WriteLine($"Inseret Only numbers 1 - {hotDrinks.Count}");
            }
            return 0;
        }
    }
}
