using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Student : User
    {
        private List<String> documents;

        public Student(String neptunCode, String name, String type, List<string> subjects, List<String> _documents)
            : base(neptunCode, name, type, subjects)
        {
            this.documents = _documents;
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

        public List<String> getDocuments()
        {
            return documents;
        }

        public void setDocuments(List<String> _documents)
        {
            documents = _documents;
        }
    }
}
