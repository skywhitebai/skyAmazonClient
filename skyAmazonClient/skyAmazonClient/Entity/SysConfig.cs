using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient.Entity
{
    class SysConfig
    {
        private Int32 id;

        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private String keyName;

        public String KeyName
        {
            get { return keyName; }
            set { keyName = value; }
        }

        private String keyValue;

        public String KeyValue
        {
            get { return keyValue; }
            set { keyValue = value; }
        }

        private String remark;

        public String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

    }
}
