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

        public Registry(List<Admin> _admins, List<Student> _students, List<Teacher> _teachers, List<Subject> _subjects,
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

        public void AddAdmin(Admin _new)
        {
            admins.Add(_new);
        }

        public void RemoveAdmin(String id)
        {
            for(int i = 0; i < admins.Count; i++)
            {
                if (admins[i].getNeptunCode() == id)
                {
                    admins.RemoveAt(i);
                }
            }
        }

        public void AddStudent(Student _new)
        {
            students.Add(_new);
        }

        public void RemoveStudent(String id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].getNeptunCode() == id)
                {
                    students.RemoveAt(i);
                }
            }
        }

        public void AddTeacher(Teacher _new)
        {
            teachers.Add(_new);
        }

        public void RemoveTeacher(String id)
        {
            for (int i = 0; i < teachers.Count; i++)
            {
                if (teachers[i].getNeptunCode() == id)
                {
                    teachers.RemoveAt(i);
                }
            }
        }

        public void AddSubject(Subject _new)
        {
            subjects.Add(_new);
        }

        public void RemoveSubject(String id)
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                if (subjects[i].getId() == id)
                {
                    subjects.RemoveAt(i);
                }
            }
        }

        public void AddDemand(Demand _new)
        {
            demands.Add(_new);
        }

        public void RemoveDemand(String id)
        {
            for (int i = 0; i < demands.Count; i++)
            {
                if (demands[i].getDemandId() == id)
                {
                    demands.RemoveAt(i);
                }
            }
        }

        public void AddRequest(Request _new)
        {
            requests.Add(_new);
        }

        public void RemoveRequest(String id)
        {
            for (int i = 0; i < requests.Count; i++)
            {
                if (requests[i].getId() == id)
                {
                    requests.RemoveAt(i);
                }
            }
        }

        public void AddClassRoom(ClassRoom _new)
        {
            classRooms.Add(_new);
        }

        public void RemoveClassRoom(String id)
        {
            for (int i = 0; i < classRooms.Count; i++)
            {
                if (classRooms[i].getId() == id)
                {
                    classRooms.RemoveAt(i);
                }
            }
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
