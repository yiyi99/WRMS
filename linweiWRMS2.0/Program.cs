using linweiWRMS.DBHelper;
using linweiWRMS2._0.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linweiWRMS2._0 {
    static class Program {
        //初始化项目类型
        public static int type = 0;
        public static String globalPwd = "";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            bool createNew;
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out createNew)) {
                if (createNew) {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new LoginForm());
                } else {
                    MessageBox.Show("该程序己启动运行,无法启动新的实例","警告提示！");
                }
            }
        }
    }
}
