<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication5.WebForm1" %>
<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc" TagName="Student"%> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <uc:Student ID="studentcontrol" runat="server" ObjType="User" /> 
        </div>
    </form>
</body>
</html>
