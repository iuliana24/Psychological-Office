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
    public partial class PsychologistTests : Form
    {
        public PsychologistTests()
        {
            InitializeComponent();
            displayTests();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        
        private void displayTests()
        {
            Con.Open();
            string query = "SELECT t.testID as Id, tr.name as Nume, t.name as Test, tr.date as Data, tr.time as Ora, tr.score as Rezultat, tr.interpretation as Interpretare FROM test t join test_result tr on t.testID = tr.testID;";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            testsView.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void pacientsLb_Click(object sender, EventArgs e)
        {

            PsychologistPacients Obj = new PsychologistPacients();
            Obj.Show();
            this.Hide();
        }

        private void appointmentsLb_Click(object sender, EventArgs e)
        {

            PsychologistAppointments Obj = new PsychologistAppointments();
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

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void PsychologistTests_Load(object sender, EventArgs e)
        {
            testsView.Columns[0].Width = 40;
            testsView.Columns[1].Width = 150;
            testsView.Columns[2].Width = 150;
            testsView.Columns[3].Width = 150;
            testsView.Columns[4].Width = 150;
            testsView.Columns[5].Width = 150;
            testsView.Columns[6].Width = 150;
        }

    }
}