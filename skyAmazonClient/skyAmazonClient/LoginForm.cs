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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skyAmazonClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.Text = "123";
            txtUserName.Text = "admin";
        }

        private void ckShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShowPassword.Checked)
            {
                //复选框被勾选，明文显示
                txtPassword.PasswordChar = new char();
            }
            else
            {
                //复选框被取消勾选，密文显示
                txtPassword.PasswordChar = '*';
            }
        }

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
            BaseResponse<CurrentUserInfo> loginResponse = AccountService.login(userName, password);
            if (!loginResponse.isSuccessd())
            {
                MessageBox.Show(loginResponse.Message);
                return;
            }
            AppConstant.currentUserInfo = loginResponse.Data;
            //获取店铺信息
            BaseResponse<Shop> getCurrentUserShopResponse = ShopService.getCurrentUserShop();
            if (!getCurrentUserShopResponse.isSuccessd())
            {
                MessageBox.Show(getCurrentUserShopResponse.Message);
                return;
            }
            if (String.IsNullOrEmpty(getCurrentUserShopResponse.Data.SellerId)
                || String.IsNullOrEmpty(getCurrentUserShopResponse.Data.MwsAuthToken)
                || String.IsNullOrEmpty(getCurrentUserShopResponse.Data.ShopMarketplaceId)
                )
            {
                MessageBox.Show("店铺信息不完整");
                return;
            }
            AppConstant.currentUserShop = getCurrentUserShopResponse.Data;
            //跳转主界面
            this.DialogResult = DialogResult.OK;
            this.Dispose();
            this.Close();
        }
    }
}
