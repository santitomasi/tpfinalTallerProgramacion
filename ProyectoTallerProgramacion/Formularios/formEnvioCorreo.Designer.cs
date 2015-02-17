namespace formPrincipal
{
    partial class formEnvioCorreo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEnvioCorreo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.correo_Asunto = new System.Windows.Forms.TextBox();
            this.correo_Texto = new System.Windows.Forms.TextBox();
            this.botonAdjuntar = new System.Windows.Forms.Button();
            this.botonEnviar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.correo_Destino = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listaCuentas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asunto:";
            // 
            // correo_Asunto
            // 
            this.correo_Asunto.Location = new System.Drawing.Point(97, 71);
            this.correo_Asunto.Name = "correo_Asunto";
            this.correo_Asunto.Size = new System.Drawing.Size(382, 20);
            this.correo_Asunto.TabIndex = 3;
            // 
            // correo_Texto
            // 
            this.correo_Texto.Location = new System.Drawing.Point(28, 97);
            this.correo_Texto.Multiline = true;
            this.correo_Texto.Name = "correo_Texto";
            this.correo_Texto.Size = new System.Drawing.Size(451, 265);
            this.correo_Texto.TabIndex = 5;
            // 
            // botonAdjuntar
            // 
            this.botonAdjuntar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonAdjuntar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.botonAdjuntar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonAdjuntar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAdjuntar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.botonAdjuntar.Location = new System.Drawing.Point(28, 368);
            this.botonAdjuntar.Name = "botonAdjuntar";
            this.botonAdjuntar.Size = new System.Drawing.Size(191, 39);
            this.botonAdjuntar.TabIndex = 6;
            this.botonAdjuntar.Text = "Agregar archivo adjunto";
            this.botonAdjuntar.UseVisualStyleBackColor = true;
            this.botonAdjuntar.Click += new System.EventHandler(this.button2_Click);
            // 
            // botonEnviar
            // 
            this.botonEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.botonEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEnviar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.botonEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonEnviar.Location = new System.Drawing.Point(358, 368);
            this.botonEnviar.Name = "botonEnviar";
            this.botonEnviar.Size = new System.Drawing.Size(121, 39);
            this.botonEnviar.TabIndex = 7;
            this.botonEnviar.Text = "Enviar";
            this.botonEnviar.UseVisualStyleBackColor = false;
            this.botonEnviar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // correo_Destino
            // 
            this.correo_Destino.Location = new System.Drawing.Point(97, 45);
            this.correo_Destino.Name = "correo_Destino";
            this.correo_Destino.Size = new System.Drawing.Size(382, 20);
            this.correo_Destino.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Destinatario:";
            // 
            // listaCuentas
            // 
            this.listaCuentas.FormattingEnabled = true;
            this.listaCuentas.Location = new System.Drawing.Point(97, 17);
            this.listaCuentas.Name = "listaCuentas";
            this.listaCuentas.Size = new System.Drawing.Size(382, 21);
            this.listaCuentas.TabIndex = 11;
            // 
            // formEnvioCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(502, 424);
            this.Controls.Add(this.listaCuentas);
            this.Controls.Add(this.correo_Destino);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.botonEnviar);
            this.Controls.Add(this.botonAdjuntar);
            this.Controls.Add(this.correo_Texto);
            this.Controls.Add(this.correo_Asunto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formEnvioCorreo";
            this.Text = "formEnvioCorreo";
            this.Load += new System.EventHandler(this.formEnvioCorreo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox correo_Asunto;
        private System.Windows.Forms.TextBox correo_Texto;
        private System.Windows.Forms.Button botonAdjuntar;
        private System.Windows.Forms.Button botonEnviar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox correo_Destino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox listaCuentas;
    }
}