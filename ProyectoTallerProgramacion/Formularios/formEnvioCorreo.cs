using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        /// Metodo que se dispara al hacer click en el boton ENVIAR para enviar un correo.
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

            try
            {
                //Guardamos el correo en la base de datos.
                FachadaCorreo.Instancia.CrearCorreo(pCorreo);
            }
            catch //CONSIDERAR LA EXCEPCION DE PERSISTENCIA.
            {}

            try
            {
                //Enviamos el correo.
                FachadaCorreo.Instancia.EnviarCorreo(pCorreo);
            }
            catch  //CONSIDERAR LA EXCEPCION DE PERSISTENCIA.
            {}
            
            MessageBox.Show("Enviado con exito!");
        }

        /// <summary>
        /// Metodo que se dispara al hacer click en el boton Agregar Archivo Adjunto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Metodo que se dispara cuando carga el formulario para mostrar las cuentas en el 
        /// menú desplegable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formEnvioCorreo_Load(object sender, EventArgs e)
        {
            MostrarCuentas();
        }
    }
}
