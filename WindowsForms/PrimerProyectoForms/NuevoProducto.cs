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
                Cargarcbxs();
                CargarImagen();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Cargarcbxs()
        {
            try
            {
                Negocios obj = new Negocios();
                if (this.producto != null)
                {
                    txtCodigo.Text = this.producto.Codigo;
                    txtNombre.Text = this.producto.Nombre;
                    txtIMG.Text = this.producto.IMG.ToString();
                    txtPrecio.Text = this.producto.Precio.ToString();
                    txtCantidad.Text = this.producto.Cantidad.ToString();

                }
                listaColores = obj.listaColores();
                listaMarcas = obj.listaMarcas();
                listaTalle = obj.listaTalles();
                listaTipo_Productos = obj.listaTipo_Productos();

                cbxColor.DataSource = listaColores;
                cbxColor.DisplayMember = "nombre";
                cbxColor.ValueMember = "Id";

                cbxmarca.DataSource = listaMarcas;
                cbxmarca.DisplayMember = "nombre";
                cbxmarca.ValueMember = "Id";

                cbxTalle.DataSource = listaTalle;
                cbxTalle.DisplayMember = "nombre";
                cbxTalle.ValueMember = "Id";

                cbxCategoria.DataSource = listaTipo_Productos;
                cbxCategoria.DisplayMember = "nombre";
                cbxCategoria.ValueMember = "Id";

                cbxColor.SelectedValue = this.producto.Colores.Id;
                cbxmarca.SelectedValue = this.producto.Marcas.Id;
                cbxTalle.SelectedValue = this.producto.Talles.Id;
                cbxCategoria.SelectedValue = this.producto.Tipo_Productos.Id;
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
                    
                    if (this.producto != null)
                    {
                        if (Confirmar()) negocio.Modificar(pr, this.producto);
                            BorrarDatos();
                        this.Close();
                    }
                    else
                    {
                        if (Confirmar()) negocio.Agregar(pr);
                            BorrarDatos();
                    }
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
            string msj ="";
            if (this.producto != null) msj = "¿Desea modificar este producto?";
            else msj = "¿Desea agregar este producto?";
            DialogResult confirmacion = MessageBox.Show(
            msj,
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes) return true;
            return false;
        }
        private bool Cancelar()
        {
            string msj = "";
            if (this.producto != null) msj = "¿Está seguro que desea cancelar la modificacion del producto?";
            else msj = "¿Está seguro que desea cancelar el ingreso de un producto?";
            DialogResult confirmacion = MessageBox.Show(
            msj,
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
        private void CargarImagen()
        {
            try
            {
                string IMG = "";
                if (producto != null) IMG = producto.IMG;
                pbxImagen.Load(IMG);
            }
            catch
            {
                pbxImagen.Load("https://developer.android.com/static/codelabs/basic-android-kotlin-compose-load-images/img/70e008c63a2a1139.png?hl=es-419");
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
