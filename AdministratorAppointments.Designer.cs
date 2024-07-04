namespace Licenta
{
    partial class AdministratorAppointments
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministratorAppointments));
            label1 = new Label();
            appointmentsView = new DataGridView();
            label8 = new Label();
            label9 = new Label();
            date = new DateTimePicker();
            time = new DateTimePicker();
            panel1 = new Panel();
            pictureBox6 = new PictureBox();
            logoutBtn = new Label();
            invoicesLb = new Label();
            pictureBox5 = new PictureBox();
            testsLb = new Label();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            appointmentsLb = new Label();
            pictureBox2 = new PictureBox();
            pacientsLb = new Label();
            pictureBox1 = new PictureBox();
            firstname = new TextBox();
            label7 = new Label();
            lastname = new TextBox();
            label6 = new Label();
            addBtn = new Button();
            closeBtn = new PictureBox();
            editBtn = new Button();
            delBtn = new Button();
            filterComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)appointmentsView).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeBtn).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(712, 32);
            label1.Name = "label1";
            label1.Size = new Size(153, 32);
            label1.TabIndex = 5;
            label1.Text = "Programări";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // appointmentsView
            // 
            appointmentsView.AllowUserToOrderColumns = true;
            appointmentsView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = Color.MediumAquamarine;
            appointmentsView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            appointmentsView.BackgroundColor = Color.FromArgb(241, 251, 247);
            appointmentsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumAquamarine;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            appointmentsView.DefaultCellStyle = dataGridViewCellStyle2;
            appointmentsView.Location = new Point(462, 437);
            appointmentsView.Name = "appointmentsView";
            appointmentsView.RowHeadersVisible = false;
            appointmentsView.RowHeadersWidth = 20;
            appointmentsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentsView.Size = new Size(667, 262);
            appointmentsView.TabIndex = 6;
            appointmentsView.CellClick += appointmentsView_CellClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Teal;
            label8.Location = new Point(854, 228);
            label8.Name = "label8";
            label8.Size = new Size(52, 25);
            label8.TabIndex = 13;
            label8.Text = "Ora\r\n";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Teal;
            label9.Location = new Point(854, 128);
            label9.Name = "label9";
            label9.Size = new Size(61, 25);
            label9.TabIndex = 11;
            label9.Text = "Data";
            label9.TextAlign = ContentAlignment.TopCenter;
            // 
            // date
            // 
            date.Format = DateTimePickerFormat.Short;
            date.Location = new Point(854, 170);
            date.Name = "date";
            date.Size = new Size(250, 30);
            date.TabIndex = 15;
            date.Value = new DateTime(2024, 5, 8, 0, 0, 0, 0);
            // 
            // time
            // 
            time.Format = DateTimePickerFormat.Time;
            time.Location = new Point(854, 268);
            time.Name = "time";
            time.ShowUpDown = true;
            time.Size = new Size(250, 30);
            time.TabIndex = 16;
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
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(appointmentsLb);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pacientsLb);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 720);
            panel1.TabIndex = 19;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(72, 643);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 16;
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
            logoutBtn.TabIndex = 15;
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
            invoicesLb.TabIndex = 12;
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
            testsLb.TabIndex = 8;
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
            // appointmentsLb
            // 
            appointmentsLb.AutoSize = true;
            appointmentsLb.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appointmentsLb.ForeColor = Color.White;
            appointmentsLb.Location = new Point(108, 278);
            appointmentsLb.Name = "appointmentsLb";
            appointmentsLb.Size = new Size(129, 25);
            appointmentsLb.TabIndex = 5;
            appointmentsLb.Text = "Programări";
            appointmentsLb.TextAlign = ContentAlignment.TopCenter;
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
            // pacientsLb
            // 
            pacientsLb.AutoSize = true;
            pacientsLb.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pacientsLb.ForeColor = Color.White;
            pacientsLb.Location = new Point(108, 221);
            pacientsLb.Name = "pacientsLb";
            pacientsLb.Size = new Size(92, 25);
            pacientsLb.TabIndex = 3;
            pacientsLb.Text = "Pacienți";
            pacientsLb.TextAlign = ContentAlignment.TopCenter;
            pacientsLb.Click += pacientsLb_Click;
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
            // firstname
            // 
            firstname.Location = new Point(475, 268);
            firstname.Name = "firstname";
            firstname.Size = new Size(250, 30);
            firstname.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(475, 228);
            label7.Name = "label7";
            label7.Size = new Size(183, 25);
            label7.TabIndex = 22;
            label7.Text = "Prenume pacient";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // lastname
            // 
            lastname.Location = new Point(475, 170);
            lastname.Name = "lastname";
            lastname.Size = new Size(250, 30);
            lastname.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Teal;
            label6.Location = new Point(475, 128);
            label6.Name = "label6";
            label6.Size = new Size(151, 25);
            label6.TabIndex = 20;
            label6.Text = "Nume pacient";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // addBtn
            // 
            addBtn.AutoEllipsis = true;
            addBtn.BackColor = Color.Teal;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(570, 333);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(129, 49);
            addBtn.TabIndex = 24;
            addBtn.Text = "Adaugă";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.Transparent;
            closeBtn.Image = (Image)resources.GetObject("closeBtn.Image");
            closeBtn.Location = new Point(1239, 0);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(42, 42);
            closeBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            closeBtn.TabIndex = 36;
            closeBtn.TabStop = false;
            closeBtn.Click += closeBtn_Click;
            // 
            // editBtn
            // 
            editBtn.AutoEllipsis = true;
            editBtn.BackColor = Color.MediumAquamarine;
            editBtn.FlatStyle = FlatStyle.Flat;
            editBtn.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editBtn.ForeColor = Color.White;
            editBtn.Location = new Point(724, 333);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(129, 49);
            editBtn.TabIndex = 37;
            editBtn.Text = "Editează";
            editBtn.UseVisualStyleBackColor = false;
            editBtn.Click += editBtn_Click;
            // 
            // delBtn
            // 
            delBtn.AutoEllipsis = true;
            delBtn.BackColor = Color.CadetBlue;
            delBtn.FlatStyle = FlatStyle.Flat;
            delBtn.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            delBtn.ForeColor = Color.White;
            delBtn.Location = new Point(877, 333);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(129, 49);
            delBtn.TabIndex = 38;
            delBtn.Text = "Șterge";
            delBtn.UseVisualStyleBackColor = false;
            delBtn.Click += delBtn_Click;
            // 
            // filterComboBox
            // 
            filterComboBox.FormattingEnabled = true;
            filterComboBox.Location = new Point(462, 401);
            filterComboBox.Name = "filterComboBox";
            filterComboBox.Size = new Size(202, 30);
            filterComboBox.TabIndex = 40;
            // 
            // AdministratorAppointments
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 720);
            Controls.Add(filterComboBox);
            Controls.Add(delBtn);
            Controls.Add(editBtn);
            Controls.Add(closeBtn);
            Controls.Add(addBtn);
            Controls.Add(firstname);
            Controls.Add(label7);
            Controls.Add(lastname);
            Controls.Add(label6);
            Controls.Add(panel1);
            Controls.Add(time);
            Controls.Add(date);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(appointmentsView);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AdministratorAppointments";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Appointments";
            Load += AdministratorAppointments_Load;
            ((System.ComponentModel.ISupportInitialize)appointmentsView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeBtn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private DataGridView appointmentsView;
        private Label label8;
        private Label label9;
        private DateTimePicker date;
        private DateTimePicker time;
        private Panel panel1;
        private Label invoicesLb;
        private PictureBox pictureBox5;
        private Label testsLb;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private Label appointmentsLb;
        private PictureBox pictureBox2;
        private Label pacientsLb;
        private PictureBox pictureBox1;
        private TextBox firstname;
        private Label label7;
        private TextBox lastname;
        private Label label6;
        private Button addBtn;
        private PictureBox closeBtn;
        private Button editBtn;
        private Button delBtn;
        private PictureBox pictureBox6;
        private Label logoutBtn;
        private ComboBox filterComboBox;
    }
}