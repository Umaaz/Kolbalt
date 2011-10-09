using Kolbalt.Client.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kolbalt.Test
{
    
    
    /// <summary>
    ///This is a test class for IMDBFilmTest and is intended
    ///to contain all IMDBFilmTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IMDBFilmTest
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
        ///A test for ValidateFilm
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MediaApp.exe")]
        public void ValidateFilmTest()
        {
            Film film = new Film() { Synopsis = "qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui qwert yui " }; // TODO: Initialize to an appropriate value
            Film expected = null; // TODO: Initialize to an appropriate value
            Film actual;
            actual = IMDBFilm_Accessor.ValidateFilm(film);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
