using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient.Entity
{
    class BaseResponse<T>
    {
        static string SUCCESS_CODE = "200";
        string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        String message;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }
        String detailMessage;

        public String DetailMessage
        {
            get { return detailMessage; }
            set { detailMessage = value; }
        }
        T data;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

    }
}
