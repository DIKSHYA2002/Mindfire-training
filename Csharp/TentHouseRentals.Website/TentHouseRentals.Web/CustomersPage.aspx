<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomersPage.aspx.cs" Inherits="TentHouseRentals.Web.CustomersPage" %>
  <%@ Register Src="~/Navbar.ascx" TagPrefix="uc1" TagName="NavbarUC" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <link rel="stylesheet" href="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath2("./CSS/Navbar.css") %>"  />
      <link rel="stylesheet" href="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath2("./CSS/Customers.css") %>"  />
  <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:NavbarUC runat="server" ActiveTab="Customers" id="NavbarUC"/> 
            <div class="customer-form main-section">
                        <div class="input-field">
                            <input type= "text" id="txtName" placeholder="Enter Customer Name"/>
                              <button id="btnAddCustomer" class="btn"><span class="material-symbols-outlined">
                                person_add
                                </span></button>
                        </div>
                      <div class="customer-lists">
                          <div class="customer head">
                          <div class="customer-id">CUSTOMER-ID</div>
                           <div class="customer-name">CUSTOMER-NAME</div>
                           </div>
                      </div>
            </div>
        </div>
    </form>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
  
      <script src="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath("./SCRIPT/Dashboard.js") %>" type="text/javascript"></script>
</body>
</html>
