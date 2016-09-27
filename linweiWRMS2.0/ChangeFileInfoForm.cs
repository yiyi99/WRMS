using linweiWRMS2._0.DBHelper;
using linweiWRMS2._0.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linweiWRMS2._0 {
    public partial class ChangeFileInfoForm : Form {
        int f_id;
        public ChangeFileInfoForm(int f_id) {
            InitializeComponent();
            this.f_id = f_id;
            String[] oneRow = new MysqlOperate().SelectOneRow(f_id);
            this.text_f_town.Text = oneRow[0];
            this.text_f_no.Text = oneRow[1];
            this.label1.Text = oneRow[2]+"（修改）";
            this.text_f_location.Text = oneRow[3];
            this.text_f_dong.Text = oneRow[4];
            this.text_f_bei.Text = oneRow[5];
            this.text_f_value.Text = oneRow[6];
            this.text_f_maketype.Text = oneRow[7];
            this.text_f_makeperson.Text = oneRow[8];
            this.text_f_guanhutype.Text = oneRow[9];
            this.text_f_guanhuperson.Text = oneRow[10];
        }

        /// <summary>
        /// 确认更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fileSubmit_Click(object sender, EventArgs e) {
            DialogResult dr= MessageBox.Show("确定导入文件到系统吗？", "提示信息！", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK) {
                String f_town = text_f_town.Text;
                String f_no=text_f_no.Text;
                String f_location = text_f_location.Text;
                String f_dong = text_f_dong.Text;
                String f_bei = text_f_bei.Text;
                String f_value = text_f_value.Text;
                String f_maketype = text_f_maketype.Text;
                String f_makeperson = text_f_makeperson.Text;
                String f_guanhutype = text_f_guanhutype.Text;
                String f_guanhuperson = text_f_guanhuperson.Text;
                if (f_town != "" && f_no != "" && f_location != "" && f_dong != "" && f_bei != "" && f_value != "" && f_maketype != "" && f_makeperson != "" && f_guanhutype != "" && f_guanhuperson != "") {
                    string regex = @"^-?\d+\.?\d*$";
                    if (Regex.IsMatch(f_dong, regex) && Regex.IsMatch(f_bei, regex) && Regex.IsMatch(f_value, regex)) {
                        List<String> list = new List<String>();
                        list.Add(f_town);
                        list.Add(f_no);
                        list.Add(f_location);
                        list.Add(f_dong);
                        list.Add(f_bei);
                        list.Add(DateConvert.DateTimeToUnix(dateTime_f_buildtime.Value));
                        list.Add(f_value);
                        list.Add(f_maketype);
                        list.Add(f_makeperson);
                        list.Add(f_guanhutype);
                        list.Add(f_guanhuperson);
                        if (new MysqlOperate().ChangeDataToMysql(list, f_id)) {
                            MessageBox.Show("更新数据成功，右键单击刷新查看", "提示信息！");
                            this.Close();
                        } else {
                            MessageBox.Show("更新失败，请核对都提交！", "提示信息！");
                        }
                    } else {
                        MessageBox.Show("输入格式不正确，可能是东经，北纬，工程固定原值出错！", "提示信息！");
                    }
                } else {
                    MessageBox.Show("数据未填写完整无法导入文件，请填写完整后导入！", "提示信息！");
                }
            }
        }

        /// <summary>
        /// 取消更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_infoExit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
