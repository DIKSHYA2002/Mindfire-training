<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="WebApplication5.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div >  
               Email:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
             Password: <asp:TextBox ID="TextBox2"  runat="server"></asp:TextBox> <asp:Button ID="Button1" runat="server" Text="Log In" OnClick ="Button1_Click" />  
        </div> 
      </form>
</body>
</html>
