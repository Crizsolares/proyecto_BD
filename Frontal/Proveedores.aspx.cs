using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;



namespace NOMINA23.Frontal
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private Int16 idProve;
        private String nomProve;
        private String dirProve;
        private String rfcProve;
        private String telProve;
        private String tablaBusqueda = "";

        //Instanciamos el objeto conectarBD
        public SqlConnection cn = new SqlConnection("Data Source=DESKTOP-IG7NH44; Initial Catalog=tiendita_la_moderna; Trusted_Connection=True");
        private conectarid conectaBD = new conectarid();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtNomProve.Attributes.Add("onkeypress", "return soloLetras(event)");
            this.txtDirProve.Attributes.Add("onkeypress", "return soloLetras(event)");
            this.txtRFCProve.Attributes.Add("onkeypress", "return soloLetras(event)");
            this.txtTelProve.Attributes.Add("onkeypress", "return soloNumerosG(event)");

            if (!IsPostBack)
            {
                listaIDprove.DataSource = conectaBD.idProve();
                listaIDprove.DataValueField = "id_prov";
                listaIDprove.DataBind();
            }

        }

        private void LeeDatos()
        {
            idProve = Int16.Parse(listaIDprove.Text);
            nomProve = txtNomProve.Text;
            dirProve = txtDirProve.Text;
            rfcProve = txtRFCProve.Text;
            telProve = txtTelProve.Text;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            LeeDatos();
            conectaBD.SP_ManejaDatosProveedores(idProve, nomProve, dirProve, rfcProve, telProve, 1);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            LeeDatos();
            conectaBD.SP_ManejaDatosProveedores(idProve, nomProve, dirProve, rfcProve, telProve, 2);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ObtenDatos(Int16.Parse(listaIDprove.Text), 1);

            //Capturamos errores con Try y Catch
            try
            {
                //Agregamos consulta con SqlDataAdapter
                SqlDataAdapter da = new SqlDataAdapter("SELECT id_prov as 'ID', nom_prov as 'NOMBRE', dir_prov as 'DIRECCIÓN', rfc_prov as 'RFC', tel_prov as 'TELÉFONO' FROM Proveedores where id_prov = '" + listaIDprove.Text + " '", cn);
                //Contenedore de consultas almacenamos en datatable
                DataTable dt = new DataTable();
                //Llenamos la data a nuestro datatable
                da.Fill(dt);
                //Agregamos a nuestro Grid View con Data Source
                this.GVBuscarProve.DataSource = (dt);
                GVBuscarProve.DataBind();
            }
            catch(Exception ex)
            {
                throw ex;
            }
                

        }

        private void ObtenDatos(Int16 idProve, Int16 Opc)
        {
            //Dónde vamos a recibir los datos
            String datRecibidos = null;
            //Segmentamos por registro
            String segRegistro = "", segCadena = "";
            int longRegistro = 0, longCadena = 0, caso=0;

           
            datRecibidos = conectaBD.SP_RegresaDatosProveedores(idProve, Opc);
            

            longCadena = datRecibidos.Length;

            if (Opc == 2)
            {
                
            }

            while (longCadena > 1)
            {   
                //Segmentamos por registro con el carácter "$"
                //Cortamos el primer regristro
                segRegistro = datRecibidos.Substring(0, datRecibidos.IndexOf("$"));
                //Borramos el registro inicial
                datRecibidos = datRecibidos.Substring(datRecibidos.IndexOf("$")+1);

                //Cortamos el registro por atributos
                //Obtenemos la longitud del registro
                longRegistro = segRegistro.Length;

                if (Opc == 2)
                {
                   
                }

                //Cortamos por atributos
                while (longRegistro > 1)
                {
                    //Segmentamos por atribustos
                    segCadena = segRegistro.Substring(0, segRegistro.IndexOf("|"));
                    //Sortamos el primer atributo al registro
                    segRegistro = segRegistro.Substring(segRegistro.IndexOf("|") + 1);

                    //Parametrizamos
                    if (Opc == 1)
                    {
                        switch (caso)
                        {
                            case 0:
                                listaIDprove.Text = segCadena;
                                break;
                            case 1:
                                txtNomProve.Text = segCadena;
                                break;
                            case 2:
                                txtDirProve.Text = segCadena;
                                break;
                            case 3:
                                txtRFCProve.Text = segCadena;
                                break;
                            case 4:
                                txtTelProve.Text = segCadena;
                                break;
                        }
                        caso++;
                    }
                    else
                    {
                        if (Opc == 2)
                        {
                            
                        }
                    }
                    //Obtenemos longitud de la cadena cómo quedó despúes del corte
                    longRegistro = segRegistro.Length;
                }
                if (Opc == 2)
                {
                   
                }
                longCadena = datRecibidos.Length;
            }
            if (Opc == 2)
            {
                
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LeeDatos();
            conectaBD.SP_ManejaDatosProveedores(idProve, nomProve, dirProve, rfcProve, telProve, 3);
        }

        protected void btnListaProve_Click(object sender, EventArgs e)
        {
            //Agregamos consulta con SqlDataAdapter
            SqlDataAdapter da = new SqlDataAdapter("SELECT id_prov as 'ID', nom_prov as 'NOMBRE', dir_prov as 'DIRECCIÓN', rfc_prov as 'RFC', tel_prov as 'TELÉFONO' FROM Proveedores", cn);
            //Contenedore de consultas almacenamos en datatable
            DataTable dt = new DataTable();
            //Llenamos la data a nuestro datatable
            da.Fill(dt);
            //Agregamos a nuestro Grid View
            this.GVListaProve.DataSource = (dt);
            GVListaProve.DataBind();
        }


        protected void listaIDprove_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}