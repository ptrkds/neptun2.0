using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Neptun_2._0
{
    public struct CMD
    {
        public String cmd;
        public List<String> data;
    }

    public struct short_subject
    {
        public string id;
        public string name;
    }

    public struct short_user
    {
        public string id;
        public string name;
    }

    public struct busy_time
    {
        public string startTime;
        public string endTime;
    }

    class Neptun
    {
        private Registry registry = new Registry();

        private Controller controller = new Controller();

        private InterfaceLogin il = new InterfaceLogin();

        CMD cmd;

        public void start(){
            login();
            return;
        }  
        
        private void login()
        {

            bool success = false;
            bool error = false;

            while (success == false)
            {
                cmd = il.Login(error);
                switch (cmd.cmd)
                {
                    case "login":
                        success = controller.requestLogin(cmd.data, registry);
                        if (success)
                        {
                            controller.start(cmd.data[0]);
                            success = false;
                        }
                        else
                        {
                            error = true;
                        }
                        break;
                    case "exit":
                        exit();
                        success = true;
                        break;
                }
            }            
        }

        private void exit() {
            return;
        }
    }
}
