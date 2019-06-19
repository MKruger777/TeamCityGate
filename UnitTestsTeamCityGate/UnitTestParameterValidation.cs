using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamCityGate;

namespace UnitTestsTeamCityGate
{
    [TestClass]
    public class UnitTestParameterValidation
    {
        [TestMethod]
        public void TeamCityURL_NOT_OK()
        {
            bool expected = false;
            Options options = new Options();
            options.TeamCityUrl = "http:/build.binckbank.nv";
            options.TCBuildConfID = "Topline_T1_Build";
            bool actual = ParameterValidation.ParameterContentValid(options);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TeamCityURL_OK()
        {
            bool expected = true;
            Options options = new Options();
            options.TeamCityUrl = "http://build.binckbank.nv";
            options.TCBuildConfID = "Topline_T1_Build";
            bool actual = ParameterValidation.ParameterContentValid(options);
            Assert.AreEqual(expected, actual);
        }
    }
}
