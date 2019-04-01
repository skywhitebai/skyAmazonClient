using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient.Entity
{
    class CurrentUserInfo
    {
        private Int32? userId;

        public Int32? UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private String userName;

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private String mobile;

        public String Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        private String realName;

        public String RealName
        {
            get { return realName; }
            set { realName = value; }
        }

        private Int16? gender;

        public Int16? Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        private String loginToken;

        public String LoginToken
        {
            get { return loginToken; }
            set { loginToken = value; }
        }


    }
}
