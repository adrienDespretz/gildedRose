using GildedRose.Appli;
using GildedRose.Items;
using GildedRose.ItemsRepository;

namespace ConsoleView.Web
{
    public class ConsoleView : ShopOutputBoundary
    {

        public void DisplayInventory(List<ItemResponse> inventory)
        {
            foreach (var item in inventory)
            {
                Console.WriteLine("- Nom : " + item.name + " \t/ Sell in : " + item.sellIn + " \t/ Qualité : " + item.quality + " \t/ Prix : " + item.value);
            }
        }

        public void DisplayBalance(int balance)
        {
            Console.WriteLine("Votre solde : " + balance);
        }

        public static void Main(string[] args)
        {
            var shop = new ShopInteractor();
            var controller = new ConsoleController();
            var myClass = new ConsoleView();
            bool endApp = false;
            var Inventory = shop.GetInventory();
            List<ItemResponse> items = new List<ItemResponse>();
            foreach (var item in Inventory)
            {
                items.Add(new ItemResponse
                {
                    name = item.name,
                    sellIn = item.sellIn,
                    quality = item.quality,
                    value = item.basePrice
                });
            }

            int balance = 0;
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
                        myClass.DisplayInventory(items);
                        break;
                    case "2":
                        myClass.DisplayBalance(balance);
                        break;
                    case "3":
                        controller.UpdateInventory();
                        Console.WriteLine("Inventaire mis a jour ");

                        break;
                    case "4":
                        myClass.DisplayInventory(items);
                        SellItemRequest sellItemRequest = new SellItemRequest();
                        Console.WriteLine("Nom : ");
                        sellItemRequest.type = Console.ReadLine();
                        Console.WriteLine("Quality : ");
                        sellItemRequest.quality = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            int result = controller.SellItem(sellItemRequest);
                            balance = result;
                            Console.WriteLine("Produit Vendu ");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
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