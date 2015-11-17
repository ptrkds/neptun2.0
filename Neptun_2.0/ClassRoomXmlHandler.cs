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
        #region getters

        //get all

        public List<string> GetLectureIds(string roomId)
        {
            List<string> ids = new List<string>();
            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(roomId));

            ids = GetList(ref xmlReader, "lectures", "id");
            
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

        public ClassRoom GetClassRoom(string roomId)
        {
            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(roomId));
            //TODO .Create() exception handling + try catch

            //TODO resolve
            xmlReader.Read();
            xmlReader.Read();

            string id = "";
            int limit = 0;
            List<string> subjectIds = new List<string>();

            try
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        limit = Int32.Parse(GetValue(ref xmlReader, "name"));

                        subjectIds = GetList(ref xmlReader, "lectures", "id");
                    }
                }
            }
            catch (Exception e)
            {
                //TODO e
            }

            return new ClassRoom(id, limit, subjectIds);
        }
        #endregion

        #region helper methods
        private string GetXmlFileName(string id)
        {
            return "ClassRooms/" + id + ".xml";
        }
        #endregion
    }
}
