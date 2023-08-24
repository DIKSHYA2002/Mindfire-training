<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="TentHouseRentals.Web.Navbar" %>

 <nav class="sidebar close">
      <div class="menu-bar">
        <div class="menu">
          <ul class="menu-links">
           <%-- <li class="nav-link">
                 <span class="material-symbols-outlined bx bx-chevron-right toggle ">
                     chevron_right
                    </span>
              <a href="Dashboard.aspx" id="dashboardTab">
                  <span class="material-symbols-outlined bx bxs-home-smile icon">home</span>
                <span class="text nav-text">Home</span>
                 
              </a>
            </li>--%>
            <li class="nav-link">
                <span class="material-symbols-outlined bx bx-chevron-right toggle ">
                     chevron_right
                    </span>
              <a href="ProductsPage.aspx" id="productsTab">
                  <span class="material-symbols-outlined bx bx-edit-alt icon">inventory_2</span>
                <span class="text nav-text">Products</span>
              </a>
            </li>
            <li  class="nav-link shrink">
              <a href="CustomersPage.aspx" id="customersTab">
                  <span class="material-symbols-outlined bx bxs-folder-minus icon"> person_add</span>
                <span class="text nav-text">Customers</span>
              </a>
            </li>
            <li class="nav-link shrink">
              <a href="TransactionsPage.aspx" id="transactionsTab">
                  <span class="material-symbols-outlined bx bx-history icon">sync_alt</span>
                <span class="text nav-text">Transactions</span>
              </a>
            </li>
               <li class="nav-link shrink">
                <a href="Reports.aspx" id="receiptsTab">
                 <span class="material-symbols-outlined bx icon">receipt</span>
                <span class="text nav-text">Receipts</span>
              </a>
              </li>
          </ul>
        </div>
      </div>

     
    </nav>

         <asp:Button runat="server" Text="Log Out" ID="btnLogout" onclick="btnClickLogOut" ClientIDMode="static" UseSubmitBehavior="false"/>

