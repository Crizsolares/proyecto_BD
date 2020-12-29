using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

/*rama cristian */
namespace NOMINA23
{
    public class conectarid
    {

        private SqlConnection con;
        private SqlCommand comQry;
        private SqlDataReader lec;
        /*cadena de coneccion al menos 3 datos:
         servidor, base de datos, usuario y contraseña(solo para servidor remoto) */
        private String cadConexion = "Data Source=DESKTOP-LARGLFL; Initial Catalog=tiendita_la_moderna; Trusted_Connection=True";

        /*constructor */
        public conectarid()
        {
            /*sqlconnection(paramatros de conexion)*/
            con = new SqlConnection(cadConexion);
        }

        private void conBD()
        {/*metodo de conecion */
            try
            { /*intenta abriri la coneccion con la BD*/
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error al intentar conectarnos con la BD:" + ex.ToString());
            }
        }
        public  DataTable IDVENDEDOR()
        {
            
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("spConIDtodosVendedor", con);/*se co0necta con el procedimiento*/
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("transaciion no esxitosa" + ex.ToString());
            }
           
            return dt;
        }



        public DataTable TABLAVENDEDOR()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("spConsultarTablaVendedor", con);/*se co0necta con el procedimiento*/
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("transaciion no esxitosa" + ex.ToString());
            }
            return dt;
        }


        public void AgregarVendedor(string nombre,string apa, string ama, string contacto )
        {
            con.Open();/*abrre la conexion con la BD*/
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);
            bool exito = false;
                     
            try
            {
                comQry = new SqlCommand("spAgregarVendedor", con, trans);
                comQry.CommandType = CommandType.StoredProcedure;
                /*limpiamos parametros*/
                comQry.Parameters.Clear();
                comQry.Parameters.AddWithValue("@nomven", nombre);
                comQry.Parameters.AddWithValue("@apepaven", apa);
                comQry.Parameters.AddWithValue("@apamaven", ama);
                comQry.Parameters.AddWithValue("@contacto", contacto);
                comQry.ExecuteNonQuery();
                exito = true;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("transaciion no esxitosa" + ex.ToString());
            }
            if (exito)
            {
                trans.Commit();
            }
            else {
                trans.Rollback();
            }


            con.Close();

        }

        public void EliminarVendedor(Int16 idvendedor)
        {
            con.Open();/*abrre la conexion con la BD*/
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);
            bool exito = false;

            try
            {
                comQry = new SqlCommand("spEliminarVendedor", con, trans);
                comQry.CommandType = CommandType.StoredProcedure;
                /*limpiamos parametros*/
                comQry.Parameters.Clear();
                comQry.Parameters.AddWithValue("@id_vendedor", idvendedor);
                comQry.ExecuteNonQuery();
                exito = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("transaciion no esxitosa" + ex.ToString());
            }
            if (exito)
            {
                trans.Commit();
            }
            else
            {
                trans.Rollback();
            }
            con.Close();

         
        }

        public void ModificarVendedor(int id,string nombre, string apa, string ama, string contacto)
        {
            con.Open();/*abrre la conexion con la BD*/
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);
            bool exito = false;
            try
            {
                comQry = new SqlCommand("spActualizarVendedor", con, trans);
                comQry.CommandType = CommandType.StoredProcedure;
                /*limpiamos parametros*/
                comQry.Parameters.Clear();
                comQry.Parameters.AddWithValue("@id_vendedor", id);
                comQry.Parameters.AddWithValue("@nomven", nombre);
                comQry.Parameters.AddWithValue("@apepaven", apa);
                comQry.Parameters.AddWithValue("@apamaven", ama);
                comQry.Parameters.AddWithValue("@contacto", contacto);
                comQry.ExecuteNonQuery();
                exito = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("transaciion no esxitosa" + ex.ToString());
            }
            if (exito)
            {
                trans.Commit();
            }
            else
            {
                trans.Rollback();
            }
            con.Close();

        
        }

     
        


    }
}



