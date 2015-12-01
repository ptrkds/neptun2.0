using System;
using System.Collections.Generic;
using System.Xml;
using Neptun_Structure;

//created by Kristóf Weisz - UKDUJP
namespace Neptun_XML
{
    class SubjectXmlHandler : XmlHandler
    {
        #region getters
        public string GetSubjectName(string subjId)
        {
            string name = "";
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create("Subjects/" + subjId + ".xml");
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

        public List<string> GetStudentIds(string subjId)
        {
            List<string> ids = new List<string>();
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(subjId));
                ids = GetList(ref xmlReader, "students", "id");
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

        public List<string> GetBlockedStudentIds(string subjId)
        {
            List<string> ids = new List<string>();
            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(subjId));
                ids = GetList(ref xmlReader, "blacklist", "id");
                xmlReader.Dispose();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                xmlReader.Dispose();
            }

            return ids;
        }

        public Subject GetSubject(string subjId)
        {
            string id = "";
            string name = "";
            string teacher = "";
            string room = "";
            string day = "";
            string startTime = "";
            string endTime = "";
            List<string> studentIds = new List<string>();
            List<string> blockedStudentIds = new List<string>();
            XmlReader xmlReader = null;
         
            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(subjId));

                //TODO resolve hax
                xmlReader.Read();
                xmlReader.Read();

                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "subject") && (xmlReader.GetAttribute("id") == subjId))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        teacher = GetValue(ref xmlReader, "teacher");
                        room = GetValue(ref xmlReader, "room");
                        day = GetValue(ref xmlReader, "day");
                        startTime = GetValue(ref xmlReader, "startTime");
                        endTime = GetValue(ref xmlReader, "endTime");

                        studentIds = GetList(ref xmlReader, "students", "id");

                        blockedStudentIds = GetList(ref xmlReader, "blacklist", "id");
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
            
            return new Subject(id, name, teacher,room, day, startTime, endTime, studentIds, blockedStudentIds);
        }

        public string GetRoomId(string subjectId)
        {
            string room = "";
            XmlReader xmlReader = null;

            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(subjectId));
                room = GetValue(ref xmlReader, "room");
                xmlReader.Dispose();
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

            return room;
        }
        #endregion

        #region functional methods
        public bool CreateSubject(Subject subject)
        {
            //TODO try catch
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create(GetXmlFileName(subject.getId()), settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("subject");
                writer.WriteAttributeString("id", subject.getId());

                writer.WriteElementString("name", subject.getName());
                writer.WriteElementString("teacher", subject.getTeacher());
                writer.WriteElementString("room", subject.getClassRoom());
                writer.WriteElementString("day", subject.getDay());
                writer.WriteElementString("startTime", subject.getStartTime());
                writer.WriteElementString("endTime", subject.getEndTime());
                writer.WriteStartElement("students");
                foreach(string student in subject.getStudents())
                {
                    writer.WriteElementString("student", string.Empty);
                    writer.WriteAttributeString("id", student);
                }
                writer.WriteEndElement();
                writer.WriteStartElement("blacklist");

                foreach (string student in subject.getBlacklist())
                {
                    writer.WriteElementString("student", string.Empty);
                    writer.WriteAttributeString("id", student);

                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return true;
        }

        public bool Register(string subjId, string neptunCode)
        {
            try
            {
                AppendEmptyNodeWithAttr(GetXmlFileName(subjId), "/subject/students", "student", "id", neptunCode);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeRegister(string subjId, string neptunCode)
        {
            //RemoveNodeByAttr(GetXmlFileName(subj_id), "lecture/students/student[@id=\""+neptunCode+"\"]");
            try
            {
                RemoveNodeByAttr(GetXmlFileName(subjId), CreateXPathWithAttr("subject/students/student", "id", neptunCode));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool BlockStudent(string subjId, string neptunCode)
        {
            //TODO incomplete error handling! for example: student deregistered, but not added to blacklist!
            try
            {
                DeRegister(subjId, neptunCode);
                AppendEmptyNodeWithAttr(GetXmlFileName(subjId), "subject/blacklist", "student", "id", neptunCode);
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
            return "Subjects/" + id + ".xml";
        }
        #endregion

    }
}