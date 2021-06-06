using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appventas.MODEL;
using appventas.DAO;

namespace appventas.VISTA
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
            calcular();
        }

        void calcular()
        {

        }

        void ultimocorrelativodeventa()
        {
            var consultaultimaventa = new ClsDVenta();
            int lista = 0;

            foreach (var list in consultaultimaventa.UltimaVenta())
            {
                lista = list.iDVenta;
            }

            lista++;
            txtNumeroVenta.Text = lista.ToString();
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            ultimocorrelativodeventa();

            ClsCliente cliente = new ClsCliente();
                      
                comBoxCliente.DataSource = cliente.cargarComboCliente();
                comBoxCliente.DisplayMember = "nombreCliente";
                comBoxCliente.ValueMember = "iDCliente";

            ClsDocumento documento = new ClsDocumento();

                comBoxTipDocument.DataSource = documento.cargarComboDocument();
                comBoxTipDocument.DisplayMember = "nombreDocumento";
                comBoxTipDocument.ValueMember = "iDDocumento";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmProducto buscar = new frmProducto();
            buscar.Show();
            //btnAgregar.PerformClick();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double precio, cantidad, total;

                cantidad = Convert.ToDouble(txtCantidad.Text);
                precio = Convert.ToDouble(txtPrecio.Text);

                total = precio * cantidad;

                txtTotal.Text = total.ToString();
            }
            catch (Exception /*ex*/)
            {
                if (txtCantidad.Text.Equals(""))
                {
                    txtCantidad.Text = "1";
                    txtCantidad.SelectAll();
                }
            }
            
        }
        void calculartotal()
        {
            Double suma = 0;
            for (int i = 0; i < dgvVenta.Rows.Count; i++)
            {
                //    String Precio = dgvVenta.CurrentRow.Cells[2].Value.ToString();
                String datosaoperartotal = dgvVenta.Rows[i].Cells[4].Value.ToString();

                Double DatosConvertidos = Convert.ToDouble(datosaoperartotal);

                //suma = suma + DatosConvertidos;
                suma += DatosConvertidos;
                txtTotalFinal.Text = suma.ToString();
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            calcular();
            dgvVenta.Rows.Add(txtId.Text, txtNombre.Text, txtPrecio.Text, txtCantidad.Text, txtTotal.Text);
            calculartotal();
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtTotal.Text = "";

            dgvVenta.Refresh();
            dgvVenta.ClearSelection();
            int ultimafila = dgvVenta.Rows.Count -1;
            dgvVenta.FirstDisplayedScrollingRowIndex = ultimafila;
            dgvVenta.Rows[ultimafila].Selected = true;
        }

        private void txtBuscarP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)

            if (txtBuscarP.Text.Equals(""))
            {
                e.Handled = true;
                    btnBuscar.PerformClick();
                
            }
            else
            {
                    e.Handled = true;
                    ClsProducto prod = new ClsProducto();
                    var busqueda = prod.BuscarProducto(Convert.ToInt32(txtBuscarP.Text));

                    if (busqueda.Count < 1)
                    {
                        MessageBox.Show("El codigo no existe");
                        txtBuscarP.Text = "";
                    }

                   foreach (var iterar in busqueda)
                   {
                      txtId.Text = iterar.idProducto.ToString();
                      txtNombre.Text = iterar.nombreProducto.ToString();
                      txtPrecio.Text = iterar.precioProducto.ToString();
                      txtCantidad.Text = "1";
                      txtCantidad.Focus();
                      txtBuscarP.Text = "";
                   }
               
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnAgregar.PerformClick();
                txtBuscarP.Focus();
            }
        }

        private void txtBuscarP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                ClsDVenta ventas = new ClsDVenta();
                tb_venta venta = new tb_venta();

                venta.iDDocumento = Convert.ToInt32(comBoxTipDocument.SelectedValue.ToString());
                venta.iDCliente = Convert.ToInt32(comBoxCliente.SelectedValue.ToString());
                venta.iDUsuario = 1;
                venta.totalVenta = Convert.ToDecimal(txtTotal.Text);
                venta.fecha = Convert.ToDateTime(dtpFecha.Text);
                ventas.save(venta);

                ClsDDetalle detalle = new ClsDDetalle();
                tb_detalleVenta tbdetalle = new tb_detalleVenta();
                foreach (DataGridViewRow dtgv in dgvVenta.Rows)
                {
                    tbdetalle.iDVenta = Convert.ToInt32(txtNumeroVenta.Text);
                    tbdetalle.iDProducto = Convert.ToInt32(dtgv.Cells[0].Value.ToString());
                    tbdetalle.cantidad = Convert.ToInt32(dtgv.Cells[3].Value.ToString());
                    tbdetalle.precio = Convert.ToDecimal(dtgv.Cells[2].Value.ToString());
                    tbdetalle.total = Convert.ToDecimal(dtgv.Cells[4].Value.ToString());

                    detalle.guardardetalleventa(tbdetalle);
                    
                }
                ultimocorrelativodeventa();
                dgvVenta.Rows.Clear();
                txtTotalFinal.Text = "";

                MessageBox.Show("Guardado");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }

        private void dgvVenta_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculartotal();
            //MessageBox.Show("Eliminando");
        }
    }
}