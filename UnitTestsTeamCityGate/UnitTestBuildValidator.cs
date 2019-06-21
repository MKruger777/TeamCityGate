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
            bv.TeamCityUrl = "teamcity.binckbank.nv";
            bv.TeamCityBuildConfID = "T1_02BuildCompilation";
            bool actual = bv.Validate(159172);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuildValidator_NOT_OK()
        {
            bool expected = false;
            BuildValidator bv = new BuildValidator();
            bv.TeamCityUrl = "teamcity.binckbank.nv";
            bv.TeamCityBuildConfID = "T1_02BuildCompilation";
            bool actual = bv.Validate(1591777);
            Assert.AreEqual(expected, actual);
        }
    }
}
