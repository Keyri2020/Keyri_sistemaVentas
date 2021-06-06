using appventas.DAO;
using appventas.VISTA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsAcceso acce = new ClsAcceso();

            int valor = acce.acceso(txtUser.Text, txtPass.Text);

            if (valor == 1)
            {
                frmVenta venta = new frmVenta();
                venta.Show();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
