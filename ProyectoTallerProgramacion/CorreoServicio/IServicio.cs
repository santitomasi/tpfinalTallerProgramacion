using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace CorreoServicio
{
    /// <summary>
    /// Clase abstracta que sirve para establecer lo minimo a implementar 
    /// por todos los algoritmos de Servicio de Correo.
    /// </summary>
    public interface IServicio
    {
        /// <summary>
        /// Metodo para obtener los correos de una cuenta en un Servicio.
        /// </summary>
        /// <param name="pCuenta">Cuenta de la cual se descargan los correos.</param>
        /// <returns>Se devuelve una lista de correos de la cuenta.</returns>
        IList<CorreoDTO> DescargarCorreos(CuentaDTO pCuenta);

        /// <summary>
        /// Metodo para enviar un correo.
        /// </summary>
        /// <param name="pCorreo">correo a ser enviado.</param>
        void EnviarCorreo(CorreoDTO pCorreo);
    }
}
