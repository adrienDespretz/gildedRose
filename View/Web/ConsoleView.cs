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
                Console.WriteLine("\t5 - LaunchAunction");
                Console.Write("Your option? ");
                // Use a switch statement to do the math.
                switch (Console.ReadLine())
                {
                    case "1":
                        var Inventory = shop.GetInventory();
                        List<ItemResponse> items = new List<ItemResponse>();
                        foreach (var getItem in Inventory)
                        {
                            items.Add(new ItemResponse
                            {
                                name = getItem.name,
                                sellIn = getItem.sellIn,
                                quality = getItem.quality,
                                value = getItem.basePrice
                            });
                        }
                        Console.WriteLine("Liste des articles : ");
                        myClass.DisplayInventory(items);
                        break;
                    case "2":
                        myClass.DisplayBalance(balance);
                        break;
                    case "3":
                        int balanceMaj = controller.UpdateInventory();
                        balance= balanceMaj;
                        Console.WriteLine("Inventaire mis a jour ");
                        break;
                    case "4":
                        var Inventorys = shop.GetInventory();
                        List<ItemResponse> itemsForSell = new List<ItemResponse>();
                        foreach (var itemsell in Inventorys)
                        {
                            itemsForSell.Add(new ItemResponse
                            {
                                name = itemsell.name,
                                sellIn = itemsell.sellIn,
                                quality = itemsell.quality,
                                value = itemsell.basePrice
                            });
                        }
                        myClass.DisplayInventory(itemsForSell);
                        SellItemRequest sellItemRequest = new SellItemRequest();
                        Console.WriteLine("Nom : ");
                        sellItemRequest.type = Console.ReadLine();
                        Console.WriteLine("Quality : ");
                            sellItemRequest.quality = Convert.ToInt32(Console.ReadLine());
                            int result = controller.SellItem(sellItemRequest);
                            balance = result;
                            Console.WriteLine("Produit Vendu ");
                        break;
                    case "5":
                        var item = controller.LaunchAunction();
                        int numberAuction = 0;
                        double PriceWithBid = 0;
                        LaunchAunctionRequest launchAunction = new LaunchAunctionRequest();
                        launchAunction.BidPrice = item.basePrice;
                        Console.WriteLine($"L'enchère pour l'item {item.name} a été ouvert ");
                        Console.WriteLine("- Nom : " + item.name + " \t/ Sell in : " + item.sellIn + " \t/ Qualité : " + item.quality + " \t/ Prix : " + item.basePrice);
                        Console.WriteLine($"Le prix commence a {item.basePrice}  ");
                        while (numberAuction <= 2)
                        {
                            numberAuction++;
                            Console.WriteLine($"Enchère {numberAuction}/3 ");
                            Console.Write("Voulez-vous enchérire ? (oui /non) : ");
                            launchAunction.response = Console.ReadLine();
                            PriceWithBid = controller.DoBidAunction(launchAunction);
                            Console.WriteLine($"Le prix est passé a {PriceWithBid}  ");

                        }
                        Console.WriteLine($"L'enchère est fini, l'item est parti pour : {PriceWithBid} ");
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