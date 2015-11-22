using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
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

        public void setId(String _id)
        {
            id = _id;
        }

        public void setLimit(int _limit)
        {
            limit = _limit;
        }

        public void setSubjectIds(List<String> _subjectIds)
        {
            subjectIds = _subjectIds;
        }
    }

}
