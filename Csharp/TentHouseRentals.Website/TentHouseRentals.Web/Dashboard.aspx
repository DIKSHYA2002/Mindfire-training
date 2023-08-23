<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TentHouseRentals.Web.Dashboard" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc1" TagName="NavbarUC" %>  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="./CSS/Navbar.css" />
  <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <uc1:NavbarUC runat="server" ActiveTab="Dashboard" id="NavbarUC"/>  
    </form>
    <script src="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFile("./SCRIPT/Dashboard.js")%>"></script>
</body>
</html>
<%--./SCRIPT/Dashboard.js--%>