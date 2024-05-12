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
    public partial class AdministratorTests : Form
    {
        public AdministratorTests()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Setează filtre pentru tipurile de fișiere permise
            openFileDialog.Filter = "Fișiere text (*.txt)|*.txt|Toate fișierele (*.*)|*.*";

            // Afișează fereastra de dialog pentru selectarea fișierului
            DialogResult result = openFileDialog.ShowDialog();

            // Verifică dacă utilizatorul a selectat un fișier și dacă a apăsat pe butonul "OK"
            if (result == DialogResult.OK)
            {
                // Obține calea completă a fișierului selectat
                string filePath = openFileDialog.FileName;

                // Poți face ceva cu calea fișierului, cum ar fi afișarea sau încărcarea conținutului fișierului
                // Exemplu: MessageBox.Show("Fișierul selectat: " + filePath);
            }
        }
    }
}
