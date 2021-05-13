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

namespace appventas.VISTA
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                var consultacliente = bd.tb_cliente.ToList();

                comBoxCliente.DataSource = consultacliente;
                comBoxCliente.DisplayMember = "nombreCliente";
                comBoxCliente.ValueMember = "iDCliente";

                var consultaDocumento = bd.tb_documento.ToList();

                comBoxTipDocument.DataSource = consultaDocumento;
                comBoxTipDocument.DisplayMember = "nombreDocumento";
                comBoxTipDocument.ValueMember = "iDDocumento";
            }
        }
    }
}
