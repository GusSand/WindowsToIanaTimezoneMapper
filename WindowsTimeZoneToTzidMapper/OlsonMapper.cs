using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WindowsTimeZoneToTzidMapper
{
    public class OlsonMapper
    {
        private readonly Dictionary<string, string> _mapping;
        private const string _xmlPath = @"..\..\WindowsTimeZoneToTzidMapper\currenttimezones.xml";


        public OlsonMapper(string path)
        {
            if (string.IsNullOrEmpty(path))
                path = _xmlPath;

            var xml = XElement.Load(path);
            var values = from m in xml.XPathSelectElements("*/mapTimezones/mapZone")
                where m.Attribute("territory").Value == "001"
                select new
                {
                    TimeZoneId = m.Attribute("other").Value,
                    OlsonId = m.Attribute("type").Value
                };

            _mapping = values.ToDictionary(v => v.TimeZoneId, v => v.OlsonId);


        }

        public static void Main()
        {
            
        }

        public string Find(string timeZoneId)
        {
            if (!_mapping.ContainsKey(timeZoneId))
                return timeZoneId;

            return _mapping[timeZoneId];
        }
    }
}
