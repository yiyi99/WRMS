using linweiWRMS.DBHelper;
using linweiWRMS.Entity;
using linweiWRMS2._0.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linweiWRMS2._0.DBHelper {
    /// <summary>
    /// 数据库操作类
    /// </summary>
    class MysqlOperate {

        /// <summary>
        /// 左侧项目查询操作
        /// </summary>
        /// <param name="p_id"></param>
        /// <returns></returns>
        public BindingList<File> SelectFilesFromProject(String where) {
            BindingList<File> files = new BindingList<File>();
            MySqlConnection con = MysqlHelper.Connection();
            MysqlHelper mh = new MysqlHelper();
            mh.OpenConnection();
            String sql = "select f_id,f_town,f_no,f_name,f_location,f_dong,f_bei,f_buildtime,f_value,f_maketype,f_makeperson,f_guanhutype,f_guanhuperson ,f_uptime from file where "+where;
            MySqlCommand msc = new MySqlCommand(sql, con);
            MySqlDataReader mdr = msc.ExecuteReader(CommandBehavior.CloseConnection);
            int r = 0;
            while (mdr.Read()) {
                File file = new File();
                file.F_id = mdr.GetInt32("f_id");
                file.F_town= mdr.GetString("f_town");
                file.F_no = mdr.GetString("f_no");
                file.F_name = mdr.GetString("f_name");
                file.F_location = mdr.GetString("f_location");
                file.F_dong = mdr.GetInt32("f_dong");
                file.F_bei = mdr.GetInt32("f_bei");
                file.F_buildtime = DateConvert.TimeFormat(mdr.GetString("f_buildtime"), "yyyy年MM月dd日");
                file.F_value = mdr.GetFloat("f_value");
                file.F_maketype = mdr.GetString("f_maketype");
                file.F_makeperson = mdr.GetString("f_makeperson");
                file.F_guanhutype = mdr.GetString("f_guanhutype");
                file.F_guanhuperson = mdr.GetString("f_guanhuperson");
                file.F_uptime = DateConvert.TimeFormat(mdr.GetString("f_uptime"),"yyyy年MM月dd日");
                files.Add(file);
                r++;
            }
            mh.CloseConnection();
            return files;
        }

        /// <summary>
        /// 导入文件到系统
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertDataToMysql(List<String> list){
            MySqlConnection con=null;
            MysqlHelper mh=null;
            MySqlCommand msc=null;
            try {
                //接收数据
                int p_id = Program.type;
                String f_town = list[0].ToString();
                String f_no = list[1].ToString();
                String f_name = list[2].ToString();
                String f_location = list[3].ToString();
                int f_dong = int.Parse(list[4].ToString());
                int f_bei = int.Parse(list[5].ToString());
                String f_buildtime = list[6].ToString();
                float f_value = float.Parse(list[7].ToString());
                String f_maketype = list[8].ToString();
                String f_makeperson = list[9].ToString();
                String f_guanhutype = list[10].ToString();
                String f_guanhuperson = list[11].ToString();
                String f_uptime = DateConvert.NowTimeToUnix();
                //数据库操作
                con= MysqlHelper.Connection();
                mh = new MysqlHelper();
                mh.OpenConnection();
                String sql = "insert into file(p_id,f_town,f_no,f_name,f_location,f_dong,f_bei,f_buildtime,f_value,f_maketype,f_makeperson,f_guanhutype,f_guanhuperson ,f_uptime) values("+p_id+",'"+f_town+"','"+f_no+"','"+f_name+"','"+f_location+"',"+f_dong+","+f_bei+",'"+f_buildtime+"',"+f_value+",'"+f_maketype+"','"+f_makeperson+"','"+f_guanhutype+"','"+f_guanhuperson+"','"+f_uptime+"')";
                msc = new MySqlCommand(sql,con);
                msc.ExecuteNonQuery();
            } catch (Exception e) {
                return false;
            } finally {
                mh.CloseConnection();
            }
            return true;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool ChangeDataToMysql(List<String> list,int f_id){
            MySqlConnection con=null;
            MysqlHelper mh=null;
            MySqlCommand msc=null;
            try {
                //接收数据
                String f_town = list[0].ToString();
                String f_no = list[1].ToString();
                String f_location = list[2].ToString();
                int f_dong = int.Parse(list[3].ToString());
                int f_bei = int.Parse(list[4].ToString());
                String f_buildtime = list[5].ToString();
                float f_value = float.Parse(list[6].ToString());
                String f_maketype = list[7].ToString();
                String f_makeperson = list[8].ToString();
                String f_guanhutype = list[9].ToString();
                String f_guanhuperson = list[10].ToString();
                String f_uptime = DateConvert.NowTimeToUnix();
                //数据库操作
                con= MysqlHelper.Connection();
                mh = new MysqlHelper();
                mh.OpenConnection();
                String sql = "update file set f_town='" + f_town + "',f_no='" + f_no + "',f_location='" + f_location + "',f_dong=" + f_dong + ",f_bei=" + f_bei + ",f_buildtime='" + f_buildtime + "',f_value=" + f_value + ",f_maketype='" + f_maketype + "',f_makeperson='" + f_makeperson + "',f_guanhutype='" + f_guanhutype + "',f_guanhuperson='" + f_guanhuperson + "',f_uptime='" + f_uptime + "' where f_id='"+f_id+"'";
                msc = new MySqlCommand(sql,con);
                msc.ExecuteNonQuery();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            } finally {
                mh.CloseConnection();
            }
            return true;
        }

        /// <summary>
        /// 获取导出模板文件名
        /// </summary>
        /// <returns></returns>
        public String GetProjectName() {
            String res = null;
            MySqlConnection con = MysqlHelper.Connection();
            MysqlHelper mh = new MysqlHelper();
            mh.OpenConnection();
            MySqlCommand msc = new MySqlCommand("select p_name from project where p_id="+Program.type, con);
            MySqlDataReader mdr = msc.ExecuteReader(CommandBehavior.CloseConnection);
            if (mdr.Read()) {
                res= mdr.GetString("p_name");
            }
            mh.CloseConnection();
            return res;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="f_id"></param>
        /// <returns></returns>
        public bool DeleteDateFromMysql(int f_id) {
            MySqlConnection con = null;
            MysqlHelper mh = null;
            MySqlCommand msc = null;
            try {
                //数据库操作
                con = MysqlHelper.Connection();
                mh = new MysqlHelper();
                String sql = "delete from picture where f_id=" + f_id + " ;delete from file where f_id='" + f_id + "';";
                mh.OpenConnection();
                msc = new MySqlCommand(sql, con);
                msc.ExecuteNonQuery();
            } catch (Exception e) {
                return false;
            } finally {
                mh.CloseConnection();
            }
            return true;
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public bool ChangePwd(String newPwd) {
            MysqlHelper mh = new MysqlHelper();
            try {
                MySqlConnection con = MysqlHelper.Connection();
                mh.OpenConnection();
                MySqlCommand msc = new MySqlCommand("update user set u_pwd='" + newPwd + "' where u_id=1", con);
                msc.ExecuteNonQuery();
            } catch(Exception e) {
                return false;
            } finally {
                mh.CloseConnection();
            }
            return true;
        }

        /// <summary>
        /// 查看单条记录
        /// </summary>
        /// <param name="f_id"></param>
        /// <returns></returns>
        public String[] SelectOneRow(int f_id) {
            MySqlConnection con = MysqlHelper.Connection();
            MysqlHelper mh = new MysqlHelper();
            mh.OpenConnection();
            String sql = "select f_town,f_no,f_name,f_location,f_dong,f_bei,f_buildtime,f_value,f_maketype,f_makeperson,f_guanhutype,f_guanhuperson ,f_uptime from file where f_id='" + f_id+"'";
            MySqlCommand msc = new MySqlCommand(sql, con);
            MySqlDataReader mdr = msc.ExecuteReader(CommandBehavior.CloseConnection);
            String[] oneRow=null;
            if (mdr.Read()) {
                oneRow = new String[13];
                oneRow[0] = mdr.GetString("f_town");
                oneRow[1] = mdr.GetString("f_no");
                oneRow[2] = mdr.GetString("f_name");
                oneRow[3] = mdr.GetString("f_location");
                oneRow[4] = mdr.GetInt32("f_dong").ToString();
                oneRow[5] = mdr.GetInt32("f_bei").ToString();
                oneRow[6] = mdr.GetFloat("f_value").ToString();
                oneRow[7] = mdr.GetString("f_maketype");
                oneRow[8] = mdr.GetString("f_makeperson");
                oneRow[9] = mdr.GetString("f_guanhutype");
                oneRow[10] = mdr.GetString("f_guanhuperson");
            }
            mh.CloseConnection();
            return oneRow;
        }

        /// <summary>
        /// 获取所有对应文件的图片
        /// </summary>
        /// <param name="f_id"></param>
        /// <returns></returns>
        public List<String> GetPictures(int f_id) {
            MySqlConnection con = MysqlHelper.Connection();
            MysqlHelper mh = new MysqlHelper();
            mh.OpenConnection();
            String sql = "select pic_name from picture where f_id=" + f_id;
            MySqlCommand msc = new MySqlCommand(sql, con);
            MySqlDataReader mdr = msc.ExecuteReader(CommandBehavior.CloseConnection);
            List<String> pictures = new List<String>();
            while (mdr.Read()) {
                pictures.Add(mdr.GetString("pic_name"));
            }
            mh.CloseConnection();
            return pictures;
        }

        /// <summary>
        /// 返回所有图片对应的id
        /// </summary>
        /// <param name="f_id"></param>
        /// <returns></returns>
        public List<int> GetPicturesId(int f_id) {
            MySqlConnection con = MysqlHelper.Connection();
            MysqlHelper mh = new MysqlHelper();
            mh.OpenConnection();
            String sql = "select pic_id from picture where f_id=" + f_id;
            MySqlCommand msc = new MySqlCommand(sql, con);
            MySqlDataReader mdr = msc.ExecuteReader(CommandBehavior.CloseConnection);
            List<int> picturesId = new List<int>();
            while (mdr.Read()) {
                picturesId.Add(mdr.GetInt16("pic_id"));
            }
            mh.CloseConnection();
            return picturesId;
        }

        /// <summary>
        /// 通过图片表的f_no返回f_id的值
        /// </summary>
        /// <param name="f_no"></param>
        /// <returns></returns>
        public int GetF_IDFromF_NO(String f_no) {
            MySqlConnection con = MysqlHelper.Connection();
            MysqlHelper mh = new MysqlHelper();
            mh.OpenConnection();
            String sql = "select f_id from file where f_no='" + f_no+"'";
            MySqlCommand msc = new MySqlCommand(sql, con);
            MySqlDataReader mdr = msc.ExecuteReader(CommandBehavior.CloseConnection);
            int f_id = 0;
            if (mdr.Read()) {
                f_id= mdr.GetInt16("f_id");
            }
            mh.CloseConnection();
            return f_id;
        }

        /// <summary>
        /// 上传图片到系统
        /// </summary>
        /// <param name="f_id"></param>
        /// <param name="pic_name"></param>
        /// <returns></returns>
        public Boolean InsertPictureToDB(int f_id,String pic_name) {
            MySqlConnection con = null;
            MysqlHelper mh = null;
            MySqlCommand msc = null;
            try {
                con = MysqlHelper.Connection();
                mh = new MysqlHelper();
                mh.OpenConnection();
                String sql = "insert into picture(f_id,pic_name) values(" + f_id + ",'" + pic_name + "')";
                msc = new MySqlCommand(sql, con);
                msc.ExecuteNonQuery();
            } catch (Exception e) {
                return false;
            } finally {
                mh.CloseConnection();
            }
            return true;
        }

        /// <summary>
        /// 删除当前图片
        /// </summary>
        /// <param name="pic_id"></param>
        /// <returns></returns>
        public Boolean DeletePictureFromDB(int pic_id) {
            MySqlConnection con = null;
            MysqlHelper mh = null;
            MySqlCommand msc = null;
            try {
                //数据库操作
                con = MysqlHelper.Connection();
                mh = new MysqlHelper();
                mh.OpenConnection();
                String sql = "delete from picture where pic_id=" + pic_id;
                msc = new MySqlCommand(sql, con);
                msc.ExecuteNonQuery();
            } catch (Exception e) {
                return false;
            } finally {
                mh.CloseConnection();
            }
            return true;
        }
    }
}
