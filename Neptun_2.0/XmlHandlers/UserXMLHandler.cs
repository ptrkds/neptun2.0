﻿using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class UserXmlHandler : XmlHandler
    {
        #region getters
        public string GetUserName(string neptunCode)
        {
            string name = "";

            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));
            name = GetValue(ref xmlReader, "name");

            xmlReader.Dispose();
            return name;
        }

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
            List<string> documents = new List<string>();

            try
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "user") && (xmlReader.GetAttribute("id") == neptunCode))
                    {
                        id = xmlReader.GetAttribute("id");
                        name = GetValue(ref xmlReader, "name");
                        type = GetValue(ref xmlReader, "type");

                        subjects = GetList(ref xmlReader, "subjects", "id");
                        subjects = GetList(ref xmlReader, "documents", "id");
                    }
                }
            }
            catch(Exception e)
            {
                //TODO e
            }
            
            return new User(id, name, type, subjects, documents);
        }

        public List<string> GetSubjectIds(string neptunCode)
        {
            //TODO try catch
            List<string> subjects = new List<string>();
            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

            subjects = GetList(ref xmlReader, "lectures", "id");

            return subjects;
        }

        public List<string> GetDemandIds(string neptunCode)
        {
            //TODO try catch
            List<string> demands = new List<string>();
            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(neptunCode));

            demands = GetList(ref xmlReader, "demands", "id");

            return demands;
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
                if (userpw == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                //TODO e
            }

            //TODO ??
            return false;
        }
        #endregion

        #region functional methods
        //TODO implement
        public bool Register(string neptunCode, string subjId)
        {
            //AppendEmptyNodeWithAttr(GetXmlFileName(neptunCode), )
            return true;
        }

        public void DeRegister(string neptunCode, string subjId)
        {
            RemoveNodeByAttr(GetXmlFileName(neptunCode), "user/lectures/lecture[@id=\"" + subjId + "\"]");
        }
        #endregion

        #region helper methods
        //TODO implement
        bool IsValid()
        {
            return true;
        }

        private string GetXmlFileName(string id)
        {
            return "Users/" + id + ".xml";
        }
        #endregion
    }
}