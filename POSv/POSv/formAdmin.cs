using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //ADO.net 元件

namespace POSv
{
    public partial class formAdmin : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<int> searchIDs = new List<int>(); //進階搜尋結果

        public formAdmin()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void formAdmin_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";//資料庫來源本機。+@不處理特殊字元e.g.\
            scsb.InitialCatalog = "pos";
            scsb.IntegratedSecurity = true;//整合模式
            myDBConnectionString = scsb.ToString();

            cboxType.Items.Add("品名");
            cboxType.Items.Add("M價格");
            cboxType.Items.Add("L價格");
            cboxType.SelectedIndex = 0;
            ShowDataGridView();
        }

        void ShowDataGridView()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "select ID,pdtName as '品名',pdtPriceM as 'M價格',pdtPriceL as 'L價格'from Product;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            reader.Close();
            con.Close();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            lboxResult.Items.Clear();
            searchIDs.Clear();
            string transSearchStr()
            {
                string str;
                if (cboxType.Text == "品名")
                {
                    str = "pdtName";
                }
                else if(cboxType.Text == "M價格")
                {
                    str = "pdtPriceM";
                }
                else
                {
                    str = "pdtPriceL";
                }
                return str;
            }

            string str欄位名稱 = transSearchStr();
            string str搜尋字串 = txtSearch.Text;

            if (str搜尋字串 != "")
            {
                string strSQL = "select * from Product where (" + str欄位名稱 + " like @SearchString); ";//不支援參數式
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchString", "%" + str搜尋字串 + "%");


                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    lboxResult.Items.Add($"{reader["pdtName"]}/{reader["pdtPriceM"]}/{reader["pdtPriceL"]}");
                    searchIDs.Add(Convert.ToInt32(reader["id"]));
                    i += 1;
                }

                if (i <= 0)
                {
                    MessageBox.Show("查無資料");
                }

            }
            else
            {
                MessageBox.Show("無輸入內容");
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            //todo 缺少價格防呆

            int intID = 0;
            Int32.TryParse(txtID.Text, out intID);
            try
            {
                if (intID > 0)
                {
                    if (txtPdtName.Text != "" && txtPrice1.Text != "" && txtPrice2.Text != "")
                    {
                        SqlConnection con = new SqlConnection(myDBConnectionString); //資料庫連線字串
                        con.Open();
                        string strSQL = "update Product set pdtName = @Name, pdtPriceM = @P1, pdtPriceL = @P2 where id = @searchID; ";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@searchID", intID);
                        cmd.Parameters.AddWithValue("@Name", txtPdtName.Text);
                        cmd.Parameters.AddWithValue("@P1", txtPrice1.Text);
                        cmd.Parameters.AddWithValue("@P2", txtPrice2.Text);

                        int rows = cmd.ExecuteNonQuery();//執行但不查詢
                        con.Close();
                        MessageBox.Show($"{rows}筆資料更新成功");
                        ShowDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("請填寫資料欄位");
                    }
                }
            }
            catch { MessageBox.Show("請檢查欄位正確性"); }
            
            
            
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            txtID.Text = txtPdtName.Text = txtPrice1.Text = txtPrice2.Text = "";
            btnSave.Enabled = true;
        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(txtID.Text, out intID);

            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "DELETE FROM Product WHERE id=@ID;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@ID", intID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                //刪除完就清空欄位
                txtID.Text = txtPdtName.Text = txtPrice1.Text = txtPrice2.Text = "";
                ShowDataGridView();

                MessageBox.Show($"刪除{rows}筆資料");
            }
        }

        private void lboxResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxResult.SelectedIndex >= 0)
            {
                int intID = searchIDs[lboxResult.SelectedIndex];

                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "select * from Product where id= @SearchID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchID", intID);//(參數名稱,參數字元)
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtID.Text = $"{reader["ID"]}";
                    txtPdtName.Text = $"{reader["pdtName"]}";
                    txtPrice1.Text = $"{reader["pdtPriceM"]}";
                    txtPrice2.Text = $"{reader["pdtPriceL"]}";

                }
                else
                {
                    MessageBox.Show("查無資料");
                }

            }
            else
            {
                MessageBox.Show("查無資料");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            if (e.RowIndex < 0)
            {
                return;
            }
            string strSelectID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int intSelectID = Convert.ToInt32(strSelectID);

            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "select * from Product where id= @SearchID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", intSelectID);//(參數名稱,參數字元)
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtID.Text = $"{reader["ID"]}";
                txtPdtName.Text = $"{reader["pdtName"]}";
                txtPrice1.Text = $"{reader["pdtPriceM"]}";
                txtPrice2.Text = $"{reader["pdtPriceL"]}";

            }
            else
            {
                MessageBox.Show("查無資料");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            //todo 缺少價格防呆

            if (txtPdtName.Text != "" && txtPrice1.Text != "" && txtPrice2.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString); //資料庫連線字串
                    con.Open();
                    string strSQL = "insert into Product values(@Name, @P1,@P2);";
                    SqlCommand cmd = new SqlCommand(strSQL, con);

                    cmd.Parameters.AddWithValue("@Name", txtPdtName.Text);
                    cmd.Parameters.AddWithValue("@P1", txtPrice1.Text);
                    cmd.Parameters.AddWithValue("@P2", txtPrice2.Text);

                    int rows = cmd.ExecuteNonQuery();//執行但不查詢
                    con.Close();
                    MessageBox.Show($"{rows}筆資料更新成功");
                    ShowDataGridView();
                    btnSave.Enabled = false;
                }
                catch 
                {
                    MessageBox.Show("請確認輸入內容正確性");
                }
                
            }
            else
            {
                MessageBox.Show("必填所有欄位資料！\n無新增資料！");
               
            }



        }



    










    }
}
