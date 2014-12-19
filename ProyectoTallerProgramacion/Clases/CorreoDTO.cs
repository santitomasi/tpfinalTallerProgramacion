using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.DTO
{
    /// <summary>
    /// Clase utilizada para representar un correo electronico.
    /// </summary>
    public class CorreoDTO
    {
        /// <summary>
        /// Atributo ID.
        /// </summary>
        private int iId;

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
        private string iOrigen;      // <----- en vez de STRING es CUENTACORREO

        /// <summary>
        /// Atributo destino.
        /// </summary>
        private string iDestino;      // <----- en vez de STRING es CUENTACORREO

        /// <summary>
        /// Constructor de una instancia de la clase Correo .
        /// </summary>
        public CorreoDTO() {}

        /// <summary>
        /// Propiedad de lectura y escritura del ID.
        /// </summary>
        public int Id
        {
            get { return this.iId; }
            set { this.iId = value; }
        }
        
        /// <summary>
        /// Propiedad de lectura y escritura de la Fecha.
        /// </summary>
        public DateTime Fecha
        {
            get { return this.iFecha; }
            set { this.iFecha = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la Hora.
        /// </summary>
        public DateTime Hora
        {
            get { return this.iHora; }
            set { this.iHora = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Texto.
        /// </summary>
        public string Texto
        {
            get { return this.iTexto; }
            set { this.iTexto = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Origen.
        /// </summary>
        public string Origen
        {
            get { return this.iOrigen; }
            set { this.iOrigen = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Destino.
        /// </summary>
        public string Destino
        {
            get { return this.iDestino; }
            set { this.iOrigen = value; }
        }
    }
}
