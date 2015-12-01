using System;

namespace Neptun_Structure
{
    class Demand : Document
    {
        private string roomId;
        private string subjectId;
        private string subjectName;
        private string day;
        private string startTime;
        private string endTime;

        public Demand(string demandId, string state, string teacherId, string roomId, string subjectId, string subjectName, string day, string startTime, string endTime)
         :base(demandId, state, teacherId){
            this.roomId = roomId;
            this.subjectId = subjectId;
            this.subjectName = subjectName;
            this.day = day;
            this.startTime = startTime;
            this.endTime = endTime;
        }

       
        public String getSubjectId()
        {
            return subjectId;
        }
        public String getRoomId()
        {
            return roomId;
        }
        public String getStartTime()
        {
            return startTime;
        }
        public String getEndTime()
        {
            return endTime;
        }
        public String getDay()
        {
            return day;
        }
        public String getSubjectName()
        {
            return subjectName;
        }

       

        public void setSubjectId(String _subjectId)
        {
            subjectId = _subjectId;
        }

        public void setRoomId(String _roomId)
        {
            roomId = _roomId;
        }

        public void setDay(String _day)
        {
            day = _day;
        }

        public void setEndTime(String _endTime)
        {
            endTime = _endTime;
        }

        public void setStartTime(String _startTime)
        {
            startTime = _startTime;
        }
    }

}
