using PerformanceMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProductTest and is intended
    ///to contain all ProductTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductTest
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
        ///A test for SetupTime
        ///</summary>
        [TestMethod()]
        public void SetupTimeTest()
        {
            PerformanceMonitor.Product target = new PerformanceMonitor.Product(); // TODO: Initialize to an appropriate value
            int expected = 27; // TODO: Initialize to an appropriate value
            int actual;
            target.SetupTime = expected;
            actual = target.SetupTime;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Raw_id
        ///</summary>
        [TestMethod()]
        public void Raw_idTest()
        {
            PerformanceMonitor.Product target = new PerformanceMonitor.Product(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Raw_id = expected;
            actual = target.Raw_id;
            Assert.AreEqual(expected, actual);
         
        }

        /// <summary>
        ///A test for Product_size
        ///</summary>
        [TestMethod()]
        public void Product_sizeTest()
        {
            PerformanceMonitor.Product target = new PerformanceMonitor.Product(); // TODO: Initialize to an appropriate value
            string expected = "small"; // TODO: Initialize to an appropriate value
            string actual;
            target.Product_size = expected;
            actual = target.Product_size;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Product_id
        ///</summary>
        [TestMethod()]
        public void Product_idTest()
        {
            PerformanceMonitor.Product target = new PerformanceMonitor.Product(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Product_id = expected;
            actual = target.Product_id;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for ProcessingTimeM
        ///</summary>
        [TestMethod()]
        public void ProcessingTimeMTest()
        {
            PerformanceMonitor.Product target = new PerformanceMonitor.Product(); // TODO: Initialize to an appropriate value
            int expected = 77; // TODO: Initialize to an appropriate value
            int actual;
            target.ProcessingTimeM = expected;
            actual = target.ProcessingTimeM;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Price
        ///</summary>
        [TestMethod()]
        public void PriceTest()
        {
            PerformanceMonitor.Product target = new PerformanceMonitor.Product(); // TODO: Initialize to an appropriate value
            double expected = 22F; // TODO: Initialize to an appropriate value
            double actual;
            target.Price = expected;
            actual = target.Price;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Product Constructor
        ///</summary>
        [TestMethod()]
        public void ProductConstructorTest1()
        {
            PerformanceMonitor.Product target = new PerformanceMonitor.Product();
            
        }

        /// <summary>
        ///A test for Product Constructor
        ///</summary>
        [TestMethod()]
        public void ProductConstructorTest()
        {
            int id = 1; // TODO: Initialize to an appropriate value
            int rawId = 2; // TODO: Initialize to an appropriate value
            string size = "Hello"; // TODO: Initialize to an appropriate value
            int processingTime = 2; // TODO: Initialize to an appropriate value
            double price = 1F; // TODO: Initialize to an appropriate value
            PerformanceMonitor.Product target = new PerformanceMonitor.Product(id, rawId, size, processingTime, price);
            
        }
    }
}
