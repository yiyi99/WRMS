using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linweiWRMS.Entity {
    /// <summary>
    /// Project实体类
    /// </summary>
    class Project {
        private int p_id;   //项目id
        private String p_name;  //项目名称

        public int Pid {
            get { return p_id; }
            set { p_id = value; }
        }

        public String Pname {
            get { return p_name; }
            set { p_name = value; }
        }

        public Project() : base() { }

        public Project(int pid,String pname) {
            this.p_id = pid;
            this.p_name = pname;
        }
    }
}
