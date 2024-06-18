using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestFEI
{
    /// <summary>
    /// Descripción resumida de ProcedureTest
    /// </summary>
    [TestClass]
    public class ProcedureTest
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
            var result = ServiceImplementation.GetProcedureList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
