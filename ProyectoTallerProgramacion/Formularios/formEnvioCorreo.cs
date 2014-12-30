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
        private List<string> archivos = new List<string>();

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
            MessageBox.Show("Enviado con exito!");
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

    }
}
