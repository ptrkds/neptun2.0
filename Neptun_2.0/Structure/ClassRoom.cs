using System;
using System.Collections.Generic;

namespace Neptun_Structure
{
    class ClassRoom
    {
        private String id;
        private int limit;
        private List<string> subjectIds;

        public ClassRoom(String id, int limit, List<string> subjectIds)
        {
            this.id = id;
            this.limit = limit;
            this.subjectIds = subjectIds;
        }

        public String getId()
        {
            return id;
        }

        public int getLimit()
        {
            return limit;
        }

        public List<String> getSubjectIds()
        {
            return subjectIds;
        }
    }

}
