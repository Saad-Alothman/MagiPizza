﻿using WindowsFormsApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DBHandlerTest and is intended
    ///to contain all DBHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBHandlerTest
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
        ///A test for setVehicleAs
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsFormsApplication4.exe")]
        public void setVehicleAsTest()
        {
            WindowsFormsApplication4.DBHandler_Accessor target = new WindowsFormsApplication4.DBHandler_Accessor(); // TODO: Initialize to an appropriate value
            int VehicleID = 2; // TODO: Initialize to an appropriate value
            int branchID = 3; // TODO: Initialize to an appropriate value
            string newState = "GOOD"; // TODO: Initialize to an appropriate value
            target.setVehicleAs(VehicleID, branchID, newState);
            
        }



        /// <summary>
        ///A test for getBranchInfo
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsFormsApplication4.exe")]
        public void getBranchInfoTest()
        {
            WindowsFormsApplication4.DBHandler_Accessor target = new WindowsFormsApplication4.DBHandler_Accessor(); // TODO: Initialize to an appropriate value
            int bId = 2; // TODO: Initialize to an appropriate value
            WindowsFormsApplication4.Branch expected = new Branch(); // TODO: Initialize to an appropriate value
            WindowsFormsApplication4.Branch actual;
            actual = target.getBranchInfo(bId);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for DBHandler Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsFormsApplication4.exe")]
        public void DBHandlerConstructorTest()
        {
            WindowsFormsApplication4.DBHandler_Accessor target = new WindowsFormsApplication4.DBHandler_Accessor();
            
        }

    }
}
