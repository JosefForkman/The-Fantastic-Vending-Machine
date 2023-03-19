namespace Vending_Machine
{
    internal class Store : ProductContainer
    {

        public Store(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
