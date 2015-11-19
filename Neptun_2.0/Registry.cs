using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Registry
    {
        private List<Admin> admins;
        private List<Student> students;
        private List<Teacher> teachers;
        private List<Subject> subjects;
        private List<Demand> demands;
        private List<Request> requests;
        private List<ClassRoom> classRooms;

        Registry(List<Admin> _admins, List<Student> _students, List<Teacher> _teachers, List<Subject> _subjects,
            List<Demand> _demands, List<Request> _requests, List<ClassRoom> _classRooms)
        {
            this.admins = _admins;
            this.students = _students;
            this.teachers = _teachers;
            this.subjects = _subjects;
            this.demands = _demands;
            this.requests = _requests;
            this.classRooms = _classRooms;
        }

        public List<Admin> getAdmins()
        {
            return admins;
        }

        public List<Student> getStudents()
        {
            return students;
        }

        public List<Teacher> getTeachers()
        {
            return teachers;
        }

        public List<Subject> GetSubjects()
        {
            return subjects;
        }

        public List<Demand> getDemands()
        {
            return demands;
        }

        public List<Request> getRequest()
        {
            return requests;
        }

        public List<ClassRoom> getClassRooms()
        {
            return classRooms;
        }

        public void setAdmins(List<Admin> _admins)
        {
            admins = _admins;
        }

        public void setTeachers(List<Teacher> _teachers)
        {
            teachers = _teachers;
        }

        public void setStudents(List<Student> _students)
        {
            students = _students;
        }

        public void setSubjects(List<Subject> _subjects)
        {
            subjects = _subjects;
        }

        public void setDemands(List<Demand> _demands)
        {
            demands = _demands;
        }

        public void setRequests(List<Request> _requests)
        {
            requests = _requests;
        }

        public void setClassRooms(List<ClassRoom> _classRooms)
        {
            classRooms = _classRooms;
        }
    }
}
