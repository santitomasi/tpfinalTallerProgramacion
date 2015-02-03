namespace formPrincipal
{
    partial class formPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraciónDeCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listaCuentas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.opcionesExportar = new System.Windows.Forms.GroupBox();
            this.panelCorreo = new System.Windows.Forms.Panel();
            this.correo_cuentaDestino = new System.Windows.Forms.Label();
            this.correo_fecha = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.correo_cuentaOrigen = new System.Windows.Forms.Label();
            this.correo_asunto = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.listaEnviados = new System.Windows.Forms.DataGridView();
            this.correoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaRecibidos = new System.Windows.Forms.DataGridView();
            this.correoIdR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCorreoR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asuntoR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaOrigenR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaDestinoR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textoR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leidoR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.opcionesExportar.SuspendLayout();
            this.panelCorreo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaEnviados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaRecibidos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónDeCuentasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraciónDeCuentasToolStripMenuItem
            // 
            this.configuraciónDeCuentasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configuraciónDeCuentasToolStripMenuItem.Image")));
            this.configuraciónDeCuentasToolStripMenuItem.Name = "configuraciónDeCuentasToolStripMenuItem";
            this.configuraciónDeCuentasToolStripMenuItem.Size = new System.Drawing.Size(173, 20);
            this.configuraciónDeCuentasToolStripMenuItem.Text = "Configuración de Cuentas";
            this.configuraciónDeCuentasToolStripMenuItem.Click += new System.EventHandler(this.configuracionCuentasToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(15, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Redactar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(15, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Reenviar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(15, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 29);
            this.button3.TabIndex = 7;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(41, 57);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(745, 422);
            this.textBox1.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(15, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 29);
            this.button4.TabIndex = 11;
            this.button4.Text = "Actualizar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Usuario:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Contraseña:";
            this.label2.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(351, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(188, 20);
            this.textBox2.TabIndex = 18;
            this.textBox2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(385, 113);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(154, 20);
            this.textBox3.TabIndex = 19;
            this.textBox3.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(351, 153);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 20;
            this.button7.Text = "Aceptar";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(439, 153);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 21;
            this.button8.Text = "Cancelar";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Nombre:";
            this.label3.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(352, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(188, 20);
            this.textBox4.TabIndex = 23;
            this.textBox4.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleName = "";
            this.progressBar1.Location = new System.Drawing.Point(622, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(316, 17);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            this.progressBar1.VisibleChanged += new System.EventHandler(this.progressBar_VisibleChanged);
            // 
            // listaCuentas
            // 
            this.listaCuentas.FormattingEnabled = true;
            this.listaCuentas.Location = new System.Drawing.Point(12, 27);
            this.listaCuentas.Name = "listaCuentas";
            this.listaCuentas.Size = new System.Drawing.Size(134, 21);
            this.listaCuentas.TabIndex = 26;
            this.listaCuentas.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Seleccione formato:";
            this.label6.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(39, 75);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 17);
            this.radioButton2.TabIndex = 31;
            this.radioButton2.Text = "EML";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(39, 52);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(82, 17);
            this.radioButton1.TabIndex = 30;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Texto Plano";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(6, 100);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 29);
            this.button5.TabIndex = 32;
            this.button5.Text = "Siguiente";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // opcionesExportar
            // 
            this.opcionesExportar.Controls.Add(this.label6);
            this.opcionesExportar.Controls.Add(this.radioButton1);
            this.opcionesExportar.Controls.Add(this.button5);
            this.opcionesExportar.Controls.Add(this.radioButton2);
            this.opcionesExportar.Location = new System.Drawing.Point(12, 308);
            this.opcionesExportar.Name = "opcionesExportar";
            this.opcionesExportar.Size = new System.Drawing.Size(134, 135);
            this.opcionesExportar.TabIndex = 33;
            this.opcionesExportar.TabStop = false;
            this.opcionesExportar.Text = "Exportar";
            this.opcionesExportar.Visible = false;
            // 
            // panelCorreo
            // 
            this.panelCorreo.BackColor = System.Drawing.SystemColors.Window;
            this.panelCorreo.Controls.Add(this.correo_cuentaDestino);
            this.panelCorreo.Controls.Add(this.correo_fecha);
            this.panelCorreo.Controls.Add(this.label7);
            this.panelCorreo.Controls.Add(this.label5);
            this.panelCorreo.Controls.Add(this.correo_cuentaOrigen);
            this.panelCorreo.Controls.Add(this.correo_asunto);
            this.panelCorreo.Controls.Add(this.textBox1);
            this.panelCorreo.Location = new System.Drawing.Point(152, 27);
            this.panelCorreo.Name = "panelCorreo";
            this.panelCorreo.Size = new System.Drawing.Size(817, 488);
            this.panelCorreo.TabIndex = 34;
            // 
            // correo_cuentaDestino
            // 
            this.correo_cuentaDestino.AutoSize = true;
            this.correo_cuentaDestino.Location = new System.Drawing.Point(324, 28);
            this.correo_cuentaDestino.Name = "correo_cuentaDestino";
            this.correo_cuentaDestino.Size = new System.Drawing.Size(43, 13);
            this.correo_cuentaDestino.TabIndex = 14;
            this.correo_cuentaDestino.Text = "Destino";
            // 
            // correo_fecha
            // 
            this.correo_fecha.AutoSize = true;
            this.correo_fecha.Location = new System.Drawing.Point(493, 28);
            this.correo_fecha.Name = "correo_fecha";
            this.correo_fecha.Size = new System.Drawing.Size(37, 13);
            this.correo_fecha.TabIndex = 13;
            this.correo_fecha.Text = "Fecha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Para:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "De: ";
            // 
            // correo_cuentaOrigen
            // 
            this.correo_cuentaOrigen.AutoSize = true;
            this.correo_cuentaOrigen.Location = new System.Drawing.Point(71, 28);
            this.correo_cuentaOrigen.Name = "correo_cuentaOrigen";
            this.correo_cuentaOrigen.Size = new System.Drawing.Size(38, 13);
            this.correo_cuentaOrigen.TabIndex = 10;
            this.correo_cuentaOrigen.Text = "Origen";
            // 
            // correo_asunto
            // 
            this.correo_asunto.AutoSize = true;
            this.correo_asunto.Location = new System.Drawing.Point(38, 8);
            this.correo_asunto.Name = "correo_asunto";
            this.correo_asunto.Size = new System.Drawing.Size(40, 13);
            this.correo_asunto.TabIndex = 9;
            this.correo_asunto.Text = "Asunto";
            this.correo_asunto.Click += new System.EventHandler(this.label5_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(15, 125);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(131, 29);
            this.button9.TabIndex = 35;
            this.button9.Text = "Recibidos";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(15, 160);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(131, 29);
            this.button10.TabIndex = 36;
            this.button10.Text = "Enviados";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // listaEnviados
            // 
            this.listaEnviados.AllowUserToOrderColumns = true;
            this.listaEnviados.AllowUserToResizeColumns = false;
            this.listaEnviados.AllowUserToResizeRows = false;
            this.listaEnviados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaEnviados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listaEnviados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.listaEnviados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaEnviados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listaEnviados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaEnviados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.correoId,
            this.tipoCorreo,
            this.asunto,
            this.cuentaOrigen,
            this.cuentaDestino,
            this.Fecha,
            this.texto,
            this.leido});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaEnviados.DefaultCellStyle = dataGridViewCellStyle2;
            this.listaEnviados.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listaEnviados.Location = new System.Drawing.Point(152, 27);
            this.listaEnviados.Name = "listaEnviados";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaEnviados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listaEnviados.RowHeadersVisible = false;
            this.listaEnviados.RowHeadersWidth = 20;
            this.listaEnviados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listaEnviados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listaEnviados.Size = new System.Drawing.Size(817, 488);
            this.listaEnviados.TabIndex = 37;
            this.listaEnviados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaEnviados_CellClick);
            // 
            // correoId
            // 
            this.correoId.HeaderText = "correoid";
            this.correoId.Name = "correoId";
            this.correoId.Visible = false;
            // 
            // tipoCorreo
            // 
            this.tipoCorreo.HeaderText = "Tipo Correo";
            this.tipoCorreo.Name = "tipoCorreo";
            this.tipoCorreo.Visible = false;
            // 
            // asunto
            // 
            this.asunto.HeaderText = "Asunto";
            this.asunto.Name = "asunto";
            this.asunto.ReadOnly = true;
            // 
            // cuentaOrigen
            // 
            this.cuentaOrigen.HeaderText = "De";
            this.cuentaOrigen.Name = "cuentaOrigen";
            this.cuentaOrigen.Visible = false;
            // 
            // cuentaDestino
            // 
            this.cuentaDestino.HeaderText = "Para";
            this.cuentaDestino.Name = "cuentaDestino";
            this.cuentaDestino.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 70;
            // 
            // texto
            // 
            this.texto.HeaderText = "Mensaje";
            this.texto.Name = "texto";
            this.texto.Visible = false;
            // 
            // leido
            // 
            this.leido.HeaderText = "Leido";
            this.leido.Name = "leido";
            this.leido.Visible = false;
            // 
            // listaRecibidos
            // 
            this.listaRecibidos.AllowUserToResizeColumns = false;
            this.listaRecibidos.AllowUserToResizeRows = false;
            this.listaRecibidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaRecibidos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listaRecibidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.listaRecibidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaRecibidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.listaRecibidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaRecibidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.correoIdR,
            this.tipoCorreoR,
            this.asuntoR,
            this.cuentaOrigenR,
            this.cuentaDestinoR,
            this.fechaR,
            this.textoR,
            this.leidoR});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaRecibidos.DefaultCellStyle = dataGridViewCellStyle5;
            this.listaRecibidos.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listaRecibidos.Location = new System.Drawing.Point(152, 27);
            this.listaRecibidos.Name = "listaRecibidos";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaRecibidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.listaRecibidos.RowHeadersVisible = false;
            this.listaRecibidos.RowHeadersWidth = 20;
            this.listaRecibidos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listaRecibidos.Size = new System.Drawing.Size(817, 488);
            this.listaRecibidos.TabIndex = 38;
            this.listaRecibidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaRecibidos_CellClick);
            // 
            // correoIdR
            // 
            this.correoIdR.HeaderText = "Correo ID";
            this.correoIdR.Name = "correoIdR";
            this.correoIdR.Visible = false;
            // 
            // tipoCorreoR
            // 
            this.tipoCorreoR.HeaderText = "Tipo Correo";
            this.tipoCorreoR.Name = "tipoCorreoR";
            this.tipoCorreoR.Visible = false;
            // 
            // asuntoR
            // 
            this.asuntoR.HeaderText = "Asunto";
            this.asuntoR.Name = "asuntoR";
            this.asuntoR.ReadOnly = true;
            // 
            // cuentaOrigenR
            // 
            this.cuentaOrigenR.HeaderText = "De";
            this.cuentaOrigenR.Name = "cuentaOrigenR";
            this.cuentaOrigenR.ReadOnly = true;
            // 
            // cuentaDestinoR
            // 
            this.cuentaDestinoR.HeaderText = "Para";
            this.cuentaDestinoR.Name = "cuentaDestinoR";
            this.cuentaDestinoR.Visible = false;
            // 
            // fechaR
            // 
            this.fechaR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fechaR.HeaderText = "Fecha";
            this.fechaR.Name = "fechaR";
            this.fechaR.ReadOnly = true;
            this.fechaR.Width = 70;
            // 
            // textoR
            // 
            this.textoR.HeaderText = "Mensaje";
            this.textoR.Name = "textoR";
            this.textoR.Visible = false;
            // 
            // leidoR
            // 
            this.leidoR.HeaderText = "Leido";
            this.leidoR.Name = "leidoR";
            this.leidoR.Visible = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(15, 265);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(131, 29);
            this.button6.TabIndex = 39;
            this.button6.Text = "Exportar";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(981, 518);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.opcionesExportar);
            this.Controls.Add(this.listaCuentas);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listaEnviados);
            this.Controls.Add(this.listaRecibidos);
            this.Controls.Add(this.panelCorreo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formPrincipal";
            this.Text = "Gestor de correos ";
            this.Load += new System.EventHandler(this.formPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.opcionesExportar.ResumeLayout(false);
            this.opcionesExportar.PerformLayout();
            this.panelCorreo.ResumeLayout(false);
            this.panelCorreo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaEnviados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaRecibidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox listaCuentas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox opcionesExportar;
        private System.Windows.Forms.ToolStripMenuItem configuraciónDeCuentasToolStripMenuItem;
        private System.Windows.Forms.Panel panelCorreo;
        private System.Windows.Forms.Label correo_asunto;
        private System.Windows.Forms.Label correo_cuentaOrigen;
        private System.Windows.Forms.Label correo_fecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label correo_cuentaDestino;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridView listaEnviados;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn asunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn texto;
        private System.Windows.Forms.DataGridViewTextBoxColumn leido;
        private System.Windows.Forms.DataGridView listaRecibidos;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoIdR;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCorreoR;
        private System.Windows.Forms.DataGridViewTextBoxColumn asuntoR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaOrigenR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaDestinoR;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaR;
        private System.Windows.Forms.DataGridViewTextBoxColumn textoR;
        private System.Windows.Forms.DataGridViewTextBoxColumn leidoR;

    }
}

