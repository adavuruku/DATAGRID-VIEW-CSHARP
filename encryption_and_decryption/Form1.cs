using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;

namespace encryption_and_decryption
{
    public partial class Form1 : Form
    {
        string inputFile="", outputFile ="";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               // inputFile = @"C:\Users\sherif146\Desktop\sherif.jpg";
               // outputFile = @"C:\Users\sherif146\Desktop\sherif_enc.jpg";
                
                string password = @"myKey123"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                
                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

              //  RijndaelManaged RMCrypto = new RijndaelManaged();
                TripleDESCryptoServiceProvider RMCrypto = new TripleDESCryptoServiceProvider();
                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);
                FileStream fsIn = new FileStream(outputFile, FileMode.Create);
                FileStream fsIn = new FileStream(outputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();iiiiiiiiiiiiiiiiiiii
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string password = @"myKey123"; // Your Key Here
          //  inputFile = @"C:\Users\sherif146\Desktop\sherif_enc.jpg";
           // outputFile = @"C:\Users\sherif146\Desktop\sherif_decrypt.jpg";

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

         //   RijndaelManaged RMCrypto = new RijndaelManaged();
            TripleDESCryptoServiceProvider RMCrypto = new TripleDESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

          //  openFileDialog1.Filter = "Image Files (*.*);
            string PICS = String.Empty;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                //button3.Enabled = false;
                string judee = "";
                judee = openFileDialog1.FileName;
                FileInfo file1 = new FileInfo(judee);
                //MessageBox.Show(judee);
                inputFile = judee;
                
                //file1.Name  file1.Extension file1.exist
                string file_name = file1.Name;
                outputFile = @"C:\Users\sherif146\Desktop\Encrypt\" + file_name;
                //string file_extension = file1.Extension;
                //string new_file = file_name + file_extension;
                label1.Text = file_name;
                
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //  openFileDialog1.Filter = "Image Files (*.*);
            string PICS = String.Empty;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                //button3.Enabled = false;
                string judee = "";
                judee = openFileDialog1.FileName;
                FileInfo file1 = new FileInfo(judee);
                //MessageBox.Show(judee);
                inputFile = judee;

                //file1.Name  file1.Extension file1.exist
                string file_name = file1.Name;
                outputFile = @"C:\Users\sherif146\Desktop\Decrypt\" + file_name;
                //string file_extension = file1.Extension;
                //string new_file = file_name + file_extension;
                label4.Text = file_name;

            }

        }
    }
}
