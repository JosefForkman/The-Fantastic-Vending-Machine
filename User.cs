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
        public int Money { get; private set; }

        public void SetMoney(int _money)
        {
            if (Money + _money >= 0)
            {
                Money += _money;
            }
        }
    }
}
