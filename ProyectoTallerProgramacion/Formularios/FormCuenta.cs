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

        /// <summary>
        /// Método que se dispara al hacer click en el botón Nuevo del Menú
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object[] row = { "", "", "", "" };
            listaCuentas.Rows.Add(row); 
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
            //PREGUNTAR SI ESTA SEGuROOOOOOOOOOOOOOOOOOOOOOOOOOO
            //

            if (cuenta_id.Text == "")
            {
                listaCuentas.Rows.Remove(listaCuentas.SelectedRows[0]);
                // Marca como seleccionada la ultima fila
                listaCuentas.Rows[listaCuentas.Rows.Count - 1].Selected = true;
            }
            else
            {
                CuentaDTO pCuenta = new CuentaDTO();
                pCuenta.Id = Convert.ToInt32(cuenta_id.Text);
                MessageBox.Show("Id de la cuenta a borrar: "+pCuenta.Id);
                FachadaABMCuenta.Instancia.ModificarCuenta(pCuenta);
            }
        }


        /// <summary>
        /// Metodo para cargar la informacion de las cuentas.
        /// </summary>
        private void MostrarCuentas()
        {
            foreach (CuentaDTO aCuenta in FachadaABMCuenta.Instancia.ListarCuentas())
            {
                object[] row = { aCuenta.Id, aCuenta.Nombre, aCuenta.Direccion, aCuenta.Contraseña };
                MessageBox.Show("Id de la cuenta a añadir: " + aCuenta.Id);          
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

        private void cuenta_nombre_TextChanged(object sender, EventArgs e)
        {
            listaCuentas.SelectedRows[0].Cells["nombre"].Value = cuenta_nombre.Text;              
        }

        private void cuenta_usuario_TextChanged(object sender, EventArgs e)
        {
            listaCuentas.SelectedRows[0].Cells["usuario"].Value = cuenta_usuario.Text;
        }

        private void cuenta_contraseña_TextChanged(object sender, EventArgs e)
        {
            listaCuentas.SelectedRows[0].Cells["contraseña"].Value = cuenta_contraseña.Text;
        }

        /// <summary>
        /// Método que se ejecuta cuando se entra a una fila (Haciendo uso de las flechas)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listaCuentas_RowEnter(object sender, DataGridViewCellEventArgs e)
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



    }
}
