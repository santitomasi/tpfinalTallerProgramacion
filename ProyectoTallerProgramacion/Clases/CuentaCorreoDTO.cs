using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.DTO
{
    /// <summary>
    /// Clase utilizada para representar una cuenta de correo.
    /// </summary>
    public class CuentaCorreoDTO
    {
        /// <summary>
        /// Atributo nombre.
        /// </summary>
        private string iNombre;

        /// <summary>
        /// Atributo direccion.
        /// </summary>
        private string iDireccion;

        /// <summary>
        /// Atributo contraseña.
        /// </summary>
        private string iContraseña;     // <-------------- ¿va?

        /// <summary>
        /// Constructor de la clase CuentaCorreo.
        /// </summary>
        /// <param name="pNombre">string que representa el nombre de la cuenta de correo.</param>
        /// <param name="pDireccion">string que representa la direccion de la cuenta de correo.</param>
        /// <param name="pContraseña">string que representa la contraseña de la cuenta de correo.</param>
        public CuentaCorreoDTO(string pNombre, string pDireccion, string pContraseña)
        {
            this.iNombre = pNombre;
            this.iDireccion = pDireccion;
            this.iContraseña = pContraseña;
        }
    }
}
