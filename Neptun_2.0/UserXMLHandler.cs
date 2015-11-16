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
        public User getUser(string neptunCode)
        {
            XmlReader xmlReader = XmlReader.Create("Users/" + neptunCode + ".xml");
            //TODO .Create() exception handling + try catch

            string id = "";
            string name = "";
            string type = "";
            List<short_subject> subjects = new List<short_subject>();
            
            try
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        type = GetValue(ref xmlReader, "type");

                        subjects = getSubjects(neptunCode);
                    }
                }
            }
            catch(Exception e)
            {
                //TODO e
            }
            
            return new User(id, name, type, subjects);
        }

        public bool checkLogin(string neptunCode, string password)
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

        public List<short_subject> getSubjects(string neptunCode)
        {
            //TODO try catch
            List<short_subject> subjects = new List<short_subject>();
            XmlReader xmlReader = XmlReader.Create("Users/" + neptunCode + ".xml");

            xmlReader.ReadToFollowing("lectures");
            int cnt = Int32.Parse(xmlReader.GetAttribute("count")); //needed?

            while (xmlReader.Read() && xmlReader.Name!="lectures")
            {
                if (xmlReader.IsStartElement())
                {
                    short_subject subj = new short_subject();
                    subj.id = xmlReader.GetAttribute("id");
                    xmlReader.Read();
                    subj.name = xmlReader.Value;

                    Console.WriteLine(subj.id + " - " + subj.name);

                    subjects.Add(subj); 
                }

                //xmlReader.Read();
            }

            return subjects;
        }
    }
}
