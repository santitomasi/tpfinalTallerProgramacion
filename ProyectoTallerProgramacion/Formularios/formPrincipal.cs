using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Clases;
using Clases.DTO;
using Clases.Controladores;
using OpenPop.Pop3; 

namespace formPrincipal
{
    public partial class formPrincipal : Form
    {
        private static List<OpenPop.Mime.Message> mensajes;

        public formPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new formEnvioCorreo();
            frm.Show();
        }

        /// <summary>
        /// Método que se dispara al hacer click sobre un correo  de la lista de correos Enviados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Método que se dispara al hacer click sobre un correo  de la lista de correos Recibidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int indexSelected = listaRecibidos.Rows[e.RowIndex].Index;
            int indexSelected = e.RowIndex;

            //textBox1.Text = mensajes[indexSelected].Headers.ContentDescription;
            //textBox1.Text = listaRecibidos.Rows[indexSelected].Cell
        } 

        private void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            
            Pop3Client pop = new Pop3Client();
            pop.Connect("pop.gmail.com", 995, true);
            pop.Authenticate("santiagotommasi92", "password");
            int cantidadMensajes = pop.GetMessageCount();
            mensajes = new List<OpenPop.Mime.Message>(cantidadMensajes);

            for (int i = cantidadMensajes; i > 0; i--)       //nose si son necesarios dos ciclos!!!
            {
                mensajes.Add(pop.GetMessage(i));
                progressBar1.PerformStep();                
            }

            foreach (OpenPop.Mime.Message mensaje in mensajes)     //nose si son necesarios dos ciclos!!!
            {
                string[] row = { mensaje.Headers.Subject, Convert.ToString(mensaje.Headers.From),
                                 mensaje.Headers.Date};
                listaRecibidos.Rows.Add(row);
            }

            progressBar1.Visible = false;
        }
         
        private void agregarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaCuentas.Visible = false;
            tabControl1.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CuentaDTO cuenta = new CuentaDTO();
            cuenta.Direccion = textBox2.Text;
            cuenta.Contraseña = textBox3.Text;
            cuenta.Nombre = textBox4.Text;
            FachadaABMCuenta.Instancia.CrearCuenta(cuenta);

            listaCuentas.Visible = true;
            tabControl1.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listaCuentas.Visible = true;
            tabControl1.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }


        private void progressBar_VisibleChanged(object sender, EventArgs e)
        {
            Pop3Client pop = new Pop3Client();
            pop.Connect("pop.gmail.com", 995, true);
            pop.Authenticate("estebanschab", "password");
            int cantidadMensajes = pop.GetMessageCount();
            mensajes = new List<OpenPop.Mime.Message>(cantidadMensajes);
         
            progressBar1.Minimum = 1;
            progressBar1.Maximum = cantidadMensajes;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodo para cargar la informacion de las cuentas.
        /// </summary>
        private void MostrarCuentas()
        {
            foreach (CuentaDTO aCuenta in FachadaABMCuenta.Instancia.ListarCuentas())
            {
                string[] row = { aCuenta.Nombre};
                listaCuentas2.Rows.Add(row);
            }
            string[] row2 = { "Todas las cuentas" };
            listaCuentas2.Rows.Add(row2);
        }

        /// <summary>
        /// Metodo para cargar la informacion de los correos.
        /// </summary>
        private void MostrarCorreos()
        {
            //Borra las filas de los DataGridView antes de cargar los correos.
            listaEnviados.Rows.Clear();
            listaRecibidos.Rows.Clear();
            foreach (CorreoDTO aCorreo in FachadaCorreo.Instancia.ListarCorreos())
            {
                if (aCorreo.TipoCorreo == "Enviado")
                {
                    object[] row = { aCorreo.Asunto, aCorreo.CuentaDestino , Convert.ToString(aCorreo.Fecha) };
                    listaEnviados.Rows.Add(row);
                }
                else
                {
                    object[] row = { aCorreo.Asunto, aCorreo.CuentaOrigen, Convert.ToString(aCorreo.Fecha) };
                    listaRecibidos.Rows.Add(row);
                }
                
            }
        }

        /// <summary>
        /// Metodo para cargar la informacion de los correos de la cuenta <paramref name="pCuenta"/>.
        /// </summary>
        private void MostrarCorreos(string pCuenta)
        {
            //Borra las filas de los DataGridView antes de cargar los correos.
            listaEnviados.Rows.Clear();
            listaRecibidos.Rows.Clear();
            foreach (CorreoDTO aCorreo in FachadaCorreo.Instancia.ListarCorreos(pCuenta))
            {
                if (aCorreo.TipoCorreo == "Enviado")
                {
                    object[] row = { aCorreo.Asunto, aCorreo.CuentaDestino, Convert.ToString(aCorreo.Fecha) };
                    listaEnviados.Rows.Add(row);
                    int posicion = listaEnviados.Rows.Count - 2;
                    if (aCorreo.Leido != 0)
                    {
                        //listaEnviados.Rows[posicion].DefaultCellStyle.Font = new Font(listaEnviados.DefaultCellStyle.Font, FontStyle.Bold);
                        listaEnviados.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
                       // listaEnviados.Rows[posicion].Cells[1].Style
                    }
                }
                else
                {
                    object[] row = { aCorreo.Asunto, aCorreo.CuentaOrigen, Convert.ToString(aCorreo.Fecha) };
                    listaRecibidos.Rows.Add(row);
                    if (aCorreo.Leido != 0)
                    {
                        int posicion = listaRecibidos.Rows.Count - 2;
                        //listaEnviados.Rows[posicion].DefaultCellStyle.Font = new Font(listaEnviados.DefaultCellStyle.Font, FontStyle.Bold);
                        
                        //listaRecibidos.Rows[posicion].Cells[0].Style.Font = new Font(listaEnviados.DefaultCellStyle.Font, FontStyle.Bold); //DefaultCellStyle.BackColor = Color.Gray;
                    }
                }
            }
        }

        private void formPrincipal_Load(object sender, EventArgs e)
        {
            MostrarCuentas();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Método para mostrar los correos de una cuenta. 
        /// Se dispara al hacer doble click sobre la fila de una cuenta.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e"></param>
        private void listaCuentas2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 row = listaCuentas2.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            //CuentaDTO cuenta = new CuentaDTO();
            //cuenta.Nombre = Convert.ToString(listaCuentas2.Rows[row].Cells[0].Value);
            //libro.Id = Convert.ToInt32(listaLibros.Rows[row].Cells[0].Value);
            //libro.Titulo = Convert.ToString(listaLibros.Rows[row].Cells[1].Value);
            //libro.Autor = Convert.ToString(listaLibros.Rows[row].Cells[2].Value);
            //libro.Isbn = Convert.ToString(listaLibros.Rows[row].Cells[3].Value);
           // Form form = new formLibro(libro);
            //form.Show();
            //Close();
            //MessageBox.Show(Convert.ToString(listaCuentas2.Rows[row].Cells[0].Value));
            string cuentaSeleccionada = Convert.ToString(listaCuentas2.Rows[row].Cells[0].Value);
            if (cuentaSeleccionada.CompareTo("Todas las cuentas") != 0) // si la cuenta seleccionada es distinta de "Todas las cuentas"
            {
                MostrarCorreos(cuentaSeleccionada);
            }
            else
            {
                MostrarCorreos();
            }
            
        }

    }
}
