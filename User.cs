namespace Vending_Machine
{
    internal class User
    {
        public User(string name, int money, Cart cart)
        {
            Name = name;
            Money = money;
            Cart = cart;
        }

        public string Name { get; }
        public int Money { get; }
        public Cart Cart { get; }
    }
}
