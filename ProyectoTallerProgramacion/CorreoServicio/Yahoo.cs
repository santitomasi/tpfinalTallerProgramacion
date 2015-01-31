using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace CorreoServicio
{
    /// <summary>
    /// Clase utilizada para relacionar el programa con el servicio de correo correspondiente a Yahoo.
    /// </summary>
    public class Yahoo : Servicio
    {
        /// <summary>
        /// Constructor de la clase. Llama al constructor de la superclase pasandole como parametro
        /// el nombre del Servicio de Correo.
        /// </summary>
        public Yahoo() : base("Yahoo") {}

        /// <summary>
        /// Metodo utilizado para descargar correos de internet.
        /// </summary>
        /// <returns>Se devuelve un lista de correos.</returns>
        //public override IList<CorreoDTO> DescargarCorreos(CuentaDTO pCuenta) { }

        /// <summary>
        /// Metodo utilizado para enviar un correo.
        /// </summary>
        /// <param name="pCorreo">Correo a ser enviado.</param>
        public override void EnviarCorreo(CorreoDTO pCorreo)
        {

        }
    }
}
