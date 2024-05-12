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
            dataGridView1 = new DataGridView();
            Data = new DataGridViewTextBoxColumn();
            Ora = new DataGridViewTextBoxColumn();
            Nume_Pacient = new DataGridViewTextBoxColumn();
            Prenume_Pacient = new DataGridViewTextBoxColumn();
            label8 = new Label();
            label9 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            panel1 = new Panel();
            label5 = new Label();
            pictureBox5 = new PictureBox();
            label4 = new Label();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            textBox2 = new TextBox();
            label7 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(241, 251, 247);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Data, Ora, Nume_Pacient, Prenume_Pacient });
            dataGridView1.Location = new Point(364, 426);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.Size = new Size(852, 227);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Data
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            Data.DefaultCellStyle = dataGridViewCellStyle1;
            Data.HeaderText = "Data";
            Data.MinimumWidth = 6;
            Data.Name = "Data";
            Data.Width = 200;
            // 
            // Ora
            // 
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            Ora.DefaultCellStyle = dataGridViewCellStyle2;
            Ora.HeaderText = "Ora";
            Ora.MinimumWidth = 6;
            Ora.Name = "Ora";
            Ora.Width = 200;
            // 
            // Nume_Pacient
            // 
            Nume_Pacient.HeaderText = "Nume pacient";
            Nume_Pacient.MinimumWidth = 6;
            Nume_Pacient.Name = "Nume_Pacient";
            Nume_Pacient.Width = 200;
            // 
            // Prenume_Pacient
            // 
            Prenume_Pacient.HeaderText = "Prenume pacient";
            Prenume_Pacient.MinimumWidth = 6;
            Prenume_Pacient.Name = "Prenume_Pacient";
            Prenume_Pacient.Width = 200;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Teal;
            label8.Location = new Point(919, 228);
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
            label9.Location = new Point(919, 128);
            label9.Name = "label9";
            label9.Size = new Size(61, 25);
            label9.TabIndex = 11;
            label9.Text = "Data";
            label9.TextAlign = ContentAlignment.TopCenter;
            label9.Click += label9_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(919, 170);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 30);
            dateTimePicker1.TabIndex = 15;
            dateTimePicker1.Value = new DateTime(2024, 5, 8, 0, 0, 0, 0);
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Location = new Point(919, 268);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 30);
            dateTimePicker2.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 720);
            panel1.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(108, 396);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 12;
            label5.Text = "Facturi";
            label5.TextAlign = ContentAlignment.TopCenter;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(108, 338);
            label4.Name = "label4";
            label4.Size = new Size(64, 25);
            label4.TabIndex = 8;
            label4.Text = "Teste";
            label4.TextAlign = ContentAlignment.TopCenter;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(108, 278);
            label3.Name = "label3";
            label3.Size = new Size(129, 25);
            label3.TabIndex = 5;
            label3.Text = "Programări";
            label3.TextAlign = ContentAlignment.TopCenter;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(108, 221);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 3;
            label2.Text = "Pacienți";
            label2.TextAlign = ContentAlignment.TopCenter;
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
            // textBox2
            // 
            textBox2.Location = new Point(406, 271);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 30);
            textBox2.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(406, 231);
            label7.Name = "label7";
            label7.Size = new Size(183, 25);
            label7.TabIndex = 22;
            label7.Text = "Prenume pacient";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(406, 173);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 30);
            textBox1.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Teal;
            label6.Location = new Point(406, 131);
            label6.Name = "label6";
            label6.Size = new Size(151, 25);
            label6.TabIndex = 20;
            label6.Text = "Nume pacient";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.AutoEllipsis = true;
            button1.BackColor = Color.Teal;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(724, 326);
            button1.Name = "button1";
            button1.Size = new Size(129, 49);
            button1.TabIndex = 24;
            button1.Text = "Salvează";
            button1.UseVisualStyleBackColor = false;
            // 
            // AdministratorAppointments
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 720);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(panel1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AdministratorAppointments";
            Text = "Appointments";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private DataGridView dataGridView1;
        private Label label8;
        private Label label9;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn Ora;
        private DataGridViewTextBoxColumn Nume_Pacient;
        private DataGridViewTextBoxColumn Prenume_Pacient;
        private Panel panel1;
        private Label label5;
        private PictureBox pictureBox5;
        private Label label4;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private Label label3;
        private PictureBox pictureBox2;
        private Label label2;
        private PictureBox pictureBox1;
        private TextBox textBox2;
        private Label label7;
        private TextBox textBox1;
        private Label label6;
        private Button button1;
    }
}