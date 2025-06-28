namespace IU
{
    partial class NuevoUsuario
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
            this.comboBoxRolUsuario = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonCrearUser = new System.Windows.Forms.Button();
            this.textBoxPww = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.checkBoxMostrarContraseña = new System.Windows.Forms.CheckBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxIdUser = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.idLbl = new System.Windows.Forms.Label();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxRolUsuario
            // 
            this.comboBoxRolUsuario.FormattingEnabled = true;
            this.comboBoxRolUsuario.Location = new System.Drawing.Point(47, 162);
            this.comboBoxRolUsuario.Name = "comboBoxRolUsuario";
            this.comboBoxRolUsuario.Size = new System.Drawing.Size(167, 21);
            this.comboBoxRolUsuario.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 170);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Rol: ";
            // 
            // buttonCrearUser
            // 
            this.buttonCrearUser.Location = new System.Drawing.Point(25, 202);
            this.buttonCrearUser.Name = "buttonCrearUser";
            this.buttonCrearUser.Size = new System.Drawing.Size(75, 23);
            this.buttonCrearUser.TabIndex = 13;
            this.buttonCrearUser.Text = "Crear";
            this.buttonCrearUser.UseVisualStyleBackColor = true;
            this.buttonCrearUser.Click += new System.EventHandler(this.buttonCrearUser_Click);
            // 
            // textBoxPww
            // 
            this.textBoxPww.Location = new System.Drawing.Point(78, 108);
            this.textBoxPww.Name = "textBoxPww";
            this.textBoxPww.Size = new System.Drawing.Size(136, 20);
            this.textBoxPww.TabIndex = 12;
            this.textBoxPww.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 111);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 11;
            this.labelPassword.Text = "Password:";
            // 
            // checkBoxMostrarContraseña
            // 
            this.checkBoxMostrarContraseña.AutoSize = true;
            this.checkBoxMostrarContraseña.Location = new System.Drawing.Point(78, 134);
            this.checkBoxMostrarContraseña.Name = "checkBoxMostrarContraseña";
            this.checkBoxMostrarContraseña.Size = new System.Drawing.Size(118, 17);
            this.checkBoxMostrarContraseña.TabIndex = 10;
            this.checkBoxMostrarContraseña.Text = "Mostrar Contraseña";
            this.checkBoxMostrarContraseña.UseVisualStyleBackColor = true;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(78, 82);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(136, 20);
            this.textBoxApellido.TabIndex = 7;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(78, 56);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(136, 20);
            this.textBoxNombre.TabIndex = 6;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(78, 30);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(136, 20);
            this.textBoxUserName.TabIndex = 5;
            // 
            // textBoxIdUser
            // 
            this.textBoxIdUser.Location = new System.Drawing.Point(78, 3);
            this.textBoxIdUser.Name = "textBoxIdUser";
            this.textBoxIdUser.ReadOnly = true;
            this.textBoxIdUser.Size = new System.Drawing.Size(136, 20);
            this.textBoxIdUser.TabIndex = 4;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 34);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "UserName:";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(12, 85);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(47, 13);
            this.labelApellido.TabIndex = 2;
            this.labelApellido.Text = "Apellido:";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(12, 61);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(47, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre:";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(12, 9);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(21, 13);
            this.idLbl.TabIndex = 0;
            this.idLbl.Text = "ID:";
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(131, 202);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 23);
            this.bttnCancelar.TabIndex = 14;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            // 
            // NuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 236);
            this.Controls.Add(this.bttnCancelar);
            this.Controls.Add(this.textBoxPww);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.buttonCrearUser);
            this.Controls.Add(this.checkBoxMostrarContraseña);
            this.Controls.Add(this.comboBoxRolUsuario);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.idLbl);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.textBoxIdUser);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.lblUsername);
            this.Name = "NuevoUsuario";
            this.Text = "Crear Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRolUsuario;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonCrearUser;
        private System.Windows.Forms.TextBox textBoxPww;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.CheckBox checkBoxMostrarContraseña;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxIdUser;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.Button bttnCancelar;
    }
}