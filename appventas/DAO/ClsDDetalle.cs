using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appventas.DAO
{
    class ClsDDetalle
    {
        public void guardardetalleventa(tb_detalleVenta detalle)
        {
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                tb_detalleVenta detalleVenta = new tb_detalleVenta();
                detalleVenta.iDVenta = detalle.iDVenta;
                detalleVenta.iDProducto = detalle.iDProducto;
                detalleVenta.cantidad = detalle.cantidad;
                detalleVenta.precio = detalle.precio;
                detalleVenta.total = detalle.total;
                bd.tb_detalleVenta.Add(detalleVenta);
                bd.SaveChanges();

            }
        }
    }
}