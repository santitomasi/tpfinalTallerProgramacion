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

namespace formPrincipal
{
    public partial class formEnvioCorreo : Form
    {
        public formEnvioCorreo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("santiagotommasi92@gmail.com");
            correo.To.Add(textBox1.Text);
            correo.Subject = textBox2.Text;
            correo.Body = textBox3.Text;

            SmtpClient cliente = new SmtpClient("smtp.gmail.com");
            cliente.Port = 587;
            cliente.Credentials = new System.Net.NetworkCredential("santiagotommasi92@gmail.com", "password");
            cliente.EnableSsl = true;
            cliente.Send(correo);
            Close();
            MessageBox.Show("Enviado con exito!");
        }

    }
}
