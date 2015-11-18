using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Neptun_2._0
{


    class DemandXmlHandler : XmlHandler
    {
        #region getters

        public Demand GetDemand(string demand_Id)
        {
            string demandId = "";
            string state = "";
            string teacherId = "";
            string roomId = "";
            string subjectId = "";
            string startTime = "";
            string endTime = "";
            string comment = "";

            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(demand_Id));


            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "demand") && (xmlReader.GetAttribute("id") == demand_Id))
                {
                    demandId = xmlReader.GetAttribute("id");
                    teacherId = GetValue(ref xmlReader, "teacherId");
                    state = GetValue(ref xmlReader, "state");
                    roomId = GetValue(ref xmlReader, "roomId");
                    subjectId = GetValue(ref xmlReader, "subjectId");
                    startTime = GetValue(ref xmlReader, "startTime");
                    endTime = GetValue(ref xmlReader, "endTime");
                    comment = GetValue(ref xmlReader, "comment");
                }
            }


            return new Demand(demandId, state, teacherId, roomId, subjectId, startTime, endTime, comment);
        }

        #endregion

        //TODO implement
        public bool CreateDemand(Demand demand)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create(GetXmlFileName(demand.demandId), settings))
            {

                writer.WriteStartDocument();
                writer.WriteStartElement("demand");
                writer.WriteAttributeString("id", demand.demandId);

                writer.WriteElementString("teacherId", demand.teacherId);
                writer.WriteElementString("state", demand.state);
                writer.WriteElementString("roomId", demand.roomId);
                writer.WriteElementString("subjectId", demand.subjectId);
                writer.WriteElementString("startTime", demand.startTime);
                writer.WriteElementString("endTime", demand.endTime);
                writer.WriteElementString("comment", demand.comment);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }


            return true;
        }

        public bool ChangeDemand(Demand newDemand)
        {
            CreateDemand(newDemand);

            return true;
        }

        private string GetXmlFileName(string demandId)
        {
            return "Demands/" + demandId + ".xml";
        }


    }

    public class Demand
    {
        public string demandId;
        public string state;
        public string teacherId;
        public string roomId;
        public string subjectId;
        public string startTime;
        public string endTime;
        public string comment;

        public Demand(string demandId, string state, string teacherId, string roomId, string subjectId, string startTime, string endTime, string comment)
        {
            this.demandId = demandId;
            this.state = state;
            this.teacherId = teacherId;
            this.roomId = roomId;
            this.subjectId = subjectId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.comment = comment;
        }
    }
}
