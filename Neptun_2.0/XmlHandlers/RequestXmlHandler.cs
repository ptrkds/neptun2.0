using System;
using System.Xml;
using Neptun_Structure;

//created by Kristóf Weisz - UKDUJP
namespace Neptun_XML
{
    class RequestXmlHandler : XmlHandler
    {
        #region getters

        public Request GetRequest(string request_Id)
        {
            string requestId = "";
            string state = "";
            string ownerId = "";
            string subject = "";
            string text = "";

            XmlReader xmlReader = null;

            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(request_Id));

                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "request") && (xmlReader.GetAttribute("id") == request_Id))
                    {
                        requestId = xmlReader.GetAttribute("id");
                        state = GetValue(ref xmlReader, "state");
                        ownerId = GetValue(ref xmlReader, "owner");
                        subject = GetValue(ref xmlReader, "subject");
                        text = GetValue(ref xmlReader, "text");
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Dispose();
                }
            }

            return new Request(requestId, state, ownerId, subject, text);
        }
        #endregion

        #region functional methods

        public bool CreateRequest(Request request)
        {
            //TODO try catch
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create(GetXmlFileName(request.getId()), settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("request");
                writer.WriteAttributeString("id", request.getId());
                writer.WriteElementString("state", request.getState());
                writer.WriteElementString("owner", request.getOwner());
                writer.WriteElementString("subject", request.getSubject());
                writer.WriteElementString("text", request.getText());

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return true;
        }

        public bool JudgeRequest(string requestId, bool judge)
        {
            string judgestr;
            if (judge)
            {
                judgestr = "accepted";
            }
            else
            {
                judgestr = "declined";
            }

            try
            {
                SetValue(GetXmlFileName(requestId), "/request/state", judgestr);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region helper methods

        private string GetXmlFileName(string requestId)
        {
            return "Requests/" + requestId + ".xml";
        }

        #endregion

    }
}