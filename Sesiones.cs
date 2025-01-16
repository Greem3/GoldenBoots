﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GoldenBoots.Properties;

namespace GoldenBoots
{
    public partial class Sesiones : Form
    {
        public Sesiones()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RepeatFunctions.OpenForm(this, new Registro());
        }

        private void iniciar_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            List<object[]> data = db.Query($"SELECT * FROM USUARIOS WHERE EMAIL = '{email.Text}'");
            
            foreach (object[] row in data)
            {
                if (row[4].ToString() == pass.Text)
                {
                    MessageBox.Show("Sesión Iniciada Exitosamente", "Sesión Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RepeatFunctions.OpenForm(this, new Inicio());
                    return;
                }
            }

            MessageBox.Show("La contraseña o el correo no están correctos", "Datos no encontrados",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}


    