using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using System.IO;

namespace Exportador
{
    /// <summary>
    /// Clase utilizada para exportar un correo al sistema de archivos en Texto Plano.
    /// </summary>
    public class ExportadorTextoPlano : Exportador
    {

        /// <summary>
        /// Constructor de la clase. Llama al constructor de la superclase pasandole como parametro
        /// el nombre del metodo de exportacion.
        /// </summary>
        public ExportadorTextoPlano() : base("Texto Plano") 
        {
        }

        public override void Exportar(CorreoDTO pCorreo,string pRuta)
        {
            string[] lines = {pCorreo.CuentaOrigen, pCorreo.CuentaDestino, Convert.ToString(pCorreo.Fecha), 
                              pCorreo.Asunto, pCorreo.Texto};
            System.IO.File.WriteAllLines(pRuta + "\\Correo" + pCorreo.Id +".txt", lines);
        }

    }
}
