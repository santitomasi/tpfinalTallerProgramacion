using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace CorreoServicio
{
    /// <summary>
    /// Clase abstracta que sirve de base para los distintos servicios de correo que se deseen implementar.
    /// </summary>
    public abstract class ServicioCorreo : IServicioCorreo
    {
        /// <summary>
        /// Atributo Nombre del servicio que se construye.
        /// </summary>
        private string iNombre;

        /// <summary>
        /// Atributo Direccion.
        /// </summary>
        private string iDireccion;

        /// <summary>
        /// Atributo Contraseña.
        /// </summary>
        private string iContraseña;

        /// <summary>
        /// Constructor de la clase Servicio tomando como parametro el nombre
        /// del Servicio de correo que se instancia.
        /// </summary>
        /// <param name="pNombre"></param>
        public ServicioCorreo(string pNombre)
        {
            this.iNombre = pNombre;
            this.iContraseña = "";
            this.iDireccion = "";
        }

        /// <summary>
        /// Propiedad de solo lectura que devuelve el atributo nombre de la instancia.
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
        }

        /// <summary>
        /// Propiedad de lectura escritura de la direccion.
        /// </summary>
        public string Direccion
        {
            get { return this.iDireccion; }
            set { this.iDireccion = value; }
        }

        /// <summary>
        /// Propiedad de lectura escritura de la contraseña.
        /// </summary>
        public string Contraseña
        {
            get { return this.iContraseña; }
            set { this.iContraseña = value; }
        }

        /// <summary>
        /// Metodo abstracto que descarga los correos de un Servicio de correo referentes a una cuenta.
        /// </summary>
        /// <param name="pCuenta">Cuenta de la cual se descargan los correos.</param>
        /// <returns>Retorna una lista de correos.</returns>
        public abstract IList<CorreoDTO> DescargarCorreos(CuentaDTO pCuenta);

        /// <summary>
        /// Metodo abstracto para enviar un correo desde un Servicio de correo.
        /// </summary>
        /// <param name="pCorreo">correo a ser enviado.</param>
        public abstract void EnviarCorreo(CorreoDTO pCorreo);
    }
}
