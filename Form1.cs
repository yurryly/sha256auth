using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace sha256auth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadString("ファイルのURL");
                wc.Dispose();
                //アクセス可能な場合の処理

                
                
            }
            catch (WebException)
            {
                //アクセスできない場合の処理

            }
            
        }
       
            private void button1_Click(object sender, EventArgs e)
        {
            //チェックボックスを設定していない場合if (checkBox1.Cheked == true)は不要
            if (checkBox1.Checked == true)
            {
                if (Password("ファイルのURL", textBox1.Text))
                {
                    //パスワードがあっていた時の処理
                   

                }
                else
                {
                    //間違っている時の処理
                    MessageBox.Show("パスワードが違います", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                ///<summary>
                ///返り値がtrueなら一致falseなら不一致。
                /// </summary>

            }
            else
            {
                MessageBox.Show("利用規約に同意してください", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private bool Password(string url, string password)
        {

            WebClient client = new WebClient();
            string webps = client.DownloadString(url);

            byte[] input = Encoding.ASCII.GetBytes(password);
            System.Security.Cryptography.SHA256 sha = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            byte[] hash_sha256 = sha.ComputeHash(input);

            string hash = "";

            for (int i = 0; i < hash_sha256.Length; i++)
            {
                hash = hash + string.Format("{0:X2}", hash_sha256[i]);
            }
            if (webps == hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
     
    }
}


