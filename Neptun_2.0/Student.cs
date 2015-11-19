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

        public Student(String neptunCode, String name, String type, String pw, List<String> _subjects, List<string> subjects, List<String> _requests)
            : base(neptunCode, name, type, pw)
        {
            this.subjects = _subjects;
            this.requests = _requests;
        }

        public override String getNeptunCode()
        {
            return neptunCode;
        }

        public override void setNeptunCode(String _neptunCode)
        {
            neptunCode = _neptunCode;
        }

        public override String getName()
        {
            return name;
        }

        public override void setName(String _name)
        {
            name = _name;
        }

        public override String getType()
        {
            return type;
        }

        public override void setType(String _type)
        {
            type = _type;
        }

        public override String getPw()
        {
            return pw;
        }

        public override void setPw(String _pw)
        {
            pw = _pw;
        }

        public List<String> getSubjects()
        {
            return subjects;
        }

        public void setSubjects(List<String> _subjects)
        {
            subjects = _subjects;
        }

        public List<String> getRequests()
        {
            return requests;
        }

        public void setRequests(List<String> _requests)
        {
            requests = _requests;
        }
    }
}
