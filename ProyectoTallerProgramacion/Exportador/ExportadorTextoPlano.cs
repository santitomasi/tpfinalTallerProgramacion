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
        public ExportadorTextoPlano() : base("Texto Plano") { }

        /// <summary>
        /// Metodo para exportar un correo al sistema de archivos.
        /// </summary>
        /// <param name="pCorreo">correo a ser exportado.</param>
        /// <param name="pRuta">ruta en donde se exportará el correo.</param>
        public override void Exportar(CorreoDTO pCorreo,string pRuta)
        {
            //Formamos un array de string para luego escribir en el archivo.
            string[] lines = {pCorreo.CuentaOrigen, pCorreo.CuentaDestino, Convert.ToString(pCorreo.Fecha), 
                              pCorreo.Asunto, pCorreo.Texto};
            //Creamos y escribimos el archivo en la ruta especificada por el usuario.
            System.IO.File.WriteAllLines(pRuta + "\\Correo" + pCorreo.Asunto +".txt", lines);
        }

    }
}
