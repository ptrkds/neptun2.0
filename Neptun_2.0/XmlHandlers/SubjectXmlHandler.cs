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
        #region getters
        public string GetSubjectName(string subjId)
         {
             string name = "";

             XmlReader xmlReader = XmlReader.Create("Lectures/" + subjId + ".xml");
             name = GetValue(ref xmlReader, "name");

             xmlReader.Dispose();
             return name;
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

         public Subject GetSubject(string subjId)
         {
             XmlReader xmlReader = XmlReader.Create(GetXmlFileName(subjId));
             xmlReader.Read();
             xmlReader.Read();

             string id = "";
             string name = "";
             string teacher = "";
             string day = "";
             string startTime = "";
             string endTime = "";
             List<string> studentIds = new List<string>();
             List<string> blockedStudentIds = new List<string>();

             try
             {
                 while (xmlReader.Read()) //loop needed?
                 {
                     if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "lecture") && (xmlReader.GetAttribute("id") == subjId))
                     {
                         id = xmlReader.GetAttribute("id");
                         name = GetValue(ref xmlReader, "name");
                         teacher = GetValue(ref xmlReader, "teacher");
                         day = GetValue(ref xmlReader, "day");
                         startTime = GetValue(ref xmlReader, "startTime");
                         endTime = GetValue(ref xmlReader, "endTime");

                         studentIds = GetList(ref xmlReader, "students", "id");

                         blockedStudentIds = GetList(ref xmlReader, "blacklist", "id");
                     }
                 }
             }
             catch (Exception e)
             {
                 //TODO e
             }

             return new Subject(id, name, teacher, day, startTime, endTime, studentIds, blockedStudentIds);
         }
        #endregion

        #region functional methods
        
                //TODO register()

                public bool DeRegister(string subjId, string neptunCode)
                {
                    //RemoveNodeByAttr(GetXmlFileName(subj_id), "lecture/students/student[@id=\""+neptunCode+"\"]");
                    RemoveNodeByAttr(GetXmlFileName(subjId), CreateXPathWithAttr("lecture/students/student", "id", neptunCode));
                    return true;
                }

                public bool BlockStudent(string subjId, string neptunCode)
                {
                    //TODO isValid() in user
                    // isOnSubj()

                    DeRegister(subjId, neptunCode);
                    AppendEmptyNodeWithAttr(GetXmlFileName(subjId), "lecture/blacklist", "student", "id", neptunCode);

                    return true;
                }
        #endregion

        #region helper methods
        
    private string GetXmlFileName(string id)
    {
        return "Lectures/" + id + ".xml";
    }
        #endregion
      
    }
}
