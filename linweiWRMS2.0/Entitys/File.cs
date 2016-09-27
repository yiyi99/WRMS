using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linweiWRMS.Entity {
    /// <summary>
    /// File实体类
    /// </summary>
    public class File {
        private int f_id;   //文件id

        public int F_id {
            get { return f_id; }
            set { f_id = value; }
        }

        private String f_name;  //工程名称

        public String F_name {
            get { return f_name; }
            set { f_name = value; }
        }
        private String f_town;  //辖区村镇

        public String F_town {
            get { return f_town; }
            set { f_town = value; }
        }
        private String f_no;   //编号

        public String F_no {
            get { return f_no; }
            set { f_no = value; }
        }
        private String f_location;  //地理位置

        public String F_location {
            get { return f_location; }
            set { f_location = value; }
        }
        private int f_dong; //东经

        public int F_dong {
            get { return f_dong; }
            set { f_dong = value; }
        }
        private int f_bei;  //北纬

        public int F_bei {
            get { return f_bei; }
            set { f_bei = value; }
        }
        private String f_buildtime; //建设日期

        public String F_buildtime {
            get { return f_buildtime; }
            set { f_buildtime = value; }
        }
        private float f_value;    //工程固定原值

        public float F_value {
            get { return f_value; }
            set { f_value = value; }
        }
        private String f_maketype;    //产权类型

        public String F_maketype {
            get { return f_maketype; }
            set { f_maketype = value; }
        }
        private String f_makeperson;    //产权人

        public String F_makeperson {
            get { return f_makeperson; }
            set { f_makeperson = value; }
        }
        private String f_guanhutype;    //管护类型

        public String F_guanhutype {
            get { return f_guanhutype; }
            set { f_guanhutype = value; }
        }
        private String f_guanhuperson;  //管护人

        public String F_guanhuperson {
            get { return f_guanhuperson; }
            set { f_guanhuperson = value; }
        }
        private String f_uptime;   //文件上传时间

        public String F_uptime {
            get { return f_uptime; }
            set { f_uptime = value; }
        }

        public File() { }

        public File(String f_name, String f_town, String f_no, String f_location, int f_dong, int f_bei, String f_buildtime, float f_value, String f_maketype, String f_makeperson, String f_guanhutype, String f_guanhuperson, String f_uptime) {
            this.f_name = f_name;
            this.f_town = f_town;
            this.f_no = f_no;
            this.f_location = f_location;
            this.f_dong = f_dong;
            this.f_bei = f_bei;
            this.f_buildtime = f_buildtime;
            this.f_value = f_value;
            this.f_maketype = f_maketype;
            this.f_makeperson = f_makeperson;
            this.f_guanhutype = f_guanhutype;
            this.f_guanhuperson = f_guanhuperson;
            this.f_uptime = f_uptime;
        }
    }
}
