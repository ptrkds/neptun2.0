using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Users
    {
        UserXmlHandler handler = new UserXmlHandler();

        bool checkLogin(string id, string pw)
        {
            return handler.CheckLogin(id, pw);
        }

        List<short_subject> getSubjects(string neptunCode)
        {
            List<string> ids = handler.GetSubjectIds(neptunCode);


            //get subjectnames
            List < short_subject > subj = new List<short_subject>();
            return subj;
        }

        /*
        bool deregisterSubject(string user_id, subject_id)
        {

        }*/




    }
}