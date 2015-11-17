using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Database
    {
        UserXmlHandler handler = new UserXmlHandler();
        SubjectXmlHandler subjhandler = new SubjectXmlHandler();

        public bool checkLogin(string id, string pw)
        {
            return handler.CheckLogin(id, pw);
        }

        public User GetUser(string id)
        {
            return handler.GetUser(id);
        }


        public List<short_subject> getSubjects(string neptunCode)
        {
            List<string> ids = handler.GetSubjectIds(neptunCode);

            //get subjectnames
            List < short_subject > subj = new List<short_subject>();
            foreach (string id in ids)
            {
                short_subject ss = new short_subject();
                ss.id = id;
                ss.name = subjhandler.GetSubjectName(id);
                subj.Add(ss);
            }

            return subj;
        }

        /*
        bool deregisterSubject(string user_id, subject_id)
        {

        }*/




    }
}