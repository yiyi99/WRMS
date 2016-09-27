using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace linweiWRMS2._0.Utils {
    class ReturnStringMD5 {
        /// <summary>
        /// 返回MD5字符串
        /// </summary>
        /// <param name="baseString"></param>
        /// <returns></returns>
        public static String MD5String(String baseString) {
            //1、创建MD5对象
            MD5 md5 = new MD5CryptoServiceProvider();
            //2、将字符编码为一个字节序列
            byte[] data = System.Text.Encoding.Default.GetBytes(baseString);
            //3、计算data字节数组的哈希值
            byte[] md5data = md5.ComputeHash(data);
            //4、释放MD5对象中的所有资源
            md5.Clear();
            //5、创建字符存储器并初始化
            StringBuilder str = new StringBuilder();
            str.Append(string.Empty);
            //6、存储加密字符
            for (int i = 0; i < md5data.Length - 1; i++) {
                str.Append(md5data[i].ToString("x").PadLeft(2, '0'));
            }
            //7、返回经过MD5加密过后的字符串
            return str.ToString();
        }
    }
}
