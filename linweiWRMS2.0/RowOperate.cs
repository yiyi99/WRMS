using linweiWRMS2._0.DBHelper;
using linweiWRMS2._0.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linweiWRMS2._0 {
    public partial class RowOperate : Form {
        private int f_id; //获取行的f_no号
        private String f_name; //获取行文件的文件名

        /// <summary>
        /// 重写构造器
        /// </summary>
        /// <param name="f_id"></param>
        /// <param name="f_name"></param>
        public RowOperate(int f_id,String f_name) {
            InitializeComponent();
            this.f_id = f_id;
            this.f_name = f_name;
        }

        /// <summary>
        /// 点击查看/修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_check_Click(object sender, EventArgs e) {
            FileOperate fo=new FileOperate();
            String path=fo.SavePath(Program.type) + this.f_name.Trim() + ".";
            ProcessStartInfo psi=null;
            Process p=null;
            if (fo.FileExist(path+"xlsx")) {
                this.Close();
                psi = new ProcessStartInfo(path + "xlsx");
                p= new Process();
                p.StartInfo = psi;
                p.Start();
                this.Close();
            } else if (fo.FileExist(path + "xls")) {
                this.Close();
                psi = new ProcessStartInfo(path + "xls");
                p = new Process();
                p.StartInfo = psi;
                p.Start();
                this.Close();
            } else {
                MessageBox.Show("资源文件不存在，请导入资源！","提示信息!");
            }
        }

        /// <summary>
        /// 点击导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_export_Click(object sender, EventArgs e) {
            FileOperate fo = new FileOperate();
            String path = fo.SavePath(Program.type) + this.f_name + ".";
            String theType="";
            if (fo.FileExist(path + "xlsx")) {
                theType=".xlsx";
            } else if (fo.FileExist(path + "xls")) {
                theType=".xls";
            } else {
                MessageBox.Show("资源文件不存在，请先导入资源！", "提示信息!");
            }
            if (fo.FileExist(path + "xlsx") || fo.FileExist(path + "xls")) {
                SaveFileDialog sf = new SaveFileDialog();
                String fileName = this.f_name;
                sf.FileName = fileName+"-("+new Random().Next(100,1000)+")"+ theType;
                sf.Filter = "EXCLE表格|*.xls*";
                sf.RestoreDirectory = true;
                if (sf.ShowDialog() == DialogResult.OK) {
                    //获得文件路径
                    string saveFilePath = sf.FileName.ToString();
                    bool isTrue = fo.FileCopy(fo.SavePath(Program.type) + this.f_name+ theType, saveFilePath);
                    if (isTrue) {
                        MessageBox.Show("导出成功！", "提示");
                        this.Close();
                    } else {
                        MessageBox.Show("导出失败，目标目录下文件已存在！", "提示");
                    }
                }
            }
        }

        /// <summary>
        /// 点击删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e) {
            DialogResult dr = MessageBox.Show("确定删除此项目文件？删除后无法恢复", "提示信息！", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK) {
                    FileOperate fo = new FileOperate();
                    String path = fo.SavePath(Program.type) + this.f_name + ".";
                    String theType = "";
                    if (fo.FileExist(path + "xlsx")) {
                        theType = ".xlsx";
                    } else if (fo.FileExist(path + "xls")) {
                        theType = ".xls";
                    } else {
                        MessageBox.Show("资源文件不存在，无法删除！", "提示信息！");
                    }
                    if (fo.FileExist(path + "xlsx") || fo.FileExist(path + "xls")) {
                        String from = fo.SavePath(Program.type) + this.f_name + theType;
                        String to = fo.DelPath(Program.type) + ReturnStringMD5.MD5String(DateConvert.NowTimeToUnix()) + theType;
                        bool moveSuccess = new FileOperate().MoveFile(from, to);
                        if (moveSuccess && DeletePictureFromFile(this.f_id)) {
                            bool isTrue = new MysqlOperate().DeleteDateFromMysql(this.f_id);
                            if (isTrue) {
                                MessageBox.Show("删除文件成功,右键单击刷新查看", "提示信息！");
                                this.Close();
                            } else {
                                MessageBox.Show("删除文件失败,请重新删除", "提示信息！");
                            }
                        }
                } else {
                    MessageBox.Show("删除文件失败！", "提示信息！");
                }
            }
        }

        /// <summary>
        /// 删除指定文件下的所有图片
        /// </summary>
        /// <param name="f_no"></param>
        /// <returns></returns>
        private Boolean DeletePictureFromFile(int f_id) {
            try {
                MysqlOperate mo = new MysqlOperate();
                List<String> pictureList = mo.GetPictures(f_id);
                foreach (String name in pictureList) {
                    new FileOperate().DeleteFile(@"Data\picture\" + name);
                }
            } catch(Exception e) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 点击修改记录信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_changeinfo_Click(object sender, EventArgs e) {
            new ChangeFileInfoForm(f_id).ShowDialog();
            this.Close();
        }
    }
}
