using System;
using System.Collections.Generic;
using System.Xml;
using Neptun_Structure;

//created by Kristóf Weisz - UKDUJP
namespace Neptun_XML
{
    class ClassRoomXmlHandler : XmlHandler
    {
        #region getters

        public List<string> GetSubjectIds(string roomId)
        {
            List<string> ids = new List<string>();
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(roomId));
                ids = GetList(ref xmlReader, "subjects", "id");     
            }
            catch (Exception)
            {
                return null;
            } 
            finally
            {
                if(xmlReader != null)
                {
                    xmlReader.Dispose();
                }
            }

            return ids;
        }

        public int GetLimit(string roomId)
        {
            int limit;
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(roomId));
                limit = Int32.Parse(GetValue(ref xmlReader, "limit"));
            }
            catch(Exception)
            {
                return -1;
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Dispose();
                }
            }

            return limit;
        }

        public ClassRoom GetClassRoom(string roomId)
        {
            
            string id = "";
            int limit = 0;
            List<string> subjectIds = new List<string>();
            XmlReader xmlReader = null;
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
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Dispose();
                }
            }

            return new ClassRoom(id, limit, subjectIds);
        }

        #endregion

        #region functional methods

        public bool RegisterSubject(string roomId, string subjId)
        {
            try
            {
                AppendEmptyNodeWithAttr(GetXmlFileName(roomId), "/room/subjects", "subject", "id", subjId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeRegister(string roomId, string subjId)
        {
            try
            {
                RemoveNodeByAttr(GetXmlFileName(roomId), CreateXPathWithAttr("/room/subjects/subject", "id", subjId));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeRegisterAll(string roomId)
        {
            //RemoveNodeByAttr(GetXmlFileName(neptunCode), "user/lectures/lecture[@id=\"" + subjId + "\"]");
            List<string> ids = GetSubjectIds(roomId);
            try
            {
                foreach (string id in ids)
                {
                    RemoveNodeByAttr(GetXmlFileName(roomId), CreateXPathWithAttr("/room/subjects/subject", "id", id));
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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


