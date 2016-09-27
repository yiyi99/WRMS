using linweiWRMS.DBHelper;
using linweiWRMS2._0.DBHelper;
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
    public partial class ChangePwdForm : Form {
        public ChangePwdForm() {
            InitializeComponent();
        }

        /// <summary>
        /// 点击取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_change_no_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// 点击确认按钮，核对密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_change_yes_Click(object sender, EventArgs e) {
            String oldPwd = text_oldPwd.Text;
            String newPwd = text_newPwd.Text;
            String checkPwd = text_checkPwd.Text;
            if (!oldPwd.Equals(Program.globalPwd)) {
                MessageBox.Show("旧密码输入不正确,请重新输入！", "提示");
                ClearInputPwd();
            } else {
                if (!newPwd.Equals(checkPwd)) {
                    MessageBox.Show("两次输入的密码不一致,请重新输入！", "提示");
                    ClearInputPwd();
                } else {
                    if (!new MysqlOperate().ChangePwd(newPwd)) {
                        MessageBox.Show("密码修改失败,请重新输入！", "提示");
                        ClearInputPwd();
                    } else {
                        MessageBox.Show("修改成功", "提示");
                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 清空输入密码
        /// </summary>
        private void ClearInputPwd(){
            text_oldPwd.Text = "";
            text_newPwd.Text = "";
            text_checkPwd.Text = "";
        }
    }
}
