using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linweiWRMS.Entity {
    /// <summary>
    /// User实体类
    /// </summary>
    class User {
        private int id;    //用户id

        public int Id {
            get { return id; }
            set { id = value; }
        }
        private String name;   //用户名

        public String Name {
            get { return name; }
            set { name = value; }
        }
        private String pwd;    //用户密码

        public String Pwd {
            get { return pwd; }
            set { pwd = value; }
        }

        public User() : base() { }

        public User(int id, String name, String pwd) {
            this.id = id;
            this.name = name;
            this.pwd = pwd;
        }
    }
}
