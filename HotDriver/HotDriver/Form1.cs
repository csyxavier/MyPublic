using System.IO;
using System.IO.Compression;

namespace HotDriver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //創資料夾
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Source");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Zip");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\LaunchTarget");
            //清空Zip資料夾
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Zip");
            IEnumerable<FileInfo> fileInfo = directoryInfo.EnumerateFiles();
            foreach (FileInfo file in fileInfo)
            {
                label1.Text= file.Name+"is deleted";
                file.Delete();               
            }
            //壓縮Source內檔案至Zip
            ZipFile.CreateFromDirectory(Directory.GetCurrentDirectory() + @"\Source", Directory.GetCurrentDirectory() + @"\Zip\MyZip.zip");
            //解壓縮檔案到目標資料夾
            ZipFile.ExtractToDirectory(Directory.GetCurrentDirectory() + @"\Zip\MyZip.zip", Directory.GetCurrentDirectory() + @"\LaunchTarget", true);
            label1.Text = "解壓縮成功";
            //解壓縮檔案複製
            DirectoryInfo directoryInfo_Copy = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\LaunchTarget");
            IEnumerable<FileInfo> fileInfo_Copy = directoryInfo_Copy.EnumerateFiles();
            foreach (FileInfo file in fileInfo_Copy)
            {
                label1.Text +="\n"+ file.Name + "已更新";
            }
        }
    }
}