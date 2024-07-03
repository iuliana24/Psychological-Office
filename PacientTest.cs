﻿using Microsoft.Data.SqlClient;
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
        private Panel questionsPanel;
        private Button submitButton;
        private string connectionString = @"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public PacientTest(int testID)
        {
            InitializeComponent();
            this.testID = testID;

           
            Label testNameLabel = new Label
            {
                ForeColor = Color.Teal,    
                Text = GetTestName(testID),
                Font = new Font(Font.FontFamily, 14, FontStyle.Bold),
                AutoSize = true,
                Top = 50
                 
            };
            testNameLabel.Left = (this.ClientSize.Width - GetTextWidth(testNameLabel.Text, testNameLabel.Font)) / 2;
            this.Controls.Add(testNameLabel);

            questionsPanel = new Panel
            {
                AutoScroll = true,                                         
                Location = new Point(20, testNameLabel.Bottom + 20),
                Width = this.ClientSize.Width - 40,
                Height = this.ClientSize.Height - testNameLabel.Bottom - 80,
                AutoScrollMargin = new Size(0, 20)
              
            };
            this.Controls.Add(questionsPanel);

           
           
            submitButton = new Button
            {
                BackColor = Color.Teal,
                ForeColor = Color.White,
                Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
                Text = "Salvează",
                Width = 120,
                Height = 40,
                Top = questionsPanel.Bottom - 60,
                Left = (this.questionsPanel.Width - 120) / 2,
                
            };
            
            submitButton.Click += submitButton_Click;
            questionsPanel.Controls.Add(submitButton);

            LoadQuestionsAndOptions();

        }

        private string GetTestName(int testID)
        {
            string testName = "";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT name FROM test WHERE testID = @testID", con))
                    {
                        cmd.Parameters.AddWithValue("@testID", testID);
                        testName = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare la obținerea numelui testului: {ex.Message}");
            }
            return testName;
        }

        private void LoadQuestionsAndOptions()
        {
            questionsPanel.Controls.Clear();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT questionID, questionText FROM question WHERE testID = @testID", con))
                    {
                        cmd.Parameters.AddWithValue("@testID", testID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                int yOffset = 40;
                                while (reader.Read())
                                {
                                    int questionID = reader.GetInt32(0);
                                    string questionText = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                                    Label questionLabel = new Label
                                    {
                                        Text = questionText,                                     
                                        AutoSize = true
                                    };
                                    questionLabel.Location = new Point(30, yOffset);
                                    questionsPanel.Controls.Add(questionLabel);

                                    yOffset += questionLabel.Height + 10;

                                    yOffset = LoadOptions(questionID, yOffset);

                                    yOffset += 30;
                                    
                                }

                                yOffset += 20;
                               
                                submitButton.Top = yOffset;
                                submitButton.Left = (questionsPanel.Width - submitButton.Width) / 2;
                                questionsPanel.Controls.Add(submitButton);
                            }
                            else
                            {
                                MessageBox.Show("Nu există întrebări asociate acestui test.");
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
        }

        private int LoadOptions(int questionID, int yOffset)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT optionID, optionText, score FROM [option] WHERE questionID = @questionID", con))
                    {
                        cmd.Parameters.AddWithValue("@questionID", questionID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                int optionID = reader.GetInt32(0);
                                string optionText = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                int score = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);

                                CheckBox optionCheckBox = new CheckBox
                                {
                                    Text = optionText,
                                    Tag = score,                                  
                                    AutoSize = true
                                };
                                optionCheckBox.Location = new Point(50, yOffset);
                                questionsPanel.Controls.Add(optionCheckBox);

                                yOffset += optionCheckBox.Height + 10;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }

            return yOffset;
        }

       
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (AreAllQuestionsAnswered())
            {
                int totalScore = 0;
                foreach (Control control in questionsPanel.Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        totalScore += (int)checkBox.Tag;
                    }
                }

                SaveTestResult(totalScore);
            }
            else
            {
                MessageBox.Show("Vă rugăm să bifați cel puțin o opțiune pentru fiecare întrebare.");
            }
        }

        private bool AreAllQuestionsAnswered()
        {
            int currentQuestionID = -1;
            bool isChecked = false;

            foreach (Control control in questionsPanel.Controls)
            {
                if (control is Label label)
                {
                    if (currentQuestionID != -1 && !isChecked)
                    {
                        return false;
                    }
                    isChecked = false;
                    currentQuestionID++;
                }
                else if (control is CheckBox checkBox)
                {
                    if (checkBox.Checked)
                    {
                        isChecked = true;
                    }
                }
            }
            return isChecked;
        }

        private void SaveTestResult(int score)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO test_result(testID, score, date, time) VALUES (@testID, @score, @date, @time)", con))
                    {
                        cmd.Parameters.AddWithValue("@testID", testID);
                        cmd.Parameters.AddWithValue("@score", score);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("HH:mm:ss"));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Rezultatul testului a fost salvat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
        }

        private void PacientTest_Load(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Pacients Obj = new Pacients();
            Obj.Show();
            this.Hide();
        }

        private int GetTextWidth(string text, Font font)
        {
            using (Graphics g = this.CreateGraphics())
            {
                SizeF size = g.MeasureString(text, font);
                return (int)Math.Ceiling(size.Width);
            }
        }
    }
}
