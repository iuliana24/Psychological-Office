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
    public partial class PsychologistAppointments : Form
    {
        public PsychologistAppointments()
        {
            InitializeComponent();
            InitializeFilterComboBox();
            displayAppointments("Toate Programările");
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private void InitializeFilterComboBox()
        {
            filterComboBox.Items.Add("Toate Programările");
            filterComboBox.Items.Add("Programări Valabile");
            filterComboBox.Items.Add("Programări Terminate");
            filterComboBox.SelectedIndex = 0;
            filterComboBox.SelectedIndexChanged += filterComboBox_SelectedIndexChanged;
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = filterComboBox.SelectedItem.ToString();
            displayAppointments(selectedFilter);
        }

        private void displayAppointments(string filter)
        {
            Con.Open();
            string query = "SELECT appointmentID as Id, lastname as Nume, firstname as Prenume, date as Data, time as Ora, isCompleted as Terminat FROM appointment";

            if (filter == "Programări Valabile")
            {
                query += " WHERE isCompleted = 0";
            }
            else if (filter == "Programări Terminate")
            {
                query += " WHERE isCompleted = 1";
            }

            query += " ORDER BY date, time";

            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            appointmentsView.DataSource = ds.Tables[0];
            Con.Close();

            appointmentsView.Columns["Ora"].DefaultCellStyle.Format = @"hh\:mm";

            appointmentsView.Columns["Terminat"].ReadOnly = false;
        }

        private void pacientsLb_Click(object sender, EventArgs e)
        {
            PsychologistPacients Obj = new PsychologistPacients();
            Obj.Show();
            this.Hide();
        }

        private void testsLb_Click(object sender, EventArgs e)
        {
            PsychologistTests Obj = new PsychologistTests();
            Obj.Show();
            this.Hide();
        }

        private void invoicesLb_Click(object sender, EventArgs e)
        {
            PsychologistInvoices Obj = new PsychologistInvoices();
            Obj.Show();
            this.Hide();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PsychologistAppointments_Load(object sender, EventArgs e)
        {
            appointmentsView.Columns[0].Width = 40;
            appointmentsView.CellValueChanged += appointmentsView_CellValueChanged;
            appointmentsView.CellBeginEdit += appointmentsView_CellBeginEdit;
        }

        private void appointmentsView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == appointmentsView.Columns["Terminat"].Index)
            {
                try
                {
                    Con.Open();
                    int appointmentId = Convert.ToInt32(appointmentsView.Rows[e.RowIndex].Cells["Id"].Value);
                    bool isCompleted = Convert.ToBoolean(appointmentsView.Rows[e.RowIndex].Cells["Terminat"].Value);
                    SqlCommand cmd = new SqlCommand("UPDATE appointment SET isCompleted=@isCompleted WHERE appointmentID=@appointmentID", Con);
                    cmd.Parameters.AddWithValue("@isCompleted", isCompleted);
                    cmd.Parameters.AddWithValue("@appointmentID", appointmentId);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void appointmentsView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
            if (e.ColumnIndex == appointmentsView.Columns["Terminat"].Index)
            {
                var cellValue = appointmentsView.Rows[e.RowIndex].Cells["Id"].Value;
                if (cellValue == DBNull.Value || cellValue == null)
                {
                    e.Cancel = true;
                }
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
