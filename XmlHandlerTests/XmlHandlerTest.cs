using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neptun_2._0;
using System.Web.Mvc;
using System.Xml;
using System.Collections.Generic;

namespace XmlHandlerTest
{
    [TestClass]
    public class XmlHandlerTest
    {
        public string dir = "TestXmls";

        [TestMethod]
        public void Get2ndList()
        {
            string file = "VEMFK12.xml";
            string node = "students";
            string attr = "id";

            XmlHandler handler = new XmlHandler();

            XmlReader xmlReader = XmlReader.Create(dir+"/"+file);
            List<string> result = handler.GetList(ref xmlReader, node, attr);

            xmlReader.Dispose();
            Console.WriteLine(ObjectDumper.Dump(result));
        }

        [TestMethod]
        public void GetEmptyList()
        {
            
            string file = "EmptyList.xml";
            string node = "lectures";
            string attr = "id";

            XmlHandler handler = new XmlHandler();

            XmlReader xmlReader = XmlReader.Create(dir + "/" + file);
            List<string> empty = new List<string>();
            List<string> result = handler.GetList(ref xmlReader, node, attr);

            Console.WriteLine(ObjectDumper.Dump(result));
            Assert.IsTrue(result.Count == 0);
         
            xmlReader.Dispose();
        }

        [TestMethod]
        public void GetAllIdsTest()
        {
            XmlHandler handler = new XmlHandler();


            List<string> results = handler.GetAllIds("Lectures");

            Console.WriteLine(ObjectDumper.Dump(results));
        }
    }
}
