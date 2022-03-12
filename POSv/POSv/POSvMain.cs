using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSv
{
    public partial class POSvMain : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";

        public POSvMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
         
        }

        private void POSvMain_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";//資料庫來源本機。+@不處理特殊字元e.g.\
            scsb.InitialCatalog = "pos";
            scsb.IntegratedSecurity = true;//整合模式
            myDBConnectionString = scsb.ToString();

        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            //
            List<Control> ListOfButtons = new List<Control>
            {
               button1,button2,button3,button4,button5,button6,button7,button8,button9,button10,
                button11,button12,button13,button14,button15,button16,button17,button18,button19,button20,
                button21,button22,button23,button24,button25,button26,button27,button28,button29,button30
            };
            //for (int i = 0; i < 30; i++)
            //{
            //    ListOfButtons[i].Text = "(待上架)" + (i + 1);
            //    ListOfButtons[i].Visible = true;
            //}

            //
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();     //開啟連線
            string strSQL = "select pdtName from Product";
            SqlCommand cmd = new SqlCommand(strSQL, con); //要有sql命令和連線物件
            SqlDataReader reader = cmd.ExecuteReader();

            string strMsg = "";
            int j = 0;
            while (reader.Read())//有讀到資料就傳true
            {
                ListOfButtons[j].Text = $"{reader["pdtName"]}";
                ListOfButtons[j].Enabled = true;
                ListOfButtons[j].Visible = true;
                j += 1;
            }

            strMsg += "已載入資料庫\n資料筆數：" + j.ToString();

            reader.Close();
            con.Close();

            MessageBox.Show(strMsg);

        }

        private void btnJob_Click(object sender, EventArgs e)
        {
            jobList Job = new jobList();
            Job.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            dailyReport Rp = new dailyReport();
            Rp.ShowDialog();
        }

        private void btnAdm_Click(object sender, EventArgs e)
        {
            formAdmin Adm = new formAdmin();
            Adm.ShowDialog();
        }

        private void txtCart_Click(object sender, EventArgs e)
        {
            formCart formCart = new formCart();
            formCart.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MenuToAdd.menuToAdd = button.Text;
            addProduct addP = new addProduct();
            addP.ShowDialog();
        }

       
    }
}
