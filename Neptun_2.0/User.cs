﻿using System;
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
        public List<short_subject> subjects;

        public User(String neptunCode, String name, String type, List<short_subject> subjects)
        {
            neptunCode = this.neptunCode;
            name = this.name;
            type = this.type;
            subjects = this.subjects;
        }

        public String getNeptunCode()
        {
            return neptunCode;
        }

        public String getName()
        {
            return name;
        }

        public String getType()
        {
            return type;
        }

        public List<short_subject> getSubjects()
        {
            return subjects;
        }
    }
}
