namespace CapaPresentacion
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btmingresar = new FontAwesome.Sharp.IconButton();
            this.btmcancelar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 193);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "MANEJO DE INVENTARIO";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 143;
            this.iconPictureBox1.Location = new System.Drawing.Point(31, 21);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(144, 143);
            this.iconPictureBox1.TabIndex = 2;
            this.iconPictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(234, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(234, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(209, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(231, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nro Documento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(231, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contraseña:";
            // 
            // btmingresar
            // 
            this.btmingresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btmingresar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btmingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmingresar.ForeColor = System.Drawing.Color.White;
            this.btmingresar.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btmingresar.IconColor = System.Drawing.Color.White;
            this.btmingresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btmingresar.IconSize = 18;
            this.btmingresar.Location = new System.Drawing.Point(243, 123);
            this.btmingresar.Name = "btmingresar";
            this.btmingresar.Size = new System.Drawing.Size(89, 23);
            this.btmingresar.TabIndex = 7;
            this.btmingresar.Text = "Ingresar";
            this.btmingresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btmingresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btmingresar.UseVisualStyleBackColor = false;
            this.btmingresar.Click += new System.EventHandler(this.btmingresar_Click);
            // 
            // btmcancelar
            // 
            this.btmcancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btmcancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btmcancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmcancelar.ForeColor = System.Drawing.Color.White;
            this.btmcancelar.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btmcancelar.IconColor = System.Drawing.Color.White;
            this.btmcancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btmcancelar.IconSize = 18;
            this.btmcancelar.Location = new System.Drawing.Point(347, 123);
            this.btmcancelar.Name = "btmcancelar";
            this.btmcancelar.Size = new System.Drawing.Size(89, 23);
            this.btmcancelar.TabIndex = 8;
            this.btmcancelar.Text = "Cancelar";
            this.btmcancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btmcancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btmcancelar.UseVisualStyleBackColor = false;
            this.btmcancelar.Click += new System.EventHandler(this.btmcancelar_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(37)))), ((int)(((byte)(122)))));
            this.ClientSize = new System.Drawing.Size(471, 193);
            this.Controls.Add(this.btmcancelar);
            this.Controls.Add(this.btmingresar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btmingresar;
        private FontAwesome.Sharp.IconButton btmcancelar;
    }
}