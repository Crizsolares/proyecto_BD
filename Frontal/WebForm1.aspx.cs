using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace NOMINA23
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private conectarid cbd = new conectarid();
        private String nombre;
        private String apa;
        private String ama;
        private String contacto;
        private Int16 idvendedor;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtnombre.Attributes.Add("onkeypress", "return soloLetras(event)");
            this.txtapa.Attributes.Add("onkeypress", "return soloLetras(event)");
            this.txtama.Attributes.Add("onkeypress", "return soloLetras(event)");
            this.txtcontacto.Attributes.Add("onkeypress", "return soloNumerosG(event)");

            GridView1.DataSource = cbd.TABLAVENDEDOR();
            GridView1.DataBind();

            if (!IsPostBack)
            {
                listavendedor.DataSource = cbd.IDVENDEDOR();
                listavendedor.DataValueField = "id_vendedor";
                listavendedor.DataBind();
            }
        }
        private void LeeDatos()
        {
            nombre = txtnombre.Text;
            apa = txtapa.Text;
            ama = txtama.Text;
            contacto = txtcontacto.Text;
        }
        protected void btnagrega_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                btnguardarcambios.Visible = false;
                LeeDatos();
                cbd.AgregarVendedor(nombre, apa, ama, contacto);
                Response.Redirect("WebForm1.aspx");
            }
        }
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            btnguardarcambios.Visible = true;
        }
        protected void btneliminar_Click(object sender, EventArgs e)
        {

            btnguardarcambios.Visible = false;
            idvendedor = Int16.Parse(listavendedor.SelectedItem.Value.ToString());
            cbd.EliminarVendedor(idvendedor);
            Response.Redirect("WebForm1.aspx");
        }
        protected void btnbuscar_Click(object sender, EventArgs e)
        {

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            listavendedor.Text = GridView1.SelectedRow.Cells[1].Text;
            txtnombre.Text = GridView1.SelectedRow.Cells[2].Text;
            txtapa.Text = GridView1.SelectedRow.Cells[3].Text;
            txtama.Text = GridView1.SelectedRow.Cells[4].Text;
            txtcontacto.Text = GridView1.SelectedRow.Cells[5].Text;
        }
        protected void btnguardarcambios_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                LeeDatos();
                idvendedor = Convert.ToInt16(listavendedor.SelectedValue.ToString());
                cbd.ModificarVendedor(idvendedor, nombre, apa, ama, contacto);
                Response.Redirect("WebForm1.aspx");
            }
        }
        protected void btnbuscar_Click1(object sender, EventArgs e)
        {
            btnguardarcambios.Visible = false;
            
        }

        protected void listavendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}