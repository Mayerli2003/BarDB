using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion= new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla= new DataTable();
        SqlCommand comando = new SqlCommand();
        
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "LeerProductos";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar (string nombre, string desc, double precio, int cantidad, int estado)
        {
            //Procedimiento para insertar datos
            comando.Connection= conexion.AbrirConexion();
            comando.CommandText= "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Actualizar(string nombre, string desc, double precio, int cantidad, int estado,int idproducto)
        {
            //Procedimiento para actualozar datos 
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@idproducto", idproducto);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Borrar(int idproducto)
        {
            //Procedimiento para eliminar
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText= "EliminarProductos";
            comando.CommandType= CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idprod", idproducto);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
