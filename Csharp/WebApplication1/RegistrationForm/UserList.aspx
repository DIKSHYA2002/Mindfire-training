<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="UserList.aspx.cs" Inherits="RegistrationForm.UserList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent"  runat="server">
    <div class="user-list">

    <asp:Button runat="server" ID="RedirectAddUserPage" OnClick="RedirectAddUserPage_Click" UseSubmitBehavior="false" Text="AddUser"/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ClientIDMode="Static" >
       <Columns>
        <asp:BoundField DataField="userID" HeaderText="ID" 
            InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" />
        <asp:BoundField DataField="userFirstName" HeaderText="First Name" 
            SortExpression="userFirstName" />
        <asp:BoundField DataField="userLastName" HeaderText="Last Name" 
            SortExpression="userLastName" />
            <asp:TemplateField HeaderText="Birth Date"  >
           <ItemTemplate>
                <asp:Label Text='<%# Eval("userDateOfBirth", "{0:dd/MM/yyyy}") %>' runat="server" />
            </ItemTemplate>
                </asp:TemplateField>
           <asp:BoundField DataField="userEmail" HeaderText="Email" 
            SortExpression="userEmail" />
              <asp:ButtonField Text="Edit" CommandName="Select" runat="server" />
    </Columns>
    </asp:GridView>
        
    </div>
</asp:Content>
