using PerformanceMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for journeyTest and is intended
    ///to contain all journeyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class journeyTest
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
        ///A test for journey Constructor
        ///</summary>
        [TestMethod()]
        public void journeyConstructorTest()
        {
            PerformanceMonitor.journey target = new PerformanceMonitor.journey();
            
        }

        /// <summary>
        ///A test for Journey_capacity
        ///</summary>
        [TestMethod()]
        public void Journey_capacityTest()
        {
            PerformanceMonitor.journey target = new PerformanceMonitor.journey(); // TODO: Initialize to an appropriate value
            int expected = 21; // TODO: Initialize to an appropriate value
            int actual;
            target.Journey_capacity = expected;
            actual = target.Journey_capacity;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Journey_date
        ///</summary>
        [TestMethod()]
        public void Journey_dateTest()
        {
            PerformanceMonitor.journey target = new PerformanceMonitor.journey(); // TODO: Initialize to an appropriate value
            System.DateTime expected = new System.DateTime(); // TODO: Initialize to an appropriate value
            System.DateTime actual;
            target.Journey_date = expected;
            actual = target.Journey_date;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Journey_finishTime
        ///</summary>
        [TestMethod()]
        public void Journey_finishTimeTest()
        {
            PerformanceMonitor.journey target = new PerformanceMonitor.journey(); // TODO: Initialize to an appropriate value
            System.DateTime expected = new System.DateTime(); // TODO: Initialize to an appropriate value
            System.DateTime actual;
            target.Journey_finishTime = expected;
            actual = target.Journey_finishTime;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Journey_startTime
        ///</summary>
        [TestMethod()]
        public void Journey_startTimeTest()
        {
            PerformanceMonitor.journey target = new PerformanceMonitor.journey(); // TODO: Initialize to an appropriate value
            System.DateTime expected = new System.DateTime(); // TODO: Initialize to an appropriate value
            System.DateTime actual;
            target.Journey_startTime = expected;
            actual = target.Journey_startTime;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for JourneyId
        ///</summary>
        [TestMethod()]
        public void JourneyIdTest()
        {
            PerformanceMonitor.journey target = new PerformanceMonitor.journey(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.JourneyId = expected;
            actual = target.JourneyId;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Vehicle_id
        ///</summary>
        [TestMethod()]
        public void Vehicle_idTest()
        {
            PerformanceMonitor.journey target = new PerformanceMonitor.journey(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Vehicle_id = expected;
            actual = target.Vehicle_id;
            Assert.AreEqual(expected, actual);
            
        }
    }
}
