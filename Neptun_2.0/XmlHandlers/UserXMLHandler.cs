using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;

namespace Neptun_2._0
{
    class UserXmlHandler : XmlHandler
    {
        #region getters
        public Student GetStudent(string neptunCode)
        {
            XmlReader xmlReader;

            string id = "";
            string name = "";
            string type = "";
            string pw = "";
            List<string> subjects = new List<string>();
            List<string> requests = new List<string>();

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
                        requests = GetList(ref xmlReader, "requests", "id");
                    }
                }

                xmlReader.Dispose();
            }
            catch (IOException e)
            {
                //TODO resolva hax
                return null;
            }
           
            return new Student(id, name, type, pw, subjects, requests);
        }

        public Teacher GetTeacher(string neptunCode)
        {
            XmlReader xmlReader;
            string id = "";
            string name = "";
            string type = "";
            string pw = "";
            List<string> subjects = new List<string>();
            List<string> demands = new List<string>();

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

                xmlReader.Dispose();
            }
            catch (Exception e)
            {
                //TODO resolva hax
                return null;
            }
            
            return new Teacher(id, name, type, pw, subjects, demands);
        }

        public Admin GetAdmin(string neptunCode)
        {
            XmlReader xmlReader;
            //TODO .Create() exception handling + try catch

           

            string id = "";
            string name = "";
            string type = "";
            string pw = "";

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
                    }
                }

                xmlReader.Dispose();
            }
            catch (Exception e)
            {
                //TODO resolve hax
                return null;
            }
            
            return new Admin(id, name, type, pw);
        }

        public string GetUserName(string neptunCode)
        {
            string name = "";

            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));
            name = GetValue(ref xmlReader, "name");

            xmlReader.Dispose();
            return name;
        }

        public List<string> GetSubjectIds(string neptunCode)
        {
            List<string> subjects = new List<string>();

            try
            {
                XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

                subjects = GetList(ref xmlReader, "subjects", "id");

                xmlReader.Dispose();
            }
            catch (Exception)
            {
                //TODO resolve hax
                return null;
            }

            return subjects;
        }

        public List<string> GetRequestIds(string neptunCode)
        {
            List<string> documents = new List<string>();
            try
            {
                XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

                documents = GetList(ref xmlReader, "requests", "id");
            }
            catch (Exception)
            {
                //TODO resolve hax
                return null;
            }
            return documents;
        }

        public List<string> GetDemandIds(string neptunCode)
        {
            List<string> documents = new List<string>();
            try
            {
                XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

                documents = GetList(ref xmlReader, "demands", "id");
            }
            catch (Exception)
            {
                //TODO resolve hax
                return null;
            }
            return documents;
        }

        public string CheckLogin(string neptunCode, string password)
        {
            XmlReader xmlReader;
            string ret = "";
            try
            {
                xmlReader = XmlReader.Create("Users/" + neptunCode + ".xml");
                //TODO check header

                string userType = GetValue(ref xmlReader, "type");
                string userpw = GetValue(ref xmlReader, "pw");


                xmlReader.Dispose();

                if (userpw == password)
                {
                    ret = userType;
                }
                else
                {
                    ret = null;
                }


            }
            catch (Exception e)
            {
                //TODO e
            }

            return ret;
        }
        #endregion

        #region functional methods

        public bool Register(string neptunCode, string subjId)
        {
            //TODO implement
            AppendEmptyNodeWithAttr(GetXmlFileName(neptunCode), "/user/lectures/", "lecture", "id", subjId);
            return true;
        }

        public bool DeRegister(string neptunCode, string subjId)
        {
            //RemoveNodeByAttr(GetXmlFileName(neptunCode), "user/lectures/lecture[@id=\"" + subjId + "\"]");
            RemoveNodeByAttr(GetXmlFileName(neptunCode), CreateXPathWithAttr("/user/lectures/lecture", "id", subjId));
            return true;
        }

        public bool AppendDemand(string neptunCode, string docId)
        {
            AppendEmptyNodeWithAttr(GetXmlFileName(neptunCode), "/user/demands/", "demand", "id", docId);
            return true;
        }

        public bool AppendRequest(string neptunCode, string docId)
        {
            AppendEmptyNodeWithAttr(GetXmlFileName(neptunCode), "/user/requests/", "request", "id", docId);
            return true;
        }

        #endregion

        #region helper methods

        bool IsValid()
        {
            //TODO implement
            return true;
        }

        private string GetXmlFileName(string id)
        {
            return "Users/" + id + ".xml";
        }
        #endregion



        #region not used code

        /* public User GetUser(string neptunCode)
        {
            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));
            //TODO .Create() exception handling + try catch

            //TODO resolve
            xmlReader.Read();
            xmlReader.Read();

            string id = "";
            string name = "";
            string type = "";
            List<string> subjects = new List<string>();
            List<string> documents = new List<string>();

            try
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        type = GetValue(ref xmlReader, "type");

                        subjects = GetList(ref xmlReader, "lectures", "id");
                        documents = GetList(ref xmlReader, "documents", "id");
                    }
                }
            }
            catch(Exception e)
            {
                //TODO e
            }

            return new User(id, name, type, subjects, documents);

        }*/

        #region savers

        /*
        void SaveStudent(Student student)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create("", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("student");

                writer.WriteAttributeString("id", student.getNeptunCode());
                writer.WriteElementString("name", student.getName());
                writer.WriteElementString("type", student.getType());
                writer.WriteElementString("pw", student.getPw());

                writer.WriteStartElement("subjects");
                foreach (string subjId in student.getSubjects())
                {
                    writer.WriteElementString("subject", string.Empty);
                    writer.WriteAttributeString("id", subjId);
                }
                writer.WriteEndElement();

                writer.WriteStartElement("requests");
                foreach (string requestId in student.getRequests())
                {
                    writer.WriteElementString("request", string.Empty);
                    writer.WriteAttributeString("id", requestId);
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        void SaveTeacher(Teacher teacher)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create("", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("teacher");

                writer.WriteAttributeString("id", teacher.getNeptunCode());
                writer.WriteElementString("name", teacher.getName());
                writer.WriteElementString("type", teacher.getType());
                writer.WriteElementString("pw", teacher.getPw());

                writer.WriteStartElement("subjects");
                foreach (string subjId in teacher.getSubjects())
                {
                    writer.WriteElementString("subject", string.Empty);
                    writer.WriteAttributeString("id", subjId);
                }
                writer.WriteEndElement();

                writer.WriteStartElement("demands");
                foreach (string demandId in teacher.getDemands())
                {
                    writer.WriteElementString("demand", string.Empty);
                    writer.WriteAttributeString("id", demandId);
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        void SaveAdmin(Admin admin)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create("", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("admin");

                writer.WriteAttributeString("id", admin.getNeptunCode());
                writer.WriteElementString("name", admin.getName());
                writer.WriteElementString("type", admin.getType());
                writer.WriteElementString("pw", admin.getPw());

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        */
        #endregion

        #endregion
    }
}