using GildedRose.Items;
using GildedRose.ItemsRepository;

namespace GildedRose
{
    public class ConsoleView : ShopOutputBoundary
    {
        public static void Main(string[] args)
        {
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
                Console.Write("Your option? ");
                // Use a switch statement to do the math.
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Liste des articles : ");
                        DisplayInventory(items);
                        break;
                    case "2":
                        DisplayBalance(balance);
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