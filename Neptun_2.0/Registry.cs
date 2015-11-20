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

        public Registry(List<Admin> _admins , List<Student> _students, List<Teacher> _teachers, List<Subject> _subjects,
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

        public Registry()
        {
            admins = new List<Admin>();
            students = new List<Student>();
            teachers = new List<Teacher>();
            subjects = new List<Subject>();
            demands = new List<Demand>();
            requests = new List<Request>();
            classRooms = new List<ClassRoom>();
        }

        public void AddAdmin(Admin _new)
        {
            admins.Add(_new);
        }

        public bool ContainsAdmin(String id)
        {
            return admins.Contains(getAdmin(id));
        }

        public bool ContainsStudent(String id)
        {
            return students.Contains(getStudent(id));
        }

        public bool ContainsTeacher(String id)
        {
            return teachers.Contains(getTeacher(id));
        }

        public bool ContainsSubject(String id)
        {
            return subjects.Contains(getSubject(id));
        }

        public bool ContainsRequest(String id)
        {
            return requests.Contains(getRequest(id));
        }

        public bool ContainsDemand(String id)
        {
            return demands.Contains(getDemand(id));
        }

        public bool ContainsClassRoom(String id)
        {
            return classRooms.Contains(getClassRoom(id));
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

        public Admin getAdmin(String id)
        {
            foreach (Admin admin in admins)
            {
                if (admin.getNeptunCode() == id)
                {
                    return admin;
                }
            }
            return null;
        }

        public List<Student> getStudents()
        {
            return students;
        }

        public Student getStudent(String id)
        {
            foreach (Student student in students)
            {
                if (student.getNeptunCode() == id)
                {
                    return student;
                }
            }
            return null;
        }

        public Teacher getTeacher(String id)
        {
            foreach (Teacher teacher in teachers)
            {
                if (teacher.getNeptunCode() == id)
                {
                    return teacher;
                }
            }
            return null;
        }

        public List<Teacher> getTeachers()
        {
            return teachers;
        }

        public Subject getSubject(String id)
        {
            foreach (Subject subject in subjects)
            {
                if (subject.getId() == id)
                {
                    return subject;
                }
            }
            return null;
        }

        public List<Subject> getSubjects()
        {
            return subjects;
        }

        public Demand getDemand(String id)
        {
            foreach (Demand demand in demands)
            {
                if (demand.getDemandId() == id)
                {
                    return demand;
                }
            }
            return null;
        }

        public List<Demand> getDemands()
        {
            return demands;
        }

        public Request getRequest(String id)
        {
            foreach (Request request in requests)
            {
                if (request.getId() == id)
                {
                    return request;
                }
            }
            return null;
        }

        public List<Request> getRequests()
        {
            return requests;
        }

        public ClassRoom getClassRoom(String id)
        {
            foreach (ClassRoom classRoom in classRooms)
            {
                if (classRoom.getId() == id)
                {
                    return classRoom;
                }
            }
            return null;
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