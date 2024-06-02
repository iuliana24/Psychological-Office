﻿using System;
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
    public partial class PsychologistInvoices : Form
    {
        public PsychologistInvoices()
        {
            InitializeComponent();
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
    }
}
