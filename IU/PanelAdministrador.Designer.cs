namespace IU
{
    partial class PanelAdministrador
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Usuarios");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Roles");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Permisos");
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.buttonModificarUsuario = new System.Windows.Forms.Button();
            this.buttonCrearUser = new System.Windows.Forms.Button();
            this.textBoxPww = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.checkBoxMostrarContraseña = new System.Windows.Forms.CheckBox();
            this.checkBoxBloqueado = new System.Windows.Forms.CheckBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxIdUser = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.idLbl = new System.Windows.Forms.Label();
            this.groupBoxRol = new System.Windows.Forms.GroupBox();
            this.textBoxDesignacionRol = new System.Windows.Forms.TextBox();
            this.textBoxIDRol = new System.Windows.Forms.TextBox();
            this.bttnModificarRol = new System.Windows.Forms.Button();
            this.bttnEliminarRol = new System.Windows.Forms.Button();
            this.bttnAltaRol = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPermiso = new System.Windows.Forms.GroupBox();
            this.buttonQuitarPermiso = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboPermisos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombrePermiso = new System.Windows.Forms.TextBox();
            this.lblNombrePermiso = new System.Windows.Forms.Label();
            this.textBoxIdPermiso = new System.Windows.Forms.TextBox();
            this.lblIDPermiso = new System.Windows.Forms.Label();
            this.groupBoxRolesyPermisos = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonQuitarPermisoUser = new System.Windows.Forms.Button();
            this.buttonAsociarPermisoUser = new System.Windows.Forms.Button();
            this.comboBoxPermisos = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBoxRolesAUser = new System.Windows.Forms.GroupBox();
            this.buttonQuitarRolUser = new System.Windows.Forms.Button();
            this.buttonAsociarRolUser = new System.Windows.Forms.Button();
            this.comboBoxRolUsuario = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.treeViewUsuarios = new System.Windows.Forms.TreeView();
            this.treeViewRoles = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.treeViewPermisos = new System.Windows.Forms.TreeView();
            this.label7 = new System.Windows.Forms.Label();
            this.treeViewPermisosXRol = new System.Windows.Forms.TreeView();
            this.label8 = new System.Windows.Forms.Label();
            this.treeViewRolesyPermisosDelUsuario = new System.Windows.Forms.TreeView();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxRolParaAgregarRoles = new System.Windows.Forms.GroupBox();
            this.buttonDesasociarRolARol = new System.Windows.Forms.Button();
            this.buttonAsociarRolARol = new System.Windows.Forms.Button();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.textBoxIDRolParaAsociarRol = new System.Windows.Forms.TextBox();
            this.textBoxNombreRolParaAsociarRol = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonLimpiarCampos = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBoxAeronaves = new System.Windows.Forms.GroupBox();
            this.buttonCrearAeronave = new System.Windows.Forms.Button();
            this.textBoxSerie = new System.Windows.Forms.TextBox();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.textBoxModelo = new System.Windows.Forms.TextBox();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.textBoxIdAeronave = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Marca = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridViewAeronaves = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.groupBoxUser.SuspendLayout();
            this.groupBoxRol.SuspendLayout();
            this.groupBoxPermiso.SuspendLayout();
            this.groupBoxRolesyPermisos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxRolesAUser.SuspendLayout();
            this.groupBoxRolParaAgregarRoles.SuspendLayout();
            this.groupBoxAeronaves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAeronaves)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.buttonModificarUsuario);
            this.groupBoxUser.Controls.Add(this.buttonCrearUser);
            this.groupBoxUser.Controls.Add(this.textBoxPww);
            this.groupBoxUser.Controls.Add(this.labelPassword);
            this.groupBoxUser.Controls.Add(this.checkBoxMostrarContraseña);
            this.groupBoxUser.Controls.Add(this.checkBoxBloqueado);
            this.groupBoxUser.Controls.Add(this.textBoxApellido);
            this.groupBoxUser.Controls.Add(this.textBoxNombre);
            this.groupBoxUser.Controls.Add(this.textBoxUserName);
            this.groupBoxUser.Controls.Add(this.textBoxIdUser);
            this.groupBoxUser.Controls.Add(this.lblUsername);
            this.groupBoxUser.Controls.Add(this.labelApellido);
            this.groupBoxUser.Controls.Add(this.labelNombre);
            this.groupBoxUser.Controls.Add(this.idLbl);
            this.groupBoxUser.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(359, 179);
            this.groupBoxUser.TabIndex = 0;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "Usuario:";
            // 
            // buttonModificarUsuario
            // 
            this.buttonModificarUsuario.Location = new System.Drawing.Point(278, 147);
            this.buttonModificarUsuario.Name = "buttonModificarUsuario";
            this.buttonModificarUsuario.Size = new System.Drawing.Size(75, 23);
            this.buttonModificarUsuario.TabIndex = 14;
            this.buttonModificarUsuario.Text = "Modificar";
            this.buttonModificarUsuario.UseVisualStyleBackColor = true;
            this.buttonModificarUsuario.Click += new System.EventHandler(this.buttonModificarUsuario_Click);
            // 
            // buttonCrearUser
            // 
            this.buttonCrearUser.Location = new System.Drawing.Point(11, 148);
            this.buttonCrearUser.Name = "buttonCrearUser";
            this.buttonCrearUser.Size = new System.Drawing.Size(75, 23);
            this.buttonCrearUser.TabIndex = 13;
            this.buttonCrearUser.Text = "Crear";
            this.buttonCrearUser.UseVisualStyleBackColor = true;
            this.buttonCrearUser.Click += new System.EventHandler(this.buttonCrearUser_Click);
            // 
            // textBoxPww
            // 
            this.textBoxPww.Location = new System.Drawing.Point(75, 124);
            this.textBoxPww.Name = "textBoxPww";
            this.textBoxPww.Size = new System.Drawing.Size(136, 20);
            this.textBoxPww.TabIndex = 12;
            this.textBoxPww.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(9, 127);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 11;
            this.labelPassword.Text = "Password:";
            // 
            // checkBoxMostrarContraseña
            // 
            this.checkBoxMostrarContraseña.AutoSize = true;
            this.checkBoxMostrarContraseña.Location = new System.Drawing.Point(241, 126);
            this.checkBoxMostrarContraseña.Name = "checkBoxMostrarContraseña";
            this.checkBoxMostrarContraseña.Size = new System.Drawing.Size(118, 17);
            this.checkBoxMostrarContraseña.TabIndex = 10;
            this.checkBoxMostrarContraseña.Text = "Mostrar Contraseña";
            this.checkBoxMostrarContraseña.UseVisualStyleBackColor = true;
            this.checkBoxMostrarContraseña.CheckedChanged += new System.EventHandler(this.checkBoxMostrarContraseña_CheckedChanged);
            // 
            // checkBoxBloqueado
            // 
            this.checkBoxBloqueado.AutoSize = true;
            this.checkBoxBloqueado.Location = new System.Drawing.Point(241, 19);
            this.checkBoxBloqueado.Name = "checkBoxBloqueado";
            this.checkBoxBloqueado.Size = new System.Drawing.Size(77, 17);
            this.checkBoxBloqueado.TabIndex = 9;
            this.checkBoxBloqueado.Text = "Bloqueado";
            this.checkBoxBloqueado.UseVisualStyleBackColor = true;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(75, 98);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(136, 20);
            this.textBoxApellido.TabIndex = 7;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(75, 72);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(136, 20);
            this.textBoxNombre.TabIndex = 6;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(75, 46);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(136, 20);
            this.textBoxUserName.TabIndex = 5;
            // 
            // textBoxIdUser
            // 
            this.textBoxIdUser.Location = new System.Drawing.Point(75, 19);
            this.textBoxIdUser.Name = "textBoxIdUser";
            this.textBoxIdUser.ReadOnly = true;
            this.textBoxIdUser.Size = new System.Drawing.Size(136, 20);
            this.textBoxIdUser.TabIndex = 4;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(9, 50);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "UserName:";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(9, 101);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(47, 13);
            this.labelApellido.TabIndex = 2;
            this.labelApellido.Text = "Apellido:";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(9, 77);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(47, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre:";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(9, 25);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(21, 13);
            this.idLbl.TabIndex = 0;
            this.idLbl.Text = "ID:";
            // 
            // groupBoxRol
            // 
            this.groupBoxRol.Controls.Add(this.textBoxDesignacionRol);
            this.groupBoxRol.Controls.Add(this.textBoxIDRol);
            this.groupBoxRol.Controls.Add(this.bttnModificarRol);
            this.groupBoxRol.Controls.Add(this.bttnEliminarRol);
            this.groupBoxRol.Controls.Add(this.bttnAltaRol);
            this.groupBoxRol.Controls.Add(this.label2);
            this.groupBoxRol.Controls.Add(this.label1);
            this.groupBoxRol.Location = new System.Drawing.Point(377, 13);
            this.groupBoxRol.Name = "groupBoxRol";
            this.groupBoxRol.Size = new System.Drawing.Size(264, 144);
            this.groupBoxRol.TabIndex = 1;
            this.groupBoxRol.TabStop = false;
            this.groupBoxRol.Text = "Rol:";
            // 
            // textBoxDesignacionRol
            // 
            this.textBoxDesignacionRol.Location = new System.Drawing.Point(87, 49);
            this.textBoxDesignacionRol.Name = "textBoxDesignacionRol";
            this.textBoxDesignacionRol.Size = new System.Drawing.Size(162, 20);
            this.textBoxDesignacionRol.TabIndex = 6;
            // 
            // textBoxIDRol
            // 
            this.textBoxIDRol.Location = new System.Drawing.Point(36, 24);
            this.textBoxIDRol.Name = "textBoxIDRol";
            this.textBoxIDRol.ReadOnly = true;
            this.textBoxIDRol.Size = new System.Drawing.Size(45, 20);
            this.textBoxIDRol.TabIndex = 5;
            // 
            // bttnModificarRol
            // 
            this.bttnModificarRol.Location = new System.Drawing.Point(97, 100);
            this.bttnModificarRol.Name = "bttnModificarRol";
            this.bttnModificarRol.Size = new System.Drawing.Size(75, 23);
            this.bttnModificarRol.TabIndex = 4;
            this.bttnModificarRol.Text = "Modificar";
            this.bttnModificarRol.UseVisualStyleBackColor = true;
            this.bttnModificarRol.Click += new System.EventHandler(this.bttnModificarRol_Click);
            // 
            // bttnEliminarRol
            // 
            this.bttnEliminarRol.Location = new System.Drawing.Point(178, 100);
            this.bttnEliminarRol.Name = "bttnEliminarRol";
            this.bttnEliminarRol.Size = new System.Drawing.Size(75, 23);
            this.bttnEliminarRol.TabIndex = 3;
            this.bttnEliminarRol.Text = "Eliminar";
            this.bttnEliminarRol.UseVisualStyleBackColor = true;
            this.bttnEliminarRol.Click += new System.EventHandler(this.bttnEliminarRol_Click);
            // 
            // bttnAltaRol
            // 
            this.bttnAltaRol.Location = new System.Drawing.Point(16, 100);
            this.bttnAltaRol.Name = "bttnAltaRol";
            this.bttnAltaRol.Size = new System.Drawing.Size(75, 23);
            this.bttnAltaRol.TabIndex = 2;
            this.bttnAltaRol.Text = "Alta";
            this.bttnAltaRol.UseVisualStyleBackColor = true;
            this.bttnAltaRol.Click += new System.EventHandler(this.bttnAltaRol_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Designación:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // groupBoxPermiso
            // 
            this.groupBoxPermiso.Controls.Add(this.buttonQuitarPermiso);
            this.groupBoxPermiso.Controls.Add(this.button2);
            this.groupBoxPermiso.Controls.Add(this.comboPermisos);
            this.groupBoxPermiso.Controls.Add(this.label3);
            this.groupBoxPermiso.Controls.Add(this.textBoxNombrePermiso);
            this.groupBoxPermiso.Controls.Add(this.lblNombrePermiso);
            this.groupBoxPermiso.Controls.Add(this.textBoxIdPermiso);
            this.groupBoxPermiso.Controls.Add(this.lblIDPermiso);
            this.groupBoxPermiso.Location = new System.Drawing.Point(647, 12);
            this.groupBoxPermiso.Name = "groupBoxPermiso";
            this.groupBoxPermiso.Size = new System.Drawing.Size(318, 145);
            this.groupBoxPermiso.TabIndex = 2;
            this.groupBoxPermiso.TabStop = false;
            this.groupBoxPermiso.Text = "Permiso:";
            // 
            // buttonQuitarPermiso
            // 
            this.buttonQuitarPermiso.Location = new System.Drawing.Point(170, 89);
            this.buttonQuitarPermiso.Name = "buttonQuitarPermiso";
            this.buttonQuitarPermiso.Size = new System.Drawing.Size(110, 36);
            this.buttonQuitarPermiso.TabIndex = 13;
            this.buttonQuitarPermiso.Text = "Quitar permiso";
            this.buttonQuitarPermiso.UseVisualStyleBackColor = true;
            this.buttonQuitarPermiso.Click += new System.EventHandler(this.buttonQuitarPermiso_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 36);
            this.button2.TabIndex = 12;
            this.button2.Text = "Asociar permiso";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonAsociarPermiso_Click);
            // 
            // comboPermisos
            // 
            this.comboPermisos.FormattingEnabled = true;
            this.comboPermisos.Location = new System.Drawing.Point(103, 57);
            this.comboPermisos.Name = "comboPermisos";
            this.comboPermisos.Size = new System.Drawing.Size(151, 21);
            this.comboPermisos.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Permiso:";
            // 
            // textBoxNombrePermiso
            // 
            this.textBoxNombrePermiso.Location = new System.Drawing.Point(143, 23);
            this.textBoxNombrePermiso.Name = "textBoxNombrePermiso";
            this.textBoxNombrePermiso.ReadOnly = true;
            this.textBoxNombrePermiso.Size = new System.Drawing.Size(169, 20);
            this.textBoxNombrePermiso.TabIndex = 3;
            // 
            // lblNombrePermiso
            // 
            this.lblNombrePermiso.AutoSize = true;
            this.lblNombrePermiso.Location = new System.Drawing.Point(90, 26);
            this.lblNombrePermiso.Name = "lblNombrePermiso";
            this.lblNombrePermiso.Size = new System.Drawing.Size(47, 13);
            this.lblNombrePermiso.TabIndex = 2;
            this.lblNombrePermiso.Text = "Nombre:";
            // 
            // textBoxIdPermiso
            // 
            this.textBoxIdPermiso.Location = new System.Drawing.Point(36, 23);
            this.textBoxIdPermiso.Name = "textBoxIdPermiso";
            this.textBoxIdPermiso.ReadOnly = true;
            this.textBoxIdPermiso.Size = new System.Drawing.Size(45, 20);
            this.textBoxIdPermiso.TabIndex = 1;
            // 
            // lblIDPermiso
            // 
            this.lblIDPermiso.AutoSize = true;
            this.lblIDPermiso.Location = new System.Drawing.Point(12, 26);
            this.lblIDPermiso.Name = "lblIDPermiso";
            this.lblIDPermiso.Size = new System.Drawing.Size(21, 13);
            this.lblIDPermiso.TabIndex = 0;
            this.lblIDPermiso.Text = "ID:";
            // 
            // groupBoxRolesyPermisos
            // 
            this.groupBoxRolesyPermisos.Controls.Add(this.groupBox2);
            this.groupBoxRolesyPermisos.Controls.Add(this.groupBoxRolesAUser);
            this.groupBoxRolesyPermisos.Location = new System.Drawing.Point(12, 197);
            this.groupBoxRolesyPermisos.Name = "groupBoxRolesyPermisos";
            this.groupBoxRolesyPermisos.Size = new System.Drawing.Size(412, 129);
            this.groupBoxRolesyPermisos.TabIndex = 3;
            this.groupBoxRolesyPermisos.TabStop = false;
            this.groupBoxRolesyPermisos.Text = "Roles/Permisos Usuario:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonQuitarPermisoUser);
            this.groupBox2.Controls.Add(this.buttonAsociarPermisoUser);
            this.groupBox2.Controls.Add(this.comboBoxPermisos);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Location = new System.Drawing.Point(179, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 95);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos a usuario";
            // 
            // buttonQuitarPermisoUser
            // 
            this.buttonQuitarPermisoUser.Location = new System.Drawing.Point(139, 49);
            this.buttonQuitarPermisoUser.Name = "buttonQuitarPermisoUser";
            this.buttonQuitarPermisoUser.Size = new System.Drawing.Size(71, 36);
            this.buttonQuitarPermisoUser.TabIndex = 7;
            this.buttonQuitarPermisoUser.Text = "Quitar permiso";
            this.buttonQuitarPermisoUser.UseVisualStyleBackColor = true;
            this.buttonQuitarPermisoUser.Click += new System.EventHandler(this.buttonQuitarPermisoUser_Click);
            // 
            // buttonAsociarPermisoUser
            // 
            this.buttonAsociarPermisoUser.Location = new System.Drawing.Point(59, 49);
            this.buttonAsociarPermisoUser.Name = "buttonAsociarPermisoUser";
            this.buttonAsociarPermisoUser.Size = new System.Drawing.Size(74, 36);
            this.buttonAsociarPermisoUser.TabIndex = 6;
            this.buttonAsociarPermisoUser.Text = "Asociar permiso";
            this.buttonAsociarPermisoUser.UseVisualStyleBackColor = true;
            this.buttonAsociarPermisoUser.Click += new System.EventHandler(this.buttonAsociarPermisoUser_Click);
            // 
            // comboBoxPermisos
            // 
            this.comboBoxPermisos.FormattingEnabled = true;
            this.comboBoxPermisos.Location = new System.Drawing.Point(59, 22);
            this.comboBoxPermisos.Name = "comboBoxPermisos";
            this.comboBoxPermisos.Size = new System.Drawing.Size(151, 21);
            this.comboBoxPermisos.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Permiso:";
            // 
            // groupBoxRolesAUser
            // 
            this.groupBoxRolesAUser.Controls.Add(this.buttonQuitarRolUser);
            this.groupBoxRolesAUser.Controls.Add(this.buttonAsociarRolUser);
            this.groupBoxRolesAUser.Controls.Add(this.comboBoxRolUsuario);
            this.groupBoxRolesAUser.Controls.Add(this.label17);
            this.groupBoxRolesAUser.Location = new System.Drawing.Point(6, 19);
            this.groupBoxRolesAUser.Name = "groupBoxRolesAUser";
            this.groupBoxRolesAUser.Size = new System.Drawing.Size(167, 95);
            this.groupBoxRolesAUser.TabIndex = 16;
            this.groupBoxRolesAUser.TabStop = false;
            this.groupBoxRolesAUser.Text = "Roles a usuario";
            // 
            // buttonQuitarRolUser
            // 
            this.buttonQuitarRolUser.Location = new System.Drawing.Point(91, 49);
            this.buttonQuitarRolUser.Name = "buttonQuitarRolUser";
            this.buttonQuitarRolUser.Size = new System.Drawing.Size(71, 36);
            this.buttonQuitarRolUser.TabIndex = 7;
            this.buttonQuitarRolUser.Text = "Quitar rol a usuario";
            this.buttonQuitarRolUser.UseVisualStyleBackColor = true;
            this.buttonQuitarRolUser.Click += new System.EventHandler(this.buttonQuitarRolUser_Click);
            // 
            // buttonAsociarRolUser
            // 
            this.buttonAsociarRolUser.Location = new System.Drawing.Point(6, 49);
            this.buttonAsociarRolUser.Name = "buttonAsociarRolUser";
            this.buttonAsociarRolUser.Size = new System.Drawing.Size(74, 36);
            this.buttonAsociarRolUser.TabIndex = 6;
            this.buttonAsociarRolUser.Text = "Asociar rol  a usuario";
            this.buttonAsociarRolUser.UseVisualStyleBackColor = true;
            this.buttonAsociarRolUser.Click += new System.EventHandler(this.buttonAsociarRolUser_Click);
            // 
            // comboBoxRolUsuario
            // 
            this.comboBoxRolUsuario.FormattingEnabled = true;
            this.comboBoxRolUsuario.Location = new System.Drawing.Point(41, 22);
            this.comboBoxRolUsuario.Name = "comboBoxRolUsuario";
            this.comboBoxRolUsuario.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRolUsuario.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Rol: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Usuarios:";
            // 
            // treeViewUsuarios
            // 
            this.treeViewUsuarios.Location = new System.Drawing.Point(12, 345);
            this.treeViewUsuarios.Name = "treeViewUsuarios";
            treeNode1.Name = "Usuarios";
            treeNode1.Text = "Usuarios";
            this.treeViewUsuarios.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewUsuarios.Size = new System.Drawing.Size(168, 357);
            this.treeViewUsuarios.TabIndex = 5;
            this.treeViewUsuarios.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewUsuarios_AfterSelect);
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.Location = new System.Drawing.Point(430, 345);
            this.treeViewRoles.Name = "treeViewRoles";
            treeNode2.Name = "Roles";
            treeNode2.Text = "Roles";
            this.treeViewRoles.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeViewRoles.Size = new System.Drawing.Size(121, 357);
            this.treeViewRoles.TabIndex = 7;
            this.treeViewRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRoles_AfterSelect);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Roles:";
            // 
            // treeViewPermisos
            // 
            this.treeViewPermisos.Location = new System.Drawing.Point(581, 345);
            this.treeViewPermisos.Name = "treeViewPermisos";
            treeNode3.Name = "Permisos";
            treeNode3.Text = "Permisos";
            this.treeViewPermisos.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeViewPermisos.Size = new System.Drawing.Size(203, 357);
            this.treeViewPermisos.TabIndex = 9;
            this.treeViewPermisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPermisos_AfterSelect);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(578, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Permisos:";
            // 
            // treeViewPermisosXRol
            // 
            this.treeViewPermisosXRol.Location = new System.Drawing.Point(815, 345);
            this.treeViewPermisosXRol.Name = "treeViewPermisosXRol";
            this.treeViewPermisosXRol.Size = new System.Drawing.Size(222, 357);
            this.treeViewPermisosXRol.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(812, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Permisos por Rol:";
            // 
            // treeViewRolesyPermisosDelUsuario
            // 
            this.treeViewRolesyPermisosDelUsuario.Location = new System.Drawing.Point(200, 345);
            this.treeViewRolesyPermisosDelUsuario.Name = "treeViewRolesyPermisosDelUsuario";
            this.treeViewRolesyPermisosDelUsuario.Size = new System.Drawing.Size(206, 357);
            this.treeViewRolesyPermisosDelUsuario.TabIndex = 13;
            this.treeViewRolesyPermisosDelUsuario.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRolesyPermisosDelUsuario_AfterSelect);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Roles y Permisos del Usuario:";
            // 
            // groupBoxRolParaAgregarRoles
            // 
            this.groupBoxRolParaAgregarRoles.Controls.Add(this.buttonDesasociarRolARol);
            this.groupBoxRolParaAgregarRoles.Controls.Add(this.buttonAsociarRolARol);
            this.groupBoxRolParaAgregarRoles.Controls.Add(this.comboBoxRoles);
            this.groupBoxRolParaAgregarRoles.Controls.Add(this.textBoxIDRolParaAsociarRol);
            this.groupBoxRolParaAgregarRoles.Controls.Add(this.textBoxNombreRolParaAsociarRol);
            this.groupBoxRolParaAgregarRoles.Controls.Add(this.label12);
            this.groupBoxRolParaAgregarRoles.Controls.Add(this.label11);
            this.groupBoxRolParaAgregarRoles.Controls.Add(this.label10);
            this.groupBoxRolParaAgregarRoles.Location = new System.Drawing.Point(430, 169);
            this.groupBoxRolParaAgregarRoles.Name = "groupBoxRolParaAgregarRoles";
            this.groupBoxRolParaAgregarRoles.Size = new System.Drawing.Size(264, 150);
            this.groupBoxRolParaAgregarRoles.TabIndex = 14;
            this.groupBoxRolParaAgregarRoles.TabStop = false;
            this.groupBoxRolParaAgregarRoles.Text = "Rol para Asociar/Desasociar a otro Rol";
            // 
            // buttonDesasociarRolARol
            // 
            this.buttonDesasociarRolARol.Location = new System.Drawing.Point(152, 101);
            this.buttonDesasociarRolARol.Name = "buttonDesasociarRolARol";
            this.buttonDesasociarRolARol.Size = new System.Drawing.Size(92, 36);
            this.buttonDesasociarRolARol.TabIndex = 7;
            this.buttonDesasociarRolARol.Text = "Desasociar rol a rol";
            this.buttonDesasociarRolARol.UseVisualStyleBackColor = true;
            this.buttonDesasociarRolARol.Click += new System.EventHandler(this.buttonDesasociarRolaRol_Click);
            // 
            // buttonAsociarRolARol
            // 
            this.buttonAsociarRolARol.Location = new System.Drawing.Point(15, 101);
            this.buttonAsociarRolARol.Name = "buttonAsociarRolARol";
            this.buttonAsociarRolARol.Size = new System.Drawing.Size(92, 36);
            this.buttonAsociarRolARol.TabIndex = 6;
            this.buttonAsociarRolARol.Text = "Asociar rol a rol";
            this.buttonAsociarRolARol.UseVisualStyleBackColor = true;
            this.buttonAsociarRolARol.Click += new System.EventHandler(this.buttonAsociarRolaRol_Click);
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(59, 66);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(186, 21);
            this.comboBoxRoles.TabIndex = 5;
            // 
            // textBoxIDRolParaAsociarRol
            // 
            this.textBoxIDRolParaAsociarRol.Location = new System.Drawing.Point(34, 25);
            this.textBoxIDRolParaAsociarRol.Name = "textBoxIDRolParaAsociarRol";
            this.textBoxIDRolParaAsociarRol.ReadOnly = true;
            this.textBoxIDRolParaAsociarRol.Size = new System.Drawing.Size(35, 20);
            this.textBoxIDRolParaAsociarRol.TabIndex = 4;
            // 
            // textBoxNombreRolParaAsociarRol
            // 
            this.textBoxNombreRolParaAsociarRol.Location = new System.Drawing.Point(145, 25);
            this.textBoxNombreRolParaAsociarRol.Name = "textBoxNombreRolParaAsociarRol";
            this.textBoxNombreRolParaAsociarRol.ReadOnly = true;
            this.textBoxNombreRolParaAsociarRol.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombreRolParaAsociarRol.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(82, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Rol Padre:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "ID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Rol hijo:";
            // 
            // buttonLimpiarCampos
            // 
            this.buttonLimpiarCampos.Location = new System.Drawing.Point(786, 180);
            this.buttonLimpiarCampos.Name = "buttonLimpiarCampos";
            this.buttonLimpiarCampos.Size = new System.Drawing.Size(75, 46);
            this.buttonLimpiarCampos.TabIndex = 2;
            this.buttonLimpiarCampos.Text = "Limpiar Campos";
            this.buttonLimpiarCampos.UseVisualStyleBackColor = true;
            this.buttonLimpiarCampos.Click += new System.EventHandler(this.buttonLimpiarCampos_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(786, 238);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 42);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.Text = "Salir";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // groupBoxAeronaves
            // 
            this.groupBoxAeronaves.Controls.Add(this.buttonCrearAeronave);
            this.groupBoxAeronaves.Controls.Add(this.textBoxSerie);
            this.groupBoxAeronaves.Controls.Add(this.textBoxMatricula);
            this.groupBoxAeronaves.Controls.Add(this.textBoxModelo);
            this.groupBoxAeronaves.Controls.Add(this.textBoxMarca);
            this.groupBoxAeronaves.Controls.Add(this.textBoxIdAeronave);
            this.groupBoxAeronaves.Controls.Add(this.label16);
            this.groupBoxAeronaves.Controls.Add(this.label15);
            this.groupBoxAeronaves.Controls.Add(this.label14);
            this.groupBoxAeronaves.Controls.Add(this.Marca);
            this.groupBoxAeronaves.Controls.Add(this.label13);
            this.groupBoxAeronaves.Location = new System.Drawing.Point(1014, 12);
            this.groupBoxAeronaves.Name = "groupBoxAeronaves";
            this.groupBoxAeronaves.Size = new System.Drawing.Size(254, 277);
            this.groupBoxAeronaves.TabIndex = 17;
            this.groupBoxAeronaves.TabStop = false;
            this.groupBoxAeronaves.Text = "Aeronaves";
            // 
            // buttonCrearAeronave
            // 
            this.buttonCrearAeronave.Location = new System.Drawing.Point(113, 199);
            this.buttonCrearAeronave.Name = "buttonCrearAeronave";
            this.buttonCrearAeronave.Size = new System.Drawing.Size(75, 45);
            this.buttonCrearAeronave.TabIndex = 10;
            this.buttonCrearAeronave.Text = "Crear Aeronave";
            this.buttonCrearAeronave.UseVisualStyleBackColor = true;
            this.buttonCrearAeronave.Click += new System.EventHandler(this.buttonCrearAeronave_Click);
            // 
            // textBoxSerie
            // 
            this.textBoxSerie.Location = new System.Drawing.Point(67, 150);
            this.textBoxSerie.Name = "textBoxSerie";
            this.textBoxSerie.Size = new System.Drawing.Size(158, 20);
            this.textBoxSerie.TabIndex = 9;
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Location = new System.Drawing.Point(67, 115);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(158, 20);
            this.textBoxMatricula.TabIndex = 8;
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(67, 86);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(158, 20);
            this.textBoxModelo.TabIndex = 7;
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(67, 57);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(158, 20);
            this.textBoxMarca.TabIndex = 6;
            // 
            // textBoxIdAeronave
            // 
            this.textBoxIdAeronave.Location = new System.Drawing.Point(67, 23);
            this.textBoxIdAeronave.Name = "textBoxIdAeronave";
            this.textBoxIdAeronave.ReadOnly = true;
            this.textBoxIdAeronave.Size = new System.Drawing.Size(34, 20);
            this.textBoxIdAeronave.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Serie";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Matricula";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Modelo";
            // 
            // Marca
            // 
            this.Marca.AutoSize = true;
            this.Marca.Location = new System.Drawing.Point(6, 60);
            this.Marca.Name = "Marca";
            this.Marca.Size = new System.Drawing.Size(37, 13);
            this.Marca.TabIndex = 1;
            this.Marca.Text = "Marca";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "ID";
            // 
            // dataGridViewAeronaves
            // 
            this.dataGridViewAeronaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAeronaves.Location = new System.Drawing.Point(1059, 345);
            this.dataGridViewAeronaves.Name = "dataGridViewAeronaves";
            this.dataGridViewAeronaves.Size = new System.Drawing.Size(209, 357);
            this.dataGridViewAeronaves.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1059, 326);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Aeronaves";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(889, 201);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(87, 58);
            this.btnBackup.TabIndex = 20;
            this.btnBackup.Text = "Copia de Seguridad";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // PanelAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dataGridViewAeronaves);
            this.Controls.Add(this.groupBoxAeronaves);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonLimpiarCampos);
            this.Controls.Add(this.groupBoxRolParaAgregarRoles);
            this.Controls.Add(this.treeViewRolesyPermisosDelUsuario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.treeViewPermisosXRol);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.treeViewPermisos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.treeViewRoles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.treeViewUsuarios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBoxRolesyPermisos);
            this.Controls.Add(this.groupBoxPermiso);
            this.Controls.Add(this.groupBoxRol);
            this.Controls.Add(this.groupBoxUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PanelAdministrador";
            this.Text = "Panel de administrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBoxUser.ResumeLayout(false);
            this.groupBoxUser.PerformLayout();
            this.groupBoxRol.ResumeLayout(false);
            this.groupBoxRol.PerformLayout();
            this.groupBoxPermiso.ResumeLayout(false);
            this.groupBoxPermiso.PerformLayout();
            this.groupBoxRolesyPermisos.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxRolesAUser.ResumeLayout(false);
            this.groupBoxRolesAUser.PerformLayout();
            this.groupBoxRolParaAgregarRoles.ResumeLayout(false);
            this.groupBoxRolParaAgregarRoles.PerformLayout();
            this.groupBoxAeronaves.ResumeLayout(false);
            this.groupBoxAeronaves.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAeronaves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.TextBox textBoxPww;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.CheckBox checkBoxMostrarContraseña;
        private System.Windows.Forms.CheckBox checkBoxBloqueado;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxIdUser;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.GroupBox groupBoxRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDesignacionRol;
        private System.Windows.Forms.TextBox textBoxIDRol;
        private System.Windows.Forms.Button bttnModificarRol;
        private System.Windows.Forms.Button bttnEliminarRol;
        private System.Windows.Forms.Button bttnAltaRol;
        private System.Windows.Forms.GroupBox groupBoxPermiso;
        private System.Windows.Forms.Label lblIDPermiso;
        private System.Windows.Forms.TextBox textBoxIdPermiso;
        private System.Windows.Forms.TextBox textBoxNombrePermiso;
        private System.Windows.Forms.Label lblNombrePermiso;
        private System.Windows.Forms.GroupBox groupBoxRolesyPermisos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView treeViewUsuarios;
        private System.Windows.Forms.TreeView treeViewRoles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeViewPermisos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView treeViewPermisosXRol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TreeView treeViewRolesyPermisosDelUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxRolParaAgregarRoles;
        private System.Windows.Forms.TextBox textBoxIDRolParaAsociarRol;
        private System.Windows.Forms.TextBox textBoxNombreRolParaAsociarRol;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonLimpiarCampos;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Button buttonDesasociarRolARol;
        private System.Windows.Forms.Button buttonAsociarRolARol;
        private System.Windows.Forms.GroupBox groupBoxAeronaves;
        private System.Windows.Forms.TextBox textBoxSerie;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.TextBox textBoxModelo;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.TextBox textBoxIdAeronave;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Marca;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonCrearAeronave;
        private System.Windows.Forms.Button buttonCrearUser;
        private System.Windows.Forms.GroupBox groupBoxRolesAUser;
        private System.Windows.Forms.Button buttonQuitarRolUser;
        private System.Windows.Forms.Button buttonAsociarRolUser;
        private System.Windows.Forms.ComboBox comboBoxRolUsuario;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonQuitarPermisoUser;
        private System.Windows.Forms.Button buttonAsociarPermisoUser;
        private System.Windows.Forms.ComboBox comboBoxPermisos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dataGridViewAeronaves;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonQuitarPermiso;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboPermisos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonModificarUsuario;
        private System.Windows.Forms.Button btnBackup;
    }
}