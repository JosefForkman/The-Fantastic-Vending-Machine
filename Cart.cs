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
            Product cartProduct = getProduktByName(storeProdukt.Name);

            // Check if possible to bay
            if (storeProdukt.Stock >= amount)
            {
                storeProdukt.Stock -= amount;
                Product product = new(storeProdukt.Name, storeProdukt.Price, amount);

                if (cartProduct != null)
                {
                    cartProduct.Stock += amount;
                } 
                else
                {
                    AddProduct(product);
                }

                totalCost += (storeProdukt.Price * amount);
            }
            else
            {
                throw new Exception("You can\'t bay more then the store have in stock");
            }
        }   
        public void getTotalMoney ()
        {
            Console.WriteLine($"Kundvangnen har ett prudukter med värdet {totalCost}");
        }
    }
}
