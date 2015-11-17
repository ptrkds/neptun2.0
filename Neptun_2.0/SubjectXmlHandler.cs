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
        public string GetSubjectName(string id)
        {
            string name = "";

            XmlReader xmlReader = XmlReader.Create("Lectures/" + id + ".xml");
            name = GetValue(ref xmlReader, "name");
            xmlReader.Dispose();

            return name;
        }

        public bool BlockStudent(string id, string neptunCode)
        {
            //TODO isValid() in user
            // isOnSubj()

            //find and delete

            AppendEmptyNodeWithAttr("Lectures/" + id + ".xml", "lecture/blacklist", "student", "id", neptunCode);

            //xmlReader.Dispose();
            return true;
        }
    }
}
