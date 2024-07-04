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
        int testID;
        
        public AdministratorTests()
        {
            InitializeComponent();
            displayTests();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


        private void displayTests()
        {
            Con.Open();
            string query = "SELECT testID as Id, name as Denumire, description as Descriere, imagePath as Imagine FROM test;";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            testsView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void uploadImgBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                imgPath.Text = selectedImagePath;


            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || description.Text == "")
            {
                MessageBox.Show("Lipsesc informații!");
            }
            else
            {
                string imagePath = imgPath.Text;
                try
                {

                    Con.Open();

                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM test WHERE CAST(name AS NVARCHAR(MAX)) = @name AND CAST(description AS NVARCHAR(MAX)) = @description", Con);
                    checkCmd.Parameters.AddWithValue("@name", name.Text);
                    checkCmd.Parameters.AddWithValue("@description", description.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Un test cu același nume și descriere există deja.");
                        Con.Close();
                        return;
                    }
                    

                    SqlCommand cmd = new SqlCommand("INSERT INTO test(name, description, imagePath) VALUES (@name, @description, @imagePath); SELECT SCOPE_IDENTITY()", Con);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@description", description.Text);
                    cmd.Parameters.AddWithValue("@imagePath", imagePath);


                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        testID = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut obține testID valid.");
                        return;
                    }

                    MessageBox.Show("Test adăugat preliminar. Adăugați întrebările și interpretările.");

                    TestQuestions addQuestions = new TestQuestions(testID, false);
                    this.Hide();
                    addQuestions.Show();
                   

                    Con.Close();
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
            if (Key == 0 || name.Text == "" || description.Text == "")
            {
                MessageBox.Show("Lipsesc informații!");
            }
            else
            {
                string imagePath = imgPath.Text;
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update test set name=@name, description=@description, imagePath=@imagePath where testID=@Key", Con);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@description", description.Text);
                    cmd.Parameters.AddWithValue("@imagePath", imagePath);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    Con.Close();


                    TestQuestions testQuestionsForm = new TestQuestions(Key, true);
                    this.Hide();
                    testQuestionsForm.LoadTestQuestions(Key);
                    testQuestionsForm.ShowDialog();

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


                    SqlCommand deleteInterpretationsCmd = new SqlCommand("DELETE FROM interpretation WHERE testID=@Key", Con);
                    deleteInterpretationsCmd.Parameters.AddWithValue("@Key", Key);
                    deleteInterpretationsCmd.ExecuteNonQuery();


                    SqlCommand deleteOptionsCmd = new SqlCommand("DELETE FROM [option] WHERE questionID IN (SELECT questionID FROM question WHERE testID=@Key)", Con);
                    deleteOptionsCmd.Parameters.AddWithValue("@Key", Key);
                    deleteOptionsCmd.ExecuteNonQuery();


                    SqlCommand deleteQuestionsCmd = new SqlCommand("DELETE FROM question WHERE testID=@Key", Con);
                    deleteQuestionsCmd.Parameters.AddWithValue("@Key", Key);
                    deleteQuestionsCmd.ExecuteNonQuery();


                    SqlCommand deleteTestCmd = new SqlCommand("DELETE FROM test WHERE testID=@Key", Con);
                    deleteTestCmd.Parameters.AddWithValue("@Key", Key);
                    deleteTestCmd.ExecuteNonQuery();

                    Con.Close();
                    MessageBox.Show("Test șters.");
                    Clear();
                    displayTests();
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
                    int imagePathIndex = 3;


                    if (selectedRow.Cells.Count > descriptionIndex)
                    {

                        name.Text = GetCellValue(selectedRow, nameIndex);
                        description.Text = GetCellValue(selectedRow, descriptionIndex);
                        imgPath.Text = GetCellValue(selectedRow, imagePathIndex);




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
            imgPath.Text = "";
            Key = 0;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void AdministratorTests_Load(object sender, EventArgs e)
        {
            testsView.Columns[0].Width = 40;
            testsView.Columns[1].Width = 240;
            testsView.Columns[2].Width = 240;
            testsView.Columns[3].Width = 240;
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
