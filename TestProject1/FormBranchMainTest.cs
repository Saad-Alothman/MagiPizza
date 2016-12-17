using WindowsFormsApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for FormBranchMainTest and is intended
    ///to contain all FormBranchMainTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FormBranchMainTest
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
        ///A test for printOrderDetails
        ///</summary>
        [TestMethod()]
        public void printOrderDetailsTest()
        {
            WindowsFormsApplication4.FormBranchMain target = new WindowsFormsApplication4.FormBranchMain(); // TODO: Initialize to an appropriate value
            WindowsFormsApplication4.order rder = new order(); // TODO: Initialize to an appropriate value
            string time = System.DateTime.Now.ToShortTimeString();
            rder.Order_processing_FinishTime = time;
            rder.Order_processing_startTime = time;
            string expected = "start Time :" + time + "\r\n" + "Finish Time: " + time; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.printOrderDetails(rder);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for FormBranchMain Constructor
        ///</summary>
        [TestMethod()]
        public void FormBranchMainConstructorTest1()
        {
            WindowsFormsApplication4.FormBranchMain target = new WindowsFormsApplication4.FormBranchMain();
            
        }

        /// <summary>
        ///A test for FormBranchMain Constructor
        ///</summary>
        [TestMethod()]
        public void FormBranchMainConstructorTest()
        {
            int bId = 0; // TODO: Initialize to an appropriate value
            WindowsFormsApplication4.FormBranchMain target = new WindowsFormsApplication4.FormBranchMain(bId);
            
        }
    }
}
