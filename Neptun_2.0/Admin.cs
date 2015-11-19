using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Admin : User
    {
        private List<String> documents;

        public Admin(String neptunCode, String name, String type, List<string> subjects)
            : base(neptunCode, name, type, subjects)
        {
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

        public override List<String> getSubjects()
        {
            return subjects;
        }

        public override void setSubjects(List<String> _subjects)
        {
            subjects = _subjects;
        }
    }
}
