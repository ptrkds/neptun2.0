using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class XMLLoader
    {
        /*
        UserXmlHandler userHandler;
        SubjectXmlHandler subjectHandler;
        ClassRoomXmlHandler roomHandler;
        RequestXmlHandler requestHandler;
        DemandXmlHandler demandHandler;
        string workDir;
        
        public XMLLoader(string workDir)
        {
            userHandler = new UserXmlHandler();
            subjectHandler = new SubjectXmlHandler();
            roomHandler = new ClassRoomXmlHandler();
            requestHandler = new RequestXmlHandler();
            demandHandler = new DemandXmlHandler();
            this.workDir = workDir;
        }
        
        Registry Load()
        {
            List<Student> students = new List<Student>();

            List<Teacher> teachers = new List<Teacher>();
            List<Admin> admins = new List<Admin>();
            List<ClassRoom> rooms = new List<ClassRoom>();
            List<Subject> subjects = new List<Subject>();
            List<Request> requests = new List<Request>();
            List<Demand> demands = new List<Demand>();


            return new Registry(admins, students, teachers, subjects, demands, requests, rooms);
        }

        List<Student> GetStudents(string dir)
        {
            List<Student> students = new List<Student>();
            List<string> studentIDs = userHandler.GetAllIds(workDir + "/Students/");
            foreach(string id in studentIDs)
            {
                students.Add(userHandler.GetStudent("", id));
            }

            return students;
        }*/
    }
}
