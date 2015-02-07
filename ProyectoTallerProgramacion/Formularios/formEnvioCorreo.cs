using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using Controladores;
using DataTransferObject;

namespace formPrincipal
{
    public partial class formEnvioCorreo : Form
    {
        private List<string> archivos = new List<string>();

        public formEnvioCorreo()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Metodo que se dispara al hacer click en el boton ENVIAR.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            CorreoDTO pCorreo = new CorreoDTO();
            pCorreo.Leido = 0;
            pCorreo.CuentaOrigen = Convert.ToString(listaCuentas.SelectedItem);
            pCorreo.CuentaDestino = textBox4.Text;
            pCorreo.Asunto = textBox2.Text;
            pCorreo.Fecha = DateTime.Today;
            pCorreo.Texto = textBox3.Text;
            pCorreo.TipoCorreo = "Enviado";
            pCorreo.Adjuntos = archivos;
            FachadaCorreo.Instancia.CrearCorreo(pCorreo);

            MessageBox.Show("Enviado con exito!");




            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("santiagotommasi92@gmail.com");
            correo.To.Add(textBox4.Text);
            correo.Subject = textBox2.Text;
            correo.Body = textBox3.Text;

            if (archivos != null)
            {
                foreach (string archivo in archivos)
                {
                    Attachment attach = new Attachment(@archivo);
                    correo.Attachments.Add(attach);
                }
                archivos.Clear();
            }

            
            SmtpClient cliente = new SmtpClient("smtp.gmail.com");
            cliente.EnableSsl = true;
            cliente.Port = 587;
            cliente.Credentials = new System.Net.NetworkCredential("santiagotommasi92@gmail.com", "password");
            
            //Aca tendriamos que poner un try-catch
            cliente.Send(correo);

            Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Seleccione Archivo";
            file.InitialDirectory = @"C:\";
            file.Filter = "All files(*.*)|*.*";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.ShowDialog();
            archivos.Add(file.FileName);
            label3.Text = file.SafeFileName;
        }

        /// <summary>
        /// Metodo para cargar la informacion de las cuentas.
        /// </summary>
        private void MostrarCuentas()
        {
            try
            {
                foreach (CuentaDTO aCuenta in FachadaABMCuenta.Instancia.ListarCuentas())
                {
                    listaCuentas.Items.Add(aCuenta.Nombre);
                }
            }
            catch
            {
                // VER QUE HACER ACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            }
            finally
            {
                // Coloca la opción de Seleccionar Cuenta
                listaCuentas.Items.Add("Seleccionar Cuenta");
                // marca como seleccionada a la opción Seleccionar Cuenta.
                listaCuentas.SelectedIndex = listaCuentas.Items.Count - 1;
            }


        }

        private void formEnvioCorreo_Load(object sender, EventArgs e)
        {
            MostrarCuentas();
        }

        private void listaCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
