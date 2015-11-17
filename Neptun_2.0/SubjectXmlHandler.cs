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

            //find and delete

            DeRegister(subjId, neptunCode);
            AppendEmptyNodeWithAttr("Lectures/" + subjId + ".xml", "lecture/blacklist", "student", "id", neptunCode);

            //xmlReader.Dispose();
            return true;
        }

        public List<string> GetStudentIds(string subjId)
        {
            List<string> ids = new List<string>();



            return ids;
        }

        public void DeRegister(string subj_id, string neptunCode)
        {
            //iterate while attr = neptuncode

            RemoveNodeByAttr("Lectures/"+subj_id+".xml", "lecture/students/student[@id=\""+neptunCode+"\"]");
        }
    }
}
