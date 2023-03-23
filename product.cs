namespace Vending_Machine
{
    class Product
    {
        public Product( string name, int price, int stock)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Stock = stock;
        }

        public Guid Id { get; }
        public string Name { get; }
        public int Price { get; }
        public int Stock { get; set; }
    }
}
