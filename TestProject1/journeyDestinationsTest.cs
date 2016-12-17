using PerformanceMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for journeyDestinationsTest and is intended
    ///to contain all journeyDestinationsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class journeyDestinationsTest
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
        ///A test for Postcode
        ///</summary>
        [TestMethod()]
        public void PostcodeTest()
        {
            PerformanceMonitor.journeyDestinations target = new PerformanceMonitor.journeyDestinations(); // TODO: Initialize to an appropriate value
            string expected ="eee"; // TODO: Initialize to an appropriate value
            string actual;
            target.Postcode = expected;
            actual = target.Postcode;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Order_id
        ///</summary>
        [TestMethod()]
        public void Order_idTest()
        {
            PerformanceMonitor.journeyDestinations target = new PerformanceMonitor.journeyDestinations(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Order_id = expected;
            actual = target.Order_id;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for journeyDestinations Constructor
        ///</summary>
        [TestMethod()]
        public void journeyDestinationsConstructorTest()
        {
            PerformanceMonitor.journeyDestinations target = new PerformanceMonitor.journeyDestinations();
            
        }

        /// <summary>
        ///A test for Destination_sequence
        ///</summary>
        [TestMethod()]
        public void Destination_sequenceTest()
        {
            PerformanceMonitor.journeyDestinations target = new PerformanceMonitor.journeyDestinations(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Destination_sequence = expected;
            actual = target.Destination_sequence;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for DestinationId
        ///</summary>
        [TestMethod()]
        public void DestinationIdTest()
        {
            PerformanceMonitor.journeyDestinations target = new PerformanceMonitor.journeyDestinations(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.DestinationId = expected;
            actual = target.DestinationId;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Duration_from_branch
        ///</summary>
        [TestMethod()]
        public void Duration_from_branchTest()
        {
            PerformanceMonitor.journeyDestinations target = new PerformanceMonitor.journeyDestinations(); // TODO: Initialize to an appropriate value
            int expected = 10; // TODO: Initialize to an appropriate value
            int actual;
            target.Duration_from_branch = expected;
            actual = target.Duration_from_branch;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Duration_from_last_stop
        ///</summary>
        [TestMethod()]
        public void Duration_from_last_stopTest()
        {
            PerformanceMonitor.journeyDestinations target = new PerformanceMonitor.journeyDestinations(); // TODO: Initialize to an appropriate value
            int expected = 15; // TODO: Initialize to an appropriate value
            int actual;
            target.Duration_from_last_stop = expected;
            actual = target.Duration_from_last_stop;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for JourneyId
        ///</summary>
        [TestMethod()]
        public void JourneyIdTest()
        {
            PerformanceMonitor.journeyDestinations target = new PerformanceMonitor.journeyDestinations(); // TODO: Initialize to an appropriate value
            int expected = 11; // TODO: Initialize to an appropriate value
            int actual;
            target.JourneyId = expected;
            actual = target.JourneyId;
            Assert.AreEqual(expected, actual);
            
        }
    }
}
