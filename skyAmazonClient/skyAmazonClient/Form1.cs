using MarketplaceWebServiceOrders;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skyAmazonClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test();
        }

        void test(){
            
             // TODO: Set the below configuration variables before attempting to run

            // Developer AWS access key replaceWithAccessKey
            string accessKey = "AKIAJA5JLNJESHZCDIKA";

            // Developer AWS secret key replaceWithSecretKey
            string secretKey = "QmfwJDGhNHG7Cm8fIslnK/3Mk9DTIolha/vaSoKs";

            // The client application name CSharpSampleCode
            string appName = "skyddt";

            // The client application version
            string appVersion = "1.0";

            // The endpoint for region service and version (see developer guide)
            // ex: https://mws.amazonservices.com replaceWithServiceURL
            string serviceURL = "https://mws.amazonservices.com";

            // Create a configuration object
            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig();
            config.ServiceURL = serviceURL;
            // Set other client connection configurations here if needed
            // Create the client itself
            MarketplaceWebServiceOrders.MarketplaceWebServiceOrders client = new MarketplaceWebServiceOrdersClient(accessKey, secretKey, appName, appVersion, config);

            MarketplaceWebServiceOrdersSample sample = new MarketplaceWebServiceOrdersSample(client);

            // Uncomment the operation you'd like to test here
            // TODO: Modify the request created in the Invoke method to be valid

            try 
            {
                IMWSResponse response = null;
                //response = sample.InvokeGetOrder();
                // response = sample.InvokeGetServiceStatus();
                 response = sample.InvokeListOrderItems();
                // response = sample.InvokeListOrderItemsByNextToken();
                //response = sample.InvokeListOrders();
                //response = sample.InvokeListOrdersByNextToken();
                Console.WriteLine("Response:");
                ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;
                // We recommend logging the request id and timestamp of every call.
                Console.WriteLine("RequestId: " + rhmd.RequestId);
                Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                string responseXml = response.ToXML();
                //string responseJson = JsonJavaScriptSerializer.ToJSON(response);
                string responseJson2 = JsonNewtonsoft.ToJSON(response);
                //Console.WriteLine(responseXml);
                //Console.WriteLine(responseJson);
                Console.WriteLine(responseJson2);
                //Console.WriteLine(response.ToJSON());                
            }
            catch (MarketplaceWebServiceOrdersException ex)
            {
                // Exception properties are important for diagnostics.
                ResponseHeaderMetadata rhmd = ex.ResponseHeaderMetadata;
                Console.WriteLine("Service Exception:");
                if(rhmd != null)
                {
                    Console.WriteLine("RequestId: " + rhmd.RequestId);
                    Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                }
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("StatusCode: " + ex.StatusCode);
                Console.WriteLine("ErrorCode: " + ex.ErrorCode);
                Console.WriteLine("ErrorType: " + ex.ErrorType);
                throw ex;
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
            String macAddress = GetSystemInfo.getMacAddr_Local();

            BaseResponse<CurrentUserInfo> baseResponse = AccountService.login(userName, password);

        }
    }
}
