﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Users
    {
        UserXmlHandler handler;

        bool checkLogin(string id, string pw)
        {
            return handler.checkLogin(id, pw);
        }
    }
}