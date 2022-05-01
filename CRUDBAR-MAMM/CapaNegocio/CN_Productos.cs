
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using System;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable LeerProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsProd(string nomprod, string desc, string precio, string cantidad, string estado)
        {
            objetoCD.Insertar(nomprod, desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad),Convert.ToInt32(estado));
        }
        public void ActProd(string nomprod, string desc, string precio, string cantidad, string estado, string idprod)
        {
            objetoCD.Actualizar(nomprod, desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad), Convert.ToInt32(estado), Convert.ToInt32(idprod));
        }
        public void EliProd(string idproducto)
        {
            objetoCD.Borrar(Convert.ToInt32(idproducto));
        }
    }
}
