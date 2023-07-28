using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Net;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public string ConnectionString;
        public string Servername;
        public string Username;
        public string Password;
        public string database;
        public string mysqlDumpchemin;
        public FtpWebRequest FtpRequest;
        public string Localfilepath;
        public Form1()
        {
            InitializeComponent();
            ConnectionString = null;
            Servername = null;
            Username = null;
            Password = null;
            database = null;
            mysqlDumpchemin = null;
            FtpRequest = null;
            Localfilepath = null;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button5.Hide();
            button4.Hide();
            button3.Hide();
            dateTimePicker1.Hide();
            label3.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Show();
            button4.Show();
            button3.Show();
            dateTimePicker1.Show();
            label3.Show();
            button6.Show();
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DbServer dbServer = new DbServer(this);
            dbServer.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ConnectionString != null)
            {
                DbFile dbFile = new DbFile(this);
                dbFile.ShowDialog();
            }
            else
            {
                MessageBox.Show($"etablie la connexion premierement", "information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.database == null)
            {
                MessageBox.Show($"choisi la base de donnee premierement", "information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                // Obtenez le répertoire de travail actuel

                // Assurez-vous que le dossier "uploads" existe, sinon créez-le

                // Créez le chemin complet du fichier de sauvegarde
                BackupDatabase(Servername, database, Username, Password);
                
                byte[] fileContents = ReadFileContents(Localfilepath);
                UploadFileToFtp(FtpRequest, fileContents);
            }

        }
        public void BackupDatabase(string server, string database, string username, string password)
        {
            string connectionString = $"server={server};user={username};password={password};database={database};";
            string mysqldumpPath = GetMySQLDumpPath(connectionString);

            if (!string.IsNullOrEmpty(mysqldumpPath))
            {
                MessageBox.Show("mysqldump path: " + mysqldumpPath);
            }
            else
            {
                MessageBox.Show("mysqldump path not found. Make sure MySQL is installed and the connection is correct.");
            }
            // Créer l'argument de la commande mysqldump
            System.IO.Directory.CreateDirectory("uploads");

            

            if (!string.IsNullOrEmpty(mysqldumpPath))
            {
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string sqlFilePath = System.IO.Path.Combine("uploads", $"{database}_{timestamp}.sql");
                this.Localfilepath = sqlFilePath;
                string arguments = $"--host={server} --user={username} --password={password} --databases {database} --result-file=\"{sqlFilePath}\"";

                ProcessStartInfo psi = new ProcessStartInfo(mysqldumpPath, arguments);
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;

                Process process = new Process();
                process.StartInfo = psi;
                process.Start();

                process.WaitForExit();
                process.Close();

                MessageBox.Show($"Database backup saved to: {sqlFilePath}");
            }
            else
            {
                MessageBox.Show("mysqldump path not found. Make sure MySQL is installed and the connection is correct.");
            }

        }
        static string GetMySQLDumpPath(string connectionString)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT @@basedir";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        string mysqlBaseDir = command.ExecuteScalar()?.ToString();
                        if (!string.IsNullOrEmpty(mysqlBaseDir))
                        {
                            return System.IO.Path.Combine(mysqlBaseDir, "bin", "mysqldump.exe");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return null;
        }
        static byte[] ReadFileContents(string localFilePath)
        {
            byte[] fileContents;
            using (StreamReader sourceStream = new StreamReader(localFilePath))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }
            return fileContents;
        }
        static void UploadFileToFtp(FtpWebRequest request, byte[] fileContents)
        {
            request.ContentLength = fileContents.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                MessageBox.Show($"Upload File Complete, status {response.StatusDescription}");
            }
        }

    }
}