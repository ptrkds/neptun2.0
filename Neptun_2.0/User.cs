using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class User
    {
        private String neptunCode;
        private String name;
        private String type;
        public List<string> subjects;
        public List<string> documents; 

        public User(String neptunCode, String name, String type, List<string> subjects, List<string> documents )
        {
            this.neptunCode = neptunCode;
            this.name = name;
            this.type = type;
            this.subjects = subjects;
            this.documents = documents;
        }

        public String getNeptunCode()
        {
            return neptunCode;
        }

        public void setNeptunCode(String _neptunCode)
        {
            neptunCode = _neptunCode;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String _name)
        {
            name = _name;
        }

        public String getType()
        {
            return type;
        }

        public void setType(String _type)
        {
            type = _type;
        }

        public List<string> getSubjects()
        {
            return subjects;
        }

        public void setSubjects(List<String> _subjects)
        {
            subjects = _subjects;
        }

        public List<string> getDocuments()
        {
            return documents;
        }

        public void setDocuments(List<String> _documents)
        {
            documents = _documents;
        }
    }
}
