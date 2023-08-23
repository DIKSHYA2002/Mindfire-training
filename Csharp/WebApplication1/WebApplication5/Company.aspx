<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="WebApplication5.Company" %>
<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc" TagName="Student"%> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>This is the company page</h1>
             <uc:Student ID="studentcontrol" runat="server" ObjType="Company" /> 
        </div>
    </form>
</body>
</html>
