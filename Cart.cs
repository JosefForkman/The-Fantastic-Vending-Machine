namespace Vending_Machine
{
    internal class Cart: ProductContainer
    {
        //private List<Product> products = new List<Product>();
        private int totalCost = 0;

        public Cart() {}

        
        
        public void reset(Store container) {
            List<Product> removedProdukts = products;

            foreach (Product product in removedProdukts)
            {
                string id = product.Id.ToString();
                int stock  = product.Stock;
                RemoveById(stock, id, container);
            }

            totalCost = 0;
        }
        public void Bay(int amount, string id, Store continuer)
        {
            Product storeProdukt = continuer.getProduktById(id);
            Product product = getProduktById(id);

            // Check if possible to bay
            if (storeProdukt.Stock >= amount)
            {
                // Set 
                product.Stock = amount;
                storeProdukt.Stock -= amount;

                totalCost += product.Price;

                AddProduct(storeProdukt);
            }
            else
            {
                throw new Exception("You can\'t bay more then the store have in stock");
            }
        }   
    }
}
