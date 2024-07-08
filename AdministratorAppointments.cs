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
        private SortedSet<Appointment> appointments = new SortedSet<Appointment>();

        public AdministratorAppointments()
        {
            InitializeComponent();
            LoadAppointments();
            displayAppointments();
            InitializeComboBox();

        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private void LoadAppointments()
        {
            Con.Open();
            string query = "SELECT appointmentID, lastname, firstname, date, time, isCompleted FROM appointment ORDER BY date, time;";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader reader = cmd.ExecuteReader();
            appointments.Clear();
            while (reader.Read())
            {
                appointments.Add(new Appointment
                {
                    Id = reader.GetInt32(0),
                    LastName = reader.GetString(1),
                    FirstName = reader.GetString(2),
                    Date = reader.GetDateTime(3),
                    Time = reader.GetTimeSpan(4),
                    IsCompleted = reader.GetBoolean(5)
                });
            }
            Con.Close();
        }

        private void displayAppointments()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nume");
            dt.Columns.Add("Prenume");
            dt.Columns.Add("Data");
            dt.Columns.Add("Ora");
            dt.Columns.Add("Status");

            foreach (var appointment in appointments)
            {
                string status = appointment.IsCompleted ? "Terminat" : "Valabil";
                dt.Rows.Add(appointment.Id, appointment.LastName, appointment.FirstName, appointment.Date.ToString("yyyy-MM-dd"), appointment.Time.ToString(@"hh\:mm"), status);
            }

            appointmentsView.DataSource = dt;
            appointmentsView.Columns["Status"].ReadOnly = true;
        }

        private void InitializeComboBox()
        {

            filterComboBox.Items.AddRange(new string[] { "Toate Programările", "Programări Valabile", "Programări Terminate" });

            filterComboBox.SelectedIndex = 0;
            filterComboBox.SelectedIndexChanged += comboBoxFilter_SelectedIndexChanged;
        }

        private void FilterAppointments(string filterOption)
        {
            switch (filterOption)
            {
                case "Toate Programările":

                    displayAppointments();
                    break;
                case "Programări Valabile":

                    var available = appointments.Where(a => !a.IsCompleted).ToList();
                    DisplayFilteredAppointments(available);
                    break;
                case "Programări Terminate":

                    var completed = appointments.Where(a => a.IsCompleted).ToList();
                    DisplayFilteredAppointments(completed);
                    break;
                default:
                    break;
            }
        }

        private void DisplayFilteredAppointments(List<Appointment> filteredAppointments)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nume");
            dt.Columns.Add("Prenume");
            dt.Columns.Add("Data");
            dt.Columns.Add("Ora");
            dt.Columns.Add("Status");

            foreach (var appointment in filteredAppointments)
            {
                string status = appointment.IsCompleted ? "Terminat" : "Valabil";
                dt.Rows.Add(appointment.Id, appointment.LastName, appointment.FirstName, appointment.Date.ToString("yyyy-MM-dd"), appointment.Time.ToString(@"hh\:mm"), status);
            }

            appointmentsView.DataSource = dt;
            appointmentsView.Columns["Status"].ReadOnly = true;
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = filterComboBox.SelectedItem.ToString();
            FilterAppointments(selectedFilter);
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
                DateTime appointmentDate = date.Value.Date;
                TimeSpan appointmentTime = time.Value.TimeOfDay;

                if (appointments.Any(a => a.Date == appointmentDate && a.Time == appointmentTime))
                {
                    MessageBox.Show("Intervalul de timp solicitat nu este disponibil!");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("insert into appointment(firstname, lastname, date, time)values(@firstname,@lastname,@date,@time)", Con);
                        cmd.Parameters.AddWithValue("@lastname", lastname.Text);
                        cmd.Parameters.AddWithValue("@firstname", firstname.Text);
                        cmd.Parameters.AddWithValue("@date", appointmentDate);
                        cmd.Parameters.AddWithValue("@time", appointmentTime);
                        cmd.ExecuteNonQuery();
                        Con.Close();

                        appointments.Add(new Appointment
                        {

                            LastName = lastname.Text,
                            FirstName = firstname.Text,
                            Date = appointmentDate,
                            Time = appointmentTime
                        });

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

                DateTime appointmentDate = date.Value.Date;
                TimeSpan appointmentTime = time.Value.TimeOfDay;

                if (appointments.Any(a => a.Id != Key && a.Date == appointmentDate && a.Time == appointmentTime))
                {
                    MessageBox.Show("Intervalul de timp solicitat nu este disponibil!");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE appointment SET firstname=@firstname, lastname=@lastname, date=@date, time=@time WHERE appointmentID=@Key", Con);
                        cmd.Parameters.AddWithValue("@lastname", lastname.Text);
                        cmd.Parameters.AddWithValue("@firstname", firstname.Text);
                        cmd.Parameters.AddWithValue("@date", appointmentDate);
                        cmd.Parameters.AddWithValue("@time", appointmentTime);
                        cmd.Parameters.AddWithValue("@Key", Key);
                        cmd.ExecuteNonQuery();
                        Con.Close();

                        var oldAppointment = appointments.First(a => a.Id == Key);
                        appointments.Remove(oldAppointment);
                        appointments.Add(new Appointment
                        {
                            Id = Key,
                            LastName = lastname.Text,
                            FirstName = firstname.Text,
                            Date = appointmentDate,
                            Time = appointmentTime
                        });

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
                    SqlCommand cmd = new SqlCommand("DELETE FROM appointment WHERE appointmentID=@Key", Con);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    var appointmentToDelete = appointments.First(a => a.Id == Key);
                    appointments.Remove(appointmentToDelete);

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

        private void clrbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
