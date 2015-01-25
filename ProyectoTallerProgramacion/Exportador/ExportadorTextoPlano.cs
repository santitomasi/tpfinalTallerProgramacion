using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases.DTO;
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

        public override void Exportar(CorreoDTO pCorreo)
        {
            using (StreamWriter file = new StreamWriter("archivo.txt", true))
            {
                file.WriteLine(pCorreo.Texto);
            }
        }

    }
}
