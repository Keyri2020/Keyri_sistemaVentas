using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appventas.MODEL;
using System.Windows.Forms;

namespace appventas.DAO
{
    class ClsCliente
    {
        public List<tb_cliente> cargarComboCliente()
        {
            List<tb_cliente> List;

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                List = bd.tb_cliente.ToList();
            }

            return List;
        }

        public void saveClient(tb_cliente client)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {

                    tb_cliente clientList = new tb_cliente();

                    clientList.nombreCliente = client.nombreCliente;
                    clientList.direccionCliente = client.direccionCliente;
                    clientList.duiCliente = client.duiCliente;

                    bd.tb_cliente.Add(clientList);
                    bd.SaveChanges();

                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void eliminarClient(tb_cliente client)
        {
            

        }

        internal void eliminarClient(int Id)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int elim = Convert.ToInt32(Id);
                    tb_cliente clientList = bd.tb_cliente.Where(d => d.iDCliente == elim).Select(d => d).FirstOrDefault();

                    bd.tb_cliente.Remove(clientList);
                    bd.SaveChanges();

                    MessageBox.Show("Eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void updateClient(tb_cliente client)
        {
            try
            {

                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {

                    int act = Convert.ToInt32(client.iDCliente);
                    tb_cliente clientList = bd.tb_cliente.Where(a => a.iDCliente == act).Select(d => d).FirstOrDefault();


                    clientList.nombreCliente = client.nombreCliente;
                    clientList.direccionCliente = client.direccionCliente;
                    clientList.duiCliente = client.duiCliente;
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