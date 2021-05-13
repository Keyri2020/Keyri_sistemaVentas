using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appventas.MODEL;

namespace appventas.DAO
{
    class clsCliente
    {
        public List<tb_cliente> datosenList()
        {
            List<tb_cliente> clientList;
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                clientList = bd.tb_cliente.ToList();
            }

            return clientList;
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

                }
            }
            catch (Exception exce)
            {

            }
        }

        public void delecteClient(tb_cliente client)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {

                    int elim = Convert.ToInt32(client.iDCliente);
                    tb_cliente clientList = bd.tb_cliente.Where(d => d.iDCliente == elim).Select(d => d).FirstOrDefault();

                    bd.tb_cliente.Remove(clientList);
                    bd.SaveChanges();

                }
            }
            catch (Exception exce)
            {

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
                }

            }
            catch (Exception ex)
            {

            }
        }    
    }
}