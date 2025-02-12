using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoldenBoots
{
    public partial class adminform : Form
    {
        private Database db;

        public adminform()
        {
            InitializeComponent();
            db = new Database(); // Inicia la conexión a la base de datos
        }

        private void adminform_Load(object sender, EventArgs e)
        {
            CargarClientes(); // Cargar clientes al iniciar el formulario
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = "";

            if (!string.IsNullOrEmpty(nombre))
            {
                try
                {
                    string query = "INSERT INTO Clientes (Nombre) VALUES (@nombre)";
                    MessageBox.Show("Cliente guardado correctamente.");
                    CargarClientes(); // Refrescar lista
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre válido.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse("", out int id))
            {
                string query = "SELECT Nombre FROM Clientes WHERE Id = @id";
                object[] cliente = db.SelectOne(query);

                if (cliente != null)
                {
                    datos.Text = $"Nombre: {cliente[0]}";
                }
                else
                {
                    datos.Text = "Cliente no encontrado.";
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido.");
            }
        }

        private void CargarClientes()
        {
            datos.Rows.Clear(); // Limpia el DataGridView

            List<object[]> clientes = db.Select("SELECT Id, Nombre FROM Clientes");

            foreach (var fila in clientes)
            {
                datos.Rows.Add(fila); // Agrega cada fila al DataGridView
            }
        }

        private void adminform_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Close(); // Cierra la conexión al cerrar el formulario
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            RepeatFunctions.OpenForm(this, new Inicio());
        }
    }
}
