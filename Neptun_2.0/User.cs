﻿using System;
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
        public List<string> document; 

        public User(String neptunCode, String name, String type, List<string> subjects, List<string> document )
        {
            this.neptunCode = neptunCode;
            this.name = name;
            this.type = type;
            this.subjects = subjects;
            this.document = document;
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

        public List<string> getDocuments()
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
            return startTime;
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

    class Request
    {
        private String id;
        private String owner;
		private String subject;
        private String text;

        public Request(string id, string subject, string owner, string text)
        {
            this.id = id;
            this.owner = owner;
			this.subject = subject;
            this.text = text;
        }
    }
}
