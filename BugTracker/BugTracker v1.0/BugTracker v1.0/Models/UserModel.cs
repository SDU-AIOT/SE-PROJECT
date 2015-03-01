using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker_v1._0.Models
{
    class UserModel
    {
        private long id;
        private string name;
        private string surname;
        private short status;

        public long Id
        {
            get { return id;  }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public short Status
        {
            get { return status; }
            set { status = value; }
        }


    }
}
