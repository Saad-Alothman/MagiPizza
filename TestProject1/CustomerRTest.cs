using PerformanceMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for CustomerRTest and is intended
    ///to contain all CustomerRTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerRTest
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
        ///A test for YCoordinate
        ///</summary>
        [TestMethod()]
        public void YCoordinateTest()
        {
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR(); // TODO: Initialize to an appropriate value
            target.YCoordinate = 1;
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.YCoordinate = expected;
            actual = target.YCoordinate;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for XCoordinate
        ///</summary>
        [TestMethod()]
        public void XCoordinateTest()
        {
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1","addr2","uk","lon",1,"a@a.com","first","lastName","e149pb","1211",4,3); // TODO: Initialize to an appropriate value
            int expected = 4; // TODO: Initialize to an appropriate value
            int actual;
            target.XCoordinate = expected;
            actual = target.XCoordinate;
            Assert.AreEqual(expected, actual);
         
        }

        /// <summary>
        ///A test for Telephone
        ///</summary>
        [TestMethod()]
        public void TelephoneTest()
        {
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
            string expected = "1211"; // TODO: Initialize to an appropriate value
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
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
            string expected = "e149pb"; // TODO: Initialize to an appropriate value
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
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
            string expected = "lastName"; // TODO: Initialize to an appropriate value
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
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
            string expected = "first"; // TODO: Initialize to an appropriate value
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
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
            string expected = "a@a.com"; // TODO: Initialize to an appropriate value
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
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
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
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "ldn", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
            string expected = "ldn"; // TODO: Initialize to an appropriate value
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
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
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
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
            string expected = "addr2"; // TODO: Initialize to an appropriate value
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
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3); // TODO: Initialize to an appropriate value
            string expected = "addr1"; // TODO: Initialize to an appropriate value
            string actual;
            target.AddressLine1 = expected;
            actual = target.AddressLine1;
            Assert.AreEqual(expected, actual);
       
        }

        /// <summary>
        ///A test for CustomerR Constructor
        ///</summary>
        [TestMethod()]
        public void CustomerRConstructorTest1()
        {
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR("addr1", "addr2", "uk", "lon", 1, "a@a.com", "first", "lastName", "e149pb", "1211", 4, 3);
            //Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CustomerR Constructor
        ///</summary>
        [TestMethod()]
        public void CustomerRConstructorTest()
        {
            string addr1 = string.Empty; // TODO: Initialize to an appropriate value
            string addr2 = string.Empty; // TODO: Initialize to an appropriate value
            string cont = string.Empty; // TODO: Initialize to an appropriate value
            string cty = string.Empty; // TODO: Initialize to an appropriate value
            int customId = 0; // TODO: Initialize to an appropriate value
            string eml = string.Empty; // TODO: Initialize to an appropriate value
            string fname = string.Empty; // TODO: Initialize to an appropriate value
            string lname = string.Empty; // TODO: Initialize to an appropriate value
            string pcode = string.Empty; // TODO: Initialize to an appropriate value
            string tel = string.Empty; // TODO: Initialize to an appropriate value
            int x = 0; // TODO: Initialize to an appropriate value
            int y = 0; // TODO: Initialize to an appropriate value
            PerformanceMonitor.CustomerR target = new PerformanceMonitor.CustomerR(addr1, addr2, cont, cty, customId, eml, fname, lname, pcode, tel, x, y);
            
        }
    }
}
