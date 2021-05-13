using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appventas.MODEL;

namespace appventas.DAO
{
    class clsDocumento
    {
        public List<tb_documento> cargarList()

        {
            List<tb_documento> listDocument;

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                listDocument = bd.tb_documento.ToList();


            }

            return listDocument;
        }

        public void guardarDatos(tb_documento client)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {

                    tb_documento lista = new tb_documento();

                    lista.nombreDocumento = client.nombreDocumento;

                    bd.tb_documento.Add(lista);
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void eliminarDatos(int idClient)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int elim = Convert.ToInt32(idClient);
                    tb_documento list = bd.tb_documento.Where(d => d.iDDocumento == elim).Select(d => d).FirstOrDefault();


                    bd.tb_documento.Remove(list);
                    bd.SaveChanges();


                }
            }
            catch (Exception ex)
            {

            }
        }

        public void actualizarDatosr(tb_documento client)
        {
            try
            {


                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {

                    int actua = Convert.ToInt32(client.iDDocumento);
                    tb_documento lista = bd.tb_documento.Where(a => a.iDDocumento == actua).Select(a => a).FirstOrDefault();

                    lista.nombreDocumento = lista.nombreDocumento;

                    bd.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

    }
}