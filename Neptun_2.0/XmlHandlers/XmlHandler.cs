using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

//created by Kristóf Weisz - UKDUJP
namespace Neptun_XML
{
    class XmlHandler
    {
        #region getters
        protected string GetValue(ref XmlReader xmlReader, string node)
        {
            string str;
            try
            {
                xmlReader.ReadToFollowing(node);
                str = xmlReader.ReadElementContentAsString();
            }
            catch (Exception)
            {
                throw;
            }

            return str;
        }

        protected List<string> GetList(ref XmlReader xmlReader, string parentNode, string attr)
        {
            List<string> list = new List<string>();
            try
            {
                xmlReader.ReadToFollowing(parentNode);
                while (xmlReader.Read() && xmlReader.Name != parentNode && xmlReader.IsStartElement()) //+HasValue?
                {
                    if (xmlReader.IsStartElement()) //unnecessary?
                    {
                        string str = "";
                        str = xmlReader.GetAttribute(attr);
                        list.Add(str);
                    }
                }
            }
            catch (Exception)
            {
                throw;
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

        //TODO  recover after exception??
        #region setters
        protected void SetAttribute(string filepath, string xpath, int idx, string value)
        {
            //sets value as the [idx] attribute of the given xpath
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);
                XmlNode node = doc.SelectSingleNode(xpath);
                node.Attributes[idx].Value = value;

                doc.Save(filepath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void SetValue(string filepath, string xpath, string value)
        {
            //sets value as the [idx] attribute of the given xpath

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);
                XmlNode node = doc.SelectSingleNode(xpath);

                node.InnerText = value;

                doc.Save(filepath);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region append methods
        protected void AppendNode(string filepath, string xpath, string node_name, string node_value)
        {
            //append node with given value
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);
                XmlNode node = doc.SelectSingleNode(xpath);

                XmlElement elem = doc.CreateElement(node_name);
                elem.InnerText = node_name;

                node.AppendChild(elem);

                doc.Save(filepath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void AppendNode(string filepath, string xpath, string node_name, string node_value, string attr_name, string attr_value)
        {
            //append node with given value and attribute
            try
            {
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
            catch (Exception)
            {
                throw;
            }
        }

        protected void AppendEmptyNodeWithAttr(string filepath, string xpath, string node_name, string attr_name, string attr_value)
        {
            //append an empty child node with the given attribute

            try
            {
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
            catch (Exception)
            {

                throw;
            }
         
        }
        #endregion

        #region remove methods
        protected void RemoveNodeByAttr(string filepath, string xpath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);


                XmlNode parent = doc.SelectSingleNode(xpath).ParentNode;
                parent.RemoveChild(doc.SelectSingleNode(xpath));

                doc.Save(filepath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteContent(string directory)
        {
            //TODO test
            try
            {
                List<string> files = GetAllIds(directory);
                foreach (string file in files)
                {
                    File.Delete(directory + "/" + file + ".xml");
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region helper methods
        protected string CreateXPathWithAttr(string xpath, string attrName, string attrValue)
        {
            return xpath + "[@" + attrName + " =\"" + attrValue + "\"]";
        }
        #endregion

        // private string GetXmlFileName(string id) { }
    }
}