using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace Exportador
{
    /// <summary>
    /// Clase utilizada para exportar un correo al sistema de archivos en formato EML.
    /// </summary>
    public class ExportadorEML : Exportador
    {
        
        /// <summary>
        /// Constructor de la clase. Llama al constructor de la superclase pasandole como parametro
        /// el nombre del metodo de exportacion.
        /// </summary>
        public ExportadorEML() : base("EML") 
        {
        }

        public override void Exportar(CorreoDTO pCorreo, string pRuta)
        { 
        }

    }
}
