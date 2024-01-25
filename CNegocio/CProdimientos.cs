using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDATOS;
using System.Data;

namespace CNegocio
{
   public class CProdimientos
    {
        CProcedimiento obj = new CProcedimiento();
         public DataTable CargarDatos(string tabla)
        {
            return obj.cargarDatos(tabla);
        }

        public string GenerarCodigo(string tabla)
        {
            return obj.GenerarCodigo(tabla);

        }
    }
}
