using FEIService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace UnitTestFEI
{
    /// <summary>
    /// Descripción resumida de TutorTest
    /// </summary>
    [TestClass]
    public class TutorTest
    {
        private Implementations ServiceImplementation { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceImplementation = new Implementations();
        }

        [TestMethod()]
        public void Test01_GetTutorsList_SuccessfullTest()
        {
            var result = ServiceImplementation.GetTutorsList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
