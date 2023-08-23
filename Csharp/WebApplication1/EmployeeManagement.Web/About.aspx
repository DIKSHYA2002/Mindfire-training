<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="EmployeeManagement.Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <div  id="userList">
             <div>
            <h1>Users will be displayed here</h1>
            <div class="table-rows">
               <div class="row headers">
        <div class="col-cell headers">First Name</div>
          <div class="col-cell headers">Last Name</div>
          <div class="col-cell headers">Email</div>
          <div class="col-cell headers">Phone Number</div>
          
                      <div class="col-cell headers"></div>
           </div>
            </div>
          
        </div>
        </div>
        
</asp:Content>
