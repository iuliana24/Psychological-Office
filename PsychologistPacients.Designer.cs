namespace Licenta
{
    partial class PsychologistPacients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PsychologistPacients));
            panel1 = new Panel();
            pictureBox6 = new PictureBox();
            logoutBtn = new Label();
            invoicesLb = new Label();
            pictureBox5 = new PictureBox();
            testsLb = new Label();
            pictureBox4 = new PictureBox();
            appointmentsLb = new Label();
            pictureBox3 = new PictureBox();
            pacientsLb = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            Nume = new DataGridViewTextBoxColumn();
            Prenume = new DataGridViewTextBoxColumn();
            Varsta = new DataGridViewTextBoxColumn();
            Gen = new DataGridViewComboBoxColumn();
            Telefon = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Diagnostic = new DataGridViewTextBoxColumn();
            label1 = new Label();
            closeBtn = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeBtn).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(logoutBtn);
            panel1.Controls.Add(invoicesLb);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(testsLb);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(appointmentsLb);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pacientsLb);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 720);
            panel1.TabIndex = 3;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(72, 643);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            // 
            // logoutBtn
            // 
            logoutBtn.AutoSize = true;
            logoutBtn.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoutBtn.ForeColor = Color.White;
            logoutBtn.Location = new Point(108, 648);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(84, 25);
            logoutBtn.TabIndex = 17;
            logoutBtn.Text = "Logout";
            logoutBtn.TextAlign = ContentAlignment.TopCenter;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // invoicesLb
            // 
            invoicesLb.AutoSize = true;
            invoicesLb.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            invoicesLb.ForeColor = Color.White;
            invoicesLb.Location = new Point(108, 396);
            invoicesLb.Name = "invoicesLb";
            invoicesLb.Size = new Size(86, 25);
            invoicesLb.TabIndex = 16;
            invoicesLb.Text = "Facturi";
            invoicesLb.TextAlign = ContentAlignment.TopCenter;
            invoicesLb.Click += invoicesLb_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(72, 391);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 11;
            pictureBox5.TabStop = false;
            // 
            // testsLb
            // 
            testsLb.AutoSize = true;
            testsLb.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            testsLb.ForeColor = Color.White;
            testsLb.Location = new Point(108, 338);
            testsLb.Name = "testsLb";
            testsLb.Size = new Size(64, 25);
            testsLb.TabIndex = 15;
            testsLb.Text = "Teste";
            testsLb.TextAlign = ContentAlignment.TopCenter;
            testsLb.Click += testsLb_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(72, 333);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 30);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // appointmentsLb
            // 
            appointmentsLb.AutoSize = true;
            appointmentsLb.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appointmentsLb.ForeColor = Color.White;
            appointmentsLb.Location = new Point(108, 278);
            appointmentsLb.Name = "appointmentsLb";
            appointmentsLb.Size = new Size(129, 25);
            appointmentsLb.TabIndex = 14;
            appointmentsLb.Text = "Programări";
            appointmentsLb.TextAlign = ContentAlignment.TopCenter;
            appointmentsLb.Click += appointmentsLb_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(72, 273);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // pacientsLb
            // 
            pacientsLb.AutoSize = true;
            pacientsLb.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pacientsLb.ForeColor = Color.White;
            pacientsLb.Location = new Point(108, 221);
            pacientsLb.Name = "pacientsLb";
            pacientsLb.Size = new Size(92, 25);
            pacientsLb.TabIndex = 13;
            pacientsLb.Text = "Pacienți";
            pacientsLb.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(72, 216);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(72, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(146, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(241, 251, 247);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nume, Prenume, Varsta, Gen, Telefon, Email, Diagnostic });
            dataGridView1.Location = new Point(324, 134);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(927, 515);
            dataGridView1.TabIndex = 10;
            // 
            // Nume
            // 
            Nume.HeaderText = "Nume";
            Nume.MinimumWidth = 6;
            Nume.Name = "Nume";
            Nume.Width = 125;
            // 
            // Prenume
            // 
            Prenume.HeaderText = "Prenume";
            Prenume.MinimumWidth = 6;
            Prenume.Name = "Prenume";
            Prenume.Width = 125;
            // 
            // Varsta
            // 
            Varsta.HeaderText = "Vârsta";
            Varsta.MinimumWidth = 6;
            Varsta.Name = "Varsta";
            Varsta.Width = 125;
            // 
            // Gen
            // 
            Gen.HeaderText = "Gen";
            Gen.Items.AddRange(new object[] { "Masculin", "Feminin" });
            Gen.MinimumWidth = 6;
            Gen.Name = "Gen";
            Gen.Resizable = DataGridViewTriState.True;
            Gen.SortMode = DataGridViewColumnSortMode.Automatic;
            Gen.Width = 125;
            // 
            // Telefon
            // 
            Telefon.HeaderText = "Telefon";
            Telefon.MinimumWidth = 6;
            Telefon.Name = "Telefon";
            Telefon.Width = 125;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Width = 125;
            // 
            // Diagnostic
            // 
            Diagnostic.HeaderText = "Diagnostic";
            Diagnostic.MinimumWidth = 6;
            Diagnostic.Name = "Diagnostic";
            Diagnostic.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(732, 32);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 11;
            label1.Text = "Pacienți";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.Transparent;
            closeBtn.Image = (Image)resources.GetObject("closeBtn.Image");
            closeBtn.Location = new Point(1239, 0);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(42, 42);
            closeBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            closeBtn.TabIndex = 37;
            closeBtn.TabStop = false;
            closeBtn.Click += closeBtn_Click;
            // 
            // PsychologistPacients
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 720);
            Controls.Add(closeBtn);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "PsychologistPacients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Patients";
            Load += Patients_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeBtn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Label label1;
        private DataGridViewTextBoxColumn Nume;
        private DataGridViewTextBoxColumn Prenume;
        private DataGridViewTextBoxColumn Varsta;
        private DataGridViewComboBoxColumn Gen;
        private DataGridViewTextBoxColumn Telefon;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Diagnostic;
        private Label invoicesLb;
        private Label testsLb;
        private Label appointmentsLb;
        private Label pacientsLb;
        private PictureBox pictureBox6;
        private Label logoutBtn;
        private PictureBox closeBtn;
    }
}