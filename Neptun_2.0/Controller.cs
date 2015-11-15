using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Controller
    {
        //!!! VOID -> ??? !!!

        Interface ui;

        User userLoggedIn;

        CMD cmd;

        public bool requestLogin()
        {

            return true;
        }


        public void start(User user)
        {
            userLoggedIn = user;

            //HAXX
            switch (userLoggedIn)
            {
                case "admin":
                    adminMain();
                    break;
                case "teacher":
                    teacherMain();
                    break;
                case "student":
                    studentMain();
                    break;
            }
        }

        private void adminMain()
        {
            ui = new AdminInterface();

            while (true)
            {
                cmd = ui.MainMenu();
                switch (cmd.cmd)
                {
                    case "demandSubmission":
                        demandJudgement();
                        break;
                    case "maintenance":
                        maintenance();
                        break;
                    case "requestJudgement":
                        requestJudgement();
                        break;
                    case "logOut":

                }
            }

        }

        private void teacherMain()
        {
            ui = new TeacherInterface();

            while (true)
            {
                cmd = ui.MainMenu();
                switch (cmd.cmd)
                {
                    case "filter":
                        filter();
                        break;
                    case "studentBlock":
                        studentBlock();
                        break;
                    case "requestJudgement":
                        requestRequestJudgement();
                        break;
                    case "logOut":

                }
            }
        }


        private bool requestDemandChange()
        {

        }

        private bool requestDemandJudgement()
        {

        }

        private bool requestDemandSubmission()
        {

        }


        private bool requestDeregisterSubject()
        {
            
        }

        private bool requestFilter()
        {

        }


        private bool requestMaintenance()
        {

        }

        private bool requestRegisterForSubject()
        {

        }

        private bool requestRequestJudgement()
        {

        }

        private bool requestRequestSubmission()
        {

        }

        private int studentBlock()
        {
            List<String> subject_list = ;

            while (true) {
                cmd = ui.selectSubject(subject_list);

                if (cmd.cmd != "exit")
                {
                    if (studentBlock_studentSelect() == 1)
                    {
                        ui.sb_successful;
                        return 1;
                    }
                    else if(studentBlock_studentSelect() == -1)
                    {
                        ui.sb_unsuccessful;
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        private int studentBlock_studentSelect()
        {
            while (true) {
                List<String> student_list = ;

                cmd = ui.selectStudent();

                if (cmd.cmd != "exit")
                {
                    if (requestStudentBlock(student_list[Int32.Parse(cmd.cmd)]))
                    {
                        return 1; //sikerült
                    }
                    else
                    {
                        return -1; //sikertelen
                    }     
                }
                else
                {
                    return 0; //exit code
                }
            }
        }

        private bool requestStudentBlock(String student)
        {
            //kiso eltiltja
            if () {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void requestTimeTable()
        {

        }


    }
}
