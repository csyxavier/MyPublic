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
            //�и�Ƨ�
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Source");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Zip");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\LaunchTarget");
            //�M��Zip��Ƨ�
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Zip");
            IEnumerable<FileInfo> fileInfo = directoryInfo.EnumerateFiles();
            foreach (FileInfo file in fileInfo)
            {
                label1.Text= file.Name+"is deleted";
                file.Delete();               
            }
            //���YSource���ɮצ�Zip
            ZipFile.CreateFromDirectory(Directory.GetCurrentDirectory() + @"\Source", Directory.GetCurrentDirectory() + @"\Zip\MyZip.zip");
            //�����Y�ɮר�ؼи�Ƨ�
            ZipFile.ExtractToDirectory(Directory.GetCurrentDirectory() + @"\Zip\MyZip.zip", Directory.GetCurrentDirectory() + @"\LaunchTarget", true);
            label1.Text = "�����Y���\";
            //�����Y�ɮ׽ƻs
            DirectoryInfo directoryInfo_Copy = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\LaunchTarget");
            IEnumerable<FileInfo> fileInfo_Copy = directoryInfo_Copy.EnumerateFiles();
            foreach (FileInfo file in fileInfo_Copy)
            {
                label1.Text +="\n"+ file.Name + "�w��s";
            }
        }
    }
}