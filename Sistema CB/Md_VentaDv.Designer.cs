namespace Sistema_CB
{
    partial class Md_VentaDv
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
            this.txtBauche = new System.Windows.Forms.TextBox();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontoDv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtMontoBs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBauche
            // 
            this.txtBauche.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBauche.Location = new System.Drawing.Point(104, 27);
            this.txtBauche.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBauche.Name = "txtBauche";
            this.txtBauche.Size = new System.Drawing.Size(170, 24);
            this.txtBauche.TabIndex = 21;
            // 
            // cbVendedor
            // 
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Location = new System.Drawing.Point(105, 177);
            this.cbVendedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(170, 24);
            this.cbVendedor.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Bauche:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Vendedor:";
            // 
            // txtMontoDv
            // 
            this.txtMontoDv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoDv.Location = new System.Drawing.Point(105, 127);
            this.txtMontoDv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMontoDv.Name = "txtMontoDv";
            this.txtMontoDv.Size = new System.Drawing.Size(170, 24);
            this.txtMontoDv.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Monto Dv:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(94, 236);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(104, 36);
            this.btnAgregar.TabIndex = 22;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtMontoBs
            // 
            this.txtMontoBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoBs.Location = new System.Drawing.Point(104, 77);
            this.txtMontoBs.Margin = new System.Windows.Forms.Padding(4);
            this.txtMontoBs.Name = "txtMontoBs";
            this.txtMontoBs.Size = new System.Drawing.Size(170, 24);
            this.txtMontoBs.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Monto Bs:";
            // 
            // Md_VentaDv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(299, 299);
            this.Controls.Add(this.txtMontoBs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtBauche);
            this.Controls.Add(this.cbVendedor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMontoDv);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Md_VentaDv";
            this.Text = "Md_VentaDv";
            this.Load += new System.EventHandler(this.Md_VentaDv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBauche;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMontoDv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtMontoBs;
        private System.Windows.Forms.Label label3;
    }
}