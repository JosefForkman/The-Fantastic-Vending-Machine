namespace Vending_Machine
{
    internal class product
    {
        public product(int id, string name, int price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public int Id { get; }
        public string Name { get; }
        public int Price { get; }
        public int Stock { get; }
    }
}
