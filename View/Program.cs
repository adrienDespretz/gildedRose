
using GildedRose.ItemsRepository;

namespace GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            FileItemsRepository fileItemsRepository = new FileItemsRepository();

            Console.WriteLine("Gilded Rose\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
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
                        var itemslist = fileItemsRepository.GetInventory();

                        foreach (var item in itemslist)
                        {
                            Console.WriteLine("Name" + item.name);
                            Console.WriteLine("SellIn" + item.sellIn);
                            Console.WriteLine("Quality" + item.quality);
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        var itemlist = fileItemsRepository.GetInventory();
                        Shop shop = new Shop(itemlist);
                        shop.UpdateQuality();
                            Console.WriteLine("Item has been updated");

                        break;
                    case "4":

                        break;


                }
                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;

        }
    }
}