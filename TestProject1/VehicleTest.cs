using WindowsFormsApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for VehicleTest and is intended
    ///to contain all VehicleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VehicleTest
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
        ///A test for VehicleId
        ///</summary>
        [TestMethod()]
        public void VehicleIdTest()
        {
            WindowsFormsApplication4.Vehicle target = new WindowsFormsApplication4.Vehicle(); // TODO: Initialize to an appropriate value
            int expected = 11; // TODO: Initialize to an appropriate value
            int actual;
            target.VehicleId = expected;
            actual = target.VehicleId;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsAvailable
        ///</summary>
        [TestMethod()]
        public void IsAvailableTest()
        {
            WindowsFormsApplication4.Vehicle target = new WindowsFormsApplication4.Vehicle(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsAvailable = expected;
            actual = target.IsAvailable;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Capacity
        ///</summary>
        [TestMethod()]
        public void CapacityTest()
        {
            WindowsFormsApplication4.Vehicle target = new WindowsFormsApplication4.Vehicle(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Capacity = expected;
            actual = target.Capacity;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for BranchId
        ///</summary>
        [TestMethod()]
        public void BranchIdTest()
        {
            WindowsFormsApplication4.Vehicle target = new WindowsFormsApplication4.Vehicle(); // TODO: Initialize to an appropriate value
            int expected = 28; // TODO: Initialize to an appropriate value
            int actual;
            target.BranchId = expected;
            actual = target.BranchId;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Vehicle Constructor
        ///</summary>
        [TestMethod()]
        public void VehicleConstructorTest1()
        {
            WindowsFormsApplication4.Vehicle target = new WindowsFormsApplication4.Vehicle();
            
        }

        /// <summary>
        ///A test for Vehicle Constructor
        ///</summary>
        [TestMethod()]
        public void VehicleConstructorTest()
        {
            int vid = 2; // TODO: Initialize to an appropriate value
            int bid = 2; // TODO: Initialize to an appropriate value
            int capacity = 1; // TODO: Initialize to an appropriate value
            bool available = false; // TODO: Initialize to an appropriate value
            WindowsFormsApplication4.Vehicle target = new WindowsFormsApplication4.Vehicle(vid, bid, capacity, available);
            
        }
    }
}
