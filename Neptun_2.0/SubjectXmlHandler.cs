using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Neptun_2._0
{
    class SubjectXmlHandler : XmlHandler
    {
        public string GetSubjectName(string subjId)
        {
            string name = "";

            XmlReader xmlReader = XmlReader.Create("Lectures/" + subjId + ".xml");
            name = GetValue(ref xmlReader, "name");

            xmlReader.Dispose();
            return name;
        }

        public bool BlockStudent(string subjId, string neptunCode)
        {
            //TODO isValid() in user
            // isOnSubj()

            DeRegister(subjId, neptunCode);
            AppendEmptyNodeWithAttr(GetXmlFileName(subjId), "lecture/blacklist", "student", "id", neptunCode);

            //xmlReader.Dispose();
            return true;
        }

        public List<string> GetStudentIds(string subjId)
        {
            List<string> ids = new List<string>();


            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(subjId));
            ids = GetList(ref xmlReader, "students", "id");

            xmlReader.Dispose();
            return ids;
        }

        public List<string> GetBlockedStudentIds(string subjId)
        {
            List<string> ids = new List<string>();

            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(subjId));
            ids = GetList(ref xmlReader, "blacklist", "id");

            xmlReader.Dispose();
            return ids;
        }

        public bool Register(string subjId, string neptunCode)
        {

            return true;
        }

        public bool DeRegister(string subjId, string neptunCode)
        {

            //RemoveNodeByAttr(GetXmlFileName(subj_id), "lecture/students/student[@id=\""+neptunCode+"\"]");
            RemoveNodeByAttr(GetXmlFileName(subjId), CreateXPathWithAttr("lecture/students/student", "id", neptunCode));
            return true;
        }

        private string GetXmlFileName(string id)
        {
            return "Lectures/" + id + ".xml";
        }

        
    }
}
