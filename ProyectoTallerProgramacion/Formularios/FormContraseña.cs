using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormContraseña : Form
    {
        public string varf2; //variable para pasar informacion

        public FormContraseña()
        {
            InitializeComponent();
        }

        private void mostrar_CheckedChanged(object sender, EventArgs e)
        {                   
            if (mostrar.Checked == true)
            {
                cuenta_contraseña.UseSystemPasswordChar = false;               
            }
            else
            {
                cuenta_contraseña.UseSystemPasswordChar = true;               
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            varf2 = cuenta_contraseña.Text; //asignamos a la variable lo capturado en el textbox
        }
        
    }
}
