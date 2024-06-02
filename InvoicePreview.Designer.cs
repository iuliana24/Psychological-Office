namespace Licenta
{
    partial class InvoicePreview
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoicePreview));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            closeBtn = new PictureBox();
            label6 = new Label();
            label7 = new Label();
            label3 = new Label();
            label9 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label8 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            lastnamelb = new Label();
            firstnamelb = new Label();
            consultTypelb = new Label();
            datelb = new Label();
            amountlb = new Label();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printBtn = new PictureBox();
            panel2 = new Panel();
            toolTip1 = new ToolTip(components);
            close = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)printBtn).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)close).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(closeBtn);
            panel1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 130);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(338, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.Transparent;
            closeBtn.Image = (Image)resources.GetObject("closeBtn.Image");
            closeBtn.Location = new Point(1238, 0);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(42, 42);
            closeBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            closeBtn.TabIndex = 37;
            closeBtn.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(111, 455);
            label6.Name = "label6";
            label6.Size = new Size(117, 23);
            label6.TabIndex = 43;
            label6.Text = "Nume client:";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(111, 500);
            label7.Name = "label7";
            label7.Size = new Size(143, 23);
            label7.TabIndex = 45;
            label7.Text = "Prenume client:";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(111, 546);
            label3.Name = "label3";
            label3.Size = new Size(109, 23);
            label3.TabIndex = 55;
            label3.Text = "Tip consult:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(111, 777);
            label9.Name = "label9";
            label9.Size = new Size(58, 23);
            label9.TabIndex = 56;
            label9.Text = "Data:";
            label9.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(539, 777);
            label2.Name = "label2";
            label2.Size = new Size(60, 23);
            label2.TabIndex = 57;
            label2.Text = "Total:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(285, 186);
            label1.Name = "label1";
            label1.Size = new Size(237, 32);
            label1.TabIndex = 58;
            label1.Text = "Cabinet psihologic";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(111, 326);
            label4.Name = "label4";
            label4.Size = new Size(66, 23);
            label4.TabIndex = 59;
            label4.Text = "Firmă:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(111, 368);
            label5.Name = "label5";
            label5.Size = new Size(80, 23);
            label5.TabIndex = 60;
            label5.Text = "Telefon:";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(111, 410);
            label8.Name = "label8";
            label8.Size = new Size(77, 23);
            label8.TabIndex = 61;
            label8.Text = "Adresă:";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(183, 327);
            label10.Name = "label10";
            label10.Size = new Size(269, 22);
            label10.TabIndex = 62;
            label10.Text = "Cabinet individual de psihologie";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.White;
            label11.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(197, 369);
            label11.Name = "label11";
            label11.Size = new Size(131, 22);
            label11.TabIndex = 63;
            label11.Text = "+40722222222";
            label11.TextAlign = ContentAlignment.TopCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.White;
            label12.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(194, 411);
            label12.Name = "label12";
            label12.Size = new Size(94, 22);
            label12.TabIndex = 64;
            label12.Text = "Baia Mare";
            label12.TextAlign = ContentAlignment.TopCenter;
            // 
            // lastnamelb
            // 
            lastnamelb.AutoSize = true;
            lastnamelb.BackColor = Color.White;
            lastnamelb.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lastnamelb.ForeColor = Color.Black;
            lastnamelb.Location = new Point(234, 456);
            lastnamelb.Name = "lastnamelb";
            lastnamelb.Size = new Size(19, 22);
            lastnamelb.TabIndex = 65;
            lastnamelb.Text = "?";
            lastnamelb.TextAlign = ContentAlignment.TopCenter;
            // 
            // firstnamelb
            // 
            firstnamelb.AutoSize = true;
            firstnamelb.BackColor = Color.White;
            firstnamelb.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            firstnamelb.ForeColor = Color.Black;
            firstnamelb.Location = new Point(260, 501);
            firstnamelb.Name = "firstnamelb";
            firstnamelb.Size = new Size(19, 22);
            firstnamelb.TabIndex = 66;
            firstnamelb.Text = "?";
            firstnamelb.TextAlign = ContentAlignment.TopCenter;
            // 
            // consultTypelb
            // 
            consultTypelb.AutoSize = true;
            consultTypelb.BackColor = Color.White;
            consultTypelb.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            consultTypelb.ForeColor = Color.Black;
            consultTypelb.Location = new Point(226, 547);
            consultTypelb.Name = "consultTypelb";
            consultTypelb.Size = new Size(19, 22);
            consultTypelb.TabIndex = 67;
            consultTypelb.Text = "?";
            consultTypelb.TextAlign = ContentAlignment.TopCenter;
            // 
            // datelb
            // 
            datelb.AutoSize = true;
            datelb.BackColor = Color.White;
            datelb.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datelb.ForeColor = Color.Black;
            datelb.Location = new Point(175, 778);
            datelb.Name = "datelb";
            datelb.Size = new Size(19, 22);
            datelb.TabIndex = 68;
            datelb.Text = "?";
            datelb.TextAlign = ContentAlignment.TopCenter;
            // 
            // amountlb
            // 
            amountlb.AutoSize = true;
            amountlb.BackColor = Color.White;
            amountlb.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            amountlb.ForeColor = Color.Black;
            amountlb.Location = new Point(605, 778);
            amountlb.Name = "amountlb";
            amountlb.Size = new Size(19, 22);
            amountlb.TabIndex = 69;
            amountlb.Text = "?";
            amountlb.TextAlign = ContentAlignment.TopCenter;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printBtn
            // 
            printBtn.Anchor = AnchorStyles.None;
            printBtn.BackColor = Color.Transparent;
            printBtn.Image = (Image)resources.GetObject("printBtn.Image");
            printBtn.Location = new Point(710, 3);
            printBtn.Name = "printBtn";
            printBtn.Size = new Size(42, 42);
            printBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            printBtn.TabIndex = 70;
            printBtn.TabStop = false;
            printBtn.Click += printBtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(amountlb);
            panel2.Controls.Add(datelb);
            panel2.Controls.Add(consultTypelb);
            panel2.Controls.Add(firstnamelb);
            panel2.Controls.Add(lastnamelb);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(0, 51);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 950);
            panel2.TabIndex = 71;
            // 
            // close
            // 
            close.BackColor = Color.Transparent;
            close.Image = (Image)resources.GetObject("close.Image");
            close.Location = new Point(758, 3);
            close.Name = "close";
            close.Size = new Size(42, 42);
            close.SizeMode = PictureBoxSizeMode.StretchImage;
            close.TabIndex = 72;
            close.TabStop = false;
            close.Click += close_Click;
            // 
            // InvoicePreview
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 1000);
            Controls.Add(close);
            Controls.Add(panel2);
            Controls.Add(printBtn);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "InvoicePreview";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)printBtn).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)close).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox closeBtn;
        private PictureBox pictureBox1;
        private Label label6;
        private Label label7;
        private Label label3;
        private Label label9;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label lastnamelb;
        private Label firstnamelb;
        private Label consultTypelb;
        private Label datelb;
        private Label amountlb;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PictureBox printBtn;
        private Panel panel2;
        private ToolTip toolTip1;
        private PictureBox close;
    }
}