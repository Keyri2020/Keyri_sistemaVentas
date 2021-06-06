using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appventas.MODEL;

namespace appventas.DAO
{
    class ClsUsuario
    {
        public List<tb_usuario> cargarDatos()
        {
            List<tb_usuario> List;

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                List = bd.tb_usuario.ToList();
            }

            return List;
        }

        public void guardarUser(tb_usuario usuario)
        {
            try
            {

                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {

                    tb_usuario userList = new tb_usuario();

                    userList.iDUsuario = usuario.iDUsuario;
                    userList.email = usuario.email;
                    userList.contrasena = usuario.contrasena;
                    
                    bd.tb_usuario.Add(userList);
                    bd.SaveChanges();

                    MessageBox.Show("Guardado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void eliminarUser(int id)
        {
            try
            {

                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int elim = Convert.ToInt32(id);
                    tb_usuario userList = bd.tb_usuario.Where(d => d.iDUsuario == elim).Select(d => d).FirstOrDefault();

                    bd.tb_usuario.Remove(userList);
                    bd.SaveChanges();

                    MessageBox.Show("Eliminado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void actualizarUser(tb_usuario usuario)
        {
            try
            {

                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int act = Convert.ToInt32(usuario.iDUsuario);
                    tb_usuario userList = bd.tb_usuario.Where(a => a.iDUsuario == act).Select(a => a).FirstOrDefault();

                    userList.iDUsuario = usuario.iDUsuario;
                    userList.email = usuario.email;
                    userList.contrasena = usuario.contrasena;

                    bd.SaveChanges();

                    MessageBox.Show("Actualizado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

    }

}
