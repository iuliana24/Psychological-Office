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

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if(lastname.Text == "" || firstname.Text == "" || gender.Text == ""
                || age.Text == "" || mail.Text == "" || phone.Text == "")
            {
                MessageBox.Show("Lipsesc informatii!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into pacient(firstname, lastname, age, gender, phone, email, diagnostic)values(@firstname,@lastname,@age,@gender,@phone,@email,@diagnostic)", Con);
                    cmd.Parameters.AddWithValue("@lastname", lastname.Text);
                    cmd.Parameters.AddWithValue("@firstname", firstname.Text);
                    cmd.Parameters.AddWithValue("@age", age.Text);
                    cmd.Parameters.AddWithValue("@gender", gender.Text);
                    cmd.Parameters.AddWithValue("@phone", phone.Text);
                    cmd.Parameters.AddWithValue("@email", mail.Text);
                    cmd.Parameters.AddWithValue("@diagnostic", diagnosis.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Pacient adaugat.");
                    displayPacients();
                    
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void displayPacients()
        {
            Con.Open();
            string query = "SELECT lastname as Nume, firstname as Prenume, age as Varsta," +
                " gender as Gen, phone as Telefon, Email, Diagnostic  FROM pacient;";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            pacientsView.DataSource = ds.Tables[0];
            Con.Close();
        }

    }
}
