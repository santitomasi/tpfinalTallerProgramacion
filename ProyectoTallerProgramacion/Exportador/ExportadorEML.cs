using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using System.Net.Mail;

namespace Exportador
{
    /// <summary>
    /// Clase utilizada para exportar un correo al sistema de archivos en formato EML.
    /// </summary>
    public class ExportadorEML : Exportador
    {
        
        /// <summary>
        /// Constructor de la clase. Llama al constructor de la superclase pasandole como parametro
        /// el nombre del metodo de exportacion.
        /// </summary>
        public ExportadorEML() : base("EML") {}

        /// <summary>
        /// Metodo para exportar un correo al Sistema de Archivos.
        /// </summary>
        /// <param name="pCorreo">correo a ser exportado.</param>
        /// <param name="pRuta">ruta donde se ubicará el correo exportado.</param>
        public override void Exportar(CorreoDTO pCorreo, string pRuta)
        {
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress(pCorreo.CuentaOrigen);
            correo.To.Add(pCorreo.CuentaDestino);
            correo.Subject = pCorreo.Asunto;
            correo.Body = pCorreo.Texto;

            SmtpClient client = new SmtpClient("mysmtphost");
            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            client.PickupDirectoryLocation = pRuta;
            client.Send(correo);
        }
    }
}
