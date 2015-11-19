using System;
using System.Xml;
using System.Collections.Generic;

namespace Neptun_2._0
{
    class UserXmlHandler : XmlHandler
    {
        #region reworked

        #region getters
        public Student GetStudent(string dir, string neptunCode)
        {
            XmlReader xmlReader = XmlReader.Create(dir + neptunCode + ".xml");
            //TODO .Create() exception handling + try catch

            //TODO resolve Hax
            xmlReader.Read();
            xmlReader.Read();

            string id = "";
            string name = "";
            string type = "";
            string pw = "";
            List<string> subjects = new List<string>();
            List<string> requests = new List<string>();

            try
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "student") && (xmlReader.GetAttribute("id") == neptunCode))
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new Student(id, name, type, pw, subjects, requests);
        }

        public Teacher GetTeacher(string dir, string neptunCode)
        {
            XmlReader xmlReader = XmlReader.Create(dir + neptunCode + ".xml");
            //TODO .Create() exception handling + try catch

            //TODO resolve Hax
            xmlReader.Read();
            xmlReader.Read();

            string id = "";
            string name = "";
            string type = "";
            string pw = "";
            List<string> subjects = new List<string>();
            List<string> demands = new List<string>();

            try
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "teacher") && (xmlReader.GetAttribute("id") == neptunCode))
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new Teacher(id, name, type, pw, subjects, demands);
        }

        public Admin GetDemand(string dir, string neptunCode)
        {
            XmlReader xmlReader = XmlReader.Create(dir + neptunCode + ".xml");
            //TODO .Create() exception handling + try catch

            //TODO resolve Hax
            xmlReader.Read();
            xmlReader.Read();

            string id = "";
            string name = "";
            string type = "";
            string pw = "";

            try
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "admin") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        type = GetValue(ref xmlReader, "type");
                        pw = GetValue(ref xmlReader, "pw");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new Admin(id, name, type, pw);
        }
        #endregion

        #region savers


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

        #endregion

        #endregion

        #region old_version
        /*
        #region getters
        public string GetUserName(string neptunCode)
        {
            string name = "";

            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));
            name = GetValue(ref xmlReader, "name");

            xmlReader.Dispose();
            return name;
        }

        public User GetUser(string neptunCode)
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

        }

        public List<string> GetSubjectIds(string neptunCode)
        {
            //TODO try catch
            List<string> subjects = new List<string>();
            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

            subjects = GetList(ref xmlReader, "lectures", "id");

            return subjects;
        }

        public List<string> GetDocumentIds(string neptunCode)
        {
            //TODO try catch
            List<string> documents = new List<string>();
            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

            documents = GetList(ref xmlReader, "documents", "id");
            return documents;
        }

        public bool CheckLogin(string neptunCode, string password)
        {
            XmlReader xmlReader;
            try
            {
                xmlReader = XmlReader.Create("Users/" + neptunCode + ".xml");
                //TODO check header

                string userpw = GetValue(ref xmlReader, "pw");
                xmlReader.Dispose();
                if (userpw == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                //TODO e
            }

            //TODO ??
            return false;
        }
        #endregion

        #region functional methods
        //TODO implement
        public bool Register(string neptunCode, string subjId)
        {
            AppendEmptyNodeWithAttr(GetXmlFileName(neptunCode), "/user/lectures/", "lecture", "id", subjId);
            return true;
        }

        public bool DeRegister(string neptunCode, string subjId)
        {
            //RemoveNodeByAttr(GetXmlFileName(neptunCode), "user/lectures/lecture[@id=\"" + subjId + "\"]");
            RemoveNodeByAttr(GetXmlFileName(neptunCode), CreateXPathWithAttr("/user/lectures/lecture", "id", subjId));
            return true;
        }

        public bool AppendDocument(string neptunCode, string docId)
        {
            AppendEmptyNodeWithAttr(GetXmlFileName(neptunCode), "/user/documents/", "document", "id", docId);
            return true;
        }
        #endregion

        #region helper methods
        //TODO implement
        bool IsValid()
        {
            return true;
        }

        private string GetXmlFileName(string dir, string id)
        {
            return dir + id + ".xml";
        }
        #endregion*/
        #endregion
    }
}