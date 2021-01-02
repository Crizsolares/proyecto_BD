<%@ Page Title="" Language="C#" MasterPageFile="~/Frontal/Site1.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="NOMINA23.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="principal">
        <div class="calendario">
            <asp:Calendar runat="server" ID="Fechafin"></asp:Calendar>
        </div>
        <asp:Button ID="genera_pdf" runat="server" Text="pdf" OnClick="genera_pdf_Click" />
    </div>
</asp:Content>
