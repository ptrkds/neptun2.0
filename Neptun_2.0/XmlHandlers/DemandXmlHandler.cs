using System.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using Neptun_Structure;

namespace Neptun_XML
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

            XmlReader xmlReader = null;

            try
            {
                xmlReader = XmlReader.Create(GetXmlFileName(demand_Id));

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
            }
            catch (System.Exception)
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
            return new Demand(demandId, state, teacherId, roomId, subjectId, subjectName, day, startTime, endTime);
        }

        #endregion

        #region functional methods

        public bool CreateDemand(Demand demand)
        {
            //TODO try catch
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create(GetXmlFileName(demand.getId()), settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("demand");
                writer.WriteAttributeString("id", demand.getId());
                writer.WriteElementString("state", demand.getState());
                writer.WriteElementString("teacherId", demand.getOwner());
                writer.WriteElementString("roomId", demand.getRoomId());
                writer.WriteElementString("subjectId", demand.getSubjectId());
                writer.WriteElementString("subjectName", demand.getSubjectName());
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
            //TODO try catch
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

            try
            {
                SetValue(GetXmlFileName(demandId), "/demand/state", judgestr);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteSubjects()
        {
            //TODO test
            try
            {
                List<string> files = GetAllIds("Demands/");
                foreach (string file in files)
                {
                    File.Delete("Demands/" + file);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region helper method

        private string GetXmlFileName(string demandId)
        {
            return "Demands/" + demandId + ".xml";
        }

        #endregion
    }
}

//created by Kristóf Weisz - UKDUJP