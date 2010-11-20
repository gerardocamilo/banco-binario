﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using appBancoBinario.Plataforma.CapaDeNegocio.Productos;
using appBancoBinario.Clientes.CapaDeNegocio.Clases;

namespace appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes
{
    public abstract class Solicitud
    {
        private Producto _productoAsociado;
        private ClientesDetails _cliente;
        private String _sNumeroSolicitud;
        private String _sNumeroSolicitudAsociado;
        private String _sEstado;

        public Producto ProductoAsociado
        {
            get { return _productoAsociado; }
            set { _productoAsociado = value; }
        }

        public ClientesDetails Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public String NumeroSolicitud
        {
            get { return _sNumeroSolicitud; }
            set { _sNumeroSolicitud = value; }
        }

        public String NumeroSolicitudAsociado
        {
            get { return _sNumeroSolicitudAsociado; }
            set { _sNumeroSolicitudAsociado = value; }
        }

        public String Estado
        {
            get { return _sEstado; }
            set { _sEstado = value; }
        }
    }
}