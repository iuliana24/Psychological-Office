using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Licenta
{
    public partial class AdministratorTests : Form
    {
        public AdministratorTests()
        {
            InitializeComponent();
            displayTests();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private void displayTests()
        {
            Con.Open();
            string query = "SELECT testID as Id, name as Denumire, description as Descriere, filePath as CaleFișier FROM test;";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            testsView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private string selectedFilePath = "";
        private void fileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fișiere text (*.txt)|*.txt|Toate fișierele (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                selectedFilePath = openFileDialog.FileName;
                filename.Text = Path.GetFileName(selectedFilePath);
            }
            else
            {

                MessageBox.Show("Selectarea fișierului a fost anulată.");
                selectedFilePath = "";
            }
        }

     


        private void addBtn_Click(object sender, EventArgs e)
        {

            if (name.Text == "" || description.Text == "" || selectedFilePath == "")
            {
                MessageBox.Show("Lipsesc informații sau fișierul nu este încărcat!");
            }
            else
            {
                try
                {


                    Con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO test(name, description, filePath) VALUES (@name, @description, @filePath)", Con);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@description", description.Text);
                    cmd.Parameters.AddWithValue("@filePath", selectedFilePath);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Test adăugat.");
                    displayTests();

                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }


        }

        int Key = 0;
        private void Clear()
        {
            name.Text = "";
            description.Text = "";
            selectedFilePath = "";
            filename.Text = "Niciun fișier selectat.";
            Key = 0;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

   
        private void testsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdministratorTests_Load(object sender, EventArgs e)
        {
            testsView.Columns[0].Width = 40;
            testsView.Columns[1].Width = 210;
            testsView.Columns[2].Width = 210;
            testsView.Columns[3].Width = 210;
        }
    }
}
