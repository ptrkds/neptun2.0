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
    }
}