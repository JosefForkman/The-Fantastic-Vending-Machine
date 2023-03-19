namespace Vending_Machine
{
    abstract class ProductContainer
    {
        protected ProductContainer(List<product> product)
        {
            Product = product;
        }

        public List<product> Product;

        public void AddProduct (product product)
        {
            Product.Add (product);
        }
        public List<product> GetAllProducts () 
        { 
            return Product; 
        }
    }
}
