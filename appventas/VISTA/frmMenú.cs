using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas.VISTA
{
    public partial class FrmMenú : Form
    {
        public FrmMenú()
        {
            InitializeComponent();
        }

        private void tablaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public String estadoUser;

        private void frmMenú_Load(object sender, EventArgs e)
        {
            label1.Text = estadoUser;
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente cliente = new frmCliente();
            cliente.MdiParent = this;
            cliente.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void documentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocumento documento = new frmDocumento();
            documento.MdiParent = this;
            documento.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto producto = new frmProducto();
            producto.MdiParent = this;
            producto.Show();
        }

        public static frmVenta venta = new frmVenta();
        private void tablaDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            venta.Show();
        }

        public static frmUsuario usuario = new frmUsuario();
        private void agregarUnNuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario.Show();
        }
    }
}