﻿using MarketplaceWebServiceOrders;
using MarketplaceWebServiceOrders.Model;
using skyAmazonClient.Entity;
using skyAmazonClient.Service;
using skyCommon;
using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private Shop shop;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String userName = txtUserName.Text;
            String password = txtPassword.Text;
            if (String.IsNullOrEmpty(userName))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            //登录获取loginToken
            String macAddress = GetSystemInfo.getMacAddr_Local();
            BaseResponse<CurrentUserInfo> loginResponse = AccountService.login(userName, password);
            if (!loginResponse.isSuccessd())
            {
                MessageBox.Show(loginResponse.Message);
                return;
            }
            //获取店铺信息
            BaseResponse<Shop> getCurrentUserShopResponse = ShopService.getCurrentUserShop();
            if (!getCurrentUserShopResponse.isSuccessd())
            {
                MessageBox.Show(getCurrentUserShopResponse.Message);
                return;
            }
            //AppConstant.sellerId = getCurrentUserShopResponse.Data.SellerId;
            //AppConstant.mwsAuthToken = getCurrentUserShopResponse.Data.MwsAuthToken;
            if(String.IsNullOrEmpty(getCurrentUserShopResponse.Data.SellerId)
                ||String.IsNullOrEmpty(getCurrentUserShopResponse.Data.MwsAuthToken)
                || String.IsNullOrEmpty(getCurrentUserShopResponse.Data.ShopMarketplaceId)
                )
            {
                MessageBox.Show("店铺信息不完整");
                return;
            }
            AppConstant.dealInfoAppend("开始同步数据");
            if (AppConstant.threadShowDealInfo != null)
            {
                AppConstant.threadShowDealInfo.Abort();
            }
            AppConstant.threadShowDealInfo = new Thread(new ThreadStart(
               showDealInfo));
            AppConstant.threadShowDealInfo.Start(); //启动线程
            shop = getCurrentUserShopResponse.Data;
            if (AppConstant.threadSynOrder != null)
            {
                AppConstant.threadSynOrder.Abort();
            }
            AppConstant.threadSynOrder = new Thread(new ThreadStart(
               synOrder));
            AppConstant.threadSynOrder.Start(); //启动线程

            
            
        }
        private void showDealInfo()
        {
           while(true){
               doShowDealInfo();
               Thread.Sleep(TimeSpan.FromSeconds(1));
           }
        }
        void doShowDealInfo()
        {
            StringBuilder sbDealInfo = new StringBuilder();
            foreach (String str in AppConstant.dealInfo)
            {
                sbDealInfo.Append(str).Append("\r\n");
            }
            txtDealInfo.Text = sbDealInfo.ToString();
        }
        private void synOrder()
        {
            while (true)
            {
                doSynOrder();
                Thread.Sleep(TimeSpan.FromMinutes(AppConstant.synOrderSleepTimeMinute));
            }
        }
        void doSynOrder()
        {
            //获取订单信息
            new OrderService().synOrder(shop);
            AppConstant.dealInfoAppend("同步结束等待" + AppConstant.synOrderSleepTimeMinute + "分钟");
        }
    }
}
