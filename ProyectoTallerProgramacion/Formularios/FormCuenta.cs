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
            if (pCuenta.Id == -1) // ACORDARSE DE PONER -1 cuando en el form se estacreando una
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
              //  listaCuentas.//Items.Add(aCuenta.Nombre);
                
            }
           // listaCuentas.Items.Add("Todas las cuentas");

        }

        private void FormCuenta_Load(object sender, EventArgs e)
        {
            MostrarCuentas();
        }

        private void FormCuenta_Shown(object sender, EventArgs e)
        {
            MostrarCuentas();
        }



    }
}
