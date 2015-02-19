using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using System.Net.Mail;
using OpenPop.Pop3;

namespace CorreoServicio
{
    /// <summary>
    /// Clase utilizada para relacionar el programa con el servicio de correo correspondiente a Yahoo.
    /// </summary>
    public class Yahoo : ServicioCorreo
    {
        /// <summary>
        /// Constructor de la clase. Llama al constructor de la superclase pasandole como parametro
        /// el nombre del Servicio de Correo.
        /// </summary>
        public Yahoo() : base("Yahoo") {}

        /// <summary>
        /// Metodo utilizado para enviar un correo.
        /// </summary>
        /// <param name="pCorreo">Correo a ser enviado.</param>
        /// <param name="pCuenta">Cuenta con la que se envia el correo</param>
        public override void EnviarCorreo(CorreoDTO pCorreo, CuentaDTO pCuenta)
        {
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress(pCuenta.Direccion);
            correo.To.Add(pCorreo.CuentaDestino);
            correo.Subject = pCorreo.Asunto;
            correo.Body = pCorreo.Texto;
            if (pCorreo.Adjuntos != null) 
            {
                foreach (string archivo in pCorreo.Adjuntos)
                {
                    Attachment attach = new Attachment(@archivo);
                    correo.Attachments.Add(attach);
                }
            }
            SmtpClient cliente = new SmtpClient("smtp.mail.yahoo.com");
            cliente.EnableSsl = true;
            cliente.Port = 587; // o 465
            cliente.Credentials = new System.Net.NetworkCredential(pCuenta.Direccion, pCuenta.Contraseña);

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
            Pop3Client pop = new Pop3Client();
            pop.Connect("pop.mail.yahoo.com", 995, true);
            pop.Authenticate(pCuenta.Direccion, pCuenta.Contraseña);  // ver si usamos esto o los tributos iDireccion e iContraseña (hay que cargarlos desde la fachada)
            int cantidadMensajes = pop.GetMessageCount();
            List<CorreoDTO> mCorreos = new List<CorreoDTO>();
            OpenPop.Mime.Message mensaje;

            for (int i = cantidadMensajes; i > 0; i--)
            {
                mensaje = pop.GetMessage(i);


                
                // obtengo el texto del cuerpo del correo.
                string cuerpo = "";
                OpenPop.Mime.MessagePart texto = mensaje.FindFirstPlainTextVersion();
                if (texto != null)
                {
                    // We found some plaintext!
                    cuerpo = texto.GetBodyAsText();
                }
                else
                {
                    // Might include a part holding html instead
                    OpenPop.Mime.MessagePart html = mensaje.FindFirstHtmlVersion();
                    if (html != null)
                    {
                        // We found some html!
                        cuerpo = html.GetBodyAsText();
                    }
                }

                string pTipoCorreo;
                // Determina si el correo es enviado o recibido comparando la direccion de la cuenta con la direccion
                // que aparece como direccion remitente.
                if (mensaje.Headers.From.Address == pCuenta.Direccion)
                {
                    pTipoCorreo = "Enviado";
                }
                else
                {
                    pTipoCorreo = "Recibido";
                }

                // Armar el string de cuenta destino con las cuentas destinatarias.
                string pDestino = "";
                foreach (OpenPop.Mime.Header.RfcMailAddress mailAdres in mensaje.Headers.To)
                {
                        pDestino = pDestino + mailAdres.Address + "; ";
                }

                mCorreos.Add(new CorreoDTO()
                {
                    Fecha = mensaje.Headers.DateSent,
                    TipoCorreo = pTipoCorreo,
                    Texto = cuerpo,
                    CuentaOrigen = mensaje.Headers.From.Address,
                    CuentaDestino = pDestino,
                    Asunto = mensaje.Headers.Subject,
                    Leido = false,        
                    ServicioId = mensaje.Headers.MessageId
       
                });
            }

            return mCorreos;

        }
  


    }
}
