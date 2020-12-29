<%@ Page Title="" Language="C#" MasterPageFile="~/Frontal/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NOMINA23.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
            especiales = "8-127-32";

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }
    </script>
<script>
    function soloNumerosG(e) {
        var key = window.Event ? e.which : e.keyCode

        return (key >= 48 && key <= 57)
    }
</script>

    <style type="text/css">
        .auto-style3 {
            width: 107px;
        }
        .auto-style4 {
            width: 113px;
        }
        .auto-style5 {
            width: 68px;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div style="text-align:center;">
          <table border="2" style="margin: 0 auto;">
            <tr>
              <td colspan="3"><h1 align="center">&nbsp;</h1>
                  <h1 align="center"><asp:Label ID="Label1" runat="server" Text="EMPLEADOS"></asp:Label></h1>
                  <p align="center">&nbsp;</p>
              </td>
            </tr>
                    
            <tr>        
              <td class="auto-style5" style="vertical-align:baseline;" >
                    <br />
                    <asp:Button ID="btnagregar" runat="server" OnClick="btnagrega_Click" Text="Agregar" ValidateRequestMode="Enabled" Height="43px" Width="101px" ValidationGroup="validardatos" />							
                    <br />
                    <br />
                    <asp:Button ID="btnmodificar" runat="server" Text="Modificar" OnClick="btnmodificar_Click"  Height="43px" Width="101px" />                              
                    <br />
                    <br />
                    <asp:Button ID="btneliminar" runat="server" Text="Eliminar" OnClick="btneliminar_Click"  Height="43px" Width="101px"/>				
				    <br />
                    <br />
				    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" OnClick="btnbuscar_Click1"  Height="43px" Width="101px"/>
              </td>
              <td class="auto-style7" style="vertical-align:baseline;" >
                    <br />
                    <asp:Label ID="lblid" runat="server" Text="ID Empleado"></asp:Label>
                    &nbsp;&nbsp;&nbsp;		
                    <asp:DropDownList ID="listavendedor" runat="server" OnSelectedIndexChanged="listavendedor_SelectedIndexChanged" Height="31px" Width="124px">
                    </asp:DropDownList>			
                    <br />
                    <br />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnombre"
                        EnableClientScript="false" ErrorMessage="Ingresar Nombre" Text="*" Display="Dynamic"
                        ValidationGroup="validardatos" ForeColor="#CC3300">
					</asp:RequiredFieldValidator>
                    <asp:Label ID="lblnombre" runat="server" Text="Nombre: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="txtnombre" runat="server" ></asp:TextBox>
                    <br />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtapa"
                        EnableClientScript="false" ErrorMessage="Ingresar Apellido Paterno" Text="*" Display="Dynamic"
                        ValidationGroup="validardatos" ForeColor="#CC3300">
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="lblapa" runat="server" Text="Apellido Paterno:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtapa" runat="server" ></asp:TextBox>
                    <br />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtama"
                        EnableClientScript="false" ErrorMessage="Ingresar Apellido Materno" Text="*" Display="Dynamic"
                        ValidationGroup="validardatos" ForeColor="#CC3300">
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="lblama" runat="server" Text="Apellido Materno: "></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtama" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcontacto"
                        EnableClientScript="false" ErrorMessage="Ingresar Número Telefónico" Text="*" Display="Dynamic"
                        ValidationGroup="validardatos" ForeColor="#CC3300">
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="lblcontacto" runat="server" Text="Número Telefónico: "></asp:Label>
                    <asp:TextBox ID="txtcontacto" runat="server" Width="162px"></asp:TextBox>		
                    <br />			
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnguardarcambios" runat="server" OnClick="btnguardarcambios_Click" Text="Guardar Cambios" Visible="False" class="auto-style3" align="center" Height="49px" Width="156px" ValidationGroup="validardatos" />
                    <asp:ValidationSummary runat="server" ID="vsumAll" DisplayMode="BulletList" CssClass="validationsummary" ValidationGroup="validardatos" ForeColor="Red" />
                </td>
                <td class="auto-style4" style="vertical-align:baseline;" >
                    <br />
                       <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="421px" >
						    <Columns>
                            <asp:CommandField ShowSelectButton="True">
                            </asp:CommandField>
                            </Columns>
                            <HeaderStyle BackColor="#990033" ForeColor="White" />
                            <SelectedRowStyle BackColor="#F8568A" />
					    </asp:GridView>
                </td>
           </tr>               
       </table>
      </div>
</asp:Content>
