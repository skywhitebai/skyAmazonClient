using skyAmazonClient.Entity;
using skyAmazonClient.util;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            init();
        }
        void init()
        {
            lbCurrentUserInfo.Text = "用户名:" + AppConstant.currentUserInfo.UserName + "  公司名:" + AppConstant.currentUserShop.ShopName;
            initOrderTask();
            initInventoryTask();
            initLvTask();
        }

        private void initLvTask()
        {
            AppConstant.threadBindLvTask = new Thread(
               bindLvTask);
            AppConstant.threadBindLvTask.IsBackground = true;
            AppConstant.threadBindLvTask.Start();
        }
        void bindLvTask()
        {
            while (true)
            {
                List<SynTask> list = new List<SynTask>();
                list.Add(AppConstant.SynTaskInfo.OrderTask);
                list.Add(AppConstant.SynTaskInfo.InventoryTask);
                lvTask.Items.Clear();
                foreach (SynTask synTask in list)
                {
                    ListViewItem lvi = new ListViewItem(synTask.TaskName);
                    lvi.SubItems.Add(DateTimeUtils.timeToStr(synTask.LastExecuteTime));
                    lvi.SubItems.Add(synTask.ExecuteTimes.ToString());
                    lvi.SubItems.Add(synTask.SynDataNumber.ToString());
                    lvi.SubItems.Add(synTask.Status);
                    if (synTask.DealInfoList.Count > 0)
                    {
                        lvi.SubItems.Add(synTask.DealInfoList[synTask.DealInfoList.Count - 1]);
                    }
                    lvTask.Items.Add(lvi);
                }
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }            
        }

        private void initInventoryTask()
        {
            SynTask inventoryTask = new SynTask();
            inventoryTask.TaskName = AppConstant.synInventoryTaskName;
            inventoryTask.ExecuteTimes = 0;
            inventoryTask.SynDataNumber = 0;
            inventoryTask.Status = SynTask.statusEnable;
            AppConstant.SynTaskInfo.InventoryTask = inventoryTask;
            inventoryTask.ExecuteThread = SynTasks.InventorySynTask.getThreadTask();
            inventoryTask.ExecuteThread.Start();
        }

        private void initOrderTask()
        {
            SynTask orderTask = new SynTask();
            orderTask.TaskName = AppConstant.synOrderTaskName; 
            orderTask.ExecuteTimes = 0;
            orderTask.SynDataNumber = 0;
            orderTask.Status = SynTask.statusEnable;
            AppConstant.SynTaskInfo.OrderTask = orderTask;
            orderTask.ExecuteThread = SynTasks.OrderSynTask.getThreadTask();
            orderTask.ExecuteThread.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("确定退出吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.ExitThread(); 
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void lvTask_DoubleClick(object sender, EventArgs e)
        {
            var items = this.lvTask.SelectedItems;
            if (items.Count == 0)
            {
                return;
            }
            ListViewItem item = items[0];
            String taskName=item.SubItems[0].Text;
            DealInfoForm dealInfoForm = new DealInfoForm(taskName);
            dealInfoForm.StartPosition = FormStartPosition.CenterParent;
            dealInfoForm.ShowDialog();
        }       
    }
}
