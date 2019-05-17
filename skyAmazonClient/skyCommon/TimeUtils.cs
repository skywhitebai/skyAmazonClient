using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace skyCommon
{
    public static class TimeUtils
    {
        /// <summary>
        /// 字符串转换为时间（yyyy-MM-dd）
        /// </summary>
        /// <param name="timeStr"></param>
        /// <returns></returns>
        public static DateTime getDateTime(string timeStr){
            DateTime dateTime=new DateTime();
            if (!DateTime.TryParse(timeStr, out dateTime))
            {
                throw new Exception(timeStr+"时间转换失败");
            }
            return dateTime;
        }
    }
}
