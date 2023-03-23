using System.ComponentModel;
using System.Linq;

namespace Vending_Machine
{
    class Store: ProductContainer
    {
        public string Name { get; }

        

        public Store(string name)
        {
            Name = name;
        }
        

        public void removeById(int amount, string id, Store continuer)
        {
            // Get the prodokt from Store
            Product stroreProduct = getProduktById(id);

            // check if we can remove
            if (stroreProduct.Stock < amount)
            {
                throw new Exception("You are trying to remove more then you have.");
            }

            // Remove the stock by the amount
            stroreProduct.Stock -= amount;

            // Remove the prodokt
            products.Remove(stroreProduct);
        }
    }
}
