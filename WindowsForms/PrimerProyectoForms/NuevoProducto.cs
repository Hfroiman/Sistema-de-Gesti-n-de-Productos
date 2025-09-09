using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrimerProyectoForms
{
    public partial class NuevoProducto : Form
    {
        private Productos producto = null;
        private List<Colores> listaColores = new List<Colores>();
        private List<Talles> listaTalle = new List<Talles>();
        private List<Marcas> listaMarcas = new List<Marcas>();
        private List<Tipo_Productos> listaTipo_Productos = new List<Tipo_Productos>();

        public NuevoProducto(Productos seleccionado = null)
        {
            InitializeComponent();
            this.producto = seleccionado;
            Text = "MODIFICAR PRODUCTO";
        }

        private void NuevoProducto_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.producto != null)
                {
                    Cargarcbxs(this.producto);
                    CargarImagen(this.producto.IMG.ToString());
                }
                else
                {
                    Cargarcbxs();
                    CargarImagen();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Cargarcbxs(Productos pr = null)
        {
            try
            {
                Negocios obj = new Negocios();
                if (pr != null)
                {
                    txtCodigo.Text = pr.Codigo;
                    txtNombre.Text = pr.Nombre;
                    txtIMG.Text = pr.IMG.ToString();
                    txtPrecio.Text = pr.Precio.ToString();
                    txtCantidad.Text = pr.Cantidad.ToString();
                }
                listaColores = obj.listaColores();
                    listaMarcas = obj.listaMarcas();
                    listaTalle = obj.listaTalles();
                    listaTipo_Productos = obj.listaTipo_Productos();

                cbxColor.SelectedValue = pr.Colores.Id;
                    cbxColor.DataSource = listaColores;
                    cbxColor.DisplayMember = "nombre";
                    cbxColor.ValueMember = "Id";

                cbxmarca.SelectedValue = pr.Marcas.Id;
                    cbxmarca.DataSource = listaMarcas;
                    cbxmarca.DisplayMember = "nombre";
                    cbxmarca.ValueMember = "Id";

                cbxTalle.SelectedValue = pr.Talles.Id;
                    cbxTalle.DataSource = listaTalle;
                    cbxTalle.DisplayMember = "nombre";
                    cbxTalle.ValueMember = "Id";

                cbxCategoria.SelectedValue = pr.Tipo_Productos.Id;
                cbxCategoria.SelectedValue = pr.Tipo_Productos.Id;
                    cbxCategoria.DataSource = listaTipo_Productos;
                    cbxCategoria.DisplayMember = "nombre";
                cbxCategoria.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                Negocios negocio = new Negocios();
                Productos pr = new Productos();
                Colores color = new Colores();
                Marcas marca = new Marcas();
                Talles talle = new Talles();
                Tipo_Productos categoria = new Tipo_Productos();
            try
            {
                if (ConfirmarDatos())
                {
                    pr.Codigo = txtCodigo.Text;
                    pr.Nombre = txtNombre.Text;
                    pr.IMG = txtIMG.Text;
                    pr.Precio = int.Parse(txtPrecio.Text);
                    pr.Cantidad = int.Parse(txtCantidad.Text);
                    color.Id = (int)cbxColor.SelectedValue;
                    color.Nombre =cbxColor.Text;
                    pr.Colores = color;

                    marca.Id = (int)cbxmarca.SelectedValue;
                    marca.Nombre = cbxmarca.Text;
                    pr.Marcas = marca;

                    talle.Id = (int)cbxTalle.SelectedValue;
                    talle.Nombre = cbxTalle.Text;
                    pr.Talles = talle;

                    categoria.Id = (int)cbxCategoria.SelectedValue;
                    categoria.Nombre = cbxCategoria.Text;
                    pr.Tipo_Productos = categoria;

                    if (Confirmar()) negocio.Agregar(pr);
                        BorrarDatos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ConfirmarDatos()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                    return false;
                }
                if (!int.TryParse(txtCodigo.Text, out int cantidad))
                {
                    MessageBox.Show("El codigo debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidad.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txtIMG.Text))
                {
                    MessageBox.Show("Debe ingresar un URL de una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                    return false;
                }
                if (!int.TryParse(txtCantidad.Text, out cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidad.Focus();
                    return false;
                }
                if (!int.TryParse(txtPrecio.Text, out cantidad))
                {
                    MessageBox.Show("El precio debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidad.Focus();
                    return false;
                }

                if (cbxColor.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (cbxTalle.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un talle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (cbxmarca.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (cbxCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BorrarDatos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIMG.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }

        private bool Confirmar()
        {
            DialogResult confirmacion = MessageBox.Show(
            "¿Desea agregar este producto?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes) return true;
            return false;
        }
        private bool Cancelar()
        {
            DialogResult confirmacion = MessageBox.Show(
            "¿Está seguro que desea cancelar el ingreso de un producto?",
            "Cancelar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes) return true;
            return false;
        }

        private void txtIMG_TextChanged(object sender, EventArgs e)
        {
            CargarImagen();
        }
        private void CargarImagen(string img= null)
        {
            try
            {
                string Img = txtIMG.Text;
                if (img != null) Img = img;
                pbxImagen.Load(Img);
            }
            catch
            {
                pbxImagen.Load("data:image/png;base64,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");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Cancelar()) this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnIrCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cancelar()) this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
