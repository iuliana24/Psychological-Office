using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Licenta
{
    public partial class AdministratorPacients : Form
    {
       
        public AdministratorPacients()
        {
            InitializeComponent();
            displayPacients();
        }

        
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        private void AdministratorPacients_Load(object sender, EventArgs e)
        {
            pacientsView.Columns[0].Width = 40;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (lastname.Text == "" || firstname.Text == "" || gender.Text == ""
                || dob.Value.Date == DateTime.MinValue || mail.Text == "" || phone.Text == "")
            {
                MessageBox.Show("Lipsesc informații!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into pacient(firstname, lastname, dob, gender, phone, email, observation)values(@firstname,@lastname,@dob,@gender,@phone,@email,@observation)", Con);
                    cmd.Parameters.AddWithValue("@lastname", lastname.Text);
                    cmd.Parameters.AddWithValue("@firstname", firstname.Text);
                    cmd.Parameters.AddWithValue("@dob", dob.Value.Date);
                    cmd.Parameters.AddWithValue("@gender", gender.Text);
                    cmd.Parameters.AddWithValue("@phone", phone.Text);
                    cmd.Parameters.AddWithValue("@email", mail.Text);
                    cmd.Parameters.AddWithValue("@observation", observation.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Pacient adăugat.");
                    displayPacients();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void displayPacients()
        {
            Con.Open();
            string query = "SELECT pacientID as Id, lastname as Nume, firstname as Prenume, dob as DataNașterii," +
                " gender as Gen, phone as Telefon, Email, observation as Observații FROM pacient;";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            pacientsView.DataSource = ds.Tables[0];
            Con.Close();
        }


        int Key = 0;

        private void pacientsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = pacientsView.Rows[e.RowIndex];

                    int id = 0;
                    int lastnameIndex = 1;
                    int firstnameIndex = 2;
                    int dobIndex = 3;
                    int genderIndex = 4;
                    int phoneIndex = 5;
                    int mailIndex = 6;
                    int observationIndex = 7;

                    if (selectedRow.Cells.Count > observationIndex)
                    {
                        lastname.Text = GetCellValue(selectedRow, lastnameIndex);
                        firstname.Text = GetCellValue(selectedRow, firstnameIndex);
                        dob.Text = GetCellValue(selectedRow, dobIndex);
                        gender.Text = GetCellValue(selectedRow, genderIndex);
                        phone.Text = GetCellValue(selectedRow, phoneIndex);
                        mail.Text = GetCellValue(selectedRow, mailIndex);
                        observation.Text = GetCellValue(selectedRow, observationIndex);

                        if (int.TryParse(GetCellValue(selectedRow, id), out int keyValue))
                        {
                            Key = keyValue;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCellValue(DataGridViewRow row, int columnIndex)
        {
            var cellValue = row.Cells[columnIndex].Value;

            if (cellValue == null)
            {
                return string.Empty;
            }

            if (cellValue is string stringValue)
            {
                return stringValue;
            }

            return cellValue.ToString();
        }


        private void editBtn_Click(object sender, EventArgs e)
        {
            if (lastname.Text == "" || firstname.Text == "" || gender.Text == ""
                || dob.Value.Date == DateTime.MinValue || mail.Text == "" || phone.Text == "")
            {
                MessageBox.Show("Lipsesc informații!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update pacient set firstname=@firstname, lastname=@lastname, dob=@dob, gender=@gender, phone=@phone, email=@email, observation=@observation where pacientID=@Key", Con);
                    cmd.Parameters.AddWithValue("@lastname", lastname.Text);
                    cmd.Parameters.AddWithValue("@firstname", firstname.Text);
                    cmd.Parameters.AddWithValue("@dob", dob.Value.Date);
                    cmd.Parameters.AddWithValue("@gender", gender.Text);
                    cmd.Parameters.AddWithValue("@phone", phone.Text);
                    cmd.Parameters.AddWithValue("@email", mail.Text);
                    cmd.Parameters.AddWithValue("@observation", observation.Text);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Pacient actualizat.");
                    displayPacients();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Selectează pacientul.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from pacient where pacientID=@Key", Con);

                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Pacient șters.");
                    displayPacients();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Clear()
        {
            lastname.Text = "";
            firstname.Text = "";
            dob.Text = "";
            gender.Text = "";
            phone.Text = "";
            mail.Text = "";
            observation.Text = "";
            Key = 0;

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void appointmentsLb_Click(object sender, EventArgs e)
        {
            AdministratorAppointments Obj = new AdministratorAppointments();
            Obj.Show();
            this.Hide();
        }

        private void testsLb_Click(object sender, EventArgs e)
        {
            AdministratorTests Obj = new AdministratorTests();
            Obj.Show();
            this.Hide();
        }

        private void invoicesLb_Click(object sender, EventArgs e)
        {
            AdministratorInvoices Obj = new AdministratorInvoices();
            Obj.Show();
            this.Hide();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void clrbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
