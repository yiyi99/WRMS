using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linweiWRMS2._0.Utils {
    class DateConvert {
        /// <summary>
        /// 返回指定类型的时间格式
        /// </summary>
        /// <param name="longtime"></param>
        /// <returns></returns>
        public static String TimeFormat(String longtime,String format) {
            DateTime newDate = new DateTime(1970, 1, 1, 0, 0, 0, new DateTime().Kind).AddSeconds(long.Parse(longtime));
            String timestr = newDate.ToString(format);
            return timestr;
        }

        /// <summary>
        /// 将系统时间转化为Unix时间戳
        /// </summary>
        /// <returns></returns>
        public static String NowTimeToUnix() {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, new DateTime().Kind);
            String unixTime = (DateTime.Now - start).TotalSeconds.ToString().Substring(0, 10);
            return unixTime;
        }

        /// <summary>
        /// 将指定DateTime类型时间转换为Unix时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static String DateTimeToUnix(DateTime time) {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, new DateTime().Kind);
            String unixTime = (time - start).TotalSeconds.ToString().Substring(0);
            return unixTime;
        }

        /// <summary>
        /// 将Unix时间戳转化为DateTime类型
        /// </summary>
        /// <param name="unix"></param>
        /// <returns></returns>
        public static DateTime UnixToDateTime(String unix) {
            return DateTime.ParseExact(unix, "yyyy年MM月dd日", System.Globalization.CultureInfo.CurrentCulture);
        }
    }
}
