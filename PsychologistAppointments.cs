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
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
