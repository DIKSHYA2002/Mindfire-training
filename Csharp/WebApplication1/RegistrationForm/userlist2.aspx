<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlist2.aspx.cs" Inherits="RegistrationForm.userlist2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <link rel="stylesheet" href="userlist2.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
<body>
   
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
       </asp:ScriptManager>
        <div>
            <h1>Users will be displayed here</h1>
            <div class="table-rows">
               <div class="row header">
        <div class="col-cell header">First Name</div>
          <div class="col-cell header">Last Name</div>
          <div class="col-cell header">Email</div>
          <div class="col-cell header">Phone Number</div>
           <div class="col-cell header">Roles</div>
                      <div class="col-cell header"></div>
           </div>
            </div>
          
        </div>
    </form>
    <script src="userlist.js"></script>
</body>
</html>
