using linweiWRMS;
using linweiWRMS.DBHelper;
using linweiWRMS.Entity;
using linweiWRMS2._0.DBHelper;
using linweiWRMS2._0.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linweiWRMS2._0 {
    public partial class IndexForm : Form {
        //AutoSizeFormClass asc = new AutoSizeFormClass();
        public static BindingList<File> files=null;

        /// <summary>
        /// 入口
        /// </summary>
        public IndexForm() {
            InitializeComponent();
            //初始化表格
            InitResourse();
        }

        /// <summary>
        /// 显示窗口时初始化资源
        /// </summary>
        public void InitResourse() {
            //初始化表格大小
            //this.dataGridView1.ColumnCount = 14;
            //this.dataGridView1.RowCount = 50;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            this.dataGridView1.Columns["Column17"].Visible = false;
            this.dataGridView1.Columns[0].Width = 47;
            this.dataGridView1.Columns[1].Width = 40;
            this.dataGridView1.Columns[2].Width = 100;
            this.dataGridView1.Columns[3].Width = 170;
            this.dataGridView1.Columns[4].Width = 150;
            this.dataGridView1.Columns[5].Width = 100;
            this.dataGridView1.Columns[6].Width = 40;
            this.dataGridView1.Columns[7].Width = 40;
            this.dataGridView1.Columns[9].Width = 100;
            this.dataGridView1.Columns[10].Width = 80;
            this.dataGridView1.Columns[11].Width = 80;
            this.dataGridView1.Columns[12].Width = 80;
            this.dataGridView1.Columns[13].Width = 180;
            this.dataGridView1.Columns[15].Width = 50;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            int SH=Screen.PrimaryScreen.Bounds.Height;
            flowLayoutPanel3.Width = SW - flowLayoutPanel1.Width - 11;
            flowLayoutPanel3.Height = SH - panel_title.Height-71;
            flowLayoutPanel1.Height = flowLayoutPanel3.Height;
            dataGridView1.Width = flowLayoutPanel3.Width-1;
            dataGridView1.Height = flowLayoutPanel3.Height-48;
            panel_title.Width = SW-17;
            pictureBox_left.Height = flowLayoutPanel1.Height - 629;
            panel_bottom.Width = panel_title.Width;
            pictureBox_welcome.Width = panel_title.Width-156;
            pictureBox_welcome.Height = SH - panel_title.Height - 76;
            label_currenttime.Text = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss");
        }

        /// <summary>
        /// 左侧项目通用函数，传入id值展示列表
        /// </summary>
        /// <param name="p_id"></param>
        public void common_Click(String p_id) {
            flowLayoutPanel5.Visible = true;
            dataGridView1.Visible = true;
            pictureBox_welcome.Visible = false;
            GetFiles("p_id="+p_id);
            if (files.Count == 0) {
                MessageBox.Show("当前工程无项目，请添加！","系统提示！");
            }
        }

        /// <summary>
        /// 对返回的Files进行处理
        /// </summary>
        /// <param name="p_id"></param>
        private void GetFiles(String where) {
            files = null;
            MysqlOperate mo = new MysqlOperate();
            files = mo.SelectFilesFromProject(where);
            //排序
            default_Sort();
            this.dataGridView1.DataSource = files;
            this.dataGridView1.Refresh();
            for (int i = 0; i < files.Count; i++) {
                dataGridView1.Rows[i].Cells[1].Value = i + 1;
                dataGridView1.Rows[i].Cells[0].Value = " 选择";
                dataGridView1.Rows[i].Cells[15].Value = "查看..";
            } 
        }

        /// <summary>
        /// 点击抽水站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CSZ_Click(object sender, EventArgs e) {
            Program.type = 1;
            common_Click("1");
        }

        /// <summary>
        /// 点击地下水监测站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DXS_Click(object sender, EventArgs e) {
            Program.type = 2;
            common_Click("2");
        }

        /// <summary>
        /// 点击机电井
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_JDJ_Click(object sender, EventArgs e) {
            Program.type = 3;
            common_Click("3");
        }

        /// <summary>
        /// 点击集中供水1000方以上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_JZGSup_Click(object sender, EventArgs e) {
            Program.type = 4;
            common_Click("4");
        }

        /// <summary>
        /// 点击集中供水1000方以下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_JZGSdown_Click(object sender, EventArgs e) {
            Program.type = 5;
            common_Click("5");
        }

        /// <summary>
        /// 点击末级渠道
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MJQD_Click(object sender, EventArgs e) {
            Program.type = 6;
            common_Click("6");
        }

        /// <summary>
        /// 点击中小河流提防
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_HLDF_Click(object sender, EventArgs e) {
            Program.type = 7;
            common_Click("7");
        }

        /// <summary>
        /// 点击排水工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PS_Click(object sender, EventArgs e) {
            Program.type = 8;
            common_Click("8");
        }

        /// <summary>
        /// 点击水库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SK_Click(object sender, EventArgs e) {
            Program.type = 9;
            common_Click("9");
        }

        /// <summary>
        /// 点击淤积坝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_YJB_Click(object sender, EventArgs e) {
            Program.type = 10;
            common_Click("10");
        }

        /// <summary>
        /// 展示界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addFile_Click(object sender, EventArgs e) {
            new InputFileInfoForm().ShowDialog();
        }

        /// <summary>
        /// 默认按照辖区村镇排序
        /// </summary>
        private void default_Sort() {
            for (int i = 0; i < files.Count - 1; i++) {
                for (int j = i; j < files.Count; j++) {
                    if (files[i].F_town.CompareTo(files[j].F_town) < 0) {
                        File f = null;
                        f = files[i];
                        files[i] = files[j];
                        files[j] = f;
                    }
                }
            }
        }

        /// <summary>
        /// 按建设日期排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_timeSort_Click(object sender, EventArgs e) {
            for (int i = 0; i < files.Count - 1; i++) {
                for (int j = i; j < files.Count; j++) {
                    if (DateConvert.UnixToDateTime(files[i].F_buildtime).CompareTo(DateConvert.UnixToDateTime(files[j].F_buildtime)) < 0) {
                        File f = null;
                        f = files[i];
                        files[i] = files[j];
                        files[j] = f;
                    }
                }
            }
        }

        /// <summary>
        /// 根据项目号排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fno_score_Click(object sender, EventArgs e) {
            for (int i = 0; i < files.Count - 1; i++) {
                for (int j = i; j < files.Count; j++) {
                    if (files[i].F_no.CompareTo(files[j].F_no)<0) {
                        File f = null;
                        f = files[i];
                        files[i] = files[j];
                        files[j] = f;
                    }
                }
            }
        }

        /// <summary>
        /// 导出模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_temp_Click(object sender, EventArgs e) {
            SaveFileDialog sf = new SaveFileDialog();
            String fileName=new MysqlOperate().GetProjectName();
            sf.FileName = fileName + "-(" + new Random().Next(100, 1000) + ")" + "（模板）.xlsx";
            sf.Filter = "EXCLE表格|*.xls*";
            sf.RestoreDirectory = true;
            if (sf.ShowDialog() == DialogResult.OK) {
                //获得文件路径
                string saveFilePath = sf.FileName.ToString();
                bool isTrue = new FileOperate().FileCopy(@"Data\temps\" + Program.type + ".xlsx", saveFilePath);
                if (isTrue) {
                    MessageBox.Show("导出成功！", "提示");
                } else {
                    MessageBox.Show("导出失败，目标路径下文件已存在！", "提示");
                }
            }
        }

        /// <summary>
        /// 全部导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_outAll_Click(object sender, EventArgs e) {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "全部工程文件" + Program.type + "-(" + new Random().Next(100, 1000) + ")";
            sf.Filter = "全部文件（All）|*";
            sf.RestoreDirectory = true;
            if (sf.ShowDialog() == DialogResult.OK) {
                //获得文件路径
                string saveFilePath = sf.FileName.ToString();
                String path = "";
                int type=Program.type;
                if (type == 10) {
                    path = @"Data\project\010";
                } else {
                    path = @"Data\project\00"+type;
                }
                bool isTrue = new FileOperate().DirectoryCopy(path, saveFilePath);
                if (isTrue) {
                    MessageBox.Show("导出成功！", "提示");
                } else {
                    MessageBox.Show("导出失败！", "提示");
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, EventArgs e) {
            String mainWhere=comboBox_search.Text.Trim();
            if (mainWhere.Equals("请选择...")) {
                MessageBox.Show("请选择选项进行查询！","提示信息！");
            } else {
                String keyWords=text_search.Text.Trim();
                String field = "";
                switch (mainWhere) {
                    case "编号": field = "f_no"; break;
                    case "辖区村镇": field = "f_town"; break;
                    case "工程名称": field = "f_name"; break;
                    case "地理位置": field = "f_location"; break;
                }
                GetFiles(field.Trim()+" like '%"+ keyWords +"%'");
                if (files.Count == 0) {
                    MessageBox.Show("未搜索到项目文件，请确认后搜索！", "系统提示！");
                }
            } 
        }


        /// <summary>
        /// 为操作添加点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //判断下单元格内容是不是第一列
            if (dataGridView1.CurrentRow != null) {
                int row = dataGridView1.CurrentRow.Index;
                int f_id = int.Parse(dataGridView1.Rows[row].Cells["Column17"].Value.ToString());
                String f_name = dataGridView1.Rows[row].Cells["Column4"].Value.ToString().Trim();
                if (e.ColumnIndex == 0) {
                    new RowOperate(f_id, f_name).ShowDialog();
                } else if (e.ColumnIndex == 15) {
                    new ShowPictureForm(f_id).ShowDialog();
                }
            }
        }

        /// <summary>
        /// 安全退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_exit_Click(object sender, EventArgs e) {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 点击右上角的叉号关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexForm_FormClosing(object sender, FormClosingEventArgs e) {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_change_pwd_Click(object sender, EventArgs e) {
            new ChangePwdForm().ShowDialog();
        }

        /// <summary>
        /// 显示系统当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_now_Tick(object sender, EventArgs e) {
            label_currenttime.Text = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss");
        }

        /// <summary>
        /// 更换主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            String[] fileNames=new FileOperate().AllFile(@"Skins\");
            foreach (String fileName in fileNames) {
                contextMenuStrip_theme.Items.Add(fileName);
            }
            Point p = new Point(this.Width/4, 0);
            contextMenuStrip_theme.Show(p);
        }

        /// <summary>
        /// 加载主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_theme_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            skinEngine_theme.SkinFile = @"Skins\" + e.ClickedItem.Text;
        }

        /// <summary>
        /// 展示帮助文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_help_Click(object sender, EventArgs e) {
            Process.Start(@"Data\other\help.chm");
        }

        /// <summary>
        /// 查看系统信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_system_Click(object sender, EventArgs e) {
            new SystemInfoForm().ShowDialog(); 
        }

        /// <summary>
        /// 实时显示当前的项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_ChangeColor_Tick(object sender, EventArgs e) {
            switch (Program.type) {
                case 1:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    btn_DXS.BackColor = Color.White;
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSdown.BackColor = Color.White;
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_PS.BackColor = Color.White;
                    btn_SK.BackColor = Color.White;
                    btn_YJB.BackColor = Color.White;
                    break;
                case 2:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_DXS.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSdown.BackColor = Color.White;
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_PS.BackColor = Color.White;
                    btn_SK.BackColor = Color.White;
                    btn_YJB.BackColor = Color.White;
                    break;
                case 3:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_DXS.BackColor = Color.White;
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSdown.BackColor = Color.White;
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_PS.BackColor = Color.White;
                    btn_SK.BackColor = Color.White;
                    btn_YJB.BackColor = Color.White;
                    break;
                case 4:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_DXS.BackColor = Color.White;
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    btn_JZGSdown.BackColor = Color.White;
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_PS.BackColor = Color.White;
                    btn_SK.BackColor = Color.White;
                    btn_YJB.BackColor = Color.White;
                    break;
                case 5:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_DXS.BackColor = Color.White;
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSdown.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_PS.BackColor = Color.White;
                    btn_SK.BackColor = Color.White;
                    btn_YJB.BackColor = Color.White;
                    break;
                case 6:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_DXS.BackColor = Color.White;
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSdown.BackColor = Color.White;
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_PS.BackColor = Color.White;
                    btn_SK.BackColor = Color.White;
                    btn_YJB.BackColor = Color.White;
                    break;
                case 7:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_DXS.BackColor = Color.White;
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSdown.BackColor = Color.White;
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    btn_PS.BackColor = Color.White;
                    btn_SK.BackColor = Color.White;
                    btn_YJB.BackColor = Color.White;
                    break;
                case 8:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_DXS.BackColor = Color.White;
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSdown.BackColor = Color.White;
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_PS.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    btn_SK.BackColor = Color.White;
                    btn_YJB.BackColor = Color.White;
                    break;
                case 9:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_DXS.BackColor = Color.White;
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSdown.BackColor = Color.White;
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_PS.BackColor = Color.White;
                    btn_SK.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    btn_YJB.BackColor = Color.White;
                    break;
                case 10:
                    btn_CSZ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_DXS.BackColor = Color.White;
                    btn_JDJ.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSup.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_JZGSdown.BackColor = Color.White;
                    btn_MJQD.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_HLDF.BackColor = Color.FromArgb(Convert.ToByte(245), Convert.ToByte(251), Convert.ToByte(252));
                    btn_PS.BackColor = Color.White;
                    btn_SK.BackColor = Color.White;
                    btn_YJB.BackColor = Color.FromArgb(Convert.ToByte(183), Convert.ToByte(183), Convert.ToByte(183));
                    break;
            }
        }

        private void contextMenuStrip_refresh_Click(object sender, EventArgs e) {
            GetFiles("p_id=" + Program.type); 
        }

        /// <summary>
        /// 主界面自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void IndexForm_Load(object sender, EventArgs e) {
        //   asc.controllInitializeSize(this);
        //}
    }
}
