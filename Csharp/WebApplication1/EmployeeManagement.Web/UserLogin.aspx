<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="EmployeeManagement.Web.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet"  href="StyleSheet.css"/>
</head>
<body>
  <form id="form1" runat="server">

         <div class="login-page">
                <div class="input-field">
                    <label for="txtEmail">Email</label>
                   <input type="email" runat="server" id="txtEmail" clientidmode ="static"/>
                </div>
                <div class="input-field" >
                    <label for="txtPassword">Password</label>
                   <input type="password" runat="server" id="txtPassword" clientidmode ="static"/>
                </div>
             <div class="input-field">
                 <asp:Button  runat="server"  id="btnSubmit" ClientIDMode="static" UseSubmitBehavior="false"   OnClick="Login" Text="Login" />
             </div>
            </div>
    </form>
</body>
</html>
