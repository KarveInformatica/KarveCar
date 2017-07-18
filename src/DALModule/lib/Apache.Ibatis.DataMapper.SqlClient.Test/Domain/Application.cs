using System.Collections.Generic;
using System.Collections;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Domain
{
    public class Application
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Role role;
        public Role DefaultRole
        {
            get { return role; }
            set { role = value; }
        }

        private IList<ApplicationUser> users;
        public IList<ApplicationUser> Users
        {
            get { return users; }
            set { users = value; }
        }

    }
}
