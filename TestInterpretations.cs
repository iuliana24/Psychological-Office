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
    public partial class TestInterpretations : Form
    {
        private int testID;
        private List<Interpretation> interpretationsList;
        public TestInterpretations(int testID)
        {
            InitializeComponent();
            this.testID = testID;
            interpretationsList = new List<Interpretation>();
            LoadInterpretations();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=True");


        private void LoadInterpretations()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM interpretation WHERE testID=@testID", Con);
                cmd.Parameters.AddWithValue("@testID", testID);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 1;

                while (reader.Read())
                {
                    Interpretation interpretation = new Interpretation
                    {
                        InterpretationID = Convert.ToInt32(reader["interpretationID"]),
                        TestID = testID,
                        ScoreMin = Convert.ToInt32(reader["scoreMIN"]),
                        ScoreMax = Convert.ToInt32(reader["scoreMAX"]),
                        Text = reader["interpretationText"].ToString()
                    };
                    interpretationsList.Add(interpretation);

                   
                    TextBox scoreMinTextBox = this.Controls["min" + i] as TextBox;
                    TextBox scoreMaxTextBox = this.Controls["max" + i] as TextBox;
                    TextBox interpretationTextBox = this.Controls["interpretation" + i] as TextBox;

                    if (scoreMinTextBox != null && scoreMaxTextBox != null && interpretationTextBox != null)
                    {
                        scoreMinTextBox.Text = interpretation.ScoreMin.ToString();
                        scoreMaxTextBox.Text = interpretation.ScoreMax.ToString();
                        interpretationTextBox.Text = interpretation.Text;
                    }

                    i++;
                }

                reader.Close();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare la încărcarea interpretărilor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Con.Close();
            }
        }


        private void addBtn_Click(object sender, EventArgs e)
        {

            interpretationsList.Clear();

            for (int i = 1; i <= 3; i++)
            {
                TextBox scoreMinTextBox = this.Controls["min" + i] as TextBox;
                TextBox scoreMaxTextBox = this.Controls["max" + i] as TextBox;
                TextBox interpretationTextBox = this.Controls["interpretation" + i] as TextBox;

                if (scoreMinTextBox != null && scoreMaxTextBox != null && interpretationTextBox != null &&
                    int.TryParse(scoreMinTextBox.Text, out int scoreMin) &&
                    int.TryParse(scoreMaxTextBox.Text, out int scoreMax) &&
                    !string.IsNullOrEmpty(interpretationTextBox.Text))
                {
                    interpretationsList.Add(new Interpretation
                    {
                        TestID = testID,
                        ScoreMin = scoreMin,
                        ScoreMax = scoreMax,
                        Text = interpretationTextBox.Text
                    });
                }
                else
                {
                    MessageBox.Show("Completați toate câmpurile!");
                    return;
                }
            }

            try
            {
                Con.Open();

                SqlCommand deleteCmd = new SqlCommand("DELETE FROM interpretation WHERE testID=@testID", Con);
                deleteCmd.Parameters.AddWithValue("@testID", testID);
                deleteCmd.ExecuteNonQuery();

                foreach (var interpretation in interpretationsList)
                {
                    SqlCommand insertInterpretationCmd = new SqlCommand("INSERT INTO interpretation(scoreMIN, scoreMAX, interpretationText, testID) " +
                        "VALUES(@scoreMIN, @scoreMAX, @interpretationText, @testID)", Con);
                    insertInterpretationCmd.Parameters.AddWithValue("@testID", testID);
                    insertInterpretationCmd.Parameters.AddWithValue("@scoreMIN", interpretation.ScoreMin);
                    insertInterpretationCmd.Parameters.AddWithValue("@scoreMAX", interpretation.ScoreMax);
                    insertInterpretationCmd.Parameters.AddWithValue("@interpretationText", interpretation.Text);
                    insertInterpretationCmd.ExecuteNonQuery();
                }
                Con.Close();
                MessageBox.Show("Datele au fost salvate cu succes.");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare la salvarea datelor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Con.Close();
            }
        }

        private void ClearForm()
        {
            for (int i = 1; i <= 3; i++)
            {
                TextBox scoreMinTextBox = this.Controls["min" + i] as TextBox;
                TextBox scoreMaxTextBox = this.Controls["max" + i] as TextBox;
                TextBox interpretationTextBox = this.Controls["interpretation" + i] as TextBox;

                if (scoreMinTextBox != null && scoreMaxTextBox != null && interpretationTextBox != null)
                {
                    scoreMinTextBox.Text = "";
                    scoreMaxTextBox.Text = "";
                    interpretationTextBox.Text = "";
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            AdministratorTests Obj = new AdministratorTests();
            Obj.Show();
            this.Hide();
        }

       
    }
}
