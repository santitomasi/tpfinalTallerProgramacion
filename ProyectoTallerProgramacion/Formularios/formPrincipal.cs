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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                dataGridView2.Rows.Add(row);
            }

            progressBar1.Visible = false;
        }
         
        private void agregarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
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

            listBox1.Visible = true;
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
            listBox1.Visible = true;
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = dataGridView2.Rows[e.RowIndex].Index;

            textBox1.Text = mensajes[indexSelected].Headers.ContentDescription;
        } 

        private void progressBar_VisibleChanged(object sender, EventArgs e)
        {
            Pop3Client pop = new Pop3Client();
            pop.Connect("pop.gmail.com", 995, true);
            pop.Authenticate("santiagotommasi92", "password");
            int cantidadMensajes = pop.GetMessageCount();
            mensajes = new List<OpenPop.Mime.Message>(cantidadMensajes);
         
            progressBar1.Minimum = 1;
            progressBar1.Maximum = cantidadMensajes;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
        }
    }
}
