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
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=OfficeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        private void AdministratorPacients_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == ""
                || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Lipsesc informatii");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into pacient(firstname, lastname, age, gender, phone, email)values(@firstname,@lastname,@age,@gender,@phone, @email)", Con);
                    cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@age", textBox4.Text);
                    cmd.Parameters.AddWithValue("@gender", textBox3.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox6.Text);
                    cmd.Parameters.AddWithValue("@email", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Pacient adaugat");
                    
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
