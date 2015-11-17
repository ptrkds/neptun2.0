using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class UserXmlHandler : XmlHandler
    {
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
            
            try
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        type = GetValue(ref xmlReader, "type");

                        subjects = GetSubjectIds(neptunCode);
                    }
                }
            }
            catch(Exception e)
            {
                //TODO e
            }
            
            return new User(id, name, type, subjects);
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
                if (userpw == password )
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch(Exception e)
            {
                //TODO e
            }
            
            //TODO ??
            return false;
        }

        public List<string> GetSubjectIds(string neptunCode)
        {
            //TODO try catch
            List<string> subjects = new List<string>();
            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

            xmlReader.ReadToFollowing("lectures");
            int cnt = Int32.Parse(xmlReader.GetAttribute("count")); //unused variable

            /*
            while (xmlReader.Read() && xmlReader.Name!="lectures")
            {
                if (xmlReader.IsStartElement())
                {
                    string id = "";
                    id = xmlReader.GetAttribute("id");
                    
                    //Console.WriteLine(subj.id + " - " + subj.name);

                    subjects.Add(id); 
                }

                //xmlReader.Read();
            }*/

            subjects = GetList(ref xmlReader, "lectures", "id");

            return subjects;
        }

        //TODO implement
        public void deregister(string neptunCode, string subjId)
        {
            RemoveNodeByAttr(GetXmlFileName(neptunCode), "user/lectures/lecture[@id=\"" + subjId + "\"]");
        }

        //TODO implement
        bool IsValid()
        {
            return true;
        }

        public string GetUserName(string neptunCode)
        {
            string name = "";

            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));
            name = GetValue(ref xmlReader, "name");

            xmlReader.Dispose();
            return name;
        }

        private string GetXmlFileName(string id)
        {
            return "Users/" + id + ".xml";
        }

    }
}
