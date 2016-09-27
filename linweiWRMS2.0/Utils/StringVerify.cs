using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linweiWRMS2._0.Utils {
    /// <summary>
    /// 字符串验证类
    /// </summary>
    class StringVerify {
        public static Boolean FileNameIsSame(String path,String name) {
            String newName=Path.GetFileNameWithoutExtension(path);
            if (newName.Trim().Equals(name.Trim())) {
                return true;
            }
            return false;
        }
    }
}
