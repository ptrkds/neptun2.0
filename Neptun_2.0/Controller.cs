﻿using System;
using System.Collections.Generic;
using Neptun_Structure;

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

        private Database db = new Database();

        public String requestLogin(List<String> data)
        {
            String check = null;
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
        public void start(String neptun_code, String type)
        {
            try
            {
                switch (type)
                {
                    case "admin":
                        userLoggedIn = db.GetAdmin(neptun_code);
                        break;
                    case "teacher":
                        userLoggedIn = db.GetTeacher(neptun_code);
                        break;
                    case "student":
                        userLoggedIn = db.GetStudent(neptun_code);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            switch (type)
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
                        demandJudgement();
                        break;
                    case "requestMaintenance":
                        requestMaintenance();
                        break;
                    case "requestJudgement":
                        requestJudgement();
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
                        requestFilter();
                        break;
                    case "studentBlock":
                        studentBlock();
                        break;
                    
                    case "demand":
                        cmd = tui.demandMenu();
                        switch (cmd.cmd)
                        {
                            case "demandSubmission":
                                requestDemandSubmission();
                                break;
                            case "demandChange":
                                demandChange();
                                break;
                            case "logout":
                                break;
                        }
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
                    case "logout":
                        return;
                }
            }
        }

        //Teacher Functions

        //Student Block
        private bool studentBlock()
        {
            List<short_subject> subjects = db.getShortSubjects(userLoggedIn.getNeptunCode());

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
                cmd = tui.demandChangeMenu(demands);

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
        }
        
        private int requestDemandChange(String demand_id)
        {
            Demand demand = db.getDemand(demand_id); ;


            cmd = tui.demandChangeSubMenu(demand, db.getAllRoom());

            if (cmd.cmd != "exit")
            {
                Demand newDemand = new Demand(cmd.data[1], "null", userLoggedIn.getNeptunCode(), 
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
                    int judg = requestDemandJudgement(cmd.data[0]);
                    if (judg == 1)
                    {
                        aui.demand_accept();
                        return true;
                    }
                    else if (judg == 0)
                    {
                        aui.demand_decline();
                        return true;
                    }
                    else
                    {
                        aui.demand_unsuccessful();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private int requestDemandJudgement(String demand_id)
        {
            cmd = aui.judgeDemand();
            if (cmd.cmd != "exit")
            {
                if (db.demandJudgement(demand_id, userLoggedIn.getNeptunCode(), Boolean.Parse(cmd.cmd)))
                {
                    if (db.getDemand(demand_id).getState() == "accepted")
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        
        
        //Demand Submission
        private bool requestDemandSubmission(String selected_class = "", String day="", String startTime = "", String endTime="")
        {
            List<ClassRoom> rooms = db.getAllRoom();

            cmd = tui.demandSubmissionMenu(rooms, selected_class, day, startTime, endTime);

            
            if (cmd.cmd != "exit")
            {

                Demand newDemand = new Demand(cmd.data[1], "null", userLoggedIn.getNeptunCode(),
                   cmd.data[0], cmd.data[1], cmd.data[2], cmd.data[3], cmd.data[4], cmd.data[5]);

                if (db.demandSubmission(newDemand, userLoggedIn.getNeptunCode()))
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
            List<Subject> subjects = new List<Subject>();

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
            List<Subject> subjects = db.getSubjects(userLoggedIn.getNeptunCode());

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
                List<ClassRoom> classes = db.getFreeClasses(cmd.data[0], cmd.data[1], cmd.data[2]);
                CMD cmd2 = tui.filterSelectClass(classes);
                if (cmd2.cmd != "exit")
                {
                    requestDemandSubmission(cmd2.data[0], cmd.data[0], cmd.data[1], cmd.data[2]);
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
            cmd = aui.requestMaintenanceMenu();

            if (cmd.cmd != "exit")
            {
                if (db.maintenance())
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
            List<Request> requests = db.getAllRequest();

            while (true)
            {
                cmd = aui.selectRequest(requests);
                if (cmd.cmd != "exit")
                {
                    int judg = requestRequestJudgement(cmd.data[0]);
                    if (judg == 1)
                    {
                        aui.request_accept();
                        return true;
                    }
                    else if (judg == 0)
                    {
                        aui.request_decline();
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
        }
        private int requestRequestJudgement(String request_id)
        {
            cmd = aui.judgeRequest(db.getRequest(request_id));
            //request delete
            if (cmd.cmd != "exit")
            {

                if (db.requestJudgement(request_id, userLoggedIn.getNeptunCode(), Boolean.Parse(cmd.cmd)))
                {
                    if (db.getRequest(request_id).getState() == "accepted")
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        
        //Request Submission
        private bool requestRequestSubmission()
        {
            cmd = sui.requestSubmissionMenu();
            if (cmd.cmd != "exit")
            {
                String time = DateTime.Now.ToString("MM-dd-yy-hh-mm-ss");
                Request newRequest = new Request(userLoggedIn.getNeptunCode()+time, "null", cmd.data[0], userLoggedIn.getNeptunCode(),
                    cmd.data[1]);


                if (db.requestSubmission(newRequest, userLoggedIn.getNeptunCode()))
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
