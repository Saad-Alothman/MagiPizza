using PerformanceMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DataFeedTest and is intended
    ///to contain all DataFeedTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataFeedTest
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
        ///A test for orderSize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PerformanceMonitor.exe")]
        public void orderSizeTest()
        {
            PerformanceMonitor.DataFeed_Accessor target = new PerformanceMonitor.DataFeed_Accessor(); 
            PerformanceMonitor.DFOrder order = new DFOrder(); // TODO: Initialize to an appropriate value
            int[] ol = new int[2];
            ol[0] = 1;
            ol[1] = 11;
            order.order.Add(ol);
            int expected = 11; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.orderSize(order);
            Assert.AreEqual(expected, actual);
            
        }


       

        /// <summary>
        ///A test for insert_order
        ///</summary>
        [TestMethod()]
        public void insert_orderTest()
        {
            PerformanceMonitor.DataFeed target = new PerformanceMonitor.DataFeed(); // TODO: Initialize to an appropriate value
            int customerId = 1; // TODO: Initialize to an appropriate value
            string orderDate = System.DateTime.Now.ToShortDateString(); // TODO: Initialize to an appropriate value
            string orderTime = System.DateTime.Now.ToShortTimeString(); // TODO: Initialize to an appropriate value
            string orderStatus = "placed"; // TODO: Initialize to an appropriate value
            string order_processing_startTime = System.DateTime.Now.ToShortTimeString();  // TODO: Initialize to an appropriate value
            string order_processing_FinishTime = System.DateTime.Now.Add(new System.TimeSpan(0,5,0)).ToShortTimeString();  // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;

            actual = target.insert_order(customerId, orderDate, orderTime, orderStatus, order_processing_startTime, order_processing_FinishTime);
            expected = actual;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for getVehiclesAverageSize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PerformanceMonitor.exe")]
        public void getVehiclesAverageSizeTest()
        {
            PerformanceMonitor.DataFeed_Accessor target = new PerformanceMonitor.DataFeed_Accessor(); // TODO: Initialize to an appropriate value
            WindowsFormsApplication4.Vehicle v = new WindowsFormsApplication4.Vehicle(1,2,20,true);
            target.dbVehicles.Add(v);
            v = new WindowsFormsApplication4.Vehicle(1, 2, 10, true);
            target.dbVehicles.Add(v);
            int expected = 15; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.getVehiclesAverageSize();
            Assert.AreEqual(expected, actual);
            
        }






        /// <summary>
        ///A test for calcDistance
        ///</summary>
        [TestMethod()]
        public void calcDistanceTest()
        {
            PerformanceMonitor.DataFeed target = new PerformanceMonitor.DataFeed(); // TODO: Initialize to an appropriate value
            int[] start = {15,15}; // TODO: Initialize to an appropriate value
            int[] finish = {15,15}; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.calcDistance(start, finish);
            Assert.AreEqual(expected, actual);
            
        }



    }
}
