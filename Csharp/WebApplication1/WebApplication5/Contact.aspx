

<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication5.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="form" ClientIDMode ="static">
        <div>
            <label>Full Name</label>
             <input type="text" />
        </div>
         <div>
            <label>Email</label>
             <input type="email" />
        </div>
        <div>
            <label>Phone Number</label>
             <input type="Number" /></div>
        <div>
             <label>Roles</label>
            <asp:dropdownlist runat="server"  ID ="userroles" ClientIDMode ="static">
             </asp:dropdownlist >
        </div>
    </div>
   
    <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black"  AutoGenerateColumns="False"
     >
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
         <Columns>
         <asp:TemplateField HeaderText="ID" ItemStyle-Width="100px"  >
        <ItemTemplate>
            <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("userID") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtUserID" runat="server" Text='<%# Eval("userID") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Name" ItemStyle-Width="100px">
        <ItemTemplate>
            <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("userName") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtUserName" runat="server" Text='<%# Eval("userName") %>' ></asp:TextBox>
        </EditItemTemplate>
    
    </asp:TemplateField>
             <asp:TemplateField HeaderText="Email" ItemStyle-Width="100px">
        <ItemTemplate>
            <asp:Label ID="lblUserEmail" runat="server" Text='<%# Eval("userEmail") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtUserEmail" runat="server" Text='<%# Eval("userEmail") %>' ></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Contact" ItemStyle-Width="100px">
        <ItemTemplate>
            <asp:Label ID="lblUserPhone" runat="server" Text='<%# Eval("userPhone") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtUserPhone" runat="server" Text='<%# Eval("userPhone") %>'></asp:TextBox>
        </EditItemTemplate>
      
    </asp:TemplateField>
             <asp:TemplateField HeaderText="Gender" ItemStyle-Width="100px">
        <ItemTemplate>
            <asp:Label ID="lblUserGender" runat="server" Text='<%# Eval("userGender") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtUserGender" runat="server" Text='<%# Eval("userGender") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField >
        <asp:TemplateField HeaderText="D.O.B" ItemStyle-Width="100px">
        <ItemTemplate>
        <asp:Label ID="lblUserdob" runat="server" Text='<%# Eval("userDateOfBirth","{0:d}") %>'  ></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
          <asp:TextBox ID="txtUserdob" runat="server" Text='<%# Eval("userDateOfBirth") %>'></asp:TextBox>
          </EditItemTemplate>
        </asp:TemplateField >
      <asp:CommandField ButtonType="Link" ShowEditButton="true" ControlStyle-CssClass="btn btn-success"  ControlStyle-ForeColor="White">
         </asp:CommandField>
        <asp:CommandField ButtonType="Link" ShowDeleteButton="true"  ControlStyle-CssClass="btn btn-danger"  ControlStyle-ForeColor="White">

         </asp:CommandField>
</Columns>
    </asp:GridView>
   
</asp:Content>
