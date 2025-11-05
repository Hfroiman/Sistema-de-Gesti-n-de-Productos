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
        private List<Marcas> listaMarcas = new List<Marcas>();
        private List<Tipo_Productos> listaTipos = new List<Tipo_Productos>();
        public Index()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_CBX_Filtros();
                CargarLista();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarLista()
        {
            try
            {
                Negocios negocio = new Negocios();
                listaProductos = negocio.Listar();
                cargardgv();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Cargar_CBX_Filtros()
        {
            try
            {
                int inicio = -1;
                Negocios negocios = new Negocios();
                listaMarcas = negocios.listaMarcas();
                listaTipos = negocios.listaTipo_Productos();

                cbxMarcas.DataSource = listaMarcas;
                cbxMarcas.DisplayMember = "Nombre";
                cbxMarcas.ValueMember = "Id";
                cbxMarcas.SelectedIndex = inicio;

                cbxtipos.DataSource = listaTipos;
                cbxtipos.DisplayMember = "Nombre";
                cbxtipos.ValueMember = "Id";
                cbxtipos.SelectedIndex = inicio;

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
                dgvProductos.DataSource = listaProductos;
                OcultarColumnas();
                if (listaProductos.Count > 0)
                {
                    CargarImagen(listaProductos[0].IMG);
                    CargarDetalle(listaProductos[0]);
                }
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
            }
            catch (Exception ex)
            {
                throw ex;
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
            {/*
                Carrito carrito = new Carrito(listaCarrito);
                carrito.FormClosed += (s, args) => CargarLista();
                carrito.ShowDialog();*/
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
            catch
            {
                pbxImg.Load("https://developer.android.com/static/codelabs/basic-android-kotlin-compose-load-images/img/70e008c63a2a1139.png?hl=es-419");
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
                ventana.FormClosed += (s, args) => CargarLista();
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
            try
            {
                Productos seleccionado = new Productos();
                seleccionado = (Productos)dgvProductos.CurrentRow.DataBoundItem;

                NuevoProducto modificar = new NuevoProducto(seleccionado);
                modificar.FormClosed += (s, args) => CargarLista();
                modificar.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocios neg = new Negocios();
                Productos seleccionado = new Productos();
                seleccionado = (Productos)dgvProductos.CurrentRow.DataBoundItem;
                if (Confirmar()) neg.BajaLogica(seleccionado);
                cargardgv();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool Confirmar()
        {
            string msj = "¿Estas seguro de eliminar el producto?";
            DialogResult confirmacion = MessageBox.Show(
            msj,
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes) return true;
            return false;
        }
        
        private void cbxtipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FiltrarProductos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbxMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FiltrarProductos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FiltrarProductos()
        {
            try
            {
                Negocios neg = new Negocios();
                Marcas marca = new Marcas();
                Tipo_Productos tipo = new Tipo_Productos();

                string nombre = txtbuscar.Text;
                marca = (Marcas)cbxMarcas.SelectedItem;
                tipo = (Tipo_Productos)cbxtipos.SelectedItem;

                listaProductos = neg.Filtarbusqueda(marca, tipo, nombre);
                cargardgv();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void brnBorrarfiltros_Click(object sender, EventArgs e)
        {
            Cargar_CBX_Filtros();
            txtbuscar.Text = "";
            CargarLista();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FiltrarProductos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCargarCarrito_Click(object sender, EventArgs e)
        {
            Productos seleccionado = new Productos();
            try
            {/*
                if(cbxCantidad.SelectedItem != null)
                {
                    int cantSeleccionada = (int)cbxCantidad.SelectedItem;
                    seleccionado = (Productos)dgvProductos.CurrentRow.DataBoundItem;
                    seleccionado.Cantidad = cantSeleccionada;
                    Carrito.listacarrito(seleccionado);
                    //listaCarrito.Add(seleccionado);

                }
                else SeleccionarCant();*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SeleccionarCant()
        {
            string msj = "Debe seleccionar la cantidad de productos a cargar en el carrito.";
            DialogResult confirmacion = MessageBox.Show(
            msj,
            "Confirmar",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes) return true;
            return false;
        }
    }
}
