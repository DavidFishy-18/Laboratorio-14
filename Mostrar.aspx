<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mostrar.aspx.cs" Inherits="Laboratorio__14.Mostrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listado de albumes registrados</h2>
    <p><asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>Seleccione al Album del artista que desea&nbsp; vizualizar&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Width="120px">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Mostrar" class ="btn btn-secondary" OnClick="Button1_Click"/>
    </p>
    <p>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
&nbsp;
    </p>
</asp:Content>
