using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSv
{
    static class ListBuild//飲料確認加入購物車
    {
        public static int countOrder = 0;
        static List<int> orderML = new List<int>();
        static List<int> orderIce = new List<int>();
        static List<int> orderSugar = new List<int>();
        static List<int> orderNum = new List<int>();
        static List<int> orderIngredient = new List<int>();

        public static void ListBuilder(int ML,int ice,int sugar,int cupNum,int ingredient)
        {
            orderML.Add(ML);
            orderIce.Add(ice);
            orderSugar.Add(sugar);
            orderNum.Add(cupNum);
            orderIngredient.Add(ingredient);

            //MessageBox.Show(orderML[countOrder]+ "\n"+ orderIce[countOrder] + "\n" + orderSugar[countOrder] + "\n" + orderNum[countOrder] + "\n" + orderIngredient[countOrder]+ "\n加入購物車，總計已加入"+ (countOrder+1) + "筆訂單");
            MessageBox.Show("加入購物車，總計已加入" + (countOrder + 1) + "筆訂單");
            countOrder++;

        }
    }

    static class MenuToAdd
    {
        public static string menuToAdd = "";//傳遞menu點選的品名
    } 

    static class Cart
    {
        public static int cartTotal;
        public static List<string> itemInfo= new  List<string>();
        public static List<int> itemPrice = new List<int>();
    }


}
