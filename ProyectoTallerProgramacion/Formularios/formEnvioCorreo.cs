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
        private CorreoDTO iCorreo;

        /// <summary>
        /// Constructor de una instancia del form de envio de correos .
        /// </summary>
        public formEnvioCorreo() 
        {           
            InitializeComponent();
            iCorreo = null;
        }

        /// <summary>
        /// Constructor de una instancia del form de envio de correos .
        /// </summary>
        public formEnvioCorreo(CorreoDTO pCorreo)
        {
            iCorreo = pCorreo;
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
            pCorreo.CuentaDestino = correo_Destino.Text;
            pCorreo.Asunto = correo_Asunto.Text;
            pCorreo.Fecha = DateTime.Today;
            pCorreo.Texto = correo_Texto.Text;
            pCorreo.TipoCorreo = "Enviado";
            pCorreo.Adjuntos = archivos;

            try
            {
                //Enviamos el correo.
                FachadaCorreo.Instancia.EnviarCorreo(pCorreo);

                //Guardamos el correo en la base de datos.

                // Actualiza el valor del campo CuentaOrigen. Se pasa con el nombre de la cuenta pero se debe guardar con la direccion.
                //REVISAR ESTOOOOO ^
                pCorreo.CuentaOrigen = FachadaABMCuenta.Instancia.ObtenerCuenta(pCorreo.CuentaOrigen).Direccion;
                //Setea el valor del campo servicioid
                pCorreo.ServicioId = "Correo enviado por el Cliente de Correo";
                FachadaCorreo.Instancia.CrearCorreo(pCorreo);
            }
            catch (Exception exception) //CONSIDERAR  EXCEPCIONes DE PERSISTENCIA y de envio.
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.InnerException.Message);
            }
            
            MessageBox.Show("Enviado con exito!");

            this.Close();
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
            if (iCorreo != null)
            {
                correo_Destino.Text = iCorreo.CuentaDestino;
                correo_Asunto.Text = iCorreo.Asunto;
                correo_Texto.Text = iCorreo.Texto;
                // Recorre la lista para encontrar el elemento que debe dejar seleccionado
                for (int i = 0; i < listaCuentas.Items.Count; i++)
                {
                    if (FachadaABMCuenta.Instancia.ObtenerCuenta(Convert.ToString(listaCuentas.Items[i])).Direccion == iCorreo.CuentaOrigen)
                    {
                        listaCuentas.SelectedIndex = i;
                        break;
                    }
                }
            }
            
        }
    }
}
