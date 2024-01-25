using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SisCoS
{
    public class CProdimientoN

    {
        CProcedimientos obj = new CProcedimientos();
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
