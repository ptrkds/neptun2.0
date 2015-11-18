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
        [TestMethod]
        public void GetList()
        {
            string dir = "Lectures";
            string file = "VEMFK12.xml";
            string node = "blacklist";
            string attr = "id";

            XmlHandler handler = new XmlHandler();

            XmlReader xmlReader = XmlReader.Create(dir+"/"+file);
            List<string> result = handler.GetList(ref xmlReader, node, attr);

            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
        }

        [TestMethod]
        public void GetAllIdsTest()
        {
            XmlHandler handler = new XmlHandler();


            string[] result = handler.GetAllIds("Lectures");

            foreach(string str in result)
            {
                Console.WriteLine(str);
            }

        }
    }
}
