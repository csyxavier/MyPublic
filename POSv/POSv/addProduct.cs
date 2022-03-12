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
    public partial class addProduct : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<int> searchIDs = new List<int>(); //進階搜尋結果

        public addProduct()
        {
            InitializeComponent();
            //導入選擇商品預覽資料
            //this.Load += new System.EventHandler(btnAddPreview_Click);
            btnSubmit.Enabled = false;
            
        }
        //shadow
        private const int dropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= dropShadow;
                return cp; 
            }
        }


        //參數定義
        #region
        enum CupML
        {
            M = 1, L
        }
        enum Ice
        {
            正常冰 = 1, 少冰, 微冰, 去冰, 常溫, 熱
        }
        enum Sugar
        {
            全糖 = 1, 八分, 五分, 三分, 一分, 無糖
        }
        enum Ingredient
        {
            _=-1,加波霸=1,加珍珠,加布丁,加芋圓
        }
        int igrtPrice = 10;//Ingredient的定價
        int TotalCount;//小計：(定價+加料錢)*杯數
        //參數初始值
        int ML = ((int)CupML.L);
        int ice = ((int)Ice.少冰);
        int sugar = ((int)Sugar.八分);
        uint cupNum = 1;//杯數
        int ingredient=-1;
        string getList()
        {
            return (CupML)ML  +"\n糖："+ (Sugar)sugar+"\n冰：" + (Ice)ice+ "\n" + cupNum +"杯\n" + (Ingredient)ingredient;
        }
        string cupForSQL()
        {
            string result;
            if(ML==1)
            {
                result = "pdtPriceM";
            }
            else
            {
                result = "pdtPriceL";
            }
            return result;
        }
        #endregion

        private void addProduct_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "pos";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPreview_Click(object sender, EventArgs e)
        {
            //加入購物車預覽
            label2.Text = getList();
            btnSubmit.Enabled = true;
            //設定品名
            lbpdtName.Text = MenuToAdd.menuToAdd;
            //抓定價
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "select * from Product where pdtName = @Search";//不支援參數式
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@Search", MenuToAdd.menuToAdd);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int priceM = Convert.ToInt32(reader["pdtPriceM"]);
            int priceL = Convert.ToInt32(reader["pdtPriceL"]);
            int selectPrice;//取得飲料售價
            if((CupML)ML==CupML.L)
            {
                selectPrice = priceL;
            }
            else
            {
                selectPrice = priceM;
            }
            //小計：(定價+加料錢)*杯數           
            if((Ingredient)ingredient!=Ingredient._)
            {
                TotalCount = (selectPrice + igrtPrice)* Convert.ToInt32(txtNum.Text);
            }
            else
            {
                TotalCount = (selectPrice) * Convert.ToInt32(txtNum.Text);
            }
            labelPrice.Text = TotalCount/ Convert.ToInt32(txtNum.Text)+"*"+ Convert.ToInt32(txtNum.Text);
            labelTotal.Text = "小計$"+TotalCount.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            //這杯飲料的資訊
            ListBuild.ListBuilder(ML, ice, sugar, (int)cupNum, ingredient);
            Cart.itemInfo.Add(lbpdtName.Text+ label2.Text+"\n小計$"+TotalCount);
            //MessageBox.Show(Cart.itemInfo[0]);
            this.Close();

            //加總到購物車顯示label用
            Cart.cartTotal += TotalCount;
            Cart.itemPrice.Add(TotalCount);
        }


        private void btnM_Click(object sender, EventArgs e)
        {
            if (ML!=((int)CupML.M))
            {
                ML = ((int)CupML.M);
                btnM.BackColor = Color.Lime;
                btnL.BackColor = Color.White;
                
            }
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            if (ML != ((int)CupML.L))
            {
                ML = ((int)CupML.L);
                btnL.BackColor = Color.Lime;
                btnM.BackColor = Color.White;
             }
        }

        private void btnIce1_Click(object sender, EventArgs e)
        {
            if (ice != ((int)Ice.正常冰))
            {
                ice = ((int)Ice.正常冰);
                btnIce1.BackColor = Color.Lime;
                btnIce2.BackColor = btnIce3.BackColor = btnIce4.BackColor = btnIce5.BackColor = btnIce6.BackColor = Color.White;
            }
        }

        private void btnIce2_Click(object sender, EventArgs e)
        {
            if (ice != ((int)Ice.少冰))
            {
                ice = ((int)Ice.少冰);
                btnIce2.BackColor = Color.Lime;
                btnIce1.BackColor = btnIce3.BackColor = btnIce4.BackColor = btnIce5.BackColor = btnIce6.BackColor = Color.White;
            }
        }

        private void btnIce3_Click(object sender, EventArgs e)
        {
            if (ice != ((int)Ice.微冰))
            {
                ice = ((int)Ice.微冰);
                btnIce3.BackColor = Color.Lime;
                btnIce1.BackColor = btnIce2.BackColor = btnIce4.BackColor = btnIce5.BackColor = btnIce6.BackColor = Color.White;
            }
        }

        private void btnIce4_Click(object sender, EventArgs e)
        {
            if (ice != ((int)Ice.去冰))
            {
                ice = ((int)Ice.去冰);
                btnIce4.BackColor = Color.Lime;
                btnIce1.BackColor = btnIce2.BackColor = btnIce3.BackColor = btnIce5.BackColor = btnIce6.BackColor = Color.White;
            }
        }

        private void btnIce5_Click(object sender, EventArgs e)
        {
            if (ice != ((int)Ice.常溫))
            {
                ice = ((int)Ice.常溫);
                btnIce5.BackColor = Color.Lime;
                btnIce1.BackColor = btnIce2.BackColor = btnIce3.BackColor = btnIce4.BackColor = btnIce6.BackColor = Color.White;
            }
        }

        private void btnIce6_Click(object sender, EventArgs e)
        {
            if (ice != ((int)Ice.熱))
            {
                ice = ((int)Ice.熱);
                btnIce6.BackColor = Color.Lime;
                btnIce1.BackColor = btnIce2.BackColor = btnIce3.BackColor = btnIce4.BackColor = btnIce5.BackColor = Color.White;
            }
        }

        private void btnSugar1_Click(object sender, EventArgs e)
        {
            if (sugar != ((int)Sugar.全糖))
            {
                sugar = ((int)Sugar.全糖);
                btnSugar1.BackColor = Color.Lime;
                btnSugar2.BackColor = btnSugar3.BackColor = btnSugar4.BackColor = btnSugar5.BackColor = btnSugar6.BackColor = Color.White;
            }
        }

        private void btnSugar2_Click(object sender, EventArgs e)
        {
            if (sugar != ((int)Sugar.八分))
            {
                sugar = ((int)Sugar.八分);
                btnSugar2.BackColor = Color.Lime;
                btnSugar1.BackColor = btnSugar3.BackColor = btnSugar4.BackColor = btnSugar5.BackColor = btnSugar6.BackColor = Color.White;
            }
        }

        private void btnSugar3_Click(object sender, EventArgs e)
        {
            if (sugar != ((int)Sugar.五分))
            {
                sugar = ((int)Sugar.五分);
                btnSugar3.BackColor = Color.Lime;
                btnSugar1.BackColor = btnSugar2.BackColor = btnSugar4.BackColor = btnSugar5.BackColor = btnSugar6.BackColor = Color.White;
            }
        }

        private void btnSugar4_Click(object sender, EventArgs e)
        {
            if (sugar != ((int)Sugar.三分))
            {
                sugar = ((int)Sugar.三分);
                btnSugar4.BackColor = Color.Lime;
                btnSugar1.BackColor = btnSugar2.BackColor = btnSugar3.BackColor = btnSugar5.BackColor = btnSugar6.BackColor = Color.White;
            }
        }

        private void btnSugar5_Click(object sender, EventArgs e)
        {
            if (sugar != ((int)Sugar.一分))
            {
                sugar = ((int)Sugar.一分);
                btnSugar5.BackColor = Color.Lime;
                btnSugar1.BackColor = btnSugar2.BackColor = btnSugar3.BackColor = btnSugar4.BackColor = btnSugar6.BackColor = Color.White;
            }
        }

        private void btnSugar6_Click(object sender, EventArgs e)
        {
            if (sugar != ((int)Sugar.無糖))
            {
                sugar = ((int)Sugar.無糖);
                btnSugar6.BackColor = Color.Lime;
                btnSugar1.BackColor = btnSugar2.BackColor = btnSugar3.BackColor = btnSugar4.BackColor = btnSugar5.BackColor = Color.White;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            cupNum += 1;
            txtNum.Text = cupNum.ToString();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (cupNum >1)
            {
                cupNum -= 1;
                txtNum.Text = cupNum.ToString();
            }
           
        }

        private void btnIngredient_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Visible = true;
            ingredient = ((int)Ingredient.加波霸);
            btnIngret1.BackColor = Color.Lime;
        }

        private void btnIngret1_Click(object sender, EventArgs e)
        {
            if (ingredient != ((int)Ingredient.加波霸))
            {
                ingredient = ((int)Ingredient.加波霸);
                btnIngret1.BackColor = Color.Lime;
                btnIngret2.BackColor = btnIngret3.BackColor = btnIngret4.BackColor = Color.White;
            }
        }

        private void btnIngret2_Click(object sender, EventArgs e)
        {
            if (ingredient != ((int)Ingredient.加珍珠))
            {
                ingredient = ((int)Ingredient.加珍珠);
                btnIngret2.BackColor = Color.Lime;
                btnIngret1.BackColor = btnIngret3.BackColor = btnIngret4.BackColor = Color.White;
            }
        }

        private void btnIngret3_Click(object sender, EventArgs e)
        {
            if (ingredient != ((int)Ingredient.加布丁))
            {
                ingredient = ((int)Ingredient.加布丁);
                btnIngret3.BackColor = Color.Lime;
                btnIngret1.BackColor = btnIngret2.BackColor = btnIngret4.BackColor = Color.White;
            }
        }

        private void btnIngret4_Click(object sender, EventArgs e)
        {
            if (ingredient != ((int)Ingredient.加芋圓))
            {
                ingredient = ((int)Ingredient.加芋圓);
                btnIngret4.BackColor = Color.Lime;
                btnIngret1.BackColor = btnIngret2.BackColor = btnIngret3.BackColor = Color.White;
            }
        }

      
    }
}
