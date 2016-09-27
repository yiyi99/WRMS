using linweiWRMS2._0.DBHelper;
using linweiWRMS2._0.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linweiWRMS2._0 {
    public partial class ShowPictureForm : Form {
        //存储图片
        List<String> pictures = null;
        //存储图片id
        List<int> picturesId = null;
        //记录当前位置
        int index = 0;
        //当前文件编号
        int f_id = 0;

        /// <summary>
        /// 初始化信息
        /// </summary>
        /// <param name="f_no"></param>
        public ShowPictureForm(int f_id) {
            InitializeComponent();
            MysqlOperate mo = new MysqlOperate();
            this.f_id = f_id;
            pictures = mo.GetPictures(f_id);
            picturesId = mo.GetPicturesId(f_id);
            int count=pictures.Count ;
            FileOperate fo=new FileOperate();
            foreach (String file in pictures) {
                fo.FileCopy(@"Data\picture\" + file, @"Data\moment\" + file);
            }
            if (count != 0) {
                kpImageViewer1.ImagePath = @"Data\moment\" + pictures[index];
            } else {
                MessageBox.Show("当前项目无图片，请先上传","提示");
            }
            label_picture_num.Text = count+"";
        }

        /// <summary>
        /// 上一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_previous_Click(object sender, EventArgs e) {
            if (index > 0) {
                index--;
                CommonShowPicture(this.f_id);
            } 
        }

        /// <summary>
        /// 下一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_next_Click(object sender, EventArgs e) {
            if (index < pictures.Count-1) {
                index++;
                CommonShowPicture(this.f_id);
            } 
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_picture_upload_Click(object sender, EventArgs e) {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|JPEG|*.jpeg";
            if (file.ShowDialog() == DialogResult.OK) {
                DialogResult dr = MessageBox.Show("确定导入图片到系统吗？", "提示信息！", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK) {
                    MysqlOperate mo = new MysqlOperate();
                    int f_id = this.f_id;
                    String base_pic_name = ReturnStringMD5.MD5String(DateConvert.NowTimeToUnix());
                    String fileName=base_pic_name+"."+new FileOperate().GetFex(file.FileName);
                    if (mo.InsertPictureToDB(f_id, fileName)) {
                        FileOperate fo=new FileOperate();
                        if (fo.FileCopy(file.FileName.Trim(), @"Data\picture\" + fileName) && fo.FileCopy(file.FileName.Trim(), @"Data\moment\" + fileName)) {
                            MessageBox.Show("上传成功", "提示信息！");
                            this.index = 0;
                            label_picture_num.Text = CommonShowPicture(this.f_id) + "";
                        } else {
                            MessageBox.Show("上传失败", "提示信息！");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_picture_delete_Click(object sender, EventArgs e) {
            DialogResult dr = MessageBox.Show("确定删除图片吗？", "提示信息！", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK) {
                FileOperate fo=new FileOperate();
                if (fo.DeleteFile(@"Data\picture\" + pictures[index])) {
                    if (new MysqlOperate().DeletePictureFromDB(picturesId[index])) {
                        MessageBox.Show("删除成功", "提示信息！");
                        this.index = 0;
                        label_picture_num.Text = CommonShowPicture(this.f_id) + "";
                    }
                } else {
                    MessageBox.Show("删除失败", "提示信息！");
                }
            }
        }

        /// <summary>
        /// 公共展示图片的函数
        /// </summary>
        /// <param name="f_no"></param>
        private int CommonShowPicture(int f_id) {
            pictures = null;
            picturesId = null;
            MysqlOperate mo = new MysqlOperate();
            pictures = mo.GetPictures(f_id);
            picturesId = mo.GetPicturesId(f_id);
            if (pictures.Count != 0) {
                kpImageViewer1.ImagePath = @"Data\moment\" + pictures[index];
            }
            return pictures.Count;
        }

        /// <summary>
        /// 当窗口关闭时清理临时文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPictureForm_FormClosed(object sender, FormClosedEventArgs e) {
            FileOperate fo=new FileOperate();
            String[] allFiles = fo.AllFile(@"Data\moment\");
            kpImageViewer1.Dispose();
            foreach(String file in allFiles){
                fo.DeleteFile(@"Data\moment\" + file);
            }
        } 
    }
}
