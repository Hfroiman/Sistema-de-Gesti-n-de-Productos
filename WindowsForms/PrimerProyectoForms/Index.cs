using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace PrimerProyectoForms
{
    public partial class Index : Form
    {
        private List<Productos> listaProductos = new List<Productos>();
        private List<Colores> listaColores = new List<Colores>();
        private List<Talles> listaTalles = new List<Talles>();
        public Index()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cargardgv();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cargardgv()
        {
            try
            {
                Negocios negocio = new Negocios();
                listaProductos = negocio.Listar();
                dgvProductos.DataSource = listaProductos;
                OcultarColumnas();
                CargarImagen(listaProductos[0].IMG);
                CargarDetalle(listaProductos[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDetalle(Productos productos)
        {
            try
            {
                lblNombreProducto.Text = productos.Nombre;
                lblPrecio.Text = "PRECIO: $" + productos.Precio.ToString();
                lblCantidad.Text = "TOTAL DISPONIBLE: " + productos.Cantidad.ToString();
                lblcolor.Text = "COLOR: " + productos.Colores.Nombre.ToString();
                lbltalle.Text = "TALLE: " + productos.Talles.Nombre.ToString();
                CargarCBX(productos.Cantidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCBX(int cantidad)
        {
            cbxCantidad.Items.Clear();
            for (int i = 1; i <= cantidad; i++)
            {
                cbxCantidad.Items.Add(i);
            } 
        }

        private void OcultarColumnas()
        {
            dgvProductos.Columns["IMG"].Visible = false;
            dgvProductos.Columns["Colores"].Visible = false;
            dgvProductos.Columns["Talles"].Visible = false;
            dgvProductos.Columns["Tipo_Productos"].Visible = false;
        }

        private void btnIrCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Application.OpenForms)
                {
                    if (item.GetType() == typeof(Carrito))
                    {
                        return;
                    }
                }
                Carrito ventana = new Carrito();
                ventana.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Productos seleccionado = (Productos)dgvProductos.CurrentRow.DataBoundItem;
                CargarImagen(seleccionado.IMG);
                CargarDetalle(seleccionado);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarImagen(string iMG)
        {
            try
            {
                pbxImg.Load(iMG);
            }
            catch {
                pbxImg.Load("htt");
            }
        }

        private void btnAgregarNuevoProducto_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Application.OpenForms)
                {
                    if (item.GetType() == typeof(NuevoProducto))
                    {
                        return;
                    }
                }
                NuevoProducto ventana = new NuevoProducto();
                ventana.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnIrAVentas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Application.OpenForms)
                {
                    if (item.GetType() == typeof(Ventas))
                    {
                        return;
                    }
                }
                Ventas ventana = new Ventas();
                ventana.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Productos seleccionado = new Productos();
            seleccionado = (Productos)dgvProductos.CurrentRow.DataBoundItem;

            NuevoProducto modificar = new NuevoProducto(seleccionado);
            modificar.ShowDialog();
        }
    }
}
