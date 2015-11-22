using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Request
    {
        private String id;
        private String state;
        private String owner;
        private String subject;
        private String text;

        public Request(string id, string state, string subject, string owner, string text)
        {
            this.id = id;
            this.state = state;
            this.owner = owner;
            this.subject = subject;
            this.text = text;
        }

        public String getId()
        {
            return id;
        }

        public String getState()
        {
            return state;
        }

        public String getOwner()
        {
            return owner;
        }

        public String getSubject()
        {
            return subject;
        }

        public String getText()
        {
            return text;
        }

        public void setId(String _id)
        {
            id = _id;
        }

        public void setState(String _state)
        {
            state = _state;
        }

        public void setOwner(String _owner)
        {
            owner = _owner;
        }

        public void setSubject(String _subject)
        {
            subject = _subject;
        }

        public void setText(String _text)
        {
            text = _text;
        }
    }
}
