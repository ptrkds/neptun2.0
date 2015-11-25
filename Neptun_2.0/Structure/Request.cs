using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Request : Document
    {
        private String subject;
        private String text;

        public Request(string id, string state, string subject, string owner, string text):
            base(id, state, owner)
        {
            this.subject = subject;
            this.text = text;
        }

        

        public String getSubject()
        {
            return subject;
        }

        public String getText()
        {
            return text;
        }
    }
}
