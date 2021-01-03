<%@ Page Title="" Language="C#" MasterPageFile="~/Frontal/Site1.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="NOMINA23.Frontal.WebForm3" %>

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
        <table>
            <tr>
                <th colspan="3"><h1 align="center">&nbsp;</h1>
                    <h1 align="center"><asp:Label ID="Label1" runat="server" Text="PROVEEDORES"></asp:Label></h1>
                    <p align="center">&nbsp;</p>
                </th>
            </tr>
            <tr>
                <td class="auto-style5" style="vertical-align:baseline;" >
                    <br />
                    <asp:Button runat="server" ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" ValidateRequestMode="Enabled" Height="43px" Width="101px" ValidationGroup="validardatos"  />
                    <br />
                    <br />
                    <asp:Button runat="server" ID="btnModificar" Text="Modificar" OnClick="btnModificar_Click" Height="43px" Width="101px" />
                    <br />
                    <br />
                    <asp:Button runat="server" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click" Height="43px" Width="101px" />
                    <br />
                    <br />
                    <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" Height="43px" Width="101px" />
                    <br />
                </td>

                <td class="auto-style7" style="vertical-align:baseline;" >

                    <!--ID del proveedor-->
                    <br />
                    <asp:Label runat="server" ID="lblIDprove" Text="ID Proveedor: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;	
                    <asp:DropDownList runat="server" ID="listaIDprove" OnSelectedIndexChanged="listaIDprove_SelectedIndexChanged" AutoPostBack="true" Height="31px" Width="124px"></asp:DropDownList>
                    <br />
                    
                    <!--Nombre del proveedor-->
                    <br />
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell>Nombre: </asp:TableCell>
                            <asp:TableCell><asp:TextBox runat="server" ID="txtNomProve"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell><br /></asp:TableCell>
                        </asp:TableRow>
                        <%--Dirreción proveedor--%>
                        <asp:TableRow>
                            <asp:TableCell>Dirección: </asp:TableCell>
                            <asp:TableCell><asp:TextBox runat="server" ID="txtDirProve"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell><br /></asp:TableCell>
                        </asp:TableRow>
                        <%--RFC--%>
                        <asp:TableRow>
                            <asp:TableCell>RFC: </asp:TableCell>
                            <asp:TableCell><asp:TextBox runat="server" ID="txtRFCProve"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell><br /></asp:TableCell>
                        </asp:TableRow>
                        <%--Teléfono--%>
                        <asp:TableRow>
                            <asp:TableCell>Número telefónico:</asp:TableCell>
                            <asp:TableCell><asp:TextBox runat="server" ID="txtTelProve"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell><br /></asp:TableCell>
                        </asp:TableRow>

                        <%--Guardar cambios
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="btnGuardarCambiosProve" Text="Guardar Cambios"  Height="43px" Width="150px" />
                            </asp:TableCell>
                        </asp:TableRow>--%>
                        


                        <asp:TableRow>
                            <asp:TableCell><br /><br /></asp:TableCell>
                        </asp:TableRow>
                        

                    </asp:Table>
                    <br />
                </td>





                <td class="auto-style4" style="vertical-align:baseline;" >
                    <tr>
                        <br />
                        <div>
                            <asp:GridView runat="server" ID="GVBuscarProve" Width="1500 px">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                                </Columns>
                                <HeaderStyle BackColor="#990033" ForeColor="White" />
                                <SelectedRowStyle BackColor="#F8568A" />
                            </asp:GridView>
                        </div>
                    </tr>
                    <tr>
                        <br />
                        <div>
                            <asp:GridView runat="server" ID="GVListaProve" Width="1500 px">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                                </Columns>
                                <HeaderStyle BackColor="#990033" ForeColor="White" />
                                <SelectedRowStyle BackColor="#F8568A" />
                            </asp:GridView>
                        </div>
                    </tr>

                </td>

                <tr>
                    <td class="auto-style5" style="vertical-align:baseline;">
                        <br />
                        <br />
                        <asp:Button runat="server" ID="btnListaProve" Text="Mostrar Proveedores" OnClick="btnListaProve_Click" Height="43px" Width="150px" />
                    </td>
                </tr>


            </tr>
                     
       </table>
      </div>
</asp:Content>
