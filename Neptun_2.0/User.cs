using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class User
    {
        private String neptunCode;
        private String name;
        private String type;
        public List<string> subjects;

        public User(String neptunCode, String name, String type, List<string> subjects)
        {
            this.neptunCode = neptunCode;
            this.name = name;
            this.type = type;
            this.subjects = subjects;
        }

        public String getNeptunCode()
        {
            return neptunCode;
        }

        public String getName()
        {
            return name;
        }

        public String getType()
        {
            return type;
        }

        public List<string> getSubjects()
        {
            return subjects;
        }
    }

    class Subject
    {
        private String id;
        private String name;
        private String teacher;
        private String day;
        private String startTime;
        private String endTime;

        private List<String> students;

        private List<String> blacklist;


        public Subject(string id, string name, string teacher, string day, string startTime, string endTime, List<string> students, List<string> blacklist)
        {
            this.id = id;
            this.name = name;
            this.teacher = teacher;
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
            return id;
        }

        public String getEndTime()
        {
            return id;
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

    class ClassRoom
    {
        private String id;
        private int limit;
        private List<string> subjectIds;

        public ClassRoom(String id, int limit, List<string> subjectIds)
        {
            this.id = id;
            this.limit = limit;
            this.subjectIds = subjectIds;
        }
    }
}
