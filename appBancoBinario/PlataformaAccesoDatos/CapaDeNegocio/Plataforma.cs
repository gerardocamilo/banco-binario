using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Plataforma.CapaDeNegocio;
using Plataforma.CapaDeNegocio.Productos;
using Plataforma.CapaDeNegocio.Solicitudes;
using Plataforma.CapaDeDatos;
using System.Data;

namespace PlataformaAccesoDatos
{
    public class Plataforma
    {
        PlataformaDAO _plataformaDAO;

        public Plataforma() {
            this._plataformaDAO = new PlataformaDAO();
        }
        
        public void solicitarProducto(Solicitud solicitud) {
            this._plataformaDAO.pCrearSolicitud(solicitud);
        }

        public List<Producto> pObtenerProductosPorCliente(ClientesDetails cliente) {
            List<Producto> productos = this._plataformaDAO.pObtenerProductosPorIdentificacionCliente(cliente.identificacion);
            return productos;
        }

    }
}