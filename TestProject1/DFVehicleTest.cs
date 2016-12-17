using PerformanceMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DFVehicleTest and is intended
    ///to contain all DFVehicleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DFVehicleTest
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
        ///A test for TimeToDeliver
        ///</summary>
        [TestMethod()]
        public void TimeToDeliverTest()
        {
            PerformanceMonitor.DFVehicle target = new PerformanceMonitor.DFVehicle(); // TODO: Initialize to an appropriate value
            int expected = 20; // TODO: Initialize to an appropriate value
            int actual;
            target.TimeToDeliver = expected;
            actual = target.TimeToDeliver;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for LastJourney
        ///</summary>
        [TestMethod()]
        public void LastJourneyTest()
        {
            PerformanceMonitor.DFVehicle target = new PerformanceMonitor.DFVehicle(); // TODO: Initialize to an appropriate value
            PerformanceMonitor.journey j = new journey();
            j.Journey_capacity = 1;
            j.Journey_finishTime = System.DateTime.Now;
            j.Journey_startTime = System.DateTime.Now;
            j.JourneyId = 1;
            j.Vehicle_id = 2;            
            PerformanceMonitor.journey expected = j; // TODO: Initialize to an appropriate value
            PerformanceMonitor.journey actual;
            target.LastJourney = expected;
            actual = target.LastJourney;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsDirect
        ///</summary>
        [TestMethod()]
        public void IsDirectTest()
        {
            PerformanceMonitor.DFVehicle target = new PerformanceMonitor.DFVehicle(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsDirect = expected;
            actual = target.IsDirect;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for IfEmptyCanContainOrder
        ///</summary>
        [TestMethod()]
        public void IfEmptyCanContainOrderTest()
        {
            PerformanceMonitor.DFVehicle target = new PerformanceMonitor.DFVehicle(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IfEmptyCanContainOrder = expected;
            actual = target.IfEmptyCanContainOrder;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for HasJourney
        ///</summary>
        [TestMethod()]
        public void HasJourneyTest()
        {
            PerformanceMonitor.DFVehicle target = new PerformanceMonitor.DFVehicle(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.HasJourney = expected;
            actual = target.HasJourney;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for Distance_from_customer
        ///</summary>
        [TestMethod()]
        public void Distance_from_customerTest()
        {
            PerformanceMonitor.DFVehicle target = new PerformanceMonitor.DFVehicle(); // TODO: Initialize to an appropriate value
            double expected = 20.2; // TODO: Initialize to an appropriate value
            double actual;
            target.Distance_from_customer = expected;
            actual = target.Distance_from_customer;
            Assert.AreEqual(expected, actual);        
        }

        /// <summary>
        ///A test for CanAddToCurrentJourney
        ///</summary>
        [TestMethod()]
        public void CanAddToCurrentJourneyTest()
        {
            PerformanceMonitor.DFVehicle target = new PerformanceMonitor.DFVehicle(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.CanAddToCurrentJourney = expected;
            actual = target.CanAddToCurrentJourney;
            Assert.AreEqual(expected, actual);
        }

    }
}
