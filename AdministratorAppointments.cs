using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Licenta
{
    public partial class AdministratorAppointments : Form
    {
        public AdministratorAppointments()
        {
            InitializeComponent();
            displayAppointments();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        private void displayAppointments()
        {
            Con.Open();
            string query = "SELECT appointmentID as Id, lastname as Nume, firstname as Prenume, date as Data," +
                " time as Ora FROM appointment;";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            appointmentsView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (lastname.Text == "" || firstname.Text == "" || date.Value.Date == DateTime.MinValue
                || time.Value == DateTime.MinValue)
            {
                MessageBox.Show("Lipsesc informații!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into appointment(firstname, lastname, date, time)values(@firstname,@lastname,@date,@time)", Con);
                    cmd.Parameters.AddWithValue("@lastname", lastname.Text);
                    cmd.Parameters.AddWithValue("@firstname", firstname.Text);
                    cmd.Parameters.AddWithValue("@date", date.Value.Date);
                    string formattedTime = time.Value.ToString("t");
                    cmd.Parameters.AddWithValue("@time", formattedTime);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Programare adăugată.");
                    displayAppointments();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        int Key = 0;
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (lastname.Text == "" || firstname.Text == "" || date.Value.Date == DateTime.MinValue
                || time.Value == DateTime.MinValue)
            {
                MessageBox.Show("Lipsesc informații!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update appointment set firstname=@firstname, lastname=@lastname, date=@date, time=@time where appointmentID=@Key", Con);
                    cmd.Parameters.AddWithValue("@lastname", lastname.Text);
                    cmd.Parameters.AddWithValue("@firstname", firstname.Text);
                    cmd.Parameters.AddWithValue("@date", date.Value.Date);
                    string formattedTime = time.Value.ToString("t");
                    cmd.Parameters.AddWithValue("@time", formattedTime);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Programare actualizată.");
                    displayAppointments();
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
                MessageBox.Show("Selectează programarea.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from appointment where appointmentID=@Key", Con);

                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Programare ștearsă.");
                    displayAppointments();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void appointmentsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = appointmentsView.Rows[e.RowIndex];

                    int id = 0;
                    int lastnameIndex = 1;
                    int firstnameIndex = 2;
                    int dateIndex = 3;
                    int timeIndex = 4;


                    if (selectedRow.Cells.Count > timeIndex)
                    {


                        lastname.Text = GetCellValue(selectedRow, lastnameIndex);
                        firstname.Text = GetCellValue(selectedRow, firstnameIndex);
                        date.Text = GetCellValue(selectedRow, dateIndex);
                        time.Text = GetCellValue(selectedRow, timeIndex);


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

        private void Clear()
        {
            lastname.Text = "";
            firstname.Text = "";
            date.Text = "";
            time.Text = "";
            Key = 0;

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdministratorAppointments_Load(object sender, EventArgs e)
        {

            appointmentsView.Columns[0].Width = 40;
        }

        private void pacientsLb_Click(object sender, EventArgs e)
        {
            AdministratorPacients Obj = new AdministratorPacients();
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

      
    }
}
