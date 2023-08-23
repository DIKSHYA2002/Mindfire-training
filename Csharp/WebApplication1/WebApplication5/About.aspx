<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication5.About" EnableViewState="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updatepnl" runat="server">  
    <ContentTemplate>  
         <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
  <tr>
    <td style="width: 150px">
        CountryName:<br />
        <asp:TextBox ID="txtCountryName" runat="server" Width="140" />
    </td>
    <td style="width: 150px">
        CountryAbr:<br />
        <asp:TextBox ID="txtCountryAbr" runat="server" Width="140" />
    </td>
    <td style="width: 100px">
     <asp:Button ID="Button2"  runat="server" Text="Add country" CssClass="btn btn-primary" OnClick="AddCountryToDatabase" Height="47px" Width="128px"/>
    </td>
</tr>
</table>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
       OnRowEditing="OnRowEditing" 
       OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" OnRowCancelingEdit="OnRowCancelingEdit" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Height="208px" Width="1060px">
    <Columns>
         <asp:TemplateField HeaderText="CountryID" >
        <ItemTemplate>
            <asp:Label ID="lblCountryID" runat="server" Text='<%# Eval("CountryID") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtCountryID" runat="server" Text='<%# Eval("CountryID") %>'></asp:TextBox>
        </EditItemTemplate>
            
    </asp:TemplateField>
    <asp:TemplateField HeaderText="CountryName" >
        <ItemTemplate>
            <asp:Label ID="lblCountryName" runat="server" Text='<%# Eval("CountryName") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtCountryName" runat="server" Text='<%# Eval("CountryName") %>' ></asp:TextBox>
        </EditItemTemplate>
   
    </asp:TemplateField>
    <asp:TemplateField HeaderText="CountryAbr">
        <ItemTemplate>
            <asp:Label ID="lblCountryAbr" runat="server" Text='<%# Eval("CountryAbr") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtCountryAbr" runat="server" Text='<%# Eval("CountryAbr") %>'></asp:TextBox>
        </EditItemTemplate>
      
    </asp:TemplateField>
      <asp:CommandField ButtonType="Link" ShowEditButton="true" ControlStyle-CssClass="btn btn-success"  ControlStyle-ForeColor="White">
         </asp:CommandField>
        <asp:CommandField ButtonType="Link" ShowDeleteButton="true"  ControlStyle-CssClass="btn btn-danger"  ControlStyle-ForeColor="White">
         </asp:CommandField>
         </Columns>

         <FooterStyle BackColor="White" ForeColor="#000066" />
         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
         <RowStyle ForeColor="#000066" />
         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F1F1F1" />
         <SortedAscendingHeaderStyle BackColor="#007DBB" />
         <SortedDescendingCellStyle BackColor="#CAC9C9" />
         <SortedDescendingHeaderStyle BackColor="#00547E" />
 </asp:GridView>
   
    </ContentTemplate>  
</asp:UpdatePanel> 
</asp:Content>
