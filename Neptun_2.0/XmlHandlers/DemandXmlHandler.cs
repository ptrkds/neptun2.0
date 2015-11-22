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
            string subjectName = "";
            string day = "";
            string startTime = "";
            string endTime = "";

            XmlReader xmlReader = XmlReader.Create(GetXmlFileName(demand_Id));


            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "demand") && (xmlReader.GetAttribute("id") == demand_Id))
                {
                    demandId = xmlReader.GetAttribute("id");
                    state = GetValue(ref xmlReader, "state");
                    teacherId = GetValue(ref xmlReader, "teacherId");
                    roomId = GetValue(ref xmlReader, "roomId");
                    subjectId = GetValue(ref xmlReader, "subjectId");
                    subjectName = GetValue(ref xmlReader, "subjectName");
                    day = GetValue(ref xmlReader, "day");
                    startTime = GetValue(ref xmlReader, "startTime");
                    endTime = GetValue(ref xmlReader, "endTime");
                }
            }

            return new Demand(demandId, state, teacherId, roomId, subjectId, subjectName, day, startTime, endTime);
        }
        
        #endregion

        #region functional methods
        
    public bool CreateDemand(Demand demand)
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "\t";

        using (XmlWriter writer = XmlWriter.Create(GetXmlFileName(demand.getDemandId()), settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("demand");
            writer.WriteAttributeString("id", demand.getDemandId());
            writer.WriteElementString("state", demand.getState());
            writer.WriteElementString("teacherId", demand.getTeacherId());
            writer.WriteElementString("roomId", demand.getRoomId());
            writer.WriteElementString("subjectId", demand.getSubjectId());
            writer.WriteElementString("subjectName", demand.getDemandId());
            writer.WriteElementString("day", demand.getDay());
            writer.WriteElementString("startTime", demand.getStartTime());
            writer.WriteElementString("endTime", demand.getEndTime());

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

    public bool JudgeDemand(string demandId, bool judge)
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

        SetValue(GetXmlFileName(demandId), "/demand/state", judgestr);

        return true;
    }
    
        #endregion

        #region helper method
        
    private string GetXmlFileName(string demandId)
    {
        return "Demands/" + demandId + ".xml";
    }

        #endregion



        /* public Demand GetDemand(string dir, string demand_Id)
       {
           string demandId = "";
           string state = "";
           string teacherId = "";
           string roomId = "";
           string subjectId = "";
           string subjectName = "";
           string day = "";
           string startTime = "";
           string endTime = "";

           XmlReader xmlReader = XmlReader.Create(dir + demandId + ".xml");


           while (xmlReader.Read())
           {
               if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "demand") && (xmlReader.GetAttribute("id") == demand_Id))
               {
                   demandId = xmlReader.GetAttribute("id");
                   state = GetValue(ref xmlReader, "state");
                   teacherId = GetValue(ref xmlReader, "teacherId");
                   roomId = GetValue(ref xmlReader, "roomId");
                   subjectId = GetValue(ref xmlReader, "subjectId");
                   subjectName = GetValue(ref xmlReader, "subjectName");
                   day = GetValue(ref xmlReader, "day");
                   startTime = GetValue(ref xmlReader, "startTime");
                   endTime = GetValue(ref xmlReader, "endTime");
               }
           }

           return new Demand(demandId, state, teacherId, roomId, subjectId, subjectName, day, startTime, endTime);
       }*/
    }
}
