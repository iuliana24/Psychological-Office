using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licenta
{
    public partial class Pacients : Form
    {
        public Pacients()
        {
            InitializeComponent();
            LoadTests();
        }

        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        private void LoadTests()
        {
            Panel testsPanel = new Panel();
            testsPanel.AutoScroll = true;

            testsPanel.Width = 1187;
            testsPanel.Height = 700;
            testsPanel.Top = 215;
            testsPanel.Left = 48;

            SqlDataReader reader = null;

            try
            {
                using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                {
                    Con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT testID, name, imagePath FROM test", Con))
                    {

                        using (reader = cmd.ExecuteReader())
                        {


                            int yOffset = 10;
                            int spacing = 30;
                            int maxControlsPerRow = 5;

                            int controlCount = 0;
                            int rowCount = 0;

                            int totalControlsWidth = (150 + spacing * 2) * maxControlsPerRow - spacing * 2;
                            int xOffset = (testsPanel.Width - totalControlsWidth) / 2;


                            while (reader.Read())
                            {
                                int testID = reader.GetInt32(0);
                                string testName = reader.GetString(1);
                                string imagePath = reader.IsDBNull(2) ? null : reader.GetString(2);

                                PictureBox pb = new PictureBox();
                                pb.Width = 150;
                                pb.Height = 150;
                                pb.Top = yOffset + (pb.Height + spacing * 3) * rowCount;
                                pb.Left = xOffset + ((pb.Width + spacing * 2) * (controlCount % maxControlsPerRow));


                                if (!string.IsNullOrEmpty(imagePath))
                                {
                                    pb.Image = Image.FromFile(imagePath);
                                }


                                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                                pb.Click += (s, e) => OpenTest(testID);


                                Label lbl = new Label();
                                lbl.Text = testName;
                                lbl.AutoSize = true;
                                lbl.Width = pb.Width;
                                lbl.Top = pb.Top + pb.Height + 10;
                                lbl.Left = pb.Left;
                                lbl.MaximumSize = new Size(pb.Width + 10, 0);
                                lbl.MinimumSize = new Size(pb.Width + 10, 0);
                                lbl.TextAlign = ContentAlignment.TopCenter;
                                lbl.Font = new Font("Times New Roman", 12, FontStyle.Bold);

                                testsPanel.Controls.Add(pb);
                                testsPanel.Controls.Add(lbl);


                                controlCount++;
                                if (controlCount % maxControlsPerRow == 0)
                                {
                                    rowCount++;
                                }

                                int contentHeight = yOffset + (150 + spacing * 3) * (rowCount + 1) + spacing * 5;
                                testsPanel.AutoScrollMinSize = new Size(testsPanel.Width, contentHeight);

                                if (contentHeight > testsPanel.Height)
                                {
                                    testsPanel.VerticalScroll.Visible = true;

                                }

                            }
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
            finally
            {
                reader?.Close();
            }
            this.Controls.Add(testsPanel);

        }


        private void OpenTest(int testID)
        {

            try
            {
                using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                {
                    if (Con.State == ConnectionState.Closed)
                        Con.Open();

                   
                    PacientTest testForm = new PacientTest(testID);
                    testForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void Pacients_Load(object sender, EventArgs e)
        {

        }
    }
}
