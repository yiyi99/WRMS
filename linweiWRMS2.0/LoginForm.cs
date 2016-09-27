using linweiWRMS.DBHelper;
using linweiWRMS2._0.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linweiWRMS2._0 {
    public partial class LoginForm : Form {
        /// <summary>
        /// 加载组件
        /// </summary>
        public LoginForm() {
            InitializeComponent();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_login_Click(object sender, EventArgs e) {
            if (!WindowsService.ISStart("mysql")) {
                MessageBox.Show("mysql服务未启动，请以管理员模式进入install启服务后登陆系统","警告提示！");
                System.Environment.Exit(0);
            }
            MySqlConnection con = MysqlHelper.Connection();
            MysqlHelper mh = new MysqlHelper();
            mh.OpenConnection();
            MySqlCommand msc = new MySqlCommand("select u_pwd,md5_pwd from user", con);
            MySqlDataReader mdr = msc.ExecuteReader(CommandBehavior.CloseConnection);
            if (mdr.Read()) {
                String text_pwd=text_login.Text.ToLower().Trim();
                if (text_pwd.Equals(mdr.GetString("u_pwd")) || text_pwd.Equals(mdr.GetString("md5_pwd"))) {
                    Program.globalPwd=mdr.GetString("u_pwd");
                    this.Visible = false;
                    new IndexForm().Show();
                } else {
                    MessageBox.Show("密码输入错误，请重新输入！", "错误提示");
                    text_login.Text = "";
                    text_login.Focus();
                }
            }
            mh.CloseConnection();
        }
    }
}
