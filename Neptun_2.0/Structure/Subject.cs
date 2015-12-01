using System;
using System.Collections.Generic;

namespace Neptun_Structure
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
        public String getClassRoom()
        {
            return classRoom;
        }

        public String getName()
        {
            return name;
        }
        public String getTeacher()
        {
            return teacher;
        }
        public String getDay()
        {
            return day;
        }
        public String getStartTime()
        {
            return startTime;
        }
        public String getEndTime()
        {
            return endTime;
        }
        public List<String> getStudents()
        {
            return students;
        }
        public List<String> getBlacklist()
        {
            return blacklist;
        }
    }
}
