using System;

namespace Neptun_Structure
{
    class User
    {
        protected String neptunCode;
        protected String name;
        protected String type;
        protected String pw;

        protected User(String neptunCode, String name, String type, String pw)
        {
            this.neptunCode = neptunCode;
            this.name = name;
            this.type = type;
            this.pw = pw;
        }

        public String getNeptunCode()
        {
            return neptunCode;
        }
        public String getType()
        {
            return type;
        }
        public String getName()
        {
            return name;
        }
        public String getPw()
        {
            return pw;
        }
    }
}
