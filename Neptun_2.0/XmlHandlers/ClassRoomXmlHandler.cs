using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Neptun_2._0
{
    class ClassRoomXmlHandler : XmlHandler
    {
        //TODO ???
        //public void Save(ClassRoom room)

        #region getters

        public List<string> GetSubjectIds(string roomId)
        {
            List<string> ids = new List<string>();
            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(roomId));

            ids = GetList(ref xmlReader, "subjects", "id");

            return ids;
        }

        public int GetLimit(string roomId)
        {
            int limit;

            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(roomId));

            limit = Int32.Parse(GetValue(ref xmlReader, "limit"));

            xmlReader.Dispose();
            return limit;
        }

        public ClassRoom GetClassRoom(string roomId)
        {
            XmlReader xmlReader;
            //TODO .Create() exception handling + try catch

            string id = "";
            int limit = 0;
            List<string> subjectIds = new List<string>();

            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(roomId));

                //TODO resolve
                xmlReader.Read();
                xmlReader.Read();

                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "room") && (xmlReader.GetAttribute("id") == roomId))
                    {
                        id = xmlReader.GetAttribute("id");
                        limit = Int32.Parse(GetValue(ref xmlReader, "limit"));

                        subjectIds = GetList(ref xmlReader, "subjects", "id");
                    }
                }

                xmlReader.Dispose();
            }
            catch (Exception)
            {
                //TODO hax
                return null;
            }

            return new ClassRoom(id, limit, subjectIds);
        }

        #endregion

        #region functional methods

        public bool RegisterSubject(string roomId, string subjId)
        {
            AppendEmptyNodeWithAttr(GetXmlFileName(roomId), "/room/subjects", "subject", "id", subjId);
            return true;
        }

        public void DeRegister(string roomId, string subjId)
        {
            RemoveNodeByAttr(GetXmlFileName(roomId), CreateXPathWithAttr("/room/subjects/subject", "id", subjId));
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
