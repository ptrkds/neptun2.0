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
            List<short_subject> lectures = new List<short_subject>();
            
            try
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        type = GetValue(ref xmlReader, "type");

                        xmlReader.ReadToFollowing("lectures");
                        int cnt = Int32.Parse(xmlReader.GetAttribute("count"));
                        
                        while (xmlReader.Read() && xmlReader.IsStartElement())
                        {
                            short_subject subj = new short_subject();
                            subj.id = xmlReader.GetAttribute("id");
                            subj.name = xmlReader.Value;
                            lectures.Add(subj);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                //TODO e
            }
            
            return new User(id, name, type, lectures);
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

        public 
    }
}
