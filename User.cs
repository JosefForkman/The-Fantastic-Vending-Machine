namespace Vending_Machine
{
    internal class User
    {
        public User(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public string Name { get; }
        public int Money { get; }
    }
}
