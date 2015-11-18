using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Database
    {
        UserXmlHandler userHandler = new UserXmlHandler();
        SubjectXmlHandler subjectHandler = new SubjectXmlHandler();
        DemandXmlHandler demandHandler = new DemandXmlHandler();
        ClassRoomXmlHandler roomHandler = new ClassRoomXmlHandler();

        public bool checkLogin(string id, string pw)
        {
            return userHandler.CheckLogin(id, pw);
        }

        public User GetUser(string id)
        {
            return userHandler.GetUser(id);
        }


        public List<short_subject> getSubjects(string neptunCode)
        {
            List<string> ids = userHandler.GetSubjectIds(neptunCode);

            //get subjectnames
            List < short_subject > subj = new List<short_subject>();
            foreach (string id in ids)
            {
                short_subject ss = new short_subject();
                ss.id = id;
                ss.name = subjectHandler.GetSubjectName(id);
                subj.Add(ss);
            }

            return subj;
        }

        public List<short_user> getStudents(string subj_id)
        {
            List < short_user > students = new List<short_user>();

            List<string> ids = subjectHandler.GetStudentIds(subj_id);

            foreach (string id in ids)
            {
                short_user su = new short_user();
                su.id = id;
                su.name = userHandler.GetUserName(id);
                students.Add(su);
            }

            return students;
        }

        // TODO átírni azt, hogy mindkettő igaz legyen.
        public bool BlockStudent(string subj_id, string neptun_code)
        {
            bool ret;
            userHandler.DeRegister(neptun_code, subj_id);
            return subjectHandler.BlockStudent(subj_id, neptun_code);
        }

        public List<Subject> TimeTable(string neptun_code)
        {
            List<Subject> timeTable = new List<Subject>();

            List<String> subj_ids = userHandler.GetSubjectIds(neptun_code);

            foreach (string id in subj_ids)
            {
                timeTable.Add(subjectHandler.GetSubject(id));
            }

            return timeTable;
        }

        public List<Demand> getDemands(String neptun_code)
        {
            List<Demand> demands = new List<Demand>();

            List<String> ids = userHandler.GetDemandIds(neptun_code);

            foreach (string id in ids)
            {
                Demand newDemand = demandHandler.GetDemand(id);
                demands.Add(newDemand);
            }

            return demands;
        }

        public Demand getDemand(String demand_id)
        {
            return demandHandler.GetDemand(demand_id);
        }

        public bool demandChange(Demand newDemand)
        {
            return demandHandler.ChangeDemand(newDemand);
        }

        public List<Demand> getAllDemand()
        {
            String[] ids = demandHandler.GetAllIds("Demands/");

            List<Demand> demands = new List<Demand>();

            foreach (string id in ids)
            {
                Demand newDemand = demandHandler.GetDemand(id);
                demands.Add(newDemand);
            }

            return demands;
        }

        public bool demandJudgement(String demand_id, String neptun_code Boolean state)
        {
            Demand newDemand = demandHandler.GetDemand(demand_id);

            bool userNewDemand = userHandler.Register(neptun_code, newDemand.subjectId);


            bool newSubject = subjectHandler

        }

        public List<ClassRoom> getAllRoom()
        {
            List<ClassRoom> rooms = new List<ClassRoom>();

            String[] ids = demandHandler.GetAllIds("ClassRooms/");

            foreach (string id in ids)
            {
                ClassRoom newRoom = roomHandler.GetClassRoom(id);
                rooms.Add(newRoom);
            }

            return rooms;
        }

        public bool demandSubmission(Demand newDemand)
        {
            return demandHandler.CreateDemand(newDemand);
        }
    }
}