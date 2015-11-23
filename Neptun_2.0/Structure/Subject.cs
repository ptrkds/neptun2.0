using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Subject
    {
        private String id;
        private String name;
        private String teacher;
        private String classRoom;
        private String day;
        private String startTime;
        private String endTime;

        private List<String> students;

        private List<String> blacklist;


        public Subject(string id, string name, string teacher, string classRoom, string day, string startTime, string endTime, List<string> students, List<string> blacklist)
        {
            this.id = id;
            this.name = name;
            this.teacher = teacher;
            this.classRoom = classRoom;
            this.day = day;
            this.startTime = startTime;
            this.endTime = endTime;
            this.students = students;
            this.blacklist = blacklist;
        }

        public String getId()
        {
            return id;
        }

        public void setId(String _id)
        {
            id = _id;
        }

        public String getClassRoom()
        {
            return classRoom;
        }

        public void setClassRoom(string _classRoom)
        {
            classRoom = _classRoom;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String  _name)
        {
            name = _name;
        }

        public String getTeacher()
        {
            return teacher;
        }

        public void setTeacher(String _teacher)
        {
            teacher = _teacher;
        }

        public String getDay()
        {
            return day;
        }

        public void setDay(String _day)
        {
            day = _day;
        }

        public String getStartTime()
        {
            return startTime;
        }

        public void setStartTime(String _startTime)
        {
            startTime = _startTime;
        }

        public String getEndTime()
        {
            return id;
        }

        public void setEndTime(String _endTime)
        {
            endTime = _endTime;
        }

        public List<String> getStudents()
        {
            return students;
        }

        public void setStudents(List<String> _students)
        {
            students = _students;
        }

        public List<String> getBlacklist()
        {
            return blacklist;
        }

        public void setBlacklist(List<String> _blacklist)
        {
            blacklist = _blacklist;
        }
    }
}
