namespace Vending_Machine
{
    class Store: ProductContainer
    {
        public string Name { get; }

        public Store(string name)
        {
            Name = name;
        }
    }
}
