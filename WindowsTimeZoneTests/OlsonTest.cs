using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsTimeZoneToTzidMapper;

namespace WindowsTimeZoneTests
{

    [TestClass]
    public class OlsonTest
    {
        private OlsonMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            string path = @"..\..\..\WindowsTimeZoneToTzidMapper\currenttimezones.xml";
            _mapper = new OlsonMapper(path);
        }

        // mapZone other="Eastern Standard Time" territory="001" type="America/New_York"/>
        [TestMethod]
        public void TestMethodEasternTime()
        {
            const string timezoneId = "Eastern Standard Time";
            const string olsonString = "America/New_York";
            var result = _mapper.Find(timezoneId);
            Assert.AreEqual(olsonString, result);
        }


        [TestMethod]
        public void TestMethodPacificTime()
        {
            // ("Pacific Standard Time", "America/Los_Angeles")]
            const string timezoneId = "Pacific Standard Time";
            const string olsonString = "America/Los_Angeles";
            var result = _mapper.Find(timezoneId);
            Assert.AreEqual(olsonString, result);
        }

        [TestMethod]
        public void TestMethodEurope()
        {
            // <mapZone other="W. Europe Standard Time" territory="001" type="Europe/Berlin"/>
            const string timezoneId = "W. Europe Standard Time";
            const string olsonString = "Europe/Berlin";
            var result = _mapper.Find(timezoneId);
            Assert.AreEqual(olsonString, result);

        }

        [TestMethod]
        public void TestMethodUnknown()
        {
            // unknown
            const string timezoneId = "Unknown Id";
            var result = _mapper.Find(timezoneId);
            Assert.AreEqual(timezoneId, result);


        }



    }
}
