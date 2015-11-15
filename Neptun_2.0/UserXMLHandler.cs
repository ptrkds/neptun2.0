using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class UserXMLHandler : XmlHandler
    {
       

        public void getUser(string neptunCode)
        {
            User tmp = new User();
            XmlReader xmlReader = XmlReader.Create("Users/" + neptunCode + ".xml");
            //using ()
            //{
            //xmlReader.ReadToFollowing("pw");
            //Console.WriteLine(xmlReader.Name + xmlReader.ReadElementContentAsString());

            //reader.ReadElementContentAsString();

            //reader.ReadElementString("id");


            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                {
                    // if (xmlReader.HasAttributes)
                    //   Console.WriteLine("-" + xmlReader.GetAttribute("id"));
                    //Console.WriteLine(xmlReader.Name + xmlReader.NodeType);
                    tmp.name = GetValue(ref xmlReader, "name");
                    /*xmlReader.ReadToFollowing("name");
                    tmp.name = xmlReader.ReadElementContentAsString();
                    Console.WriteLine("-" + tmp.name);*/
                    //Console.WriteLine(xmlReader.Name + xmlReader.NodeType);

                    tmp.type = GetValue(ref xmlReader, "type");

                    //xmlReader.ReadToFollowing("type");
                    //Console.WriteLine(xmlReader.Name + xmlReader.NodeType);
                    //tmp.type = xmlReader.ReadElementContentAsString();
                    // Console.WriteLine(tmp.type);
                    //Console.WriteLine(xmlReader.Name + xmlReader.NodeType);

                    Console.WriteLine(tmp.name + " "+ tmp.type);
                }
            }


            Console.ReadLine();
            //}

            // return tmp;
            xmlReader.Dispose();
        }

        public bool checkLogin(string neptunCode, string password)
        {
            XmlReader xmlReader;
            try
            {
                xmlReader = XmlReader.Create("Users/" + neptunCode + ".xml");
                //check header
                string yep = GetValue(ref xmlReader, "pw");
                xmlReader.Dispose();
                if (yep == password )
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
                //open error
            }
            
            //??
            return false;
                  
        }
    }
}
