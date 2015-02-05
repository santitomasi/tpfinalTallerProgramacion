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
            pCuenta.Id = Convert.ToInt32(cuenta_id.Text);
            if (pCuenta.Id == -1) // ACORDARSE DE PONER -1 cuando en el form se está creando una
            {
                FachadaABMCuenta.Instancia.CrearCuenta(pCuenta);
            }
            else
            {
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

            cuenta_id.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["cuentaId"].Value);
            cuenta_nombre.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["nombre"].Value);
            cuenta_usuario.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["usuario"].Value);
            cuenta_contraseña.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["contraseña"].Value);
            cuenta_contraseña2.Text = Convert.ToString(listaCuentas.Rows[indexSelected].Cells["contraseña"].Value);
        }





    }
}
