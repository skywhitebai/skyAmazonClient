using FBAInventoryServiceMWS.Model;
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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
         new InventoryService().syn(AppConstant.currentUserShop);
        
        }
    }
}
