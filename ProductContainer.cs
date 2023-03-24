namespace Vending_Machine
{
    abstract class ProductContainer
    {
        

        protected List<Product> products = new List<Product>();

        public void AddProduct (Product product)
        {
            products.Add(product);
        }
        public void GetAllProducts()
        {
            foreach (Product product in products)
                Console.WriteLine($"{product.Name} {product.Stock} with id {product.Id}");

            if (products.Count <= 0)
            {
                Console.WriteLine("It´s empty!");
            }
        }
        public Product getProduktById(string id)
        {
            return products.Find(value => value.Id.ToString() == id);
        }
        public Product getProduktByName(string Name)
        {
            return products.Find(value => value.Name == Name);
        }

        public void RemoveById(int amount, string id, Store continuer)
        {
            Product product = getProduktById(id);
            Product storeProdukt = continuer.getProduktByName(product.Name);


            // Error check 
            if (product.Stock < amount)
            {
                throw new Exception("You are trying to remove more then you have.");
            }

            // check storeProdukt is does not exist
            if (storeProdukt == null)
            {
                throw new Exception("You are trying to access an prodokt from stor which does not exist.");
            }
            
            // Set the right amount on prodokt and vending maskin
            product.Stock -= amount;
            storeProdukt.Stock += amount;

            // If prodoct not exist more, remove it
            if (product.Stock == 0)
            {
                products.Remove(product);
            }
        }
    }
}
