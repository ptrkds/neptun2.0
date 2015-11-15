using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Controller
    {
        Interface ui;

        User userLoggedIn;

        CMD cmd;

        public bool requestLogin(List<String> data)
        {
            return checkKiso(data);
        }

        //When user logged in
        public void start(String user_neptun_code)
        {
            userLoggedIn = kisofgv(user_neptun_code);

            switch (userLoggedIn.getType())
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

        //Mains
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
                        requestMaintenance();
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
                        requestFilter();
                        break;
                    case "studentBlock":
                        studentBlock();
                        break;
                    case "demandSubmission":
                        requestDemandSubmission();
                        break;
                    case "demandChange":
                        demandChange();
                        break;
                    case "timeTable":
                        requestTeacherTimeTable();
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
                        requestStudentTimeTable();
                        break;
                    case "requestSubmission":
                        requestRequestSubmission();
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



        //Demand Change
        private bool demandChange()
        {
            List<String> demands = ;

            while (true)
            {
                cmd = ui.selectDemand(demands);

                if(cmd.cmd != "exit")
                {
                    int ret = requestDemandChange(cmd.data[0]);
                    if (ret == 1)
                    {
                        ui.demandChange_successful();
                        return true;
                    }
                    else if(ret == -1)
                    {
                        ui.demandChange_unsuccessful();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private int requestDemandChange(String demand_id)
        {
            Demand demand = ;

            cmd = ui.demandChange(demand);

            if(cmd.cmd != exit)
            {
                int ret = kisovisszatérése(cmd.data);
                if(ret == 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }


        //Demand Judgement
        private bool demandJudgement()
        {
            List<String> demands = ;

            while (true)
            {
                cmd = ui.selectDemand(demands);
                if(cmd.cmd != "exit")
                {
                    if (requestDemandJudgement(cmd.data[0]))
                    {
                        ui.demand_accept();
                        return true;
                    }
                    else
                    {
                        ui.demand_decline();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private bool requestDemandJudgement(String demand_id)
        {
            //demand delete
            if (kisofgv(demand_id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        //Demand Submission
        private bool requestDemandSubmission()
        {
            cmd = ui.demandSubmission();
            if(cmd.cmd != "exit")
            {
                if (kisofgv(cmd.data))
                {
                    ui.demandSubmission_successful();
                    return true;
                }
                else
                {
                    ui.demandSubmission_unsuccessful();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        //Register For Subject
        private bool registerForSubject()
        {
            List<String> subjects = ;

            while (true)
            {
                cmd = ui.selectSubject(subjects);
                if (cmd.cmd != "exit")
                {
                    if (requestRegisterForSubject(cmd.data[0]))
                    {
                        ui.regForSubject_successful();
                        return true;
                    }
                    else
                    {
                        ui.regForSubject_unsuccessful();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private bool requestRegisterForSubject(String subject_id)
        {
            if (kisofgv(subject_id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Deregister Subject
        private bool deregisterSubject()
        {
            List<String> subject_list = ;

            while (true)
            {
                cmd = ui.selectSubject();

                if (cmd.cmd != "exit")
                {
                    if ( requestDeregisterSubject( cmd.data[0]) )
                    {
                        ui.deregister_successful();
                        return true;
                    }
                    else
                    {
                        ui.deregister_unsuccessful();
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private bool requestDeregisterSubject(String subject_id)
        {
            if (kisofgv(subject_id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Filter - x
        private bool requestFilter()
        {

        }


        //Maintenance
        private bool requestMaintenance()
        {
            cmd = ui.maintenance();

            if(cmd.cmd != "exit")
            {
                if (kisofgv())
                {
                    ui.maintenance_successful();
                    return true;
                }
                else
                {
                    ui.maintenance_unsuccessful();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }


        //Request Judgement
        private bool requestJudgement()
        {
            List<String> requests = ;

            while (true)
            {
                cmd = ui.selectRequest(requests);
                if (cmd.cmd != "exit")
                {
                    if (requestRequestJudgement(cmd.data[0]))
                    {
                        ui.request_accept();
                        return true;
                    }
                    else
                    {
                        ui.request_decline();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private bool requestRequestJudgement(String request_id)
        {
            //request delete
            if (kisofgv(request_id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Request Submission
        private bool requestRequestSubmission()
        {
            cmd = ui.requestSubmission();
            if (cmd.cmd != "exit")
            {
                if (kisofgv(cmd.data))
                {
                    ui.requestSubmission_successful();
                    return true;
                }
                else
                {
                    ui.requestSubmission_unsuccessful();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        //Student Block
        private bool studentBlock()
        {
            List<String> subjects = ;

            while (true) {
                cmd = ui.selectSubject(subjects);

                if (cmd.cmd != "exit")
                {
                    int ret = studentBlock_studentSelect(cmd.data[0]);
                    if (ret == 1)
                    {
                        ui.studentBlock_successful;
                        return true;
                    }
                    else if(ret == -1){
                        ui.studentBlock_unsuccessful;
                        return true;
                    }
                    //ha ret == 0, akkor újrafut a ciklus úgyis
                }
                else
                {
                    return false; //visszalép a main menu-be és újra fut ott a while ciklus
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
