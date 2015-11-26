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
            xmlReader.Dispose();
            return new Request(requestId, state, ownerId, subject, text);
        }

       /* public Request GetRequest(string request_Id)
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
        }*/
        
        #endregion

        #region functional methods
        
    public bool CreateRequest(Request request)
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "\t";

        using (XmlWriter writer = XmlWriter.Create(GetXmlFileName(request.getId()), settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("request");
            writer.WriteAttributeString("id", request.getId());
            writer.WriteElementString("owner", request.getOwner());
            writer.WriteElementString("text", request.getText());

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

        SetValue(GetXmlFileName(requestId), "/request/state", judgestr);

        return true;
    }
    
        #endregion

        #region help method
        
    private string GetXmlFileName(string requestId)
    {
        return "Requests/" + requestId + ".xml";
    }
    
        #endregion
       
    }
}
