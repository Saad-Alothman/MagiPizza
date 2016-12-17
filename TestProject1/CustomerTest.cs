using WindowsFormsApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for CustomerTest and is intended
    ///to contain all CustomerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Telephone
        ///</summary>
        [TestMethod()]
        public void TelephoneTest()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            string expected = "123"; // TODO: Initialize to an appropriate value
            string actual;
            target.Telephone = expected;
            actual = target.Telephone;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Postcode
        ///</summary>
        [TestMethod()]
        public void PostcodeTest()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            string expected = "postCode"; // TODO: Initialize to an appropriate value
            string actual;
            target.Postcode = expected;
            actual = target.Postcode;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for LastName
        ///</summary>
        [TestMethod()]
        public void LastNameTest()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            string expected = "lname"; // TODO: Initialize to an appropriate value
            string actual;
            target.LastName = expected;
            actual = target.LastName;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for FirstName
        ///</summary>
        [TestMethod()]
        public void FirstNameTest()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            string expected = "name"; // TODO: Initialize to an appropriate value
            string actual;
            target.FirstName = expected;
            actual = target.FirstName;
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for Email
        ///</summary>
        [TestMethod()]
        public void EmailTest()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            string expected = "me@me"; // TODO: Initialize to an appropriate value
            string actual;
            target.Email = expected;
            actual = target.Email;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Customer_id
        ///</summary>
        [TestMethod()]
        public void Customer_idTest()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            int expected = 44; // TODO: Initialize to an appropriate value
            int actual;
            target.Customer_id = expected;
            actual = target.Customer_id;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for County
        ///</summary>
        [TestMethod()]
        public void CountyTest()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            string expected = "county"; // TODO: Initialize to an appropriate value
            string actual;
            target.County = expected;
            actual = target.County;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for City
        ///</summary>
        [TestMethod()]
        public void CityTest()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            string expected = "lon"; // TODO: Initialize to an appropriate value
            string actual;
            target.City = expected;
            actual = target.City;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for AddressLine2
        ///</summary>
        [TestMethod()]
        public void AddressLine2Test()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            string expected = "add2"; // TODO: Initialize to an appropriate value
            string actual;
            target.AddressLine2 = expected;
            actual = target.AddressLine2;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for AddressLine1
        ///</summary>
        [TestMethod()]
        public void AddressLine1Test()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(); // TODO: Initialize to an appropriate value
            string expected = "add1"; // TODO: Initialize to an appropriate value
            string actual;
            target.AddressLine1 = expected;
            actual = target.AddressLine1;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Customer Constructor
        ///</summary>
        [TestMethod()]
        public void CustomerConstructorTest1()
        {
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer();
            
        }

        /// <summary>
        ///A test for Customer Constructor
        ///</summary>
        [TestMethod()]
        public void CustomerConstructorTest()
        {
            string addr1 = "add1"; // TODO: Initialize to an appropriate value
            string addr2 = "add2"; // TODO: Initialize to an appropriate value
            string cont = "county"; // TODO: Initialize to an appropriate value
            string cty = "city"; // TODO: Initialize to an appropriate value
            int customId = 37; // TODO: Initialize to an appropriate value
            string eml = "e@e.com"; // TODO: Initialize to an appropriate value
            string fname = "saad"; // TODO: Initialize to an appropriate value
            string lname = "fahad"; // TODO: Initialize to an appropriate value
            string pcode = "what"; // TODO: Initialize to an appropriate value
            string tel = "tel?"; // TODO: Initialize to an appropriate value
            WindowsFormsApplication4.Customer target = new WindowsFormsApplication4.Customer(addr1, addr2, cont, cty, customId, eml, fname, lname, pcode, tel);
            
        }
    }
}
