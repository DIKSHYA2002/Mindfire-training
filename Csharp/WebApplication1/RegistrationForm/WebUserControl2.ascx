<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl2.ascx.cs" Inherits="RegistrationForm.WebUserControl2" %>
<div class="form-container2">

<h3>Notes are displayed Here</h3>
    <div class="fieldset">
        <asp:TextBox ID="TextArea1" runat="server" Text="Add Notes Here" ></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" UseSubmitBehavior="false" />
    </div>
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
    >
    <Columns>
        
         <asp:TemplateField HeaderText="NOTES" >
        <ItemTemplate>
            <asp:Label ID="lbNote" runat="server" Text='<%# Eval("Note") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
         </Columns>
 </asp:GridView>
</div>
 