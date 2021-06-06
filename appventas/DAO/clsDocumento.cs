using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appventas.MODEL;
using System.Windows.Forms;

namespace appventas.DAO
{
    class ClsDocumento
    {
        public List<tb_documento> cargarComboDocument()
        {
            List<tb_documento> List;

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                List = bd.tb_documento.ToList();
            }

            return List;
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

                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

                    MessageBox.Show("Eliminado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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