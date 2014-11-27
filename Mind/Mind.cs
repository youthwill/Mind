using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mind
{
    public partial class Mind : Form
    {
        public Mind()
        {
            InitializeComponent();
        }

        public string getDataFromTxt(string path)
        {
            string strResult = "";
            try {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                String line = "";
                int count = 0;
                while((line=sr.ReadLine())!=null)
                {
                    count++;
                    string qiHao = "";
                    string kaiJiangHao = "";
                    string houEr = "";
                    string houSan = "";
                    string[] temp = new string[]{""};
                    
                    string[] stringSeparators = new string[] { "-" };

                    strResult = line.ToString();
                    temp = strResult.Split(stringSeparators, StringSplitOptions.None)[1].ToString().Split(new string[] { "\t" }, StringSplitOptions.None);
                    ListViewItem lvi = new ListViewItem(temp[0].ToString());
                    lvi.SubItems.AddRange(new string[] { temp[1].ToString() });
                    this.data_listView.Items.Add(lvi);
                    if (count == 84)
                    {
                        break;
                    }
                    //MessageBox.Show(strResult);
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            return strResult;
        }

        public void bindHaoma()
        {
            string path = "ssc.txt";
            //this.data_textBox.Text = getDataFromTxt(path);
            getDataFromTxt(path);
        }

        private void Mind_Load(object sender, EventArgs e)
        {
            bindHaoma();
        }
    }

}
