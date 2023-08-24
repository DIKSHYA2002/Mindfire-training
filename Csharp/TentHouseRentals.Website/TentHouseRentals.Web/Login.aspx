﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TentHouseRentals.Web.Login" clientIDmode="Static"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <link rel="stylesheet" href="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath2("./CSS/Form.css") %>"  />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
   
</head>
<body>
    <form id="form1" runat="server" >
        <div class="form-container">
             <div class="login-container container">
                 <h1 >Login</h1>
            <div class="input-field">
                    <label for="txtEmail" id="lbltxtEmail">Email *</label>
                    <input type="email" runat="server" id="txtEmail" refto="lbltxtEmail" />
            </div>
            <div class="input-field" >
                    <label for="txtPassword" id="lbltxtPassword">Password *</label>
                   <input type="password" runat="server" id="txtPassword" refto= "lbltxtPassword"/>
            </div>
            <div class="input-field button">
                <asp:Button ID="btnLogin" runat="server" Text="Login"    UseSubmitBehavior="false" OnClientClick="if(ValidateLogin()) { return false;};"
                  OnClick="LoginBtn" />


                 <asp:Button ID="btnReinitialise" runat="server" Text="initialise"  UseSubmitBehavior="false"
                  OnClientClick="if(ValidateLogin()) { return false;};"
                  OnClick="Reinitialise"/>
            </div>
        </div> 
        </div>
    </form>
     <script src="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath("./SCRIPT/Form.js") %>" type="text/javascript"></script>
   
</body>
</html>