using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient.util
{
    class DateTimeUtils
    {
        public static string timeToStr(DateTime? dateTime){
            if (dateTime == null)
            {
                return null;
            }
            return dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
