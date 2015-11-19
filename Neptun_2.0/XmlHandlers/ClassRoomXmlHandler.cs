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

        #region rework
        public ClassRoom GetClassRoom(string dir, string roomId)
        {
            XmlReader xmlReader = XmlReader.Create(dir + roomId + ".xml");
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
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "room") && (xmlReader.GetAttribute("id") == roomId))
                    {
                        id = xmlReader.GetAttribute("id");
                        limit = Int32.Parse(GetValue(ref xmlReader, "limit"));

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

        //TODO implement
        public void Save(ClassRoom room)
        {

        }
        #endregion

        #region old_version
        #region getters
        /*
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
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "room") && (xmlReader.GetAttribute("id") == roomId))
                    {
                        id = xmlReader.GetAttribute("id");
                        limit = Int32.Parse(GetValue(ref xmlReader, "limit"));

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
        */
        #endregion

        #region functional methods
        /*
    public bool RegisterSubject(string roomId, string subjId)
    {
        AppendEmptyNodeWithAttr(GetXmlFileName(roomId), "/room/lectures/", "lecture", "id", subjId);
        return true;
    }

    public void DeRegister(string roomId, string subjId)
    {
        RemoveNodeByAttr(GetXmlFileName(roomId), CreateXPathWithAttr("/room/lectures/lecture", "id", subjId));
    }
    */
        #endregion

        #region helper methods
        /*
    private string GetXmlFileName(string id)
    {
        return "ClassRooms/" + id + ".xml";
    }
    */
        #endregion
        #endregion

    }
}
