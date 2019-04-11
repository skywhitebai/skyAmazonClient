﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skyAmazonClient
{
    public partial class DealInfoForm : Form
    {
        String taskName;
        Thread threadShowDealInfo;
        public DealInfoForm(String taskName)
        {
            this.taskName = taskName;
            InitializeComponent();
            showDealInfo();
        }

        private void showDealInfo()
        {
            threadShowDealInfo = new Thread(doShowDealInfo);
            threadShowDealInfo.IsBackground = true;
            threadShowDealInfo.Start(); //启动线程
           
        }
        void doShowDealInfo()
        {
            StringBuilder sbDealInfo = new StringBuilder();
            List<String> dealInfo=null;
            switch (taskName)
            {
                case AppConstant.synOrderTaskName:
                    dealInfo=AppConstant.SynTaskInfo.OrderTask.DealInfoList;
                    break;
                case AppConstant.synInventoryTaskName:
                    dealInfo = AppConstant.SynTaskInfo.InventoryTask.DealInfoList;
                    break;
            }
            if (dealInfo != null)
            {
                foreach (String str in dealInfo)
                {
                    sbDealInfo.Append(str).Append("\r\n");
                }
                txtDealInfo.Text = sbDealInfo.ToString(); 
            }
                           
            Thread.Sleep(TimeSpan.FromSeconds(1));
            doShowDealInfo();
        }

        private void DealInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadShowDealInfo != null)
            {
                threadShowDealInfo.Abort();
            }
            this.Dispose();
        }
    }
}