
using GildedRose.ItemsRepository;

namespace GildedRose {  
class Program
{
        static void Main(string[] args)
        {
            FileItemsRepository fileItemsRepository = new FileItemsRepository();

            Console.WriteLine("Gilded Rose\r");
            Console.WriteLine("------------------------\n");

            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - DisplayInventory");
            Console.WriteLine("\t2 - DisplayBalance");
            Console.WriteLine("\t3 - UpdateInventory");
            Console.WriteLine("\t4 - SellItem");
            Console.Write("Your option? ");

            // Use a switch statement to do the math.
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Liste des articles : ");

                    var inventory =  fileItemsRepository.GetInventory();
                    foreach(var item in inventory)
                    {
                        Console.WriteLine("- Nom : " + item.name + " \t/ Sell in : " + item.sellIn + " \t/ Qualité : " + item.quality);
                    }
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
            }
            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the Calculator console app...");
            Console.ReadKey();
            }
}
}