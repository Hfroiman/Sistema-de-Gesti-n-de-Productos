using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Negocios
    {
        public List<Productos> Listar()
        {
            List<Productos> lista = new List<Productos>();
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.SetearConsulta("SELECT pr.Codigo, IMG, pr.Nombre as Nombre, Cantidad, Precio, col.Nombre as Color, col.Id_Color as Id_Color, t.Nombre as Talle, t.Id_Talle, m.Nombre as Marca, m.Id_Marca, tp.Nombre as Categoria, tp.Id_Tipo FROM Productos pr INNER JOIN Colores col on pr.Id_Color=col.ID_Color INNER JOIN Talles t on pr.Id_Talle=t.ID_Talle INNER JOIN Marcas m on pr.Id_Marca= m.ID_Marca INNER JOIN Tipo_Producto tp on pr.Id_Tipo=tp.ID_Tipo where pr.Estado=0");
                acceso.EjecutarLectura();
                while (acceso.Lector.Read())
                {
                    Productos aux = new Productos();
                    aux.Colores = new Colores();
                    aux.Talles = new Talles();
                    aux.Marcas = new Marcas();
                    aux.Tipo_Productos = new Tipo_Productos();

                    aux.Codigo = (string) acceso.Lector["Codigo"];
                    aux.IMG = (string)acceso.Lector["IMG"];
                    aux.Nombre = (string)acceso.Lector["Nombre"];
                    aux.Cantidad = Convert.ToInt32(acceso.Lector["Cantidad"]);
                    aux.Precio = Convert.ToInt32(acceso.Lector["Precio"]);

                    aux.Colores.Nombre = (string) acceso.Lector["Color"];
                    aux.Colores.Id = Convert.ToInt32(acceso.Lector["Id_Color"]);

                    aux.Talles.Nombre = (string) acceso.Lector["Talle"];
                    aux.Talles.Id = Convert.ToInt32(acceso.Lector["Id_Talle"]);

                    aux.Marcas.Nombre = (string) acceso.Lector["Marca"];
                    aux.Marcas.Id = Convert.ToInt32(acceso.Lector["Id_Marca"]);

                    aux.Tipo_Productos.Nombre = (string)acceso.Lector["Categoria"];
                    aux.Tipo_Productos.Id = Convert.ToInt32(acceso.Lector["Id_Tipo"]);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }finally
            {
                acceso.CerrarConexion();
            }
        }

        public List<Colores> listaColores()
        {
            List<Colores> lista = new List<Colores>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT Id_Color, Nombre from Colores");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Colores col = new Colores();

                    col.Id = Convert.ToInt32(datos.Lector["ID_Color"]);
                    col.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(col);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Marcas> listaMarcas()
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT Id_Marca, Nombre from Marcas");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Marcas obj = new Marcas();

                    obj.Id = Convert.ToInt32(datos.Lector["ID_Marca"]);
                    obj.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(obj);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Talles> listaTalles()
        {
            List<Talles> lista = new List<Talles>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT Id_Talle, Nombre from Talles");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Talles obj = new Talles();

                    obj.Id = Convert.ToInt32(datos.Lector["ID_Talle"]);
                    obj.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(obj);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Tipo_Productos> listaTipo_Productos()
        {
            List<Tipo_Productos> lista = new List<Tipo_Productos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT Id_Tipo, Nombre from Tipo_Producto");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Tipo_Productos obj = new Tipo_Productos();

                    obj.Id = Convert.ToInt32(datos.Lector["ID_Tipo"]);
                    obj.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(obj);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int Agregar(Productos pr)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO Productos (Codigo, IMG, Nombre, Id_Color, Id_Talle, Id_Marca, Id_Tipo, Cantidad, Precio, Estado) VALUES (@Codigo, @IMG,@Nombre, @Id_Color, @Id_Talle, @Id_Marca, @Id_Tipo, @Cantidad, @Precio, 0)");
                datos.SetearParametro("@Codigo", pr.Codigo);
                datos.SetearParametro("@IMG", pr.IMG);
                datos.SetearParametro("@Nombre", pr.Nombre);
                datos.SetearParametro("@Id_Color", pr.Colores.Id);
                datos.SetearParametro("@Id_Talle", pr.Talles.Id);
                datos.SetearParametro("@Id_Marca", pr.Marcas.Id);
                datos.SetearParametro("@Id_Tipo", pr.Tipo_Productos.Id);
                datos.SetearParametro("@Cantidad", pr.Cantidad);
                datos.SetearParametro("@Precio", pr.Precio);

                datos.EjecutarAccion();
                return 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int Modificar(Productos pr, Productos seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Productos SET Codigo=@NCODIGO, IMG=@NIMG, Nombre=@NNOMBRE, Id_Color=@NIDCOLOR, Id_Talle=@NIDTALLE, Id_Marca=@NIDMARCA, Id_Tipo=@NIDTIPO, Cantidad=@NCANTIDAD, Precio=@NPRECIO WHERE Codigo=@CODIGO AND Id_Color=@IDCOLOR AND Id_Marca=@IDMARCA AND Id_Talle=@IDTALLE  AND Id_Tipo=@IDTIPO");
                datos.SetearParametro("@NCODIGO", pr.Codigo);
                datos.SetearParametro("@NIMG", pr.IMG);
                datos.SetearParametro("@NNombre", pr.Nombre);
                datos.SetearParametro("@NIDCOLOR", pr.Colores.Id);
                datos.SetearParametro("@NIDTALLE", pr.Talles.Id);
                datos.SetearParametro("@NIDMARCA", pr.Marcas.Id);
                datos.SetearParametro("@NIDTIPO", pr.Tipo_Productos.Id);
                datos.SetearParametro("@NCANTIDAD", pr.Cantidad);
                datos.SetearParametro("@NPRECIO", pr.Precio);

                datos.SetearParametro("@CODIGO", seleccionado.Codigo);
                datos.SetearParametro("@IDCOLOR", seleccionado.Colores.Id);
                datos.SetearParametro("@IDMARCA", seleccionado.Marcas.Id);
                datos.SetearParametro("@IDTALLE", seleccionado.Talles.Id);
                datos.SetearParametro("@IDTIPO", seleccionado.Tipo_Productos.Id);

                datos.EjecutarAccion();
                return 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int BajaLogica(Productos seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Productos SET Estado=1 WHERE Codigo=@Codigo");
                datos.SetearParametro("@Codigo", seleccionado.Codigo);

                datos.EjecutarAccion();
                return 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}