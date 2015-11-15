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

    class Neptun
    {
        

        Controller controller = new Controller();

        Interface ui = new Interface();

        public void start(){
            login();
        }  
        
        private void login()
        {
            CMD command;
            command = ui.startUp();

            switch (cmd) {
                case "login":
                    
                    break;
                case "exit":
                    exit();
                    break;
            } 
        }  


        void exit() {
        }
    }
}
