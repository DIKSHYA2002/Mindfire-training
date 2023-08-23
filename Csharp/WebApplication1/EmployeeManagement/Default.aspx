<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeManagement._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

         <div class="login-page">
                <div class="input-field">
                    <label for="txtEmail">Email</label>
                   <input type="email" runat="server" id="txtEmail" clientIDmode ="static">
                </div>
                <div class="input-field" >
                    <label for="txtPassword">Password</label>
                   <input type="password" runat="server" id="txtPassword" clientIDmode ="static">
                </div>
             <div class="input-field">
                 <asp:Button  runat="server"  id="btnSubmit" ClientIDMode="static" UseSubmitBehavior="false"   OnClick="Login" Text="Login" />
             </div>
            </div>
       

</asp:Content>
