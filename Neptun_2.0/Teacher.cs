using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Teacher : User
    {
        private List<string> subjects;
        private List<String> demands;

        public Teacher(String neptunCode, String name, String type, String pw, List<string> subjects, List<String> _subjects, List<String> _demands)
            : base(neptunCode, name, type, pw)
        {
            this.demands = _demands;
            this.subjects = _subjects;
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

        public List<String> getDemands()
        {
            return demands;
        }

        public void setDemands(List<String> _demands)
        {
            demands = _demands;
        }
    }
}
