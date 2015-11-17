using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Neptun_2._0
{
    class ClassRoomXmlHandler : XmlHandler
    {
        //TODO implement
        public List<string> GetLectureIds(string roomId)
        {
            List<string> ids = new List<string>();


            
            return ids;
        }

        public int GetLimit(string roomId)
        {
            int limit;

            XmlReader xmlReader = XmlReader.Create("ClassRooms/" + roomId + ".xml");

            limit = Int32.Parse(GetValue(ref xmlReader, "limit"));

            xmlReader.Dispose();
            return limit;
        }
    }
}
