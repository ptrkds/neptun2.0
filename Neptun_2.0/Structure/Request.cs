using System;

namespace Neptun_Structure
{
    class Request : Document
    {
        private String subject;
        private String text;

        public Request(string id, string state, string owner, string subject, string text):
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
