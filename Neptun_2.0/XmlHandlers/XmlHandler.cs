using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Neptun_2._0
{
    class XmlHandler
    { 
        #region getters
        protected string GetValue(ref XmlReader xmlReader, string node)
        {
            //TODO try catch
            string str;

            xmlReader.ReadToFollowing(node);
            str = xmlReader.ReadElementContentAsString();
            
            return str;
        }

        protected List<string> GetList(ref XmlReader xmlReader, string parentNode, string attr)
        {
            List<string> list = new List<string>();
            xmlReader.ReadToFollowing(parentNode);
            while (xmlReader.Read() && xmlReader.Name != parentNode && xmlReader.IsStartElement()) //HasValue
            {
                if (xmlReader.IsStartElement()) //unnecessary
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

        public List<string> GetAllIds(string directory)
        {
            //string[] pdfFiles = Directory.GetFiles(directory, "*.xml").Select(path => Path.GetFileName(path)).ToArray();

            string[] pdfFiles = Directory.GetFiles(directory, "*.xml").Select(path => Path.GetFileName(path)).ToArray(); //doesnt excludes ".xml".... -.-"
            List<string> pdfFileNames = new List<string>();
            foreach (string str in pdfFiles)
            {
                pdfFileNames.Add(str.Remove(str.Length - 4)); //TODO better way?
            }

            return pdfFileNames;
        }
        #endregion

        #region setters
        protected void SetAttribute(string filepath, string xpath, int idx, string value)
        {
            //TODO try catch

            //sets value as the [idx] attribute of the given xpath
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNode node = doc.SelectSingleNode(xpath);
            //Console.WriteLine(node.Name);
            
            node.Attributes[idx].Value = value;
            
            doc.Save(filepath);
        }

        protected void SetValue(string filepath, string xpath, string value)
        {
            //TODO try catch
            //sets value as the [idx] attribute of the given xpath
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNode node = doc.SelectSingleNode(xpath);

            node.InnerText = value;

            doc.Save(filepath);
        }
        #endregion

        #region append methods
        protected void AppendNode(string filepath, string xpath, string node_name, string node_value)
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

        protected void AppendNode(string filepath, string xpath, string node_name, string node_value, string attr_name, string attr_value)
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

        protected void AppendEmptyNodeWithAttr(string filepath, string xpath, string node_name, string attr_name, string attr_value)
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
        #endregion

        #region remove methods
        protected void RemoveNodeByAttr(string filepath, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);


            XmlNode parent = doc.SelectSingleNode(xpath).ParentNode;
            parent.RemoveChild(doc.SelectSingleNode(xpath));
            
            doc.Save(filepath);
        }

        //MAINTENACNE diák deregister, tárgyak törlése
        #endregion

        #region helper methods
        //private string GetXmlFileName() { } //abstract or virtual implementation
        protected string CreateXPathWithAttr(string xpath, string attrName, string attrValue)
        {
            return xpath + "[@" + attrName + " =\"" + attrValue + "\"]";
        }
        #endregion

       // private string GetXmlFileName(string id) { }

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
