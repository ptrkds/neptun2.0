using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neptun_2._0;
using System.Web.Mvc;

namespace XmlHandlerTest
{
    [TestClass]
    public class XmlHandlerTest
    {
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
