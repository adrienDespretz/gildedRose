
using GildedRose.Items;

namespace GildedRose
{
    public class ConsolleController
    {
        private ShopInputBoudary shopBoudary;
        public static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Gilded Rose\r");
            Console.WriteLine("------------------------\n");
            while (!endApp)
            {
                // Ask the user to choose an option.
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\t1 - UpdateInventory");
                Console.WriteLine("\t2 - SellItem");
                Console.Write("Your option? ");
                // Use a switch statement to do the math.
                switch (Console.ReadLine())
                {
                    case "1":
                        shopBoudary.UpdateInventory();
                        Console.WriteLine("Item has been updated");
                        break;
                    case "2":
                        int i = 1;
                        foreach (Item item in shopBoudary.repository.GetInventory())
                        {
                            Console.WriteLine("- Nom : " + item.name + " \t/ Sell in : " + item.sellIn + " \t/ Qualité : " + item.quality + " \t/ Prix : " + item.basePrice);
                        }
                        Console.WriteLine("Nom : ");
                        var type = Console.ReadLine();
                        Console.WriteLine("Quality : ");
                        var quality = Convert.ToInt32(Console.ReadLine());
                        SellItemRequest request = new SellItemRequest();
                        request.type = type;
                        request.quality = quality;
                        try
                        {
                            shopBoudary.SellItem(request);
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