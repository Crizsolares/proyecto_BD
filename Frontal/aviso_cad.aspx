<%@ Page Title="" Language="C#" MasterPageFile="~/Frontal/Site1.Master" AutoEventWireup="true" CodeBehind="aviso_cad.aspx.cs" Inherits="NOMINA23.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <td class="auto-style4" style="vertical-align: baseline;">
            <asp:GridView ID="tablacad" runat="server"  Width="421px">
               
                <HeaderStyle BackColor="#990033" ForeColor="White" />
                <SelectedRowStyle BackColor="#F8568A" />
            </asp:GridView>
        </td>
    </div>
</asp:Content>
