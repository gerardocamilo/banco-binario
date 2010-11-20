using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Plataforma.CapaDeNegocio;
using Plataforma.CapaDeDatos;
using Plataforma.CapaDeNegocio.Productos;

namespace Plataforma.CapaDePrueba
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Cuenta cCuentaPrueba = new Cuenta();
            //cCuentaPrueba.NumeroCuenta = "CH00008";
            //cCuentaPrueba.TipoProducto = "CUENTA_AHORRO";
            //cCuentaPrueba.Estado = "ACTIVO";
            //cCuentaPrueba.Balance = 100;

            PlataformaDAO pPlataformaHelper = new PlataformaDAO();

            //bool res = pPlataformaHelper.pCrearCuenta(cCuentaPrueba);

            //if (res == true)
            //{
            //    lblTest.Text = "Cuenta Creada Exitosamente";
            //}
            //else {
            //    lblTest.Text = "Error en la transacción";
            //}
            List<Producto> p = pPlataformaHelper.pObtenerProductosPorIdentificacionCliente("22300620253");
            
            String a = "texto para break";
          
            foreach(Producto prod in p){
                if (prod!=null){

                    if (prod is Cuenta)
                    {
                        Cuenta c = (Cuenta)prod;
                        lblTest2.Text += c.ToString();
                    }
                }
            }
        }
    }
}