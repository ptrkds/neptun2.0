using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Student : User
    {
        private List<String> subjects; 
        private List<String> requests;

        public Student(String neptunCode, String name, String type, String pw, List<String> _subjects, List<String> _requests)
            : base(neptunCode, name, type, pw)
        {
            this.subjects = _subjects;
            this.requests = _requests;
        }

        public List<String> getSubjects()
        {
            return subjects;
        }

        public List<String> getRequests()
        {
            return requests;
        }
    }
}
