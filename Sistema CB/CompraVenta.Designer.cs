
namespace Sistema_CB
{
    partial class CompraVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridVentas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Cstavendedor = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtBauche = new System.Windows.Forms.TextBox();
            this.btnAgregarVenta = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnVendedores = new System.Windows.Forms.Button();
            this.BtnBauche = new System.Windows.Forms.Button();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEntrega = new System.Windows.Forms.Button();
            this.txtMontoEntrega = new System.Windows.Forms.TextBox();
            this.cbEntrega = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_BancoRef = new System.Windows.Forms.TextBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnMostrarXcobrar = new System.Windows.Forms.Button();
            this.btnMostrarCompras = new System.Windows.Forms.Button();
            this.dataGridCompras = new System.Windows.Forms.DataGridView();
            this.btnAgregarCompra = new System.Windows.Forms.Button();
            this.checkPorCobrar = new System.Windows.Forms.CheckBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMontoCompra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRecibir = new System.Windows.Forms.Button();
            this.txtMontoxCobrar = new System.Windows.Forms.TextBox();
            this.cbClientexCobrar = new System.Windows.Forms.ComboBox();
            this.btnConsultaClie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompras)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridVentas
            // 
            this.dataGridVentas.AllowUserToAddRows = false;
            this.dataGridVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(70)))));
            this.dataGridVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridVentas.ColumnHeadersHeight = 27;
            this.dataGridVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridVentas.EnableHeadersVisualStyles = false;
            this.dataGridVentas.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridVentas.Location = new System.Drawing.Point(19, 162);
            this.dataGridVentas.Name = "dataGridVentas";
            this.dataGridVentas.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Calligraphy", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridVentas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridVentas.Size = new System.Drawing.Size(364, 252);
            this.dataGridVentas.TabIndex = 2;
            this.dataGridVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVentas_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Cstavendedor);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.txtBauche);
            this.groupBox1.Controls.Add(this.btnAgregarVenta);
            this.groupBox1.Controls.Add(this.btnVentas);
            this.groupBox1.Controls.Add(this.btnVendedores);
            this.groupBox1.Controls.Add(this.BtnBauche);
            this.groupBox1.Controls.Add(this.cbVendedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMonto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridVentas);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(488, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 479);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventas";
            // 
            // btn_Cstavendedor
            // 
            this.btn_Cstavendedor.ForeColor = System.Drawing.Color.Black;
            this.btn_Cstavendedor.Location = new System.Drawing.Point(316, 72);
            this.btn_Cstavendedor.Name = "btn_Cstavendedor";
            this.btn_Cstavendedor.Size = new System.Drawing.Size(83, 23);
            this.btn_Cstavendedor.TabIndex = 17;
            this.btn_Cstavendedor.Text = "Consultar ";
            this.btn_Cstavendedor.UseVisualStyleBackColor = true;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Lucida Calligraphy", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(19, 435);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(52, 28);
            this.txtCodigo.TabIndex = 16;
            // 
            // txtBauche
            // 
            this.txtBauche.Location = new System.Drawing.Point(157, 116);
            this.txtBauche.Name = "txtBauche";
            this.txtBauche.Size = new System.Drawing.Size(145, 25);
            this.txtBauche.TabIndex = 15;
            // 
            // btnAgregarVenta
            // 
            this.btnAgregarVenta.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarVenta.Location = new System.Drawing.Point(316, 109);
            this.btnAgregarVenta.Name = "btnAgregarVenta";
            this.btnAgregarVenta.Size = new System.Drawing.Size(83, 36);
            this.btnAgregarVenta.TabIndex = 14;
            this.btnAgregarVenta.Text = "Agregar";
            this.btnAgregarVenta.UseVisualStyleBackColor = true;
            this.btnAgregarVenta.Click += new System.EventHandler(this.btnAgregarVenta_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.ForeColor = System.Drawing.Color.Black;
            this.btnVentas.Location = new System.Drawing.Point(302, 430);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(81, 36);
            this.btnVentas.TabIndex = 13;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnVendedores
            // 
            this.btnVendedores.ForeColor = System.Drawing.Color.Black;
            this.btnVendedores.Location = new System.Drawing.Point(179, 430);
            this.btnVendedores.Name = "btnVendedores";
            this.btnVendedores.Size = new System.Drawing.Size(103, 36);
            this.btnVendedores.TabIndex = 12;
            this.btnVendedores.Text = "Vendedores";
            this.btnVendedores.UseVisualStyleBackColor = true;
            this.btnVendedores.Click += new System.EventHandler(this.btnVendedores_Click);
            // 
            // BtnBauche
            // 
            this.BtnBauche.ForeColor = System.Drawing.Color.Black;
            this.BtnBauche.Location = new System.Drawing.Point(78, 430);
            this.BtnBauche.Name = "BtnBauche";
            this.BtnBauche.Size = new System.Drawing.Size(81, 36);
            this.BtnBauche.TabIndex = 11;
            this.BtnBauche.Text = "Bauche";
            this.BtnBauche.UseVisualStyleBackColor = true;
            this.BtnBauche.Click += new System.EventHandler(this.BtnBauche_Click);
            // 
            // cbVendedor
            // 
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Location = new System.Drawing.Point(157, 73);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(145, 25);
            this.cbVendedor.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bauche:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vendedor:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(157, 32);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(145, 25);
            this.txtMonto.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Monto:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEntrega);
            this.groupBox2.Controls.Add(this.txtMontoEntrega);
            this.groupBox2.Controls.Add(this.cbEntrega);
            this.groupBox2.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(488, 485);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 54);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entregar";
            // 
            // btnEntrega
            // 
            this.btnEntrega.ForeColor = System.Drawing.Color.Black;
            this.btnEntrega.Location = new System.Drawing.Point(310, 18);
            this.btnEntrega.Name = "btnEntrega";
            this.btnEntrega.Size = new System.Drawing.Size(93, 30);
            this.btnEntrega.TabIndex = 14;
            this.btnEntrega.Text = "Entregar";
            this.btnEntrega.UseVisualStyleBackColor = true;
            this.btnEntrega.Click += new System.EventHandler(this.btnEntrega_Click);
            // 
            // txtMontoEntrega
            // 
            this.txtMontoEntrega.Location = new System.Drawing.Point(173, 23);
            this.txtMontoEntrega.Name = "txtMontoEntrega";
            this.txtMontoEntrega.Size = new System.Drawing.Size(131, 25);
            this.txtMontoEntrega.TabIndex = 11;
            // 
            // cbEntrega
            // 
            this.cbEntrega.FormattingEnabled = true;
            this.cbEntrega.Location = new System.Drawing.Point(6, 23);
            this.cbEntrega.Name = "cbEntrega";
            this.cbEntrega.Size = new System.Drawing.Size(145, 25);
            this.cbEntrega.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.groupBox3.Controls.Add(this.btnConsultaClie);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txt_BancoRef);
            this.groupBox3.Controls.Add(this.btnCliente);
            this.groupBox3.Controls.Add(this.btnMostrarXcobrar);
            this.groupBox3.Controls.Add(this.btnMostrarCompras);
            this.groupBox3.Controls.Add(this.dataGridCompras);
            this.groupBox3.Controls.Add(this.btnAgregarCompra);
            this.groupBox3.Controls.Add(this.checkPorCobrar);
            this.groupBox3.Controls.Add(this.cbCliente);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtMontoCompra);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(13, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 479);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Compra";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Banco/Ref:";
            // 
            // txt_BancoRef
            // 
            this.txt_BancoRef.Location = new System.Drawing.Point(106, 108);
            this.txt_BancoRef.Name = "txt_BancoRef";
            this.txt_BancoRef.Size = new System.Drawing.Size(150, 25);
            this.txt_BancoRef.TabIndex = 13;
            // 
            // btnCliente
            // 
            this.btnCliente.ForeColor = System.Drawing.Color.Black;
            this.btnCliente.Location = new System.Drawing.Point(310, 16);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(103, 48);
            this.btnCliente.TabIndex = 12;
            this.btnCliente.Text = "Agregar Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnMostrarXcobrar
            // 
            this.btnMostrarXcobrar.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarXcobrar.Location = new System.Drawing.Point(152, 424);
            this.btnMostrarXcobrar.Name = "btnMostrarXcobrar";
            this.btnMostrarXcobrar.Size = new System.Drawing.Size(103, 35);
            this.btnMostrarXcobrar.TabIndex = 11;
            this.btnMostrarXcobrar.Text = "Por Cobrar";
            this.btnMostrarXcobrar.UseVisualStyleBackColor = true;
            this.btnMostrarXcobrar.Click += new System.EventHandler(this.btnMostrarXcobrar_Click);
            // 
            // btnMostrarCompras
            // 
            this.btnMostrarCompras.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarCompras.Location = new System.Drawing.Point(19, 425);
            this.btnMostrarCompras.Name = "btnMostrarCompras";
            this.btnMostrarCompras.Size = new System.Drawing.Size(86, 35);
            this.btnMostrarCompras.TabIndex = 10;
            this.btnMostrarCompras.Text = "Compras";
            this.btnMostrarCompras.UseVisualStyleBackColor = true;
            this.btnMostrarCompras.Click += new System.EventHandler(this.btnMostrarCompras_Click);
            // 
            // dataGridCompras
            // 
            this.dataGridCompras.AllowUserToAddRows = false;
            this.dataGridCompras.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(70)))));
            this.dataGridCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridCompras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridCompras.ColumnHeadersHeight = 27;
            this.dataGridCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridCompras.EnableHeadersVisualStyles = false;
            this.dataGridCompras.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridCompras.Location = new System.Drawing.Point(19, 207);
            this.dataGridCompras.Name = "dataGridCompras";
            this.dataGridCompras.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Calligraphy", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridCompras.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCompras.Size = new System.Drawing.Size(373, 205);
            this.dataGridCompras.TabIndex = 9;
            // 
            // btnAgregarCompra
            // 
            this.btnAgregarCompra.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarCompra.Location = new System.Drawing.Point(251, 154);
            this.btnAgregarCompra.Name = "btnAgregarCompra";
            this.btnAgregarCompra.Size = new System.Drawing.Size(86, 35);
            this.btnAgregarCompra.TabIndex = 6;
            this.btnAgregarCompra.Text = "Agregar";
            this.btnAgregarCompra.UseVisualStyleBackColor = true;
            this.btnAgregarCompra.Click += new System.EventHandler(this.btnAgregarCompra_Click);
            // 
            // checkPorCobrar
            // 
            this.checkPorCobrar.AutoSize = true;
            this.checkPorCobrar.Location = new System.Drawing.Point(47, 162);
            this.checkPorCobrar.Name = "checkPorCobrar";
            this.checkPorCobrar.Size = new System.Drawing.Size(146, 21);
            this.checkPorCobrar.TabIndex = 5;
            this.checkPorCobrar.Text = "Pend. por Cobrar";
            this.checkPorCobrar.UseVisualStyleBackColor = true;
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(106, 70);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(148, 25);
            this.cbCliente.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cliente:";
            // 
            // txtMontoCompra
            // 
            this.txtMontoCompra.Location = new System.Drawing.Point(106, 29);
            this.txtMontoCompra.Name = "txtMontoCompra";
            this.txtMontoCompra.Size = new System.Drawing.Size(150, 25);
            this.txtMontoCompra.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Monto:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRecibir);
            this.groupBox4.Controls.Add(this.txtMontoxCobrar);
            this.groupBox4.Controls.Add(this.cbClientexCobrar);
            this.groupBox4.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(13, 485);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(419, 54);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Recibir";
            // 
            // btnRecibir
            // 
            this.btnRecibir.ForeColor = System.Drawing.Color.Black;
            this.btnRecibir.Location = new System.Drawing.Point(310, 18);
            this.btnRecibir.Name = "btnRecibir";
            this.btnRecibir.Size = new System.Drawing.Size(93, 30);
            this.btnRecibir.TabIndex = 14;
            this.btnRecibir.Text = "Recibir";
            this.btnRecibir.UseVisualStyleBackColor = true;
            this.btnRecibir.Click += new System.EventHandler(this.btnRecibir_Click);
            // 
            // txtMontoxCobrar
            // 
            this.txtMontoxCobrar.Location = new System.Drawing.Point(173, 23);
            this.txtMontoxCobrar.Name = "txtMontoxCobrar";
            this.txtMontoxCobrar.Size = new System.Drawing.Size(131, 25);
            this.txtMontoxCobrar.TabIndex = 11;
            // 
            // cbClientexCobrar
            // 
            this.cbClientexCobrar.FormattingEnabled = true;
            this.cbClientexCobrar.Location = new System.Drawing.Point(6, 23);
            this.cbClientexCobrar.Name = "cbClientexCobrar";
            this.cbClientexCobrar.Size = new System.Drawing.Size(145, 25);
            this.cbClientexCobrar.TabIndex = 10;
            // 
            // btnConsultaClie
            // 
            this.btnConsultaClie.ForeColor = System.Drawing.Color.Black;
            this.btnConsultaClie.Location = new System.Drawing.Point(260, 70);
            this.btnConsultaClie.Name = "btnConsultaClie";
            this.btnConsultaClie.Size = new System.Drawing.Size(86, 25);
            this.btnConsultaClie.TabIndex = 15;
            this.btnConsultaClie.Text = "Consultar";
            this.btnConsultaClie.UseVisualStyleBackColor = true;
            this.btnConsultaClie.Click += new System.EventHandler(this.btnConsultaClie_Click);
            // 
            // CompraVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(933, 503);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CompraVenta";
            this.Text = "CompraVenta";
            this.Load += new System.EventHandler(this.CompraVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVentas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompras)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridVentas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBauche;
        private System.Windows.Forms.Button btnAgregarVenta;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnVendedores;
        private System.Windows.Forms.TextBox txtBauche;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEntrega;
        private System.Windows.Forms.TextBox txtMontoEntrega;
        private System.Windows.Forms.ComboBox cbEntrega;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkPorCobrar;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMontoCompra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarCompra;
        private System.Windows.Forms.DataGridView dataGridCompras;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRecibir;
        private System.Windows.Forms.TextBox txtMontoxCobrar;
        private System.Windows.Forms.ComboBox cbClientexCobrar;
        private System.Windows.Forms.Button btnMostrarXcobrar;
        private System.Windows.Forms.Button btnMostrarCompras;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_BancoRef;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btn_Cstavendedor;
        private System.Windows.Forms.Button btnConsultaClie;
    }
}