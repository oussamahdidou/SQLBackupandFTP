using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form1 mainform;
        public Form2(Form1 mainform)
        {
            this.Size = new Size(503, 336);
            this.mainform = mainform;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            string ftpServer = textBox1.Text;
            string userName = textBox3.Text;
            string password = textBox2.Text;
            string remoteFilePath = textBox4.Text;
            CreateFtpRequest(ftpServer,remoteFilePath,userName,password);
        }
        static FtpWebRequest CreateFtpRequest(string ftpServer, string userName, string password, string remoteFilePath)
        {
            try { 
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpServer + remoteFilePath));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(userName, password);
            request.UseBinary = true;
            request.UsePassive = true;
            return request;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion au serveur FTP : {ex.Message}", "erreur de connexion", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return null;

            }
        }



        }
    }

