using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using appBancoBinario.Plataforma.CapaDeNegocio;
using appBancoBinario.Plataforma.CapaDeNegocio.Productos;
using appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes;
using appBancoBinario.Plataforma.CapaDeDatos;
using System.Data;
using appBancoBinario.Clientes.CapaDeNegocio;

//Package that contains Debug class.
using System.Diagnostics;

namespace appBancoBinario.Plataforma.CapaDeNegocio
{
    public class Plataforma
    {
        PlataformaDAO _plataformaDAO;

        public Plataforma()
        {
            this._plataformaDAO = new PlataformaDAO();
        }

        public void solicitarProducto(Solicitud solicitud)
        {
            bool res = this._plataformaDAO.pCrearSolicitud(solicitud);

            if (res)
            {
                Debug.Write("Solicitud Creada! "); Debug.Write(solicitud.ProductoAsociado.TipoProducto);
            }
            else
            {
                Debug.WriteLine("Solicitud Fallida."); Debug.Write(solicitud.ProductoAsociado.TipoProducto);
            }
        }

        public List<Producto> pObtenerProductosPorCliente(ClientesDetails cliente)
        {
            return pObtenerProductosPorCliente(cliente.identificacion);
        }

        public List<Producto> pObtenerProductosPorCliente(String identificacionCliente)
        {
            List<Producto> productos = this._plataformaDAO.pObtenerProductosPorIdentificacionCliente(identificacionCliente);
            return productos;
        }

        public Producto pObtenerProductoPorCodigo(String codigo)
        {
            Producto prod = this._plataformaDAO.pObtenerProductoPorCodigo(codigo);
            return prod;
        }

        public bool actualizarPinTarjeta(Tarjeta tarjeta)
        {

            return actualizarPinTarjeta(tarjeta.NumeroTarjeta, tarjeta.PIN);
        }

        public bool actualizarPinTarjeta(String numeroTajeta, String PIN)
        {
            bool resultado = this._plataformaDAO.actualizarPinTarjeta(numeroTajeta, PIN);
            return resultado;
        }

        public bool pAprobarSolicitud(Solicitud solicitud) {
            pActualizarEstadoSolicitud(solicitud.NumeroSolicitud, solicitud.Estado);

            return true;
        }

        private bool pActualizarEstadoSolicitud(String numeroSolicitud, String estado)
        {
            bool resultado = false;
            resultado = this._plataformaDAO.pActualizarEstadoSolicitud(numeroSolicitud, estado);
            return resultado;
        }

        private bool pCrearProductoAprobado(Solicitud solicitud) {
            //this._plataformaDAO.crear
            return true;
        }

    }
}