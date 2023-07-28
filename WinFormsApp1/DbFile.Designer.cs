namespace WinFormsApp1
{
    partial class DbFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dbname = new TextBox();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(41, 34);
            label1.Name = "label1";
            label1.Size = new Size(325, 25);
            label1.TabIndex = 0;
            label1.Text = "Donner le nom de la base de donnee";
            // 
            // dbname
            // 
            dbname.Location = new Point(130, 89);
            dbname.Name = "dbname";
            dbname.Size = new Size(266, 23);
            dbname.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(24, 87);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 2;
            label2.Text = "Db name :";
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(298, 142);
            button1.Name = "button1";
            button1.Size = new Size(98, 29);
            button1.TabIndex = 3;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DbFile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 197);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(dbname);
            Controls.Add(label1);
            Name = "DbFile";
            Text = "DbFile";
            Load += DbFile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox dbname;
        private Label label2;
        private Button button1;
    }
}