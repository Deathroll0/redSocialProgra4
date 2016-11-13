<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginRegistrar.aspx.cs" Inherits="redSocialProgra4.vistas.loginRegistrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div>correo: <asp:TextBox id="TB6" runat="server" ></asp:TextBox>  clave: <asp:TextBox id="TB7" runat="server" ></asp:TextBox>   <asp:Button ID="Button2" runat="server" Text="Entrar" PostBackUrl="../validadores/validaLogin.aspx" /><br /> <br /></div>  
        <div>  
            <table border='1px'>
               <tr><td>Correo: </td><td> <asp:TextBox id="TB1" runat="server" ></asp:TextBox><br /></td></tr> 
                <tr><td>Nombre        : </td><td> <asp:TextBox id="TB2" runat="server" ></asp:TextBox><br /></td></tr> 
                <tr><td>Apellido      : </td><td> <asp:TextBox id="TB3" runat="server" ></asp:TextBox><br /></td></tr> 
                <tr><td>Clave         : </td><td> <asp:TextBox id="TB4" runat="server" ></asp:TextBox><br /></td></tr> 
                <tr><td>Repetir Clave : </td><td> <asp:TextBox id="TB5" runat="server" ></asp:TextBox><br /></td></tr> 
               <tr><td><asp:Button ID="Button1" runat="server" Text="Registrar" PostBackUrl="../validadores/validaRegistrar.aspx" /></td></tr> 

                </table>
        </div>  
    </div>
    </form>
</body>
</html>
