using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appventas.MODEL;

namespace appventas.DAO
{
    class ClsProducto
    {
        public List<tb_producto> cargarProductosFiltro(String filtro)
        {
            List<tb_producto> List;

            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                List = (from listadoProductos in bd.tb_producto
                        where listadoProductos.nombreProducto.Contains(filtro)
                        select listadoProductos).ToList();
            }

            return List;
        }

        public List<tb_producto> BuscarProducto(int codigo)
        {
            List<tb_producto> tb_Productos = new List<tb_producto>();
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                tb_Productos = (from listadoProductos in bd.tb_producto
                                where listadoProductos.nombreProducto.Contains(Convert.ToString(codigo))
                                select listadoProductos).ToList();
            }

            return tb_Productos;
        }
    }
}