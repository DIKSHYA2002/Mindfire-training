<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionsPage.aspx.cs" Inherits="TentHouseRentals.Web.TransactionsPage" %>

<%@ Register Src="~/Navbar.ascx" TagPrefix="uc1" TagName="NavbarUC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transactions-TentHouseRentals</title>
    <meta charset="utf-8" /> 

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
     <link rel="stylesheet" href="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath2("./CSS/Navbar.css") %>"  />
      <link rel="stylesheet" href="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath2("./CSS/Transactions.css") %>"  />
      <link rel="stylesheet" href="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath2("./CSS/Table.css") %>"  />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.5/css/select2.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:NavbarUC runat="server" ActiveTab="Transactions" ID="NavbarUC" />
        </div>
        <div class="main-section">
            <div class="header-section">
                <div class="in-out-radio-buttons">
                 <div>
                      <input type="radio" name="transactionType" value="out" id="outType" checked/>
                     <label for="outType">OUT</label>
                 </div>
                    <div>
                     <input type="radio" name="transactionType" value="in" id="inType" />
                     <label for="inType">IN</label>
                 </div>
                </div>
            </div>

            <div class="out-section">
                <div class="out-section-form" id="outSectionForm">
                    <div class="input-field">
                         <label for="transactionCustomer" id="lblCustomerName">CUSTOMER :</label>
                        <input name="transactionCustomer" list="customerList"  id="transactionCustomer" refto="lblCustomerName" type="text" autocomplete="off"/>
                          <datalist id="customerList">
                         </datalist>
                    </div>
                    <div class="input-field">
                         <label for="dtTransactionDate" id="lblDate">DATE:</label>
                       <input type="datetime-local" id="dtTransactionDate" refto="lblDate" />
                    </div>
                     <div class="input-field">
                          <label for="lstProducts" id="lblProducts">PRODUCTS:</label>
                            <select id="id_select2_example" style="width: 170px;">
                              <option id="-1" data-img_src="https://static.thenounproject.com/png/2858523-200.png" >Select Item</option>
                            </select>
                    </div>
                     <div class="input-field">
                          <label for="nbQuantity" id="lblQuanity">QUANTITY *</label>
                            <input type="number" id="counting" refto="lblQuanity"/>
                    </div>
                     <div class="input-field button-add-transaction">
                         <button id="btnAddTransaction" class="btn">Add Product</button>
                    </div>
                </div>
                <div class="out-section-list">
                    <button id="btnSaveTransactions">SAVE TRANSACTIONS</button>
                    
                    <div class="transaction-individual-head in" >
                         <div class="transaction-date">
                            DATE
                         </div>

                       <div class="transaction-product-name">
                        PRODUCT
                       </div>
                    <div class="transaction-product-quantity">
                        QTY
                    </div>
                    <div class="transaction-product-customer">
                      CUSTOMER
                    </div>
                         <div class="transaction-product-buttons">
                             DELETE
                    </div>
                  </div>
                    
                </div>
            </div>
            <div class="in-section">
                 <div class="input-field-in-section">
                        <label for="transactionCustomer2">CUSTOMER :</label>
                        <select name="transactionCustomer" id="transactionCustomer2">
                        </select>
                    </div>
               <div class="in-section-list">
                    <button id="btnSaveInTransactionsIn">SAVE TRANSACTIONS</button>
                    <div class="transaction-table table" id="transactionResults">
                          <div class='theader'>
                                <div class='table_header transaction-date out'>OUT-DATE</div>
                                <div class='table_header transaction-date in'>IN-DATE</div>
                               <div class='table_header transaction-product-id'>PRODUCT</div>
                               <div class='table_header transaction-product-quantity'>QTY</div>
                                <div class='table_header'>TYPE</div>
                                <div class='table_header transaction-product-buttons'>RETURN</div>
                          </div>
                   </div>
                   <div class="transaction-individual" >
                         <h1>No Transactions Found</h1>
                     </div>
                     
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.5/js/select2.js"></script>
    <script src="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath("./SCRIPT/SelectTool.js") %>" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    
      <script src="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath("./SCRIPT/Dashboard.js") %>" type="text/javascript"></script>
    
     <script src="<%=TentHouseRentals.Utilities.CommonFunctions.GetUpdatedFilePath("./SCRIPT/Transaction.js") %>" type="text/javascript"></script>
</body>

</html>

