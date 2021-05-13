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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
            carga();
            clear();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        void carga()
        {

            dgvCliente.Rows.Clear();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var car = db.tb_cliente.ToList();

                foreach (var iteracion in car)
                {
                    dgvCliente.Rows.Add(iteracion.iDCliente, iteracion.nombreCliente, iteracion.direccionCliente, iteracion.duiCliente);
                }
            }

        }

        void clear()
        {
            txtIdClient.Clear();
            txtClientName.Clear();
            txtDirrecion.Clear();
            txtDui.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsCliente clsclient = new clsCliente();

            tb_cliente clientList = new tb_cliente();
            clientList.nombreCliente = txtClientName.Text;
            clientList.direccionCliente = txtDirrecion.Text;
            clientList.duiCliente = txtDui.Text;


            clsclient.saveClient(clientList);

            
            clear();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsCliente deletecli = new clsCliente();
            deletecli.delecteClient(Convert.ToInt32(txtIdClient.Text));

            carga();
            clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clsCliente cliente = new clsCliente();

            tb_cliente clientList = new tb_cliente();
            clientList.iDCliente = Convert.ToInt32(txtIdClient.Text);
            clientList.nombreCliente = txtClientName.Text;
            clientList.direccionCliente = txtDirrecion.Text;
            clientList.duiCliente = txtDui.Text;
            clientList.updateClient(clientList);

            carga();
            clear();
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String idCliente = dgvCliente.CurrentRow.Cells[0].Value.ToString();
            String nombreCliente = dgvCliente.CurrentRow.Cells[1].Value.ToString();
            String DireccionCliente = dgvCliente.CurrentRow.Cells[2].Value.ToString();
            String DUI = dgvCliente.CurrentRow.Cells[3].Value.ToString();


            txtIdClient.Text = idCliente;
            txtClientName.Text = nombreCliente;
            txtDirrecion.Text = DireccionCliente;
            txtDui.Text = DUI;
        }
    }


}
