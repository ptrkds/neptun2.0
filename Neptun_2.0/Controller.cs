using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Controller
    {
        //private Interface ui = new Interface();

        private Interface ui = new Interface();
        private InterfaceLogin uil = new InterfaceLogin();
        private TeacherInterface tui = new TeacherInterface();
        private StudentInterface sui = new StudentInterface();
        private AdminInterface aui = new AdminInterface();

        User userLoggedIn;

        CMD cmd;

        Database db = new Database();

        public bool requestLogin(List<String> data)
        {
            bool check = false;
            try
            {
                check = db.checkLogin(data[0], data[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return check;
        }

        //When user logged in
        public void start(String neptun_code)
        {
            try
            {
                userLoggedIn = db.GetUser(neptun_code);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

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
            return;
        }

        //Mains
        private void adminMain()
        {
            //ui = new AdminInterface();

            while (true)
            {
                cmd = aui.AdminMainMenu();
                switch (cmd.cmd)
                {
                    case "demandSubmission":
                        //demandJudgement();
                        break;
                    case "maintenance":
                        //requestMaintenance();
                        break;
                    case "requestJudgement":
                        //requestJudgement();
                        break;
                    case "logout":
                        return;
                }
            }

        }

        private void teacherMain()
        {
            //ui = new TeacherInterface();

            while (true)
            {
                cmd = tui.TeacherMainMenu();
                switch (cmd.cmd)
                {
                    case "filter":
                        //requestFilter();
                        break;
                    case "studentBlock":
                        studentBlock();
                        break;
                    case "demandSubmission":
                        //requestDemandSubmission();
                        break;
                    case "demand":
                        cmd = tui.demandMenu();
                        break;
                    case "demandChange":
                        //demandChange();
                        break;
                    case "timeTable":
                        requestTeacherTimeTable();
                        break;
                    case "logout":
                        return;
                }
            }
        }

        private void studentMain()
        {
            //ui = new StudentInterface();

            while (true)
            {
                cmd = sui.StudentMainMenu();
                switch (cmd.cmd)
                {
                    case "timeTable":
                        //requestStudentTimeTable();
                        break;
                    case "requestSubmission":
                        //requestRequestSubmission();
                        break;
                    case "registerForSubject":
                        //registerForSubject();
                        break;
                    case "deregisterSubject":
                        //deregisterSubject();
                        break;
                    case "logout":
                        return;
                }
            }
        }

        //Teacher Functions

        //Student Block
        private bool studentBlock()
        {
            List<short_subject> subjects = db.getSubjects(userLoggedIn.getNeptunCode());

            while (true)
            {
                cmd = tui.selectSubject(subjects);

                if (cmd.cmd != "exit")
                {
                    int ret = studentBlock_studentSelect(cmd.data[0]);
                    if (ret == 1)
                    {
                        tui.studentBlock_successful();
                        return true;
                    }
                    else if (ret == -1)
                    {
                        tui.studentBlock_unsuccessful();
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
            while (true)
            {
                List<short_user> student_list = db.getStudents(subject_id);

                cmd = tui.selectStudent(student_list);

                if (cmd.cmd != "exit")
                {
                    if (requestStudentBlock(cmd.data[0], subject_id, cmd.data[1]))
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
        private bool requestStudentBlock(String student_id, String subject_id, String student_name)
        {
            if (tui.areYouSure(student_name))
            {
                if (db.BlockStudent(subject_id, student_id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        //Time Table
        private void requestStudentTimeTable()
        {
            List<Subject> timeTable = db.TimeTable(userLoggedIn.getNeptunCode());

            cmd = sui.timeTableView(timeTable);

            return;
        }
        private void requestTeacherTimeTable()
        {
            List<Subject> timeTable = db.TimeTable(userLoggedIn.getNeptunCode());

            cmd = tui.timeTableView(timeTable);

            return;
        }




        //Demand Change
        private bool demandChange()
        {
            List<Demand> demands = new List<Demand>();

            try
            {
                demands = db.getDemands(userLoggedIn.getNeptunCode());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            while (true)
            {
                cmd = tui.selectDemand(demands);

                if (cmd.cmd != "exit")
                {
                    int ret = requestDemandChange(cmd.data[0]);
                    if (ret == 1)
                    {
                        tui.demandChange_successful();
                        return true;
                    }
                    else if (ret == -1)
                    {
                        tui.demandChange_unsuccessful();
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
            

            try
            {
                Demand demand = db.getDemand(demand_id);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            cmd = tui.demandChange(demand);

            if (cmd.cmd != "exit")
            {
                Demand newDemand = new Demand(cmd.data[1], null, userLoggedIn.getNeptunCode(), 
                    cmd.data[0], cmd.data[1], cmd.data[2], cmd.data[3], cmd.data[4], cmd.data[5]);
                
                bool ret = db.demandChange(newDemand);
                if (ret)
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
            List<Demand> demands = new List<Demand>();

            try
            {
                demands = db.getAllDemand();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            while (true)
            {
                cmd = aui.selectDemand(demands);
                if (cmd.cmd != "exit")
                {
                    if (requestDemandJudgement(cmd.data[0]))
                    {
                        aui.demand_accept();
                        return true;
                    }
                    else
                    {
                        aui.demand_decline();
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
            cmd = aui.judgeDemand();
            if (cmd.cmd != "exit")
            {
                if (db.demandJudgement(demand_id, userLoggedIn.getNeptunCode(), Boolean.Parse(cmd.data[0])))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        //Demand Submission
        private bool requestDemandSubmission(String selected_class = "")
        {
            List<ClassRoom> rooms = db.getAllRoom();

            cmd = tui.demandSubmission(rooms, selected_class);

            
            if (cmd.cmd != "exit")
            {

                Demand newDemand = new Demand(cmd.data[1], null, userLoggedIn.getNeptunCode(),
                   cmd.data[0], cmd.data[1], cmd.data[2], cmd.data[3], cmd.data[4], cmd.data[5]);

                if (db.demandSubmission(newDemand))
                {
                    tui.demandSubmission_successful();
                    return true;
                }
                else
                {
                    tui.demandSubmission_unsuccessful();
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
            List<short_subject> subjects = new List<short_subject>();

            try
            {
                subjects = db.getAllSubject();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            while (true)
            {
                cmd = sui.selectSubject(subjects);
                if (cmd.cmd != "exit")
                {
                    if (requestRegisterForSubject(cmd.data[0]))
                    {
                        sui.regForSubject_successful();
                        return true;
                    }
                    else
                    {
                        sui.regForSubject_unsuccessful();
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
            if (db.registerForSubject(userLoggedIn.getNeptunCode(), subject_id))
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
            List<short_subject> subjects = db.getSubjects(userLoggedIn.getNeptunCode());




            while (true)
            {
                cmd = sui.selectSubject(subjects);

                if (cmd.cmd != "exit")
                {
                    if (requestDeregisterSubject(cmd.data[0]))
                    {
                        sui.deregister_successful();
                        return true;
                    }
                    else
                    {
                        sui.deregister_unsuccessful();
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
            if (db.deregisterSubject(userLoggedIn.getNeptunCode(), subject_id))
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
            cmd = tui.selectFilterTime();

            if (cmd.cmd != "exit")
            {
                List<ClassRoom> classes = db.getClasses(cmd.data[0], cmd.data[1]);
                cmd = tui.selectClass(classes);
                if (cmd.cmd != "exit")
                {
                    requestDemandSubmission(cmd.data[0]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }


        //Maintenance
        private bool requestMaintenance()
        {
            cmd = aui.maintenance();

            if (cmd.cmd != "exit")
            {
                if (kisofgv())
                {
                    aui.maintenance_successful();
                    return true;
                }
                else
                {
                    aui.maintenance_unsuccessful();
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
                cmd = aui.selectRequest(requests);
                if (cmd.cmd != "exit")
                {
                    if (requestRequestJudgement(cmd.data[0]))
                    {
                        aui.request_accept();
                        return true;
                    }
                    else
                    {
                        aui.request_decline();
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
            cmd = sui.requestSubmission();
            if (cmd.cmd != "exit")
            {
                if (kisofgv(cmd.data))
                {
                    sui.requestSubmission_successful();
                    return true;
                }
                else
                {
                    sui.requestSubmission_unsuccessful();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
