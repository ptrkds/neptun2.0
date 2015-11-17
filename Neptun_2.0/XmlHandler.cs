using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Neptun_2._0
{
    class XmlHandler
    {
        protected string CreateXPathWithAttr(string xpath, string attrName, string attrValue)
        {
            return xpath + "[@" + attrName + " =\"" + attrValue + "\"]";
        }

        public static string GetValue(ref XmlReader xmlReader, string node)
        {
            //TODO try catch
            string str;

            xmlReader.ReadToFollowing(node);
            str = xmlReader.ReadElementContentAsString();
            
            return str;
        }

        public void SetAttribute(string filepath, string xpath, int idx, string value)
        {
            //TODO try catch
            //sets value as the [idx] attribute of the given xpath
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNode node = doc.SelectSingleNode(xpath);
            Console.WriteLine(node.Name);

            node.Attributes[idx].Value = value;

            doc.Save(filepath);
        }

        public void AppendNode(string filepath, string xpath, string node_name, string node_value)
        {
            //TODO try catch
            //append node with given value
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNode node = doc.SelectSingleNode(xpath);

            XmlElement elem = doc.CreateElement(node_name);
            elem.InnerText = node_name;

            node.AppendChild(elem);

            doc.Save(filepath);
        }

        public void AppendNode(string filepath, string xpath, string node_name, string node_value, string attr_name, string attr_value)
        {
            //TODO try catch
            //append node with given value and attribute
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNode node = doc.SelectSingleNode(xpath);

            XmlElement elem = doc.CreateElement(node_name);
            elem.InnerText = attr_value;
            elem.IsEmpty = true;

            elem.SetAttribute(attr_name, attr_value);
            node.AppendChild(elem);

            doc.Save(filepath);
        }

        public void AppendEmptyNodeWithAttr(string filepath, string xpath, string node_name, string attr_name, string attr_value)
        {
            //TODO try catch
            //append an empty child node with the given attribute
            XmlDocument doc = new XmlDocument();

            doc.Load(filepath);
            XmlNode node = doc.SelectSingleNode(xpath);

            XmlElement elem = doc.CreateElement(node_name);
            elem.InnerText = attr_value;
            elem.IsEmpty = true;

            elem.SetAttribute(attr_name, attr_value);
            node.AppendChild(elem);

            doc.Save(filepath);
        }

        public void RemoveNodeByAttr(string filepath, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);


            XmlNode parent = doc.SelectSingleNode(xpath).ParentNode;
            parent.RemoveChild(doc.SelectSingleNode(xpath));
            
            doc.Save(filepath);
        }

        //private string GetXmlFileName() abstract or virtual implementation

        public List<string> GetList(ref XmlReader xmlReader, string node, string attr)
        {
            List<string> list = new List<string>();
            xmlReader.ReadToFollowing(node);
            while (xmlReader.Read() && xmlReader.Name != node && xmlReader.HasValue) //HasValue
            {
                if (xmlReader.IsStartElement())
                {
                    string str = "";
                    str = xmlReader.GetAttribute(attr);

                    //Console.WriteLine(subj.id + " - " + subj.name);

                    list.Add(str);
                }

                //xmlReader.Read();
            }

            return list;
        }

        #region left over code
        internal void Start()
        {
            using (XmlReader xmlReader = XmlReader.Create("UserXML.xml"))
            {
                /*reader.ReadToFollowing("id");
                Console.WriteLine(reader.Value.Trim());*/

                //reader.ReadElementContentAsString();

                //reader.ReadElementString("id");


                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == "BATMAN"))
                    {
                        if (xmlReader.HasAttributes)
                            Console.WriteLine("-" + xmlReader.GetAttribute("id"));
                    }
                }

                /*
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "users":
                                // Detect this element.
                                Console.WriteLine("Start <users> element.");
                                break;
                            case "user":
                                // Detect this article element.
                                Console.WriteLine("Start <user> element.");
                                // Search for the attribute name on this current node.
                                string attribute = reader["name"];
                                if (attribute != null)
                                {
                                    Console.WriteLine("  Has attribute name: " + attribute);
                                }
                                // Next read will contain text.
                                if (reader.Read())
                                {
                                    Console.WriteLine("  Text node: " + reader.Value.Trim());
                                }
                                break;
                            case "name":
                                Console.WriteLine("Start <name> element.");
                                if (reader.Read())
                                {
                                    Console.WriteLine("  Text node: " + reader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }*/
                Console.ReadLine();
            }
        }
        #endregion
    }
}
