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
                cmd = ui.AdminMainMenu();
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
                        //exit
                        break;
                }
            }

        }

        private void teacherMain()
        {
            ui = new TeacherInterface();

            while (true)
            {
                cmd = ui.TeacherMainMenu();
                switch (cmd.cmd)
                {
                    case "filter":
                        filter();
                        break;
                    case "studentBlock":
                        studentBlock();
                        break;
                    case "demandSubmission":
                        demandJudgement();
                        break;
                    case "demandChange":
                        demandChange();
                        break;
                    case "timeTable":
                        timeTable();
                        break;
                    case "logOut":
                        //exit
                        break;
                }
            }
        }

        private void studentMain()
        {
            ui = new StudentInterface();

            while (true)
            {
                cmd = ui.StudentMainMenu();
                switch (cmd.cmd)
                {
                    case "timeTable":
                        timeTable();
                        break;
                    case "requestSubmission":
                        requestSubmission();
                        break;
                    case "registerForSubject":
                        registerForSubject();
                        break;
                    case "deregisterSubject":
                        deregisterSubject();
                        break;
                    case "logOut":
                        //exit
                        break;
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

        //Student Block
        private int studentBlock()
        {
            List<String> subject_list = ;

            while (true) {
                cmd = ui.selectSubject(subject_list);

                if (cmd.cmd != "exit")
                {
                    int ret = studentBlock_studentSelect(cmd.data[0]);
                    if (ret == 1)
                    {
                        ui.sb_successful;
                        return 1;
                    }
                    else if(ret == -1){
                        ui.sb_unsuccessful;
                        return 1;
                    }
                    //ha ret == 0, akkor újrafut a ciklus úgyis
                }
                else
                {
                    return 0;
                }
            }
        }

        private int studentBlock_studentSelect(String subject_id)
        {
            while (true) {
                List<String> student_list = ;

                cmd = ui.selectStudent();

                if (cmd.cmd != "exit")
                {
                    if (requestStudentBlock(cmd.data[0], subject_id))
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

        private bool requestStudentBlock(String student_id, String subject_id)
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


        //Time Table
        private void requestStudentTimeTable()
        {
            List<valami structura> list = ;

            cmd = ui.timeTableView(list);

            //exit
        }

        private void requestTeacherTimeTable()
        {
            List < valami structura > list = ;

            cmd = ui.timeTableView(list);

            //exit
        }


    }
}
