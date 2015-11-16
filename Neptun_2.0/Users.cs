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
            return handler.checkLogin(id, pw);
        }

        List<short_subject> getSubjects(string neptunCode)
        {
            return handler.getSubjects(neptunCode);
        }

        /*
        bool deregisterSubject(string user_id, subject_id)
        {

        }*/




    }
}