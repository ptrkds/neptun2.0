﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    abstract class User
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

        abstract public String getNeptunCode();

        abstract public void setNeptunCode(String _neptunCode);

        abstract public String getName();

        abstract public void setName(String _name);

        abstract public String getType();

        abstract public void setType(String _type);

        abstract public String getPw();

        public abstract void setPw(String _pw);
    }
}