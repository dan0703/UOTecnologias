using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestFEI
{
    /// <summary>
    /// Descripción resumida de CareerTest
    /// </summary>
    [TestClass]
    public class CareerTest
    {
        private Implementations ServiceImplementation { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceImplementation = new Implementations();
        }

        [TestMethod()]
        public void Test01_GetCareerList_SuccessfullTest()
        {
            var result = ServiceImplementation.GetCareerList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
