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
                int showLimit = 0;
                while((line=sr.ReadLine())!=null)
                {
                    showLimit++;
                    string qiHao = "";
                    string kaiJiangHao = "";
                    string houEr = "";
                    string qianSan = "";
                    string zhongSan = "";
                    string houSan = "";
                    string shunZi = "";
                    string zeroWei = "";
                    string[] temp = new string[]{""};
                    string[] stringSeparators = new string[] { "-" };
                    
                    strResult = line.ToString();
                    temp = strResult.Split(stringSeparators, StringSplitOptions.None)[1].ToString().Split(new string[] { "\t" }, StringSplitOptions.None);
                    qiHao = temp[0].ToString();
                    kaiJiangHao = temp[1].ToString();
                    //后二
                    houEr = MindAPI.aHouEr(kaiJiangHao);

                    qianSan = MindAPI.aQianSan(kaiJiangHao);
                    zhongSan = MindAPI.aZhongSan(kaiJiangHao);
                    //后三
                    houSan = MindAPI.aHouSan(kaiJiangHao);
                    //组三遗漏统计
                    //if (houSan == "")
                    //{
                    //    louOfZusan++;
                    //    houSan = louOfZusan.ToString();
                    //}
                    //else
                    //{
                    //    louOfZusan = 0;
                    //}
                    //顺子
                    shunZi = MindAPI.isShunzi(kaiJiangHao);
                    //0位
                    zeroWei = MindAPI.whereZero(kaiJiangHao);
                    ListViewItem lvi = new ListViewItem(qiHao);
                    lvi.SubItems.AddRange(new string[] { kaiJiangHao, houEr, zeroWei, shunZi, qianSan, zhongSan, houSan });
                    this.data_listView.Items.Add(lvi);
                    if (showLimit == 30)
                    {
                        break;
                    }
                    //MessageBox.Show(strResult);
                }
                sr.Close();
                //StreamReader srr = new StreamReader(path, Encoding.Default);
                ////MessageBox.Show(MindAPI.compute(srr, 100, Int32.Parse(this.num_textBox.Text)));
                //this.res_textBox.Text = MindAPI.compute(srr, 100, Int32.Parse(this.num_textBox.Text));
                //srr.Close();
                
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

        public void getDate()
        {
            this.date_label.Text += DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void Mind_Load(object sender, EventArgs e)
        {
            getDate();
            bindHaoma();
        }

        private void fresh_button_Click(object sender, EventArgs e)
        {
            this.data_listView.Items.Clear();
            bindHaoma();
            //this.data_listView.Refresh();
            //InitializeComponent();
            //bindHaoma();
        }

        private void num_scan_button_Click(object sender, EventArgs e)
        {
            string path = "ssc.txt";
            StreamReader srr = new StreamReader(path, Encoding.Default);
            //MessageBox.Show(MindAPI.compute(srr, 100, Int32.Parse(this.num_textBox.Text)));
            if (this.num_textBox.Text != "")
            {
                this.res_textBox.Text = MindAPI.compute(srr, 100, Int32.Parse(this.num_textBox.Text));
            }
            else
            {
                MessageBox.Show("no value");
            }
            srr.Close();
        }
    }

}
