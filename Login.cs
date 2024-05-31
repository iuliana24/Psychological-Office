using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;

namespace Licenta
{
    public partial class Login : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
      );
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        private void reset_Click(object sender, EventArgs e)
        {
            role.SelectedIndex = -1;
            username.Text = "";
            password.Text = "";

        }

        public static string Role;
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (role.SelectedIndex == -1)
            {
                MessageBox.Show("Selectează un utilizator.");

            }
            else if (role.SelectedIndex == 0)
            {
                if (username.Text == "" || password.Text == "")
                {
                    MessageBox.Show("Introduceți numele de utilizator și parola administratorului.");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from client where username='" + username.Text + "'and password='" + password.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        AdministratorPacients Obj = new AdministratorPacients();
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Nume de utilizator și parolă greșite.");
                    }


                    Con.Close();
                }

            }
            else if (role.SelectedIndex == 1)
            {
                if (username.Text == "" || password.Text == "")
                {
                    MessageBox.Show("Introduceți numele de utilizator și parola psihologului.");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from client where username='" + username.Text + "'and password='" + password.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        PsychologistPacients Obj = new PsychologistPacients();
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Nume de utilizator și parolă greșite.");
                    }


                    Con.Close();
                }
            }
            else
            {
                if (username.Text == "" || password.Text == "")
                {
                    MessageBox.Show("Introduceți numele de utilizator și parola pacientului.");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from client where username='" + username.Text + "'and password='" + password.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Clients Obj = new Clients();
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Nume de utilizator și parolă greșite.");
                    }


                    Con.Close();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

