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
    public partial class TestQuestions : Form
    {
        private int testID;
        private string testName;
        private string testDescription;
        private bool isUpdate;
        public TestQuestions(int testID, bool isUpdate = false)
        {
            InitializeComponent();
            this.testID = testID;

            this.isUpdate = isUpdate;

            if (isUpdate)
            {              
                LoadTestQuestions(testID);
            }
        }

        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=True");
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=True");

        public void LoadTestQuestions(int testID)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM test_question WHERE testID=@testID", Con);
                cmd.Parameters.AddWithValue("@testID", testID);
                SqlDataReader reader = cmd.ExecuteReader();

                int questionIndex = 1;

                while (reader.Read())
                {
                    TextBox questionTextBox = this.Controls["questionTextBox" + questionIndex] as TextBox;
                    if (questionTextBox != null)
                    {
                        questionTextBox.Text = reader["questionText"].ToString();
                    }

                    int questionID = Convert.ToInt32(reader["questionID"]);

                    SqlCommand optionCmd = new SqlCommand("SELECT * FROM [option] WHERE questionID=@questionID", Con);
                    optionCmd.Parameters.AddWithValue("@questionID", questionID);
                    SqlDataReader optionReader = optionCmd.ExecuteReader();

                    int optionIndex = 1;

                    while (optionReader.Read())
                    {
                        TextBox optionTextBox = this.Controls["optionTextBox" + questionIndex + "_" + optionIndex] as TextBox;
                        if (optionTextBox != null)
                        {
                            optionTextBox.Text = optionReader["optionText"].ToString();
                        }
                        optionIndex++;
                    }
                    optionReader.Close();

                    questionIndex++;
                }
                reader.Close();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare la încărcarea întrebărilor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Con.Close();
            }
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            AdministratorTests Obj = new AdministratorTests();
            Obj.Show();
            this.Hide();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (testID == 0) 
            {
                MessageBox.Show("ID-ul testului nu este valid.");
                return;
            }

            if (!ValidateQuestionsAndOptions())
            {
                return;
            }

            try
            {
                Con.Open();

                for (int i = 1; i <= 8; i++)
                {
                    TextBox questionTextBox = this.Controls["questionTextBox" + i] as TextBox;
                    if (questionTextBox != null && !string.IsNullOrEmpty(questionTextBox.Text))
                    {
                       
                        SqlCommand questionCmd = new SqlCommand("INSERT INTO test_question(testID, questionText) VALUES(@testID, @questionText); SELECT SCOPE_IDENTITY();", Con);
                        questionCmd.Parameters.AddWithValue("@testID", testID);
                        questionCmd.Parameters.AddWithValue("@questionText", questionTextBox.Text);

                        int questionID = Convert.ToInt32(questionCmd.ExecuteScalar());

                        bool areOptionsValid = false;
                        for (int j = 1; j <= 3; j++)
                        {
                            TextBox optionTextBox = this.Controls["optionTextBox" + i + "_" + j] as TextBox;
                            if (optionTextBox != null && !string.IsNullOrEmpty(optionTextBox.Text))
                            {
                              
                                SqlCommand optionCmd = new SqlCommand("INSERT INTO [option](questionID, optionText) VALUES(@questionID, @optionText)", Con);
                                optionCmd.Parameters.AddWithValue("@questionID", questionID);
                                optionCmd.Parameters.AddWithValue("@optionText", optionTextBox.Text);
                                optionCmd.ExecuteNonQuery();

                                areOptionsValid = true;
                            }
                        }

                        if (!areOptionsValid)
                        {
                            MessageBox.Show("Introduceți cel puțin o opțiune pentru întrebarea " + i);
                            return;
                        }
                    }
                }

                Con.Close();
                MessageBox.Show("Întrebări și răspunsuri adăugate cu succes.");
                ClearQuestionsForm();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            if (isUpdate)
            {
                MessageBox.Show("Test actualizat.");
            }
        }

        private bool ValidateQuestionsAndOptions()
        {
            bool isValid = true;

            for (int i = 1; i <= 8; i++)
            {
                TextBox questionTextBox = this.Controls["questionTextBox" + i] as TextBox;
                if (questionTextBox != null && string.IsNullOrEmpty(questionTextBox.Text))
                {
                    MessageBox.Show("Introduceți text pentru întrebarea " + i);
                    isValid = false;
                    break;
                }

                bool areOptionsValid = false;
                for (int j = 1; j <= 3; j++)
                {
                    TextBox optionTextBox = this.Controls["optionTextBox" + i + "_" + j] as TextBox;
                    if (optionTextBox != null && !string.IsNullOrEmpty(optionTextBox.Text))
                    {
                        areOptionsValid = true;
                    }
                }

                if (!areOptionsValid)
                {
                    MessageBox.Show("Introduceți cel puțin o opțiune pentru întrebarea " + i);
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private void ClearQuestionsForm()
        {
            for (int i = 1; i <= 8; i++)
            {
                TextBox questionTextBox = this.Controls["questionTextBox" + i] as TextBox;
                if (questionTextBox != null)
                {
                    questionTextBox.Text = "";
                }

                for (int j = 1; j <= 3; j++)
                {
                    TextBox optionTextBox = this.Controls["optionTextBox" + i + "_" + j] as TextBox;
                    if (optionTextBox != null)
                    {
                        optionTextBox.Text = "";
                    }
                }
            }
        }
    }
}
