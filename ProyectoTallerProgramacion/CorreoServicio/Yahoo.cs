using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using System.Net.Mail;

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
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress(pCorreo.CuentaOrigen);  // <--- ¿¿¿Cuenta origen???
            correo.To.Add(pCorreo.CuentaDestino);
            correo.Subject = pCorreo.Asunto;
            correo.Body = pCorreo.Texto;
            /*
            if (pCorreo.Adjuntos != null) 
            {
                foreach (string archivo in pCorreo.Adjuntos)
                {
                    Attachment attach = new Attachment(@archivo);
                    correo.Attachments.Add(attach);
                }
            }
            */
            SmtpClient cliente = new SmtpClient("smtp.mail.yahoo.com");
            cliente.EnableSsl = true;
            cliente.Port = 587;
            cliente.Credentials = new System.Net.NetworkCredential(pCorreo.CuentaOrigen, "contraseña");

            //Aca tendriamos que poner un try-catch
            cliente.Send(correo);
        }

        /// <summary>
        /// Metodo que descarga los correos del Servicio de correo que pertenecen a la cuenta <paramref name="pCuenta"/>.
        /// </summary>
        /// <param name="pCuenta">Cuenta de la cual se descargan los correos.</param>
        /// <returns>Retorna una lista de correos.</returns>
        public override IList<CorreoDTO> DescargarCorreos(CuentaDTO pCuenta)
        {
            //metodo a implementar
            return new List<CorreoDTO>();
        }
  


    }
}
