using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Neptun_2._0
{
    class RequestXmlHandler : XmlHandler
    {
        #region rework

        public Request GetRequest(string dir, string request_Id)
        {
            string requestId = "";
            string state = "";
            string ownerId = "";
            string subject = "";
            string text = "";

            XmlReader xmlReader = XmlReader.Create(dir + request_Id + ".xml");

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

            return new Request(requestId, state, ownerId, subject, text);
        }

        void Save(Request request)
        {

        }

        #endregion

        #region old_version
        #region getters
        
        public Request GetRequest(string request_Id)
        {
            string requestId = "";
            string state = "";
            string ownerId = "";
            string subject = "";
            string text = "";

            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(request_Id));


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

            return new Request(requestId,state, ownerId, subject, text);
        }
        
        #endregion

        #region functional methods
        
    public bool CreateRequest(Request request)
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "\t";

        using (XmlWriter writer = XmlWriter.Create(GetXmlFileName(request.id), settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("request");
            writer.WriteAttributeString("id", request.id);
            writer.WriteElementString("owner", request.owner);
            writer.WriteElementString("text", request.text);

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        return true;
    }

    public bool JudgeRequest(string requestId, bool judge)
    {
        //TODO implement
        string judgestr;
        if(judge)
        {
            judgestr = "accepted";
        }
        else
        {
            judgestr = "declined";
        }

        SetAttribute(GetXmlFileName(requestId), "/request/state", 0, judgestr);

        return true;
    }
    
        #endregion

        #region help method
        
    private string GetXmlFileName(string requestId)
    {
        return "Requests/" + requestId + ".xml";
    }
    
        #endregion
        #endregion
    }
}
