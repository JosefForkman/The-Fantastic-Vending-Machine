namespace Vending_Machine
{
    internal class Cart: ProductContainer
    {
        private int totalCost = 0;
        
        
        public void Reset(Store container) {
            for (int i = 0; i < products.Count; i++) 
            {
                string id = products[i].Id.ToString();
                int stock = products[i].Stock;
                RemoveById(stock, id, container);
            }

            // It's stupid, but this needs to be fixed
            // Remove the last product if it exist
            if (products.Count != 0 )
            {
                Product product = products[0];

                RemoveById(product.Stock, product.Id.ToString(), container);
            }

            totalCost = 0;
        }
        public void Bay(int amount, string id, Store continuer, User user)
        {
            Product storeProdukt = continuer.getProduktById(id);
            Product cartProduct = getProduktByName(storeProdukt.Name);
            
            int prodoktPrice = amount * storeProdukt.Price;

            // Check if possible to bay
            if (storeProdukt.Stock >= amount && user.Money >= prodoktPrice)
            {
                storeProdukt.Stock -= amount;
                Product product = new(storeProdukt.Name, storeProdukt.Price, amount);

                // Check if prodoct alredy exist in cart
                if (cartProduct != null)
                {
                    cartProduct.Stock += amount;
                } 
                else
                {
                    AddProduct(product);
                }

                user.SetMoney(-prodoktPrice);
                totalCost += prodoktPrice;
            }
            else
            {
                throw new Exception("You can\'t bay more then the store have in stock or how much money you have in your wallet");
            }
        }   
        public void getTotalMoney ()
        {
            Console.WriteLine($"Cart has prodokts with value of{totalCost}kr");
        }
    }
}
