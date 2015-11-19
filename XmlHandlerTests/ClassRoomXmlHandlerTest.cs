using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neptun_2._0;

namespace XmlHandlerTests
{
    [TestClass]
    public class ClassRoomXmlHandlerTest
    {
        [TestMethod]
        public void GetClassRoom()
        {
            ClassRoomXmlHandler handler = new ClassRoomXmlHandler();

            ClassRoom room = handler.GetClassRoom("A1");

            Console.WriteLine(ObjectDumper.Dump(room));
        }
    }
}
