using System;

namespace Neptun_Structure
{
    class Document
    {
        private string id;
        private string state;
        private string owner;

        public Document(string id, string state, string owner)
        {
            this.id = id;
            this.state = state;
            this.owner = owner;
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
    }
}
