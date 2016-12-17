using WindowsFormsApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for EmployeeTest and is intended
    ///to contain all EmployeeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmployeeTest
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
        ///A test for Last_name
        ///</summary>
        [TestMethod()]
        public void Last_nameTest()
        {
            WindowsFormsApplication4.Employee target = new WindowsFormsApplication4.Employee(); // TODO: Initialize to an appropriate value
            string expected = "smith"; // TODO: Initialize to an appropriate value
            string actual;
            target.Last_name = expected;
            actual = target.Last_name;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsAvailable
        ///</summary>
        [TestMethod()]
        public void IsAvailableTest()
        {
            WindowsFormsApplication4.Employee target = new WindowsFormsApplication4.Employee(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsAvailable = expected;
            actual = target.IsAvailable;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for First_Name
        ///</summary>
        [TestMethod()]
        public void First_NameTest()
        {
            WindowsFormsApplication4.Employee target = new WindowsFormsApplication4.Employee(); // TODO: Initialize to an appropriate value
            string expected = "First"; // TODO: Initialize to an appropriate value
            string actual;
            target.First_Name = expected;
            actual = target.First_Name;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for EmployeeId
        ///</summary>
        [TestMethod()]
        public void EmployeeIdTest()
        {
            WindowsFormsApplication4.Employee target = new WindowsFormsApplication4.Employee(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.EmployeeId = expected;
            actual = target.EmployeeId;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for BranchId
        ///</summary>
        [TestMethod()]
        public void BranchIdTest()
        {
            WindowsFormsApplication4.Employee target = new WindowsFormsApplication4.Employee(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.BranchId = expected;
            actual = target.BranchId;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Employee Constructor
        ///</summary>
        [TestMethod()]
        public void EmployeeConstructorTest1()
        {
            WindowsFormsApplication4.Employee target = new WindowsFormsApplication4.Employee();
            
        }

        /// <summary>
        ///A test for Employee Constructor
        ///</summary>
        [TestMethod()]
        public void EmployeeConstructorTest()
        {
            int eid = 0; // TODO: Initialize to an appropriate value
            int bid = 0; // TODO: Initialize to an appropriate value
            bool available = false; // TODO: Initialize to an appropriate value
            WindowsFormsApplication4.Employee target = new WindowsFormsApplication4.Employee(eid, bid, available);
            
        }
    }
}
