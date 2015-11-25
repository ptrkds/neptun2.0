﻿using System;
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

        public Teacher(String neptunCode, String name, String type, String pw, List<String> _subjects, List<String> _demands)
            : base(neptunCode, name, type, pw)
        {
            this.demands = _demands;
            this.subjects = _subjects;
        }
        public List<String> getSubjects()
        {
            return subjects;
        }

        public List<String> getDemands()
        {
            return demands;
        }
    }
}
