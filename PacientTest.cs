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
    public partial class PacientTest : Form
    {
        private int testID;

        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public PacientTest(int testID)
        {
            InitializeComponent();
            this.testID = testID;
            LoadQuestionsAndOptions();
        }

        private void LoadQuestionsAndOptions()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT questionID, questionText FROM test_question WHERE testID = @testID", Con);
                cmd.Parameters.AddWithValue("@testID", testID);
                SqlDataReader reader = cmd.ExecuteReader();

                int yOffset = 10;
                while (reader.Read())
                {
                    int questionID = reader.GetInt32(0);
                    string questionText = reader.GetString(1);

                 
                    Label questionLabel = new Label();
                    questionLabel.Text = questionText;
                    questionLabel.Top = yOffset;
                    questionLabel.Left = 10;
                    questionLabel.AutoSize = true;
                    this.Controls.Add(questionLabel);

                    
                    LoadOptions(questionID, yOffset + 30);
                    yOffset += 100;
                }

                reader.Close();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
        }

        private void LoadOptions(int questionID, int yOffset)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT optionID, optionText, score FROM option WHERE questionID = @questionID", Con);
                cmd.Parameters.AddWithValue("@questionID", questionID);
                SqlDataReader reader = cmd.ExecuteReader();

                int xOffset = 10;
                while (reader.Read())
                {
                    int optionID = reader.GetInt32(0);
                    string optionText = reader.GetString(1);
                    int score = reader.GetInt32(2);

                   
                    RadioButton optionButton = new RadioButton();
                    optionButton.Text = optionText;
                    optionButton.Tag = score; 
                    optionButton.Top = yOffset;
                    optionButton.Left = xOffset;
                    optionButton.AutoSize = true;
                    this.Controls.Add(optionButton);

                    xOffset += 200;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int totalScore = 0;
            foreach (Control control in this.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    totalScore += (int)radioButton.Tag;
                }
            }

            SaveTestResult(totalScore);
        }

        private void SaveTestResult(int score)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO test_result(testID, score) VALUES(@testID, @score)", Con);
                cmd.Parameters.AddWithValue("@testID", testID);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("Rezultatele testului au fost salvate.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
        }
    }
}
