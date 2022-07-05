using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;


namespace Sistema_CB
{
    public partial class FormPrincipal : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form FormularioHijo;
        
        public FormPrincipal()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            PanelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconTitleBar.IconChar = currentBtn.IconChar;
                iconTitleBar.IconColor = color;
               
            }
        }
        private void DisableButton()
        {

            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void abrirFormularioHijo(Form formularioHijo)
        {
            if (FormularioHijo != null)
            {
                FormularioHijo.Close();
            }
            FormularioHijo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
            labelTitleBar.Text = formularioHijo.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBauche_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            abrirFormularioHijo(new Venta());
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            abrirFormularioHijo(new FormTransferencia());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FormularioHijo.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconTitleBar.IconChar = IconChar.Home;
            iconTitleBar.IconColor = Color.MediumPurple;
            labelTitleBar.Text = "Inicio";
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCompraVenta_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            abrirFormularioHijo(new CompraVenta());
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            abrirFormularioHijo(new Ajustes());
        }

        private void btnCausa_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            abrirFormularioHijo(new Causa());
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            abrirFormularioHijo(new Cuentas());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int lx, ly;
        int sw, sh;

        private void brtMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnCredito_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            abrirFormularioHijo(new Credito());
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if(PanelMenu.Width == 211)
            {
                PanelMenu.Width = 70;
                btnBauche.Text = "";
                btnAjustes.Text = "";
                btnCausa.Text = "";
                btnCompraVenta.Text = "";
                btnTransferencia.Text = "";
                btnCuentas.Text = "";
                BtnCredito.Text = "";
                btnInicio.Width = 70;
                btnInicio.Height = 70;
                this.Width = 1020;
            }
            else
            {
                PanelMenu.Width = 211;
                btnBauche.Text = "Venta";
                btnAjustes.Text = "Ajustes";
                btnCausa.Text = "Causa";
                btnCompraVenta.Text = "Compra / Venta";
                btnTransferencia.Text = "Transferencia";
                btnCuentas.Text = "Cuentas";
                BtnCredito.Text = "Credito";
                btnInicio.Width = 205;
                btnInicio.Height = 131;
                this.Width = 1172;
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }
    }
}
