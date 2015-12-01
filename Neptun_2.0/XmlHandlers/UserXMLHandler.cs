using System;
using System.Xml;
using System.Collections.Generic;
using Neptun_Structure;

//created by Kristóf Weisz - UKDUJP
namespace Neptun_XML
{
    class UserXmlHandler : XmlHandler
    {
        #region getters
        public Student GetStudent(string neptunCode)
        {
            string id = "";
            string name = "";
            string type = "";
            string pw = "";
            List<string> subjects = new List<string>();
            List<string> requests = new List<string>();
            XmlReader xmlReader = null;

            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

                //TODO resolve this Hax
                xmlReader.Read();
                xmlReader.Read();

                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        type = GetValue(ref xmlReader, "type");
                        pw = GetValue(ref xmlReader, "pw");
                        subjects = GetList(ref xmlReader, "subjects", "id");
                        requests = GetList(ref xmlReader, "requests", "id");
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

            return new Student(id, name, type, pw, subjects, requests);
        }

        public Teacher GetTeacher(string neptunCode)
        {

            string id = "";
            string name = "";
            string type = "";
            string pw = "";
            List<string> subjects = new List<string>();
            List<string> demands = new List<string>();
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

                //TODO resolve Hax
                xmlReader.Read();
                xmlReader.Read();

                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        type = GetValue(ref xmlReader, "type");
                        pw = GetValue(ref xmlReader, "pw");
                        subjects = GetList(ref xmlReader, "subjects", "id");
                        demands = GetList(ref xmlReader, "demands", "id");
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

            return new Teacher(id, name, type, pw, subjects, demands);
        }

        public Admin GetAdmin(string neptunCode)
        {
            string id = "";
            string name = "";
            string type = "";
            string pw = "";
            XmlReader xmlReader = null;

            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

                //TODO resolve Hax?!
                xmlReader.Read();
                xmlReader.Read();

                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        type = GetValue(ref xmlReader, "type");
                        pw = GetValue(ref xmlReader, "pw");
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

            return new Admin(id, name, type, pw);
        }

        public string GetUserName(string neptunCode)
        {
            string name = "";
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));
                name = GetValue(ref xmlReader, "name");
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

            return name;
        }

        public List<string> GetSubjectIds(string neptunCode)
        {
            List<string> subjects = new List<string>();
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));
                subjects = GetList(ref xmlReader, "subjects", "id");        
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

            return subjects;
        }

        public List<string> GetRequestIds(string neptunCode)
        {
            List<string> documents = new List<string>();
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));
                documents = GetList(ref xmlReader, "requests", "id");
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

            return documents;
        }

        public List<string> GetDemandIds(string neptunCode)
        {
            List<string> documents = new List<string>();
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));
                documents = GetList(ref xmlReader, "demands", "id");
            }
            catch (Exception)
            {
                //TODO resolve hax
                return null;
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Dispose();
                }
            }
            return documents;
        }

        public string CheckLogin(string neptunCode, string password)
        {
            //TODO error cmd
            string ret = "";
            XmlReader xmlReader = null;

            try
            {
                xmlReader = XmlReader.Create("Users/" + neptunCode + ".xml");
                //TODO check header

                string userType = GetValue(ref xmlReader, "type");
                string userpw = GetValue(ref xmlReader, "pw");

                if (userpw == password)
                {
                    ret = userType;
                }
                else
                {
                    ret = null;
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Dispose();
                }
            }

            return ret;
        }
        #endregion

        #region functional methods

        public bool Register(string neptunCode, string subjId)
        {
            try
            {
                AppendEmptyNodeWithAttr(GetXmlFileName(neptunCode), "/user/subjects", "subject", "id", subjId);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeRegister(string neptunCode, string subjId)
        {
            //RemoveNodeByAttr(GetXmlFileName(neptunCode), "user/lectures/lecture[@id=\"" + subjId + "\"]");
            try
            {
                RemoveNodeByAttr(GetXmlFileName(neptunCode), CreateXPathWithAttr("/user/subjects/subject", "id", subjId));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeRegisterAll(string neptunCode)
        {
            //RemoveNodeByAttr(GetXmlFileName(neptunCode), "user/lectures/lecture[@id=\"" + subjId + "\"]");
            List<string> subjIds = GetSubjectIds(neptunCode);
            try
            {
                foreach (string subjId in subjIds)
                {
                    RemoveNodeByAttr(GetXmlFileName(neptunCode), CreateXPathWithAttr("/user/subjects/subject", "id", subjId)); 
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool AppendDemand(string neptunCode, string docId)
        {
            try
            {
                AppendEmptyNodeWithAttr(GetXmlFileName(neptunCode), "/user/demands", "demand", "id", docId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool AppendRequest(string neptunCode, string docId)
        {
            try
            {
                AppendEmptyNodeWithAttr(GetXmlFileName(neptunCode), "/user/requests", "request", "id", docId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region helper methods

        //bool IsValid()
        //{
        //    //TODO implement
        //    return true;
        //}

        private string GetXmlFileName(string id)
        {
            return "Users/" + id + ".xml";
        }
        #endregion
    }
}