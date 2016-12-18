namespace MagiPizza.Domain.Models
{
    public class Customer
    {
        int customer_id;
        string firstName;
        string lastName;
        string addressLine1;
        string addressLine2;
        string county;
        string city;
        string postcode;
        string email;
        string telephone;


        public Customer()
        {
            this.AddressLine1 = "";
            this.AddressLine2 = "";
            this.County = "";
            this.City = "";
            this.Customer_id = -1;
            this.Email = "";
            this.FirstName = "";
            this.LastName = "";
            this.Postcode = "";
            this.Telephone = "";

        }
        public Customer(string addr1, string addr2, string cont, string cty, int customId, string eml, string fname, string lname, string pcode, string tel)
        {
            this.AddressLine1 = addr1;
            this.AddressLine2 = addr2;
            this.County = cont;
            this.City = cty;
            this.Customer_id = customId;
            this.Email = eml;
            this.FirstName = fname;
            this.LastName = lname;
            this.Postcode = pcode;
            this.Telephone = tel;

        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public string County
        {
            get { return county; }
            set { county = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string AddressLine2
        {
            get { return addressLine2; }
            set { addressLine2 = value; }
        }
        public string AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value; }
        }
        //addressLine1 	addressLine2 county postcode email telephone xCoordinate yCoordinate
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public int Customer_id
        {
            get { return customer_id; }
            set { customer_id = value; }
        }

    }
}