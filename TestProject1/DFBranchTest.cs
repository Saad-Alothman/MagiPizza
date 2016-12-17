using PerformanceMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DFBranchTest and is intended
    ///to contain all DFBranchTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DFBranchTest
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
        ///A test for QueueTime
        ///</summary>
        [TestMethod()]
        public void QueueTimeTest()
        {
            PerformanceMonitor.DFBranch target = new PerformanceMonitor.DFBranch(); // TODO: Initialize to an appropriate value
            double expected = 10.0; // TODO: Initialize to an appropriate value
            double actual;
            target.QueueTime = expected;
            actual = target.QueueTime;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsVehiclesAvailable
        ///</summary>
        [TestMethod()]
        public void IsVehiclesAvailableTest()
        {
            PerformanceMonitor.DFBranch target = new PerformanceMonitor.DFBranch(); // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsVehiclesAvailable = expected;
            actual = target.IsVehiclesAvailable;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsStaffAvailable
        ///</summary>
        [TestMethod()]
        public void IsStaffAvailableTest()
        {
            PerformanceMonitor.DFBranch target = new PerformanceMonitor.DFBranch(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsStaffAvailable = expected;
            actual = target.IsStaffAvailable;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsAvailable
        ///</summary>
        [TestMethod()]
        public void IsAvailableTest()
        {
            PerformanceMonitor.DFBranch target = new PerformanceMonitor.DFBranch(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsAvailable = expected;
            actual = target.IsAvailable;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for EnoughStock
        ///</summary>
        [TestMethod()]
        public void EnoughStockTest()
        {
            PerformanceMonitor.DFBranch target = new PerformanceMonitor.DFBranch(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.EnoughStock = expected;
            actual = target.EnoughStock;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for DistanceToCustomer
        ///</summary>
        [TestMethod()]
        public void DistanceToCustomerTest()
        {
            PerformanceMonitor.DFBranch target = new PerformanceMonitor.DFBranch(); // TODO: Initialize to an appropriate value
            double expected = 20.0; // TODO: Initialize to an appropriate value
            double actual;
            target.DistanceToCustomer = expected;
            actual = target.DistanceToCustomer;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Branch_id
        ///</summary>
        [TestMethod()]
        public void Branch_idTest()
        {
            PerformanceMonitor.DFBranch target = new PerformanceMonitor.DFBranch(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Branch_id = expected;
            actual = target.Branch_id;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for DFBranch Constructor
        ///</summary>
        [TestMethod()]
        public void DFBranchConstructorTest()
        {
            PerformanceMonitor.DFBranch target = new PerformanceMonitor.DFBranch();
            
        }
    }
}
