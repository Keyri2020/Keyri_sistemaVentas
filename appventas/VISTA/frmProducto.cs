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

namespace appventas.VISTA
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
            Carga();
            clear();
        }

        void clear()
        {
            txtIdProducto.Clear();
            txtProductName.Clear();
            txtPrecio.Clear();
            txtEstadoProduct.Clear();

        }
        void Carga()
        {

            dgvProducto.Rows.Clear();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var product = db.tb_producto.ToList();

                foreach (var iteracion in product)
                {
                    dgvProducto.Rows.Add(iteracion.idProducto, iteracion.nombreProducto, iteracion.precioProducto, iteracion.estadoProducto);
                }
            }

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsProducto producto = new clsProducto();
            tb_producto lista = new tb_producto();
            lista.nombreProducto = txtProductName.Text;
            lista.precioProducto = txtPrecio.Text;
            lista.estadoProducto = txtEstadoProduct.Text;

            producto.guardarDatos(lista);

            Carga();
            clear();
        }
    }
}
