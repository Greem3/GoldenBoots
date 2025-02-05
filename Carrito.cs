﻿using System.Data;
using GoldenBoots;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GoldenBoots
{

    public partial class Carrito : Form
    {
        private object codigoProducto;

        public Carrito()
        {
            InitializeComponent();
        }

        private void ChangeCantity(object sender, EventArgs e)
        {
            Button obj = sender as Button;

            TextBox cantity = this.Controls["cantityText" + obj.Name.Remove(0, 1)] as TextBox;

            DataTable calculator = new();

            cantity.Text = calculator.Compute($"{cantity.Text}{obj.Text}1", null).ToString();
        }

        private void NewTotal(object sender, EventArgs e)
        {
            double[] prices = (new string[] { price1.Text.Remove(0, 4), price2.Text.Remove(0, 4) }).Select(double.Parse).ToArray();
            prices[0] *= int.Parse(cantityText1.Text);
            prices[1] *= int.Parse(cantityText2.Text);
            total.Text = "Total: " + prices.Sum();
        }

        private void bvolver_Click(object sender, EventArgs e)
        {
            RepeatFunctions.OpenForm(this, new Inicio());
        }

        private void button10_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Compra realizada con éxito.");
        }




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            var productos = db.Select("select * from CARRITO_DE_COMPRAS WHERE Codigo = algo");

            if (productos.Count > 0)
            {
                string rutaImagen = productos[0][0].ToString();

                pictureBox2.Image = Image.FromFile($"././{rutaImagen}");
            }

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void Carrito_Load(object sender, EventArgs e)
        {

        }
    }
}

public class Database
{
    private string connectionString = "Server=DESKTOP-0VETQJN;Database=Base de datos goldenboots actualizada;Integrated Security=True;";

    public DataTable ObtenerProductos()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Nombre, Codigo, Talla, Precio, Imagen FROM Productos";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
        }
        return dt;
    }
}