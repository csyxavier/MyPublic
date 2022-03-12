using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSv
{
    public partial class formCart : Form
    {
        public formCart()
        {
            InitializeComponent();
        }

        private void formCart_Load(object sender, EventArgs e)
        {
            
            List<Label> ListOfLabel = new List<Label>
            {
               label1,label2,label3,label4,label5
            };
            List<FlowLayoutPanel> ListFlowPanel = new List<FlowLayoutPanel>
            {
                flowLayoutPanel1,flowLayoutPanel2,flowLayoutPanel3,flowLayoutPanel4,flowLayoutPanel5
            };

            
            for (int i = 0; i < Cart.itemInfo.Count; i++)
            {
                ListOfLabel[i].Text = Cart.itemInfo[i];
                ListFlowPanel[i].Visible = true;
                ListFlowPanel[i].Tag = i;//刪資料用
            }
            lableTotal.Text = "總計：$"+Cart.cartTotal.ToString();
        }

        private void btnToJoblist_Click(object sender, EventArgs e)
        {
            this.Close();
            Cart.itemInfo.Clear();
            Cart.itemPrice.Clear();
            Cart.cartTotal = 0;
            ListBuild.countOrder = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cart.cartTotal -= Cart.itemPrice[Convert.ToInt32(flowLayoutPanel1.Tag)];
            Cart.itemInfo.RemoveAt(Convert.ToInt32(flowLayoutPanel1.Tag));
            Cart.itemPrice.RemoveAt(Convert.ToInt32(flowLayoutPanel1.Tag));
            lableTotal.Text = "總計：$" + Cart.cartTotal.ToString();
            flowLayoutPanel1.Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cart.cartTotal -= Cart.itemPrice[Convert.ToInt32(flowLayoutPanel2.Tag)];
            Cart.itemInfo.RemoveAt(Convert.ToInt32(flowLayoutPanel2.Tag));
            Cart.itemPrice.RemoveAt(Convert.ToInt32(flowLayoutPanel2.Tag));
            lableTotal.Text = "總計：$" + Cart.cartTotal.ToString();
            flowLayoutPanel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cart.cartTotal -= Cart.itemPrice[Convert.ToInt32(flowLayoutPanel3.Tag)];
            Cart.itemInfo.RemoveAt(Convert.ToInt32(flowLayoutPanel3.Tag));
            Cart.itemPrice.RemoveAt(Convert.ToInt32(flowLayoutPanel3.Tag));
            lableTotal.Text = "總計：$" + Cart.cartTotal.ToString();
            flowLayoutPanel3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cart.cartTotal -= Cart.itemPrice[Convert.ToInt32(flowLayoutPanel4.Tag)];
            Cart.itemInfo.RemoveAt(Convert.ToInt32(flowLayoutPanel4.Tag));
            Cart.itemPrice.RemoveAt(Convert.ToInt32(flowLayoutPanel4.Tag));
            lableTotal.Text = "總計：$" + Cart.cartTotal.ToString();
            flowLayoutPanel4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cart.cartTotal -= Cart.itemPrice[Convert.ToInt32(flowLayoutPanel5.Tag)];
            Cart.itemInfo.RemoveAt(Convert.ToInt32(flowLayoutPanel5.Tag));
            Cart.itemPrice.RemoveAt(Convert.ToInt32(flowLayoutPanel5.Tag));
            lableTotal.Text = "總計：$" + Cart.cartTotal.ToString();
            flowLayoutPanel5.Visible = false;
        }

       
    }
}
