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
            frm.ShowDialog();
        }


        private void ActualizarCuenta(CuentaDTO pCuenta)
        {
            try
            {
                FachadaCorreo.Instancia.DescargarCorreos(pCuenta);
            }
            catch (Exception exeption)
            {
                // crear una excepcion para esto!!!
                MessageBox.Show(exeption.Message);

                MessageBox.Show(exeption.InnerException.Message);
            }
        }


        private void btActualizar_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;          
        //  progressBar1.PerformStep();                

            //Busca la o las cuentas seleccionadas en listaCuentas
            Int32 row = listaCuentas.SelectedIndex;
            string cuentaSeleccionada = Convert.ToString(listaCuentas.Items[row]);

            // si la cuenta seleccionada es distinta de "Todas las cuentas"
            if (cuentaSeleccionada.CompareTo("Todas las cuentas") != 0) 
            {
                CuentaDTO pCuenta = FachadaABMCuenta.Instancia.ObtenerCuenta(cuentaSeleccionada);
                ActualizarCuenta(pCuenta);
            }
            else
            {
                foreach (CuentaDTO aCuenta in FachadaABMCuenta.Instancia.ListarCuentas())
                {
                    ActualizarCuenta(aCuenta); 
                }
            }     


            // HAY QUE REFREZCAR EL FORM ENTERO ACA, O POR LO MENOS LA LISTA


            progressBar1.Visible = false;
        }
         
        private void agregarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaCuentas.Visible = false;
        }

        private void progressBar_VisibleChanged(object sender, EventArgs e)
        {
            //Pop3Client pop = new Pop3Client();
            //pop.Connect("pop.gmail.com", 995, true);
            //pop.Authenticate("santiagotommasi92", "marlou1006");
            //int cantidadMensajes = pop.GetMessageCount();
            //mensajes = new List<OpenPop.Mime.Message>(cantidadMensajes);
         
            //progressBar1.Minimum = 1;
            //progressBar1.Maximum = cantidadMensajes;
            //progressBar1.Value = 1;
            //progressBar1.Step = 1;
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
                // Coloca la opción de Todas las cuentas
                listaCuentas.Items.Add("Todas las cuentas");
                // marca como seleccionada a la opción Todas las cuentas.
                listaCuentas.SelectedIndex = listaCuentas.Items.Count-1;
            }
            
            
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
                        int posicion = listaEnviados.Rows.Count - 1;
                        listaEnviados.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
                    }
                }
                else
                {
                    listaRecibidos.Rows.Add(row);
                    if (aCorreo.Leido != 0)
                    {
                        int posicion = listaRecibidos.Rows.Count - 1;
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
                        int posicion = listaEnviados.Rows.Count - 1;
                        listaEnviados.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
                    }
                }
                else
                {
                    listaRecibidos.Rows.Add(row);
                    if (aCorreo.Leido != 0)
                    {
                        int posicion = listaRecibidos.Rows.Count - 1;
                        listaRecibidos.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
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
                MostrarCorreos(FachadaABMCuenta.Instancia.ObtenerCuenta(cuentaSeleccionada).Direccion);
            }
            else
            {
                MostrarCorreos();
            }

            //Siempre al cargar una o todas las cuentas muestra la lista de correos recibidos.
            listaEnviados.Visible = false;
            listaRecibidos.Visible = true;
            panelCorreo.Visible = false;
            //opcionesExportar.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CorreoDTO pCorreo = new CorreoDTO();


            if (listaEnviados.Visible)
            {
                //Busca el indice de la fila seleccionada en la lista de correos enviados.
                // como el método SelectedRows devuelve una lista, pero nosotros tenemos una sola fila seleccionada,
                // entonces tomamos el primer elemento.
                int indexSelected = listaEnviados.Rows.IndexOf(listaEnviados.CurrentRow);               
                pCorreo.Id = Convert.ToInt32(listaEnviados.Rows[indexSelected].Cells["correoId"].Value);
                pCorreo.Asunto = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["asunto"].Value);
                pCorreo.CuentaDestino = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["cuentaDestino"].Value);
                pCorreo.CuentaOrigen = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["cuentaOrigen"].Value);
                pCorreo.Fecha = Convert.ToDateTime(listaEnviados.Rows[indexSelected].Cells["fecha"].Value);
                pCorreo.Leido = Convert.ToInt32(listaEnviados.Rows[indexSelected].Cells["leido"].Value);
                pCorreo.Texto = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["texto"].Value);
                pCorreo.TipoCorreo = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["tipoCorreo"].Value);


            }
            else if (listaRecibidos.Visible)
            {
                //Busca el indice de la fila seleccionada en la lista de correos recibidos.
                // como el método SelectedRows devuelve una lista, pero nosotros tenemos una sola fila seleccionada,
                // entonces tomamos el primer elemento.
                int indexSelected = listaRecibidos.Rows.IndexOf(listaRecibidos.CurrentRow);
                pCorreo.Id = Convert.ToInt32(listaRecibidos.Rows[indexSelected].Cells["correoIdR"].Value);
                pCorreo.Asunto = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["asuntoR"].Value);
                pCorreo.CuentaDestino = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["cuentaDestinoR"].Value);
                pCorreo.CuentaOrigen = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["cuentaOrigenR"].Value);
                pCorreo.Fecha = Convert.ToDateTime(listaRecibidos.Rows[indexSelected].Cells["fechaR"].Value);
                pCorreo.Leido = Convert.ToInt32(listaRecibidos.Rows[indexSelected].Cells["leidoR"].Value);
                pCorreo.Texto = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["textoR"].Value);
                pCorreo.TipoCorreo = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["tipoCorreoR"].Value);
            }
            else // esta visible el form de correo
            {
                pCorreo.Id = Convert.ToInt32(correo_id.Text);
                
                // CARGAR LOS DEMAS VALORES!!!

            }
            string path;
            //listaRecibidos.Rows[indexSelected].

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                
                if (radioButton1.Checked == true)
                {
                    FachadaCorreo.Instancia.ExportarCorreo(pCorreo,path,radioButton1.Text);
                    
                }
                else
                {
                    FachadaCorreo.Instancia.ExportarCorreo(pCorreo,path,radioButton2.Text);                    
                }
            }
        }

        private void configuracionCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FormCuenta();
            frm.ShowDialog();
        }

        /// <summary>
        /// Método que se ejecuta al hacer click sobre el botón recibidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            listaEnviados.Visible = false;
            listaRecibidos.Visible = true;
            panelCorreo.Visible = false;
            //opcionesExportar.Visible = false;
        }

        /// <summary>
        /// Método que se ejecuta al hacer click sobre el botón enviados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            listaEnviados.Visible = true;
            listaRecibidos.Visible = false;
            panelCorreo.Visible = false;
            //opcionesExportar.Visible = false;
        }


        private void listaRecibidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método en desuso
        }


        private void listaEnviados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método en desuso
        }



        /// <summary>
        /// Método que se dispara al hacer doble click sobre un correo de la lista de correos Enviados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listaEnviados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = e.RowIndex;

            // Falta marcar el correo como leido en la base y en la lista!!

            textBox1.Text = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["texto"].Value);
            correo_asunto.Text = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["asunto"].Value);
            correo_cuentaDestino.Text = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["cuentaDestino"].Value);
            correo_cuentaOrigen.Text = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["cuentaOrigen"].Value);
            correo_fecha.Text = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["Fecha"].Value);
            correo_id.Text = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["correoId"].Value);
            panelCorreo.Visible = true;
            listaEnviados.Visible = false;
            opcionesExportar.Visible = true;
        }

        /// <summary>
        /// Método que se dispara al hacer doble click sobre un correo de la lista de correos Recibidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listaRecibidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = e.RowIndex;

            // Falta marcar el correo como leido en la base y en la lista!!

            textBox1.Text = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["textoR"].Value);
            correo_asunto.Text = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["asuntoR"].Value);
            correo_cuentaDestino.Text = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["cuentaDestinoR"].Value);
            correo_cuentaOrigen.Text = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["cuentaOrigenR"].Value);
            correo_fecha.Text = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["fechaR"].Value);
            correo_id.Text = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["correoIdR"].Value);
            panelCorreo.Visible = true;
            listaRecibidos.Visible = false;
            opcionesExportar.Visible = true;
            //label6.Visible = true;
            //radioButton1.Visible = true;
            //radioButton2.Visible = true;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            //
            // PREGUNTAR SI DESEA ELIMINAR!!!!!!
            //

            if (listaEnviados.Visible) 
            {
                //Busca el indice de la fila seleccionada en la lista de correos enviados.
                // como el método SelectedRows devuelve una lista, pero nosotros tenemos una sola fila seleccionada,
                // entonces tomamos el primer elemento.
                int indexSelected = listaEnviados.Rows.IndexOf(listaEnviados.CurrentRow);
                CorreoDTO pCorreo = new CorreoDTO();
                pCorreo.Id = Convert.ToInt32(listaEnviados.Rows[indexSelected].Cells["correoId"].Value);
                MessageBox.Show(Convert.ToString(pCorreo.Id));
                FachadaCorreo.Instancia.EliminarCorreo(pCorreo);

                MessageBox.Show("Eliminado con exito!");

                
            }
            else if (listaRecibidos.Visible)
            {
                //Busca el indice de la fila seleccionada en la lista de correos recibidos.
                // como el método SelectedRows devuelve una lista, pero nosotros tenemos una sola fila seleccionada,
                // entonces tomamos el primer elemento.
                int indexSelected = listaRecibidos.Rows.IndexOf(listaRecibidos.CurrentRow);
                CorreoDTO pCorreo = new CorreoDTO();
                pCorreo.Id = Convert.ToInt32(listaRecibidos.Rows[indexSelected].Cells["correoIdR"].Value);
                FachadaCorreo.Instancia.EliminarCorreo(pCorreo);
                MessageBox.Show("Eliminado con exito!");
            }
            else // esta visible el form de correo
            {
                CorreoDTO pCorreo = new CorreoDTO();
                pCorreo.Id = Convert.ToInt32(correo_id.Text);
                FachadaCorreo.Instancia.EliminarCorreo(pCorreo);
                MessageBox.Show("Eliminado con exito!");
            }


            //
            //REVISAR ESTO!!!! EL METODO DE CARGAR CUENTAS DEBERIA SER INDEPENDIENTE DEL EVENTO SELECTEDINDEXCHANGED
            // LO CUAL FACILITARIA EL PODER LLAMARLO DESDE CUALQUIER LADO
            //

            // actualiza el infice del combobox para que se lence el evento SelectionIndexChanged
            listaCuentas.SelectedIndex = 0;
            listaCuentas.SelectedIndex = listaCuentas.Items.Count - 1;


        }

    }
}
