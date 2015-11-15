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

       /* public void eventHandler(CMD command)
        {
            switch (command.cmd)
            {
                case "studentblock":
                     requestStudentBlock(); 
                    break;
                case "exit":

                    break;
            }
        }*/
        /*
        public void eventLoop(User user)
        {
            userLoggedIn = user;

            bool sajt = true;
            while(sajt)
            {


                sajt = false;
            }

    
        }*/

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
                        requestDemandJudgement();
                        break;
                    case "maintenance":
                        requestMaintenance();
                        break;
                    case "requestJudgement":
                        requestRequestJudgement();
                        break;
                    case "logOut":

                }
            }

        }

        private void teacherMain()
        {
            ui = new TeacherInterface();
            cmd = ui.MainMenu();
        }


        private void requestDemandChange()
        {

        }

        private void requestDemandJudgement()
        {

        }

        private void requestDemandSubmission()
        {

        }


        private void requestDeregisterSubject()
        {
            
        }

        private void requestFilter()
        {

        }


        private void requestMaintenance()
        {

        }

        private void requestRegisterForSubject()
        {

        }

        private void requestRequestJudgement()
        {

        }

        private void requestRequestSubmission()
        {

        }

        private int requestStudentBlock()
        {
            List<String> subject_list = ;

            while (true) {
                cmd = ui.selectSubject();

                if (cmd.cmd != "exit")
                {
                    sajt();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private int sajt()
        {
            while (true) {
                List<String> student_list = ;

                cmd = ui.selectStudent();

                if (cmd.cmd != "exit")
                {
                    requestStudentBlock(student_list[cmd.cmd]);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private bool requestStudentBlock()
        {

            return true;
        }

        private void requestTimeTable()
        {

        }


    }
}
