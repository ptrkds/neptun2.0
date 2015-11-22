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
        RequestXmlHandler requestHandler = new RequestXmlHandler();

        public String checkLogin(string id, string pw)
        {
            return userHandler.CheckLogin(id, pw);
        }

        /*public User GetUser(string id)
        {
            return userHandler.GetUser(id);
        }*/

        public Teacher GetTeacher(string id)
        {
            return userHandler.GetTeacher(id);
        }

        public Student GetStudent(string id)
        {
            return userHandler.GetStudent(id);
        }

        public Admin GetAdmin(string id)
        {
            return userHandler.GetAdmin(id);
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
            List<string> ids = demandHandler.GetAllIds("Demands/");

            List<Demand> demands = new List<Demand>();

            foreach (string id in ids)
            {
                Demand newDemand = demandHandler.GetDemand(id);
                demands.Add(newDemand);
            }

            return demands;
        }

        /*public bool demandJudgement(String demand_id, String neptun_code, Boolean state)
        {
            Demand newDemand = demandHandler.GetDemand(demand_id);

            bool userNewDemand = userHandler.Register(neptun_code, newDemand.subjectId);

            //TODO
            bool newSubject = subjectHandler

        }
        */

        public List<ClassRoom> getAllRoom()
        {
            List<ClassRoom> rooms = new List<ClassRoom>();

            List<string> ids = demandHandler.GetAllIds("ClassRooms/");

            foreach (string id in ids)
            {
                ClassRoom newRoom = roomHandler.GetClassRoom(id);
                rooms.Add(newRoom);
            }

            return rooms;
        }

        public bool demandSubmission(Demand newDemand, String neptun_code)
        {
            bool user = userHandler.AppendDemand(neptun_code, newDemand.getDemandId());
            bool demand = demandHandler.CreateDemand(newDemand);
            return user && demand;
        }

        public List<short_subject> getAllSubject()
        {
            List<string> ids = subjectHandler.GetAllIds("Lectures/");

            List<short_subject> subjects = new List<short_subject>();

            foreach (string id in ids)
            {
                short_subject newSubject = new short_subject();
                newSubject.id = id;
                newSubject.name = subjectHandler.GetSubjectName(id);
                subjects.Add(newSubject);
            }

            return subjects;
        }

        public bool registerForSubject(String neptun_code, String subject_id)
        {
            bool user = userHandler.Register(neptun_code, subject_id);
            bool subject = subjectHandler.Register(subject_id, neptun_code);

            return user && subject;
        }

        public bool deregisterSubject(String neptun_code, String subject_id)
        {
            return userHandler.DeRegister(neptun_code, subject_id);
        }

        public List<ClassRoom> getFreeClasses(String startTime, String endTime)
        {
            List<ClassRoom> classes = new List<ClassRoom>();

            busy_time time = new busy_time();
            time.startTime = startTime;
            time.endTime = endTime;

            HashSet<busy_time> set = new HashSet<busy_time>();

            List<string> ids = roomHandler.GetAllIds("ClassRooms/");

            foreach (string id in ids)
            {
                ClassRoom room = roomHandler.GetClassRoom(id);

                List<String> subj_ids = roomHandler.GetLectureIds(id);

                foreach (string subjId in subj_ids)
                {
                    busy_time busyTime = new busy_time();
                    Subject subj = subjectHandler.GetSubject(subjId);
                    busyTime.startTime = subj.getStartTime();
                    busyTime.endTime = subj.getEndTime();

                    set.Add(busyTime);
                }
                if (!set.Contains(time))
                {
                    classes.Add(room);
                }
            }

            return classes;
        }

        public bool maintenance()
        {
            return true;
        }

        public bool requestSubmission(Request newRequest, String neptun_code)
        {
            bool user = userHandler.AppendRequest(neptun_code, newRequest.getId());
            bool request = requestHandler.CreateRequest(newRequest);
            return user && request;

        }

        public List<Request> getAllRequest()
        {
            List<string> ids = requestHandler.GetAllIds("Requests/");

            List<Request> requests = new List<Request>();

            foreach (string id in ids)
            {
                Request newRequest = requestHandler.GetRequest(id);
                requests.Add(newRequest);
            }

            return requests;
        }



        public bool requestJudgement(String request_id, String neptun_code, Boolean state)
        {
            return requestHandler.JudgeRequest(request_id, state);
        }

        public bool demandJudgement(String demand_id, String neptun_code, Boolean state)
        {
            bool subject = true;
            if (state)
            {
                Demand newDemand = demandHandler.GetDemand(demand_id);

                Subject newSubject = new Subject(newDemand.getSubjectId(), newDemand.getSubjectName(), newDemand.getTeacherId(),
                        newDemand.getDay(), newDemand.getStartTime(), newDemand.getEndTime(), 
                        new List<string>(), new List<string>());

                subject = subjectHandler.CreateSubject(newSubject);
            }

            bool demand = demandHandler.JudgeDemand(demand_id, state);

            return demand && subject;
        }

        public Request getRequest(String request_id)
        {
            return requestHandler.GetRequest(request_id);
        }

    }
}