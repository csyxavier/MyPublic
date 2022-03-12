using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSv
{
    /*
     
      #第一排
            for(int i=0; i < 5; i++)
            {
                Button btn = new Button();
                btn.Text = "btn" + (i+1).ToString();
                btn.Name= "btn" + (i + 1).ToString();
                btn.Size = new Size(180, 180);
                btn.BackColor = Color.White;
                btn.Location = new Point(22*(i+1)+180*i, 22);
                panelShow.Controls.Add(btn);
                btn.Click += ;
            }
    #ListView
            listViewFood.Clear();
            listViewFood.View = View.Details;
            listViewFood.Columns.Add("ID", 80);
            listViewFood.Columns.Add("產品名稱", 300);
            listViewFood.Columns.Add("價格", 100);
            listViewFood.FullRowSelect = true;

            ListViewItem item = new ListViewItem();
            item.Tag = 1;//產品ID
            item.Text = item.Tag.ToString();
            item.SubItems.Add("珍珠奶茶");
            item.SubItems.Add("50");
            listViewFood.Items.Add(item);

    #rename all button
            foreach (Control c in panelMenu.Controls) 或參考
            foreach (Control c in panelMenu.Controls)
            {
                if (c is Button)
                {
                    ((Button)c).Text = "---";
                }
            }
    #批次命名按鈕
      List<Control> ListOfButtons = new List<Control>
        {
            button1, button2, button3, button4, button5, button6, button7, button8, button9, button10
        };
            ListOfButtons[0].Text = "FFF";
     */
}
