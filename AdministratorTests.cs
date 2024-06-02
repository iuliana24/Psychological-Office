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

        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
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

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || description.Text == "" || filename.Text == "")
            {
                MessageBox.Show("Lipsesc informații sau fișierul nu este încărcat!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update test set name=@name, description=@description, filePath=@filePath  where testID=@Key", Con);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@description", description.Text);
                    cmd.Parameters.AddWithValue("@filePath", filename.Text);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Test actualizat.");
                    displayTests();
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
                MessageBox.Show("Selectează testul.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from test where testID=@Key", Con);

                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Test șters.");
                    displayTests();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void testsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = testsView.Rows[e.RowIndex];

                    int id = 0;
                    int nameIndex = 1;
                    int descriptionIndex = 2;
                    int filePathIndex = 3;



                    if (selectedRow.Cells.Count > filePathIndex)
                    {


                        name.Text = GetCellValue(selectedRow, nameIndex);
                        description.Text = GetCellValue(selectedRow, descriptionIndex);
                        filename.Text = GetCellValue(selectedRow, filePathIndex);



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


        private void AdministratorTests_Load(object sender, EventArgs e)
        {
            testsView.Columns[0].Width = 40;
            testsView.Columns[1].Width = 210;
            testsView.Columns[2].Width = 210;
            testsView.Columns[3].Width = 210;
        }


        private void appointmentsLb_Click(object sender, EventArgs e)
        {
            AdministratorAppointments Obj = new AdministratorAppointments();
            Obj.Show();
            this.Hide();
        }

        private void pacientsLb_Click(object sender, EventArgs e)
        {
            AdministratorPacients Obj = new AdministratorPacients();
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
