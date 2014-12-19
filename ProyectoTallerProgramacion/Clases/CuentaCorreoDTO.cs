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
        /// Constructor de una instancia de la clase CuentaCorreo .
        /// </summary>
        public CuentaCorreoDTO() {}

        /// <summary>
        /// Propiedad de lectura y escritura del Nombre.
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }
        
        /// <summary>
        /// Propiedad de lectura y escritura de la Direccion.
        /// </summary>
        public string Direccion
        {
            get { return this.iDireccion; }
            set { this.iDireccion = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la Contraseña.
        /// </summary>
        public string Contraseña
        {
            get { return this.iContraseña; }
            set { this.iContraseña = value; }
        }
    }
}
