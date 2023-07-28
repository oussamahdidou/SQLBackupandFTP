using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WinFormsApp1
{
    public partial class DbFile : Form
    {
        public Form1 mainform;
        public DbFile(Form1 mainform)
        {
            InitializeComponent();
            this.Size = new Size(437, 236);
            this.mainform = mainform;

        }

        // Event handler for the CheckedChanged event of the radio buttons



        private void DbFile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = mainform.Servername;
            string username = mainform.Username;
            string password=mainform.Password;
            string database = dbname.Text;
            string connectionString = $"server={server};database={database};user={username};password={password};";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Connection is open and ready to use
                    MessageBox.Show($"Connexion etablie avec succes", "connexion succes", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    // Perform database operations here
                    mainform.database= database;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                // An error occurred while connecting or opening the connection
                MessageBox.Show($"Erreur lors de la connexion au serveur SQL : {ex.Message}", "erreur de connexion", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }
    }
}
