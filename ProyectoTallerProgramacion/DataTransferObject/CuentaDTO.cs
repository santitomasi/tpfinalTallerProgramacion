using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    /// <summary>
    /// Clase utilizada para representar una cuenta de correo.
    /// </summary>
    public class CuentaDTO
    {
        /// <summary>
        /// Atributo ID.
        /// </summary>
        private int iId;

        /// <summary>
        /// Atributo nombre.
        /// </summary>
        private string iNombre;

        /// <summary>
        /// Atributo usuario.
        /// </summary>
        private string iUsuario;

        /// <summary>
        /// Atributo contraseña.
        /// </summary>
        private string iContraseña;  

        /// <summary>
        /// Constructor de una instancia de la clase CuentaCorreo .
        /// </summary>
        public CuentaDTO() {}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            return "falta desarrollar el metodo";
        }
        
        
        /// <summary>
        /// Propiedad de lectura y escritura del ID.
        /// </summary>
        public int Id
        {
            get { return this.iId; }
            set { this.iId = value; }
        }

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
        public string Usuario
        {
            get { return this.iUsuario; }
            set { this.iUsuario = value; }
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
