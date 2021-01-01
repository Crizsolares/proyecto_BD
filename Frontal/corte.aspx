<%@ Page Title="" Language="C#" MasterPageFile="~/Frontal/Site1.Master" AutoEventWireup="true" CodeBehind="corte.aspx.cs" Inherits="NOMINA23.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
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
         <asp:Button ID="genera_pdf" runat="server" Text="pdf" OnClick="genera_pdf_Click" />

    </div>
         </div>
    
  
</asp:Content>
