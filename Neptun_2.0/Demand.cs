using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    public class Demand
    {
        private string demandId;
        private string state;
        private string teacherId;
        private string roomId;
        private string subjectId;
        private string subjectName;
        private string day;
        private string startTime;
        private string endTime;

        public Demand(string demandId, string state, string teacherId, string roomId, string subjectId, string subjectName, string day, string startTime, string endTime)
        {
            this.demandId = demandId;
            this.state = state;
            this.teacherId = teacherId;
            this.roomId = roomId;
            this.subjectId = subjectId;
            this.subjectName = subjectName;
            this.day = day;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public String getDemandId()
        {
            return demandId;
        }

        public String getState()
        {
            return state;
        }

        public String getTeacherId()
        {
            return teacherId;
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

        public void setDemandId(String _demandId)
        {
            demandId = _demandId;
        }

        public void setState(String _state)
        {
            state = _state;
        }

        public void setTeacherId(String _teacherId)
        {
            teacherId = _teacherId;
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
