using Vending_Machine;

internal class Program
{
    private static void Main(string[] args)
    {
        var store = new Store("Biltema");
        var cart = new Cart();
        var user = new User("Josef", 800);

        var game = new Game();

        game.Start();


        List<Product> products = new List<Product>(){
            new Product("Biltema korv", 15, 60),
            new Product("Kanelbulle och kaffe", 23, 60),
            new Product("Fanta", 23, 60),
            new Product("Coca Cola", 12, 60)
        };

        foreach (var product in products)
        {
            store.AddProduct(product);
        };

        while (!game.GameOver)
        {
            // listen to key presses
            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    // send key presses to the game if it's not paused
                    case ConsoleKey.H:
                        game.Pause();
                        string anser = Ask("Vill du ha hjälp (ja/nej):");
                        if (anser.ToLower() == "ja")
                        {
                            help();
                        }
                        game.Resume();
                        break;
                    case ConsoleKey.S:
                        game.Pause();
                        store.GetAllProducts();
                        game.Resume();
                        break;
                    case ConsoleKey.B:
                        game.Pause();
                        cart.GetAllProducts();
                        game.Resume();
                        break;
                    case ConsoleKey.A:
                        bay();
                        break;
                   case ConsoleKey.M:
                        cart.getTotalMoney();
                        break;
                    case ConsoleKey.Escape:
                        game.Stop();
                        return;
                }
            }
        }

        void help()
        {
            Console.WriteLine("List all the prodoct from cart write B");
            Console.WriteLine("List all the prodoct from shop write S");
            Console.WriteLine("");
        }
        void bay()
        {

            string id = Ask("Vad vill du köpa, vänligen ange id för produkten:").Trim();
            if (Guid.TryParse(id, out var guidOutput)) 
            {
                int amount = int.Parse(Ask("Hur många:"));
                cart.Bay(amount, id, store);
            }
        }
        string Ask(string text)
        {
            while (true)
            {
                Console.Write(text);
                string anser = Console.ReadLine() ?? "";
                if (anser != "")
                {
                    return anser;
                }
            }
        }
    }
}