using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neptun_2._0;
using System.Web.Mvc;
using System.Xml;
using System.Collections.Generic;

namespace XmlHandlerTests
{
    [TestClass]
    public class DemandXmlHandlerTest
    {

        [TestMethod]
        public void GetDemandTest()
        {
            DemandXmlHandler handler = new DemandXmlHandler();
            Demand demand = handler.GetDemand("ASDF1234");

            dumpDemand(demand);
        }
        private void dumpDemand(Demand toDump)
        {
            Console.WriteLine(ObjectDumper.Dump(toDump));
        }

        [TestMethod]
        public void CreateXml()
        {
            //DemandXmlHandler handler = new DemandXmlHandler();

            //handler.CreateDemand(handler.GetDemand("ASDF1234"));

        }

        [TestMethod]
        public void ChangeDemand()
        {
            //DemandXmlHandler handler = new DemandXmlHandler();

            //handler.CreateDemand(handler.GetDemand("ASDF1234"));
        }
        
    }
}
