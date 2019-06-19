using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamCityGate;

namespace UnitTestsTeamCityGate
{
    [TestClass]
    public class UnitTestBuildValidator
    {
        [TestMethod]
        public void BuildValidator_OK()
        {
            bool expected = true;
            BuildValidator bv = new BuildValidator();
            bool actual = bv.Validate(34);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuildValidator_NOT_OK()
        {
            bool expected = false;
            BuildValidator bv = new BuildValidator();
            bool actual = bv.Validate(35);
            Assert.AreEqual(expected, actual);
        }
    }
}
