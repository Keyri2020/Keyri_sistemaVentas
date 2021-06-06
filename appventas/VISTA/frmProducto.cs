using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appventas.DAO;
using appventas.VISTA;

namespace appventas.VISTA
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
            carga();
        }

        void carga()
        {
            dgvProducto.Rows.Clear();
            var ClsProducto = new ClsProducto();

            foreach (var listarDatos in ClsProducto.cargarProductosFiltro(textBox1.Text))
            {
                dgvProducto.Rows.Add(listarDatos.idProducto, listarDatos.nombreProducto, listarDatos.precioProducto, listarDatos.estadoProducto);
            }

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
        
        }

        void envio()
        {
            String id = dgvProducto.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dgvProducto.CurrentRow.Cells[1].Value.ToString();
            String Precio = dgvProducto.CurrentRow.Cells[2].Value.ToString();

            //frmVenta frmVenta = new frmVenta();
            //frmVenta.txtId.Text = id;
            //frmVenta.txtNombre.Text = Nombre;
            //frmVenta.txtPrecio.Text = Precio;
            //frmVenta.Show();

            FrmMenú.venta.txtId.Text = id;
            FrmMenú.venta.txtNombre.Text = Nombre;
            FrmMenú.venta.txtPrecio.Text = Precio;
            FrmMenú.venta.txtCantidad.Focus();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            carga();
        }

        private void dgvProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                envio();
            }
        }

        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            envio();
        }
    }
}
