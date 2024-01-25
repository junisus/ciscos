using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace SisCoS
{
    public class Validaciones
    {
        public static void SoloNumeros(KeyPressEventArgs pE)
        {
            if (!(char.IsNumber(pE.KeyChar)) && (pE.KeyChar != (char)Keys.Back) && (pE.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten Números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pE.Handled = true;
            }
           
            else
            {
                pE.Handled = false;
            }

        }

        public static void SoloLetras(KeyPressEventArgs pE)
        {
            if (!(char.IsLetter(pE.KeyChar)) && (pE.KeyChar != (char)Keys.Back) && (pE.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pE.Handled = true;
            }
            
            
            else
            {
                pE.Handled = false;
            }

        }
    }
}
