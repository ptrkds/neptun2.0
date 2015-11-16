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

    class Neptun
    {
        

        Controller controller = new Controller();

        private InterfaceLogin il = new InterfaceLogin();

        CMD cmd;

        public void start(){
            login();
            return;
        }  
        
        private void login()
        {
            cmd = il.Login();

            bool success = false;

            while (success == false)
            {
                switch (cmd.cmd)
                {
                    case "login":
                        success = controller.requestLogin(cmd.data);
                        if (success)
                        {
                            controller.start(cmd.data[0]);
                        }
                        else
                        {
                            cmd = il.Login(true);
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
