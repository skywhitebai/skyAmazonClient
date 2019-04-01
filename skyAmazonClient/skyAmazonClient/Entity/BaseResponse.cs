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
        static string FAIL_CODE = "99";
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
        public Boolean isSuccessd()
        {
            if (SUCCESS_CODE.Equals(this.code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static BaseResponse<T> failMessage(String message)
        {
            BaseResponse<T> baseResponse = new BaseResponse<T>();
            baseResponse.Code = FAIL_CODE;
            baseResponse.Message = message;
            return baseResponse;
        }

    }
}
