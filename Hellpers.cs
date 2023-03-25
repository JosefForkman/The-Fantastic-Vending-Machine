namespace Vending_Machine
{
    internal static class Hellpers
    {
        static public void Help()
        {
            Console.WriteLine("List all the prodoct from cart, write B");
            Console.WriteLine("List all the prodoct from shop, write S");
            Console.WriteLine("to start buying, write A");
            Console.WriteLine("to see cart money, write M");
            Console.WriteLine("to reset cart, write R");
            Console.WriteLine("see users money, write U");
        }
        static public void Bay(Cart cart, Store store, User user)
        {

            string id = Ask("What do you want to buy, please enter the id of the product:").Trim();
            if (Guid.TryParse(id, out var guidOutput))
            {
                int amount = int.Parse(Ask("How many:"));
                cart.Bay(amount, id, store, user);
            }
        }
        static public string Ask(string text)
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
