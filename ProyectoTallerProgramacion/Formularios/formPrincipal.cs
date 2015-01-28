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
using DataTransferObject;
using OpenPop.Pop3;
using Controladores;


namespace formPrincipal
{
    public partial class formPrincipal : Form
    {
        private static List<OpenPop.Mime.Message> mensajes;

        public formPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new formEnvioCorreo();
            frm.Show();
        }

        /// <summary>
        /// Método que se dispara al hacer click sobre un correo de la lista de correos Enviados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = e.RowIndex;

            // Falta marcar el correo como leido en la base y en la lista!!

            textBox1.Text = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["texto"].Value);
        }

        /// <summary>
        /// Método que se dispara al hacer click sobre un correo de la lista de correos Recibidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = e.RowIndex;
            // Falta marcar el correo como leido en la base y en la lista!!
            textBox1.Text = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["textoR"].Value);
        } 

        private void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            
            Pop3Client pop = new Pop3Client();
            pop.Connect("pop.gmail.com", 995, true);
            pop.Authenticate("santiagotommasi92", "marlou1006");
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
            pop.Authenticate("santiagotommasi92", "marlou1006");
            int cantidadMensajes = pop.GetMessageCount();
            mensajes = new List<OpenPop.Mime.Message>(cantidadMensajes);
         
            progressBar1.Minimum = 1;
            progressBar1.Maximum = cantidadMensajes;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
        }

        /// <summary>
        /// Metodo para cargar la informacion de las cuentas.
        /// </summary>
        private void MostrarCuentas()
        {
            foreach (CuentaDTO aCuenta in FachadaABMCuenta.Instancia.ListarCuentas())
            {
                listaCuentas.Items.Add(aCuenta.Nombre);
            }
            listaCuentas.Items.Add("Todas las cuentas");
            
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
                object[] row = { aCorreo.Id, aCorreo.TipoCorreo, aCorreo.Asunto, aCorreo.CuentaOrigen, aCorreo.CuentaDestino, Convert.ToString(aCorreo.Fecha), aCorreo.Texto, aCorreo.Leido };
                if (aCorreo.TipoCorreo == "Enviado")
                {                    
                    listaEnviados.Rows.Add(row);
                    if (aCorreo.Leido != 0)
                    {
                        int posicion = listaEnviados.Rows.Count - 2;
                        listaEnviados.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
                    }
                }
                else
                {
                    listaRecibidos.Rows.Add(row);
                    if (aCorreo.Leido != 0)
                    {
                        int posicion = listaRecibidos.Rows.Count - 2;
                        listaRecibidos.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
                    }
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
                object[] row = { aCorreo.Id, aCorreo.TipoCorreo, aCorreo.Asunto, aCorreo.CuentaOrigen, aCorreo.CuentaDestino, Convert.ToString(aCorreo.Fecha), aCorreo.Texto, aCorreo.Leido };
                if (aCorreo.TipoCorreo == "Enviado")
                {
                    listaEnviados.Rows.Add(row);                
                    if (aCorreo.Leido != 0)
                    {
                        int posicion = listaEnviados.Rows.Count - 2;
                        //listaEnviados.Rows[posicion].DefaultCellStyle.Font = new Font(listaEnviados.DefaultCellStyle.Font, FontStyle.Bold);
                        listaEnviados.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
                       // listaEnviados.Rows[posicion].Cells[1].Style
                    }
                }
                else
                {
                    listaRecibidos.Rows.Add(row);
                    if (aCorreo.Leido != 0)
                    {
                        int posicion = listaRecibidos.Rows.Count - 2;
                        listaRecibidos.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
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

        /// <summary>
        /// Método para mostrar los correos de una cuenta. 
        /// Se dispara al elegir una cuenta en el combobox.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 row = listaCuentas.SelectedIndex;
            string cuentaSeleccionada = Convert.ToString(listaCuentas.Items[row]);
            if (cuentaSeleccionada.CompareTo("Todas las cuentas") != 0) // si la cuenta seleccionada es distinta de "Todas las cuentas"
            {
                MostrarCorreos(cuentaSeleccionada);
            }
            else
            {
                MostrarCorreos();
                //ESTAS LINEAS SON PARA PROBAR USAR EL MISMO DATAGRIDVIEW PARA ENVIADOS Y RECIBIDOS
                // LISTAENVIADOS Y LISTARECIBIDOS AHORA TIENEN TODAS LAS COLUMNAS DE LOS
                // ATRIBUTOS DE CORREO, SOLO QUE TIENEN VISIVILIDAD EN FALSE LAS COLUMNAS QUE NO SE VEN
                // SI USAMOS UNA MISMA LISTA PARA LOS DOS, CUANDO QUERES VER LOS ENVIADOS HABILITAS EL PARA
                // CUANDO QUERES VER EL RECIBIDO HABILITAS EL DE

                //CREO QUE EN ENVIADOS TAMBIEN NECESITAS EL DE, TENIENDO EN CUENTA QUE PODES ESTAR VIENDO
                //LOS CORREO DE VARIAS CUENTAS 
                //by Tommasi

                //listaCuentas2.Columns[1].Visible = true; 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            button5.Visible = true;
            groupBox1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path;
            //listaRecibidos.Rows[indexSelected].
  
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                if (radioButton1.Checked == true)
                {
                    //FachadaCorreo.Instancia.ExportarCorreo( --->  CORREO  <--- ,path,radioButton1.Text);
                    //FALTA VER COMO SELECCIONAR EL CORREO Y TRANSFORMARLO A TIPO correoDTO
                }
                else
                {
                    //FachadaCorreo.Instancia.ExportarCorreo( --->  CORREO  <--- ,path,radioButton2.Text);
                    //FALTA VER COMO SELECCIONAR EL CORREO Y TRANSFORMARLO A TIPO correoDTO
                }
            }

            label6.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            button5.Visible = false;
            groupBox1.Visible = false;
        }

    }
}
