using Vending_Machine;

internal class Program
{
    private static void Main(string[] args)
    {
        var store = new Store("Biltema");
        var cart = new Cart();
        var user = new User("Josef", 480);

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
                    case ConsoleKey.H:
                        game.Pause();
                        string anser = Hellpers.Ask("Vill du ha hjälp (ja/nej):").ToLower();
                        if (anser == "ja")
                        {
                            Hellpers.Help();
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
                        Hellpers.Bay(cart, store, user);
                        break;
                   case ConsoleKey.M:
                        cart.getTotalMoney();
                        break;
                    case ConsoleKey.R:
                        cart.Reset(store);
                        break;
                    case ConsoleKey.U:
                        Console.WriteLine($"{user.Money}kr left");
                        break;
                    case ConsoleKey.Escape:
                        game.Stop();
                        return;
                }
            }
        }
    }
}