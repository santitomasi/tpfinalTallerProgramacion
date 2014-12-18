using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    /// <summary>
    /// Clase utilizada para representar un correo electronico.
    /// </summary>
    public class Correo
    {
        /// <summary>
        /// Atributo fecha.
        /// </summary>
        private DateTime iFecha;

        /// <summary>
        /// Atributo hora.
        /// </summary>
        private DateTime iHora;

        /// <summary>
        /// Atributo texto.
        /// </summary>
        private string iTexto;

        /// <summary>
        /// Atributo origen.
        /// </summary>
        private CuentaCorreo iOrigen;

        /// <summary>
        /// Atributo destino.
        /// </summary>
        private CuentaCorreo iDestino;

        /// <summary>
        /// Constructor de la clase Correo.
        /// </summary>
        /// <param name="pTexto">string que representa el mensaje del correo.</param>
        /// <param name="pOrigen">Cuenta de correo que representa quien envia el correo.</param>
        /// <param name="pDestino">Cuenta de correo que representa quien recibe el correo.</param>
        public Correo (string pTexto, CuentaCorreo pOrigen, CuentaCorreo pDestino)
        {
            this.iFecha = DateTime.Today;
            this.iHora = DateTime.UtcNow;    // <----------- nose si esto será la hora
            this.iTexto = pTexto;
            this.iOrigen = pOrigen;
            this.iDestino = pDestino;
        }
    }
}
