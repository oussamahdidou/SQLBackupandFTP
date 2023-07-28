using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace WinFormsApp1
{
    public partial class DbServer : Form
    {
        Form1 mainform;
        public DbServer(Form1 mainform)
        {
            InitializeComponent();
            this.Size = new Size(503, 336);
            this.mainform = mainform;   
        }

        private void DbServer_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { // Récupérer les informations de connexion saisies par l'utilisateur
            string server = txtServer.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Construire la chaîne de connexion
            string connectionString = $"Server={server};Uid={username};Pwd={password};";

            // Tester la connexion
            if (TestConnection(connectionString))
            {
                
                mainform.ConnectionString = connectionString; 
                mainform.Password=password;
                mainform.Username=username;
                mainform.Servername = server;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {

            }

        }
        private bool TestConnection(string connectionString)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show($"Connexion etablie avec succes", "connexion succes", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion au serveur SQL : {ex.Message}","erreur de connexion",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                return false;
            }
        }
        
    }
}
