using WindowsFormsApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for orderTest and is intended
    ///to contain all orderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class orderTest
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
        ///A test for Time_required
        ///</summary>
        [TestMethod()]
        public void Time_requiredTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order(); // TODO: Initialize to an appropriate value
            string expected = System.DateTime.Now.ToShortTimeString(); // TODO: Initialize to an appropriate value
            string actual;
            target.Time_required = expected;
            actual = target.Time_required;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Order_time
        ///</summary>
        [TestMethod()]
        public void Order_timeTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order(); // TODO: Initialize to an appropriate value
            string expected = System.DateTime.Now.ToShortTimeString(); // TODO: Initialize to an appropriate value
            string actual;
            target.Order_time = expected;
            actual = target.Order_time;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Order_status
        ///</summary>
        [TestMethod()]
        public void Order_statusTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order(); // TODO: Initialize to an appropriate value
            string expected = "done"; // TODO: Initialize to an appropriate value
            string actual;
            target.Order_status = expected;
            actual = target.Order_status;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Order_processing_startTime
        ///</summary>
        [TestMethod()]
        public void Order_processing_startTimeTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order(); // TODO: Initialize to an appropriate value
            string expected = System.DateTime.Now.ToShortTimeString(); // TODO: Initialize to an appropriate value
            string actual;
            target.Order_processing_startTime = expected;
            actual = target.Order_processing_startTime;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Order_processing_FinishTime
        ///</summary>
        [TestMethod()]
        public void Order_processing_FinishTimeTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order(); // TODO: Initialize to an appropriate value
            string expected = System.DateTime.Now.ToShortTimeString(); // TODO: Initialize to an appropriate value
            string actual;
            target.Order_processing_FinishTime = expected;
            actual = target.Order_processing_FinishTime;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Order_id
        ///</summary>
        [TestMethod()]
        public void Order_idTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order(); // TODO: Initialize to an appropriate value
            int expected = 7; // TODO: Initialize to an appropriate value
            int actual;
            target.Order_id = expected;
            actual = target.Order_id;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Order_date
        ///</summary>
        [TestMethod()]
        public void Order_dateTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order(); // TODO: Initialize to an appropriate value
            string expected = System.DateTime.Now.ToShortDateString(); // TODO: Initialize to an appropriate value
            string actual;
            target.Order_date = expected;
            actual = target.Order_date;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Dispatch_time
        ///</summary>
        [TestMethod()]
        public void Dispatch_timeTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order(); // TODO: Initialize to an appropriate value
            string expected = System.DateTime.Now.ToShortTimeString(); // TODO: Initialize to an appropriate value
            string actual;
            target.Dispatch_time = expected;
            actual = target.Dispatch_time;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Customer_id
        ///</summary>
        [TestMethod()]
        public void Customer_idTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order(); // TODO: Initialize to an appropriate value
            int expected = 2; // TODO: Initialize to an appropriate value
            int actual;
            target.Customer_id = expected;
            actual = target.Customer_id;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for order Constructor
        ///</summary>
        [TestMethod()]
        public void orderConstructorTest()
        {
            WindowsFormsApplication4.order target = new WindowsFormsApplication4.order();
            
        }
    }
}
