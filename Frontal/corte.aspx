<%@ Page Title="" Language="C#" MasterPageFile="~/Frontal/Site1.Master" AutoEventWireup="true" CodeBehind="corte.aspx.cs" Inherits="NOMINA23.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Frontal/estilos/estilos_corte.css" media="screen" />

     <style type="text/css">
         /*#ContentPlaceHolder1_calFcorte {
             display:flex;
             justify-content:center;
             ju
         }*/
         .fecha_t {
             display: flex;
             align-items:center;
             

         }
         .calendario {
             display: flex;
             align-items:center;
         }
         .principal {
             
             padding-top:4%;
         }
         .tabla {
           
             background-color:whitesmoke;
             text-align:left;
             /*width:100%;*/
             border-collapse:collapse;
         }
         .contine_table {
             border-radius: 20px;
             display:flex;
             justify-content:center;
         }
         .th_t, .td_t {
             padding: 20px;
         }
         .encabezado_tabla {
             border-radius: 20px;
             background-color: #800040;             
             border-bottom: solid 5px #800060;
             color: white;
         }
             
         }
         .total {
             background-color: seagreen;
             border-top:solid 5px blue;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="principal">

   
          <div>
       <p class="fecha_t">
           Fecha de corte
       </p> 
           
                <asp:Calendar runat="server" ID="calFcorte"></asp:Calendar>


        <div class="calendario">
            <asp:Button ID="genera_corte" runat="server" Text="Generar" OnClick="genera_corte_Click" />
        </div>
    </div>
    <div class="contine_table">

        <table class="tabla">
            <tr class="encabezado_tabla">
                <th class="th_t">Empleado</th>
                <th class="th_t">Monto</th>
                <th class="th_t">Articulos</th>
            </tr>
            <% Response.Write(tablaPres); %>            
            <% Response.Write(total); %>
            
             
        </table>


    </div>
         </div>
    
  
</asp:Content>
