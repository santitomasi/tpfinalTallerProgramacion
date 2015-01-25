using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases.DTO;

namespace Exportador
{
    /// <summary>
    /// Clase abstracta que sirve para establecer lo minimo a implementar 
    /// por todos los algoritmos de exportacion.
    /// </summary>
    public interface IExportador
    {
        /// <summary>
        /// Metodo utilizar para exportar un correo al sistema de archivos.
        /// </summary>
        /// <param name="pCorreo"></param>
        void Exportar(CorreoDTO pCorreo);
    }
}
