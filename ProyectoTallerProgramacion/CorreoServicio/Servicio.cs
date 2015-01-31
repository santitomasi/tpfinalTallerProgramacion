using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace CorreoServicio
{
    /// <summary>
    /// Clase abstracta que sirve de base para los distintos exportadores que se deseen implementar.
    /// </summary>
    public abstract class Servicio : IServicio
    {
        /// <summary>
        /// Atributo Nombre del servicio que se construye.
        /// </summary>
        private string iNombre;

        /// <summary>
        /// Constructor de la clase Servicio tomando como parametro el nombre
        /// del Servicio de correo que se instancia.
        /// </summary>
        /// <param name="pNombre"></param>
        public Servicio(string pNombre)
        {
            this.iNombre = pNombre;
        }

        /// <summary>
        /// Propiedad de solo lectura que devuelve el atributo nombre de la instancia.
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
        }

        /// <summary>
        /// Metodo abstracto que descarga los correos de un Servicio de correo refrentes a una cuenta.
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
