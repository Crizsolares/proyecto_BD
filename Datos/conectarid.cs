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


namespace NOMINA23
{
    public class conectarid
    {

        private SqlConnection con;
        private SqlCommand comQry;
        private SqlDataReader lec;
        /*cadena de coneccion al menos 3 datos:
         servidor, base de datos, usuario y contraseña(solo para servidor remoto) */
        private String cadConexion = "Data Source=DESKTOP-IG7NH44; Initial Catalog=tiendita_la_moderna; Trusted_Connection=True";

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
                Console.WriteLine("Error al intentar conectarnos con la BD:" + ex.ToString());
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

        /*-----------------------------------PROVEEDORES--------------------------------------------------*/
        //ID Proveedor
        public DataTable idProve()
        {

            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_IdProveedor", con);/*se conecta con el procedimiento*/
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


        //No devuelve datos
        public void SP_ManejaDatosProveedores(Int16 idProve, String nomProve, String dirProve, String rfcProve, String telProve, Int16 tipOperProve)
        {
            //Verificar que se llevo a cabo correctamente
            bool exito = false;

            //Abrimos la conexión de la BD
            con.Open();

            /*Se hace una transacción de tipo serializable, es decir, una tras otra.
             Sin embargo hay que configurarlo porque los objetos no están diseñados 
             para trabajar con el Store Procedure*/
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);

            try
            {   
                //Parametrizamos
                comQry = new SqlCommand("sp_ManejaDatosProveedores", con, trans);
                //Le decimos el tipo de consulta (SP)
                comQry.CommandType = CommandType.StoredProcedure;
                comQry.Parameters.Clear(); //Limpiamos parámetros del SP

                //Mandamos los parametros de entrada del SP
                comQry.Parameters.AddWithValue("@idProve", idProve);
                comQry.Parameters.AddWithValue("@nomProve", nomProve);
                comQry.Parameters.AddWithValue("@dirProve", dirProve);
                comQry.Parameters.AddWithValue("@rfcProve", rfcProve);
                comQry.Parameters.AddWithValue("@telProve", telProve);
                comQry.Parameters.AddWithValue("@tipOperProve", tipOperProve);

                comQry.ExecuteNonQuery();

                exito = true;
                Console.WriteLine("Transacción exitosa");

            }
            catch(Exception ex)
            {
                Console.WriteLine("Transacción NO EXITOSA: " + ex.ToString());
            }
            //Confirmar o negar la transacción
            finally
            {
                if (exito)
                {
                    trans.Commit(); //Confirma
                }
                else
                {
                    trans.Rollback(); //Deshacer el último cambio que se hizo o intento hacer
                }
            }
            con.Close(); //Cerramos conexión

        }

        //Devuelve datos
        public String SP_RegresaDatosProveedores(Int16 idProve, Int16 tipOperProve)
        {
            String cadReg = "";

            //Abrimos la conexión de la BD
            con.Open();

            //Obajeto tabla temporal
            DataTable tablaRegistro = new DataTable();

            try
            {
                //Declaramos el adaptador para jalar los datos desde SQL
                SqlDataAdapter datos = new SqlDataAdapter("SP_RegresaDatosProveedores", con);
                //Le decimos el tipo de consulta (SP)
                datos.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Parametrizamos
                datos.SelectCommand.Parameters.Add("@idProve", idProve);
                datos.SelectCommand.Parameters.Add("@tipOperProve", tipOperProve);

                //Hacemos llenado de nuestro objeto Data table
                datos.Fill(tablaRegistro);

                //Descomponemos la matriz para devolver una cadena
                for(int i=0; i<tablaRegistro.Rows.Count; i++)
                {
                    for(int j=0; j<tablaRegistro.Columns.Count; j++)
                    {
                        //Concatenamos la info que se va a ir obteniendo
                        cadReg += tablaRegistro.Rows[i][j].ToString() + "|";
                    }
                    cadReg += "$";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al recuperar los datos: " + ex.ToString());
            }

            //Cerramos la conexión
            con.Close();

            return cadReg;

        }


    }
}



