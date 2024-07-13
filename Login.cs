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
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
          int nHeightEllipse
        );

     
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
       
        }
       
        private void reset_Click(object sender, EventArgs e)
        {
            role.SelectedIndex = -1;
            username.Text = "";
            password.Text = "";
         
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (role.SelectedIndex == -1)
            {
                MessageBox.Show("Selectează un utilizator.");
                return;

            }
            string selectedRole = "";
            switch (role.SelectedIndex)
            {
                case 0:
                    selectedRole = "administrator";
                    break;
                case 1:
                    selectedRole = "psiholog";
                    break;
                case 2:
                    selectedRole = "pacient";
                    break;
                default:
                    MessageBox.Show("Rolul selectat nu este valid.");
                    return;
            }


            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show($"Introduceți numele de utilizator și parola {selectedRole}ului.");
                return;
            }


            string query = $"SELECT COUNT(*) FROM client WHERE username=@username AND password=@password AND role=@role";


            string connectionString = @"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);
                    cmd.Parameters.AddWithValue("@role", selectedRole);

                    try
                    {

                        con.Open();
                        int count = (int)cmd.ExecuteScalar();


                        if (count == 1)
                        {

                            switch (selectedRole)
                            {
                                case "administrator":
                                    AdministratorPacients adminForm = new AdministratorPacients();
                                    adminForm.Show();
                                    break;
                                case "psiholog":
                                    PsychologistPacients psychologistForm = new PsychologistPacients();
                                    psychologistForm.Show();
                                    break;
                                case "pacient":
                                    Pacients pacientForm = new Pacients();
                                    pacientForm.Show();
                                    break;
                            }


                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show($"Nume de utilizator și parolă greșite pentru rolul {selectedRole}.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la autentificare: {ex.Message}");
                    }
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
   
    }
}

