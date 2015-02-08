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
    public partial class FormCuenta : Form
    {
        public FormCuenta()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método que se dispara al hacer click en el botón Nuevo del Menú
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //object[] row = { "", "", "", "" };
            //listaCuentas.Rows.Add(row); 
           
            listaCuentas.CurrentRow.Selected = false;
            listaCuentas.Rows[listaCuentas.Rows.Count-1].Selected = true;

            cuenta_contraseña.Text = "";
            cuenta_contraseña2.Text = "";
            cuenta_nombre.Text = "";
            cuenta_usuario.Text = "";
            cuenta_id.Text = "";


        }

        /// <summary>
        /// Método que se dispara al hacer click en el botón Guardar del Menú
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CuentaDTO pCuenta = new CuentaDTO();
            pCuenta.Direccion = cuenta_usuario.Text;
            pCuenta.Contraseña = cuenta_contraseña.Text;
            pCuenta.Nombre = cuenta_nombre.Text;
            if (cuenta_id.Text == "")
            {
                FachadaABMCuenta.Instancia.CrearCuenta(pCuenta);
            }
            else
            {
                pCuenta.Id = Convert.ToInt32(cuenta_id.Text);
                FachadaABMCuenta.Instancia.ModificarCuenta(pCuenta);
            }
        }

        /// <summary>
        /// Método que se dispara al hacer click en el botón Borrar del Menú
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Metodo para cargar la informacion de las cuentas.
        /// </summary>
        private void MostrarCuentas()
        {
            foreach (CuentaDTO aCuenta in FachadaABMCuenta.Instancia.ListarCuentas())
            {
                object[] row = { aCuenta.Id, aCuenta.Nombre, aCuenta.Direccion, aCuenta.Contraseña };                              
                 listaCuentas.Rows.Add(row);            
            }
        }

        private void FormCuenta_Load(object sender, EventArgs e)
        {
            MostrarCuentas();
        }

        /// <summary>
        /// Metodo que se dispara al seleccionar una cuenta de listaCuentas, y que muestra la informacion de esa cuenta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listaCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = e.RowIndex;

            //Selecciona toda la fila
            listaCuentas.Rows[indexSelected].Selected = true;

            cuenta_id.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["cuentaId"].Value);
            cuenta_nombre.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["nombre"].Value);
            cuenta_usuario.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["usuario"].Value);
            cuenta_contraseña.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["contraseña"].Value);
            cuenta_contraseña2.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["contraseña"].Value);
        }

        private void listaCuentas_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //VER si no esmejor el evento RowsAdded

           // int indexSelected = listaCuentas.Rows.IndexOf(e.Row);
           // listaCuentas.Rows[indexSelected].Selected = true;
        }

        private void listaCuentas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //listaCuentas.Rows[e.RowIndex - 1].Selected = false;
           // listaCuentas.Rows[e.RowIndex].Selected = true;
        }






    }
}
