using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appventas.MODEL;

namespace appventas.DAO
{
    class clsProducto
    {
        public List<tb_producto> cargarDatos()

        {
            List<tb_producto> list;

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                list = db.tb_producto.ToList();


            }

            return list;
        }

        public void guardarDatos(tb_producto prod)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {

                    tb_producto productList = new tb_producto();

                    productList.nombreProducto = prod.nombreProducto;
                    productList.precioProducto = prod.precioProducto;
                    productList.estadoProducto = prod.estadoProducto;

                    bd.tb_producto.Add(productList);
                    bd.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void eliminarDatos(int id)
        {
            try
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    int elim = Convert.ToInt32(id);
                    tb_producto produtList = bd.tb_producto.Where(p => p.idProducto == elim).Select(p => p).FirstOrDefault();


                    bd.tb_producto.Remove(produtList);
                    bd.SaveChanges();


                }
            }
            catch (Exception ex)
            {

            }
        }

        public void actualizarDato(tb_producto producto)
        {
            try
            {


                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {

                    int act = Convert.ToInt32(producto.idProducto);
                    tb_producto productList = bd.tb_producto.Where(a => a.idProducto == act).Select(a => a).FirstOrDefault();

                    productList.nombreProducto = producto.nombreProducto;
                    productList.precioProducto = producto.precioProducto;
                    productList.estadoProducto = producto.estadoProducto;
                    bd.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
