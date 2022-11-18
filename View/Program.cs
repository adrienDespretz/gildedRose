using GildedRose.ItemsRepository;

namespace GildedRose
{
    public class Program
    {
        public static ItemRepository _repository = new FileItemsRepository();


        public static void Main(string[] args)
        {
            bool endApp = false;
            Shop shop = new Shop(_repository);

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
                        Console.WriteLine("Liste des articles : ");

                        var inventory = _repository.GetInventory();
                        foreach (var item in inventory)
                        {
                            Console.WriteLine("- Nom : " + item.name + " \t/ Sell in : " + item.sellIn + " \t/ Qualité : " + item.quality + " \t/ Prix : " + item.basePrice);
                        }
                        break;
                    case "2":
                        var balance = shop.GetBalance();
                        Console.WriteLine("Votre solde : " + balance);
                        break;
                    case "3":
                        shop.UpdateQuality();
                        Console.WriteLine("Item has been updated");
                        break;
                    case "4":
                        Console.WriteLine("Type : ");
                        var type = Console.ReadLine();
                        Console.WriteLine("Quality : ");
                        var quality = Console.Read();
                        shop.SellItem(type, quality);
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