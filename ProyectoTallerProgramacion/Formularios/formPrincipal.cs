﻿using System;
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
        /// <summary>
        /// Metodo que se dispara cuando se abre el formulario.
        /// </summary>
        public formPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que se dispara al hacer click en el boton "Redactar" para enviar un correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new formEnvioCorreo();
            frm.ShowDialog();
            // Actualiza las listas Recibidos y Enviados
            MostrarCorreos();
        }

        /// <summary>
        /// Metodo para descargar los correos de una cuenta.
        /// </summary>
        /// <param name="pCuenta"></param>
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


        /// <summary>
        /// Metodo que se dispara al hacer click en el boton "Actualizar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btActualizar_Click(object sender, EventArgs e)
        {
            //Busca la o las cuentas seleccionadas en listaCuentas
            Int32 row = listaCuentas.SelectedIndex;
            string cuentaSeleccionada = Convert.ToString(listaCuentas.Items[row]);

            // Si la cuenta seleccionada es distinta de "Todas las cuentas"
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
            // Actualiza las listas Recibidos y Enviados
            MostrarCorreos();
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
            catch (Exception exeption)
            {
                // VER QUE HACER ACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                
                MessageBox.Show(exeption.Message);
                MessageBox.Show(exeption.InnerException.Message);
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

            //Busca la cuenta seleccionada
            Int32 filaSeleccionada = listaCuentas.SelectedIndex;
            string cuentaSeleccionada = Convert.ToString(listaCuentas.Items[filaSeleccionada]);

            //Variable para almacenar los correos a mostrar.
            IList<CorreoDTO> pCorreos = new List<CorreoDTO>();


            if (cuentaSeleccionada.CompareTo("Todas las cuentas") != 0) // si la cuenta seleccionada es distinta de "Todas las cuentas"
            {
                //Carga enla variable pCorreos los correos de la cuenta seleccionada.
                string pDireccion = FachadaABMCuenta.Instancia.ObtenerCuenta(cuentaSeleccionada).Direccion;
                pCorreos = FachadaCorreo.Instancia.ListarCorreos(pDireccion);
            }
            else
            {
                //Carga enla variable pCorreos los correos de todas las cuentas.
                pCorreos = FachadaCorreo.Instancia.ListarCorreos();
            }
            foreach (CorreoDTO aCorreo in pCorreos)
            {
                object[] row = { aCorreo.Id, aCorreo.TipoCorreo, aCorreo.Asunto, aCorreo.CuentaOrigen, aCorreo.CuentaDestino, 
                                   aCorreo.Fecha.ToString("dddd, dd ") + "de " + aCorreo.Fecha.ToString("MMMM") + " de " + 
                                   aCorreo.Fecha.ToString("yyyy") + aCorreo.Fecha.ToString(" HH:mm"),
                                   aCorreo.Texto, aCorreo.Leido, aCorreo.ServicioId };
                if (aCorreo.TipoCorreo == "Enviado")
                {
                    listaEnviados.Rows.Add(row);
                    if (aCorreo.Leido != false)
                    {
                        int posicion = listaEnviados.Rows.Count - 1;
                        listaEnviados.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
                    }
                }
                else
                {
                    listaRecibidos.Rows.Add(row);
                    if (aCorreo.Leido != false)
                    {
                        int posicion = listaRecibidos.Rows.Count - 1;
                        listaRecibidos.Rows[posicion].DefaultCellStyle.BackColor = Color.Lavender;
                    }
                }
            }
        }

      //  /// <summary>
      //  /// Metodo para cargar la informacion de los correos de la cuenta <paramref name="pCuenta"/>.
     //   /// </summary>
     //   private void MostrarCorreos(string pCuenta)
      //  {
            //Borra las filas de los DataGridView antes de cargar los correos.
      //      listaEnviados.Rows.Clear();
       //     listaRecibidos.Rows.Clear();

 //       }

        /// <summary>
        /// Metodo que se dispara cuando se carga el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            // Muestra los correos de la cuenta seleccionada
            MostrarCorreos();            
            //Siempre al cargar los correos de una o todas las cuentas muestra la lista de correos recibidos.
            listaEnviados.Visible = false;
            listaRecibidos.Visible = true;
            panelCorreo.Visible = false;
        }

        /// <summary>
        /// Metodo que se dispara al hacer click en el boton "Exportar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                pCorreo.Leido = Convert.ToBoolean(listaEnviados.Rows[indexSelected].Cells["leido"].Value);
                pCorreo.Texto = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["texto"].Value);
                pCorreo.TipoCorreo = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["tipoCorreo"].Value);
                pCorreo.ServicioId = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["servicioId"].Value); 
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
                pCorreo.Leido = Convert.ToBoolean(listaRecibidos.Rows[indexSelected].Cells["leidoR"].Value);
                pCorreo.Texto = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["textoR"].Value);
                pCorreo.TipoCorreo = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["tipoCorreoR"].Value);
                pCorreo.ServicioId = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["servicioIdR"].Value); 
            }
            else // esta visible el form de correo
            {
                pCorreo.Id = Convert.ToInt32(correo_id.Text);
                pCorreo.Asunto = correo_asunto.Text;
                pCorreo.CuentaDestino = correo_cuentaDestino.Text;
                pCorreo.CuentaOrigen = correo_cuentaOrigen.Text;
                pCorreo.Fecha = Convert.ToDateTime(correo_fecha.Text);
                pCorreo.Texto = correo_texto.Text;
                
                //pCorreo.Leido = Convert.ToInt32();
                // pCorreo.TipoCorreo = 

            }
            string path;
            
            //listaRecibidos.Rows[indexSelected].

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                //crea el nombre en base del asunto del correo, eliminando los caracteres invalidos como nombre de archivo.
                string pNombre = pCorreo.Asunto;
                char[] invalidchars = Path.GetInvalidFileNameChars();
                foreach (char cChar in invalidchars)
                {
                    pNombre = pNombre.Replace(cChar, '_');
                }
                if (radioButton1.Checked == true)
                {
                    FachadaCorreo.Instancia.ExportarCorreo(pCorreo,path,radioButton1.Text, pNombre);
                }
                else
                {
                    FachadaCorreo.Instancia.ExportarCorreo(pCorreo, path, radioButton2.Text, pNombre);                    
                }
            }
        }

        /// <summary>
        /// Metodo que abre el formulario de administracion de cuentas.
        /// Se dispara al hacer click en el elemento del menu "Administrar cuentas".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configuracionCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FormCuenta();
            frm.ShowDialog();
            MostrarCuentas();
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
        }

        /// <summary>
        /// Método que se dispara al hacer doble click sobre un correo de la lista de correos Enviados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listaEnviados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = e.RowIndex;
            CorreoDTO pCorreo = new CorreoDTO();

            // Marco como leido el correo en la lista
            listaEnviados.Rows[indexSelected].Cells["leido"].Value = 1;
            listaEnviados.Rows[indexSelected].DefaultCellStyle.BackColor = Color.Lavender;

            //Carga los datos desde la grilla al objeto pCorreo
            pCorreo.Id = Convert.ToInt32(listaEnviados.Rows[indexSelected].Cells["correoId"].Value);
            pCorreo.Asunto = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["asunto"].Value);
            pCorreo.CuentaDestino = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["cuentaDestino"].Value);
            pCorreo.CuentaOrigen = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["cuentaOrigen"].Value);
            pCorreo.Fecha = Convert.ToDateTime(listaEnviados.Rows[indexSelected].Cells["fecha"].Value);
            pCorreo.Leido = Convert.ToBoolean(listaEnviados.Rows[indexSelected].Cells["leido"].Value);
            pCorreo.Texto = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["texto"].Value);
            pCorreo.TipoCorreo = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["tipoCorreo"].Value);
            pCorreo.ServicioId = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["servicioId"].Value);

            correo_texto.Text = pCorreo.Texto;
            correo_asunto.Text = pCorreo.Asunto;
            correo_cuentaDestino.Text = pCorreo.CuentaDestino;
            correo_cuentaOrigen.Text = pCorreo.CuentaOrigen;
            //copia el string de la fecha sin convertirlo a datatime porque es para mostrarlo en el form
            correo_fecha.Text = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["fecha"].Value);
            correo_id.Text = Convert.ToString(pCorreo.Id);
            correo_leido.Text = Convert.ToString(pCorreo.Leido);
            correo_servicioid.Text = pCorreo.ServicioId;
            correo_tipocorreo.Text = pCorreo.TipoCorreo;

            try
            {
                // Marco como leido el correo en la base
                FachadaCorreo.Instancia.ModificarCorreo(pCorreo);
            }
            catch( Exception exeption)
            {
                MessageBox.Show(exeption.Message);
                MessageBox.Show(exeption.InnerException.Message);
            }
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
            CorreoDTO pCorreo = new CorreoDTO();
            
            // Marco como leido el correo en la lista
            listaRecibidos.Rows[indexSelected].Cells["leidoR"].Value = 1;
            listaRecibidos.Rows[indexSelected].DefaultCellStyle.BackColor = Color.Lavender;

            pCorreo.Id = Convert.ToInt32(listaRecibidos.Rows[indexSelected].Cells["correoIdR"].Value);
            pCorreo.Asunto = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["asuntoR"].Value);
            pCorreo.CuentaDestino = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["cuentaDestinoR"].Value);
            pCorreo.CuentaOrigen = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["cuentaOrigenR"].Value);
            pCorreo.Fecha = Convert.ToDateTime(listaRecibidos.Rows[indexSelected].Cells["fechaR"].Value);
            pCorreo.Leido = Convert.ToBoolean(listaRecibidos.Rows[indexSelected].Cells["leidoR"].Value);
            pCorreo.Texto = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["textoR"].Value);
            pCorreo.TipoCorreo = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["tipoCorreoR"].Value);
            pCorreo.ServicioId = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["servicioIdR"].Value);

            correo_texto.Text = pCorreo.Texto;
            correo_asunto.Text = pCorreo.Asunto;
            correo_cuentaDestino.Text = pCorreo.CuentaDestino;
            correo_cuentaOrigen.Text = pCorreo.CuentaOrigen;
            //copia el string de la fecha sin convertirlo a datatime porque es para mostrarlo en el form
            correo_fecha.Text = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["fechaR"].Value);
            correo_id.Text = Convert.ToString(pCorreo.Id);
            correo_leido.Text = Convert.ToString(pCorreo.Leido);
            correo_servicioid.Text = pCorreo.ServicioId;
            correo_tipocorreo.Text = pCorreo.TipoCorreo;
            try
            {
                // Marco como leido el correo en la base
                FachadaCorreo.Instancia.ModificarCorreo(pCorreo);
            }                        
            catch( Exception exeption)
            {
                MessageBox.Show(exeption.Message);
                MessageBox.Show(exeption.InnerException.Message);
            }

            panelCorreo.Visible = true;
            listaRecibidos.Visible = false;
            opcionesExportar.Visible = true;
        }

        /// <summary>
        /// Metodo que se dispara al hacer click en el boton "Eliminar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEliminar_Click(object sender, EventArgs e)
        {

            //TRY

            if (MessageBox.Show("¿Está seguro que desea eliminar este correo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
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
            }
            // Actualiza las listas Recibidos y Enviados
            MostrarCorreos(); 
        }

        /// <summary>
        /// Metodo que se dispara al hacer click en el boton "Reenviar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonReenviar_Click(object sender, EventArgs e)
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
                //pCorreo.Leido = Convert.ToInt32(listaEnviados.Rows[indexSelected].Cells["leido"].Value);
                pCorreo.Texto = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["texto"].Value);
                //pCorreo.TipoCorreo = Convert.ToString(listaEnviados.Rows[indexSelected].Cells["tipoCorreo"].Value);
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
                //pCorreo.Leido = Convert.ToInt32(listaRecibidos.Rows[indexSelected].Cells["leidoR"].Value);
                pCorreo.Texto = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["textoR"].Value);
                //pCorreo.TipoCorreo = Convert.ToString(listaRecibidos.Rows[indexSelected].Cells["tipoCorreoR"].Value);
            }
            else // esta visible el form de correo
            {
                pCorreo.Id = Convert.ToInt32(correo_id.Text);
                pCorreo.Asunto = correo_asunto.Text;
                pCorreo.CuentaDestino = correo_cuentaDestino.Text;
                pCorreo.CuentaOrigen = correo_cuentaOrigen.Text;
                pCorreo.Fecha = Convert.ToDateTime(correo_fecha.Text);
                pCorreo.Texto = correo_texto.Text;
                //pCorreo.Leido = Convert.ToInt32();
                //pCorreo.TipoCorreo = 
            }
            Form frm = new formEnvioCorreo(pCorreo);
            frm.ShowDialog();
            // Actualiza las listas Recibidos y Enviados
            MostrarCorreos();
        }


    }
}
