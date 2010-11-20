using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using appBancoBinario.Plataforma.CapaDeNegocio;
using appBancoBinario.Plataforma.CapaDeNegocio.Productos;
using appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes;
using appBancoBinario.Plataforma.CapaDeDatos;
using System.Data;
using appBancoBinario.Clientes.CapaDeNegocio.Clases;

//Package that contains Debug class.
using System.Diagnostics;

namespace appBancoBinario.Plataforma.CapaDeNegocio
{
    public class Plataforma
    {
        PlataformaDAO _plataformaDAO;

        public Plataforma() {
            this._plataformaDAO = new PlataformaDAO();
        }
        
        public void solicitarProducto(Solicitud solicitud) {
            bool res = this._plataformaDAO.pCrearSolicitud(solicitud);

            if (res)
            {
                Debug.WriteLine("Solicitud Creada!");
            }
            else { Debug.WriteLine("Solicitud Fallida."); }
        }

        public List<Producto> pObtenerProductosPorCliente(ClientesDetails cliente) {
            List<Producto> productos = this._plataformaDAO.pObtenerProductosPorIdentificacionCliente(cliente.identificacion);
            return productos;
        }

    }
}