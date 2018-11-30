using System;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp1.SO
{
    public class XMLReading
    {
        public class Hello
        {
            public IList<string> HellosList { get; set; }
        }
        public static void ReadXML(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", "urn:oasis:names:tc:evs:schema:eml");

            XmlNode testNode = doc.SelectSingleNode("/ns:EML/ns:EMLHeader/ns:ManagingAuthority/ns:Description", nsmgr);
            if (testNode != null)
            {
                Console.WriteLine(testNode.InnerText);
            }
        }
    }
}
