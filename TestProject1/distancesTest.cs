using PerformanceMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for distancesTest and is intended
    ///to contain all distancesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class distancesTest
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
        ///A test for OrderId
        ///</summary>
        [TestMethod()]
        public void OrderIdTest()
        {
            PerformanceMonitor.distances target = new PerformanceMonitor.distances(); // TODO: Initialize to an appropriate value
            int expected = 10; // TODO: Initialize to an appropriate value
            int actual;
            target.OrderId = expected;
            actual = target.OrderId;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CustomerId
        ///</summary>
        [TestMethod()]
        public void CustomerIdTest()
        {
            PerformanceMonitor.distances target = new PerformanceMonitor.distances(); // TODO: Initialize to an appropriate value
            int expected = 2; // TODO: Initialize to an appropriate value
            int actual;
            target.CustomerId = expected;
            actual = target.CustomerId;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for BranchesDistance
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PerformanceMonitor.exe")]
        public void BranchesDistanceTest()
        {
            PerformanceMonitor.distances_Accessor target = new PerformanceMonitor.distances_Accessor(); // TODO: Initialize to an appropriate value
            System.Collections.Generic.List<int[]> l = new System.Collections.Generic.List<int[]>();
            int[] m = {4,4};
            l.Add(m);
            System.Collections.Generic.List<int[]> expected = l; // TODO: Initialize to an appropriate value
            System.Collections.Generic.List<int[]> actual;
            target.BranchesDistance = expected;
            actual = target.BranchesDistance;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for distances Constructor
        ///</summary>
        [TestMethod()]
        public void distancesConstructorTest()
        {
            PerformanceMonitor.distances target = new PerformanceMonitor.distances();
            
        }
    }
}
