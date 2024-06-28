using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Licenta
{
    public partial class PsychologistInvoices : Form
    {
        public PsychologistInvoices()
        {
            InitializeComponent();
            displayInvoices();
        }

        //SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-C78TFJK\SQLEXPRESS02;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K09QKJF\SQLEXPRESS;Initial Catalog=PsychologicalOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private void displayInvoices()
        {
            Con.Open();
            string query = "SELECT invoiceID as Id, lastname as Nume, firstname as Prenume, date as Data, consultType as TipConsult, amount as Total from invoice;";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            invoicesView.DataSource = ds.Tables[0];
            Con.Close();
        }

        int Key;
        private void invoicesView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = invoicesView.Rows[e.RowIndex];

                    int id = 0;


                    if (int.TryParse(GetCellValue(selectedRow, id), out int keyValue))
                    {
                        Key = keyValue;
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

        private void invoicegenBtn_Click(object sender, EventArgs e)
        {
            if (Key > 0)
            {
                try
                {
                    Con.Open();
                    string query = "SELECT * FROM invoice WHERE invoiceID = @Key";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        string firstname = row["firstname"].ToString();
                        string lastname = row["lastname"].ToString();
                        DateTime date = Convert.ToDateTime(row["date"]);
                        string consultType = row["consultType"].ToString();
                        decimal amount = Convert.ToDecimal(row["amount"]);

                        InvoicePreview previewForm = new InvoicePreview(firstname, lastname, date, consultType, amount);
                        previewForm.ShowDialog();
                        Clear();
                        Con.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Factura nu a fost găsită.");
                    }

                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Eroare SQL: {sqlEx.Message}\nCod eroare: {sqlEx.Number}\nLinia: {sqlEx.LineNumber}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"A apărut o eroare la conectarea la baza de date: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Selectați o factură pentru previzualizare.");
            }
        }

        private void Clear()
        {

            Key = 0;

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

        private void testsLb_Click(object sender, EventArgs e)
        {
            PsychologistTests Obj = new PsychologistTests();
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

        private void PsychologistInvoices_Load(object sender, EventArgs e)
        {
            invoicesView.Columns[0].Width = 40;
        }

      
    }
}
