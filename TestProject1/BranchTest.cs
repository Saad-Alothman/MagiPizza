using WindowsFormsApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for BranchTest and is intended
    ///to contain all BranchTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BranchTest
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
        ///A test for NumberOfVehicles
        ///</summary>
        [TestMethod()]
        public void NumberOfVehiclesTest()
        {
            WindowsFormsApplication4.Branch target = new WindowsFormsApplication4.Branch(); 
            int expected = 5; // TODO: Initialize to an appropriate value
            int actual;
            target.NumberOfVehicles = expected;
            actual = target.NumberOfVehicles;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for NumberOfStaff
        ///</summary>
        [TestMethod()]
        public void NumberOfStaffTest()
        {
            WindowsFormsApplication4.Branch target = new WindowsFormsApplication4.Branch(); // TODO: Initialize to an appropriate value
            int expected = 4; // TODO: Initialize to an appropriate value
            int actual;
            target.NumberOfStaff = expected;
            actual = target.NumberOfStaff;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsAvialable
        ///</summary>
        [TestMethod()]
        public void IsAvialableTest()
        {
            WindowsFormsApplication4.Branch target = new WindowsFormsApplication4.Branch(); // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsAvialable = expected;
            actual = target.IsAvialable;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for BranchVehicles
        ///</summary>
        [TestMethod()]
        public void BranchVehiclesTest()
        {
            WindowsFormsApplication4.Branch target = new WindowsFormsApplication4.Branch(); // TODO: Initialize to an appropriate value
            Vehicle v = new Vehicle(1, 1, 4, true);
            System.Collections.Generic.List<WindowsFormsApplication4.Vehicle> expected = new System.Collections.Generic.List<Vehicle>(); // TODO: Initialize to an appropriate value
            expected.Add(v);
            System.Collections.Generic.List<WindowsFormsApplication4.Vehicle> actual;
            target.BranchVehicles = expected;
            actual = target.BranchVehicles;
            Assert.AreEqual(expected, actual);
            
        }

       
        /// <summary>
        ///A test for Branch_postcode
        ///</summary>
        [TestMethod()]
        public void Branch_postcodeTest()
        {
            WindowsFormsApplication4.Branch target = new WindowsFormsApplication4.Branch(); // TODO: Initialize to an appropriate value
            string expected = "e149rt"; // TODO: Initialize to an appropriate value
            string actual;
            target.Branch_postcode = expected;
            actual = target.Branch_postcode;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Branch_id
        ///</summary>
        [TestMethod()]
        public void Branch_idTest()
        {
            WindowsFormsApplication4.Branch target = new WindowsFormsApplication4.Branch(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Branch_id = expected;
            actual = target.Branch_id;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            WindowsFormsApplication4.Branch target = new WindowsFormsApplication4.Branch(); // TODO: Initialize to an appropriate value
            object obj = new WindowsFormsApplication4.Branch(); // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Equals(obj);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Branch Constructor
        ///</summary>
        [TestMethod()]
        public void BranchConstructorTest()
        {
            WindowsFormsApplication4.Branch target = new WindowsFormsApplication4.Branch();
            
        }
    }
}
