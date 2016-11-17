<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="redSocialProgra4.vistas.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../css/principal.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Buscar amigos: <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="buscar" PostBackUrl="../validadores/validaBuscarAmigos.aspx" /><br />
        <a href="mostrarTodoAmigos.aspx">Amigos</a><br />
        <a href="miMuro.aspx">Test de muro</a><br /> <br /> <br />
        <textarea id="txtArea" name="txtArea" cols="20" rows="2"></textarea><br />
        <asp:Button ID="Button2" runat="server" Text="Botton"  PostBackUrl="~/validadores/validaPosteoActualizacion.aspx" BackColor="#009933" />
    </div>
    </form>
</body>
</html>
