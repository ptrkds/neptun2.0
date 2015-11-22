using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neptun_2._0;

namespace XmlHandlerTests
{
    [TestClass]
    public class UserXmlHandlerTest
    {

        [TestMethod]
        public void GetStudentTest()
        {/*
            UserXmlHandler handler = new UserXmlHandler();
            Student student = handler.GetStudent("Users/Students/", "UKDUJP");

            Console.WriteLine(ObjectDumper.Dump(student));*/
        }
        
        public string dir = "Users";
        [TestMethod]
        public void GetUser()
        {/*
            UserXmlHandler handler = new UserXmlHandler();
            User user = handler.GetUser("VS42ZH");

            Console.WriteLine(user.getNeptunCode());
            Console.WriteLine(user.getName());
            Console.WriteLine(user.getType());
           
            //Console.WriteLine(ObjectDumper.Dump(user));
            //Console.WriteLine(ObjectDumper.Dump(user));

            foreach(string str in user.getSubjects())
            {
                Console.WriteLine(str);
            }

            foreach (string str in user.getDocuments())
            {
                Console.WriteLine(str);
            }
            */
        }
    }
}
