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
using appventas.MODEL;

namespace appventas.VISTA
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
            carga();
            clear();
        }

        void clear()
        {
            txtIdUser.Clear();
            txtEmail.Clear();
            txtPass.Clear();

        }
        void carga()
        {
            dgvUser.Rows.Clear();
            ClsUsuario usuario = new ClsUsuario();
            List<tb_usuario> list = usuario.cargarDatos();

            foreach (var iteracion in list)
            {
                dgvUser.Rows.Add(iteracion.iDUsuario, iteracion.email, iteracion.contrasena);
            }
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsUsuario usuario = new ClsUsuario();
            tb_usuario userList = new tb_usuario();
            userList.email = txtEmail.Text;
            userList.contrasena = txtPass.Text;

            usuario.guardarUser(userList);

            carga();
            clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsUsuario usuario = new ClsUsuario();
            usuario.eliminarUser(Convert.ToInt32(txtIdUser.Text));

            carga();
            clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsUsuario usuario = new ClsUsuario();
            tb_usuario userList = new tb_usuario();
            userList.email = txtEmail.Text;
            userList.contrasena = txtPass.Text;

            usuario.actualizarUser(userList);
        }
    }
}
