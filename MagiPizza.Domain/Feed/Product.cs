namespace MagiPizza.Domain.Feed
{
    public class Product
    {
        int processingTimeM;
        double price;
        string product_size;
        int raw_id;
        int product_id;
        int setupTime;

        public int SetupTime
        {
            get { return setupTime; }
            set { setupTime = value; }
        }

        public int Product_id
        {
            get { return product_id; }
            set { product_id = value; }
        }

        public int Raw_id
        {
            get { return raw_id; }
            set { raw_id = value; }
        }

        public string Product_size
        {
            get { return product_size; }
            set { product_size = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int ProcessingTimeM
        {
            get { return processingTimeM; }
            set { processingTimeM = value; }
        }
        public Product()
        {
            this.Price = -1;
            this.ProcessingTimeM = -1;
            this.Product_id = -1;
            this.Product_size = "";
            this.Raw_id = -1;

        }
        public Product(int id,int rawId, string size,int processingTime,double price )
        {
            this.Price = -1;
            this.ProcessingTimeM = -1;
            this.Product_id = -1;
            this.Product_size = "";
            this.Raw_id = -1;

        }
    }
}