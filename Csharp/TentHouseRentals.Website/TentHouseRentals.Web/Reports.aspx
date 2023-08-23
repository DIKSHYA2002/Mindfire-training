<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TentHouseRentals.Web.Reports" EnableEventValidation="false" %>
  <%@ Register Src="~/Navbar.ascx" TagPrefix="uc1" TagName="NavbarUC" %> 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
      <link rel="stylesheet" href="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath2("./CSS/Navbar.css") %>"  />
      <link rel="stylesheet" href="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath2("./CSS/Reports.css") %>"  />
      <link rel="stylesheet" href="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath2("./CSS/Table.css") %>"  />
  <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
</head> 
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:NavbarUC runat="server" ActiveTab ="Receipts"  id="NavbarUC"/>  
        </div>
          <div class="main-section" id="productReports" runat="server" clientidmode="static">
              <div class="report-action">
                  <button id="btnProductReport">PRODUCT REPORT</button>
                    <button id="btnProductDetailedReport">DETAIL REPORT</button>
                  <%--<asp:Button runat="server" OnClick="btnClickDownloadReportProducts_Click" Text="Product Report" ></asp:Button>--%>
              <%-- <asp:Button runat="server" OnClick="btnDownloadDetail" Text="Detail Report" ></asp:Button>--%>
                <select name="SelectProductName" id="SelectProductName">
                </select>
              </div>
              <div class="report-page">
                  <div class="product-details">
                     
                  </div>
                   <div class="transaction-table table" id="transactionResults">
                          <div class='theader'>
                            <div class='table_header'>ID</div>
                            <div class='table_header'>DATE</div>
                            <div class='table_header'>CUSTOMER</div>
                            <div class='table_header'>PRODUCT</div>
                            <div class='table_header'>TYPE</div>
                            <div class='table_header'>QTY</div>
                          </div>
                  </div>
               </div>
           </div>
    </form>
       <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
      <script src="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath("./SCRIPT/Receipts.js") %>" type="text/javascript"></script>
      <script src="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath("./SCRIPT/Dashboard.js") %>" type="text/javascript"></script>
    </body>
</html>
