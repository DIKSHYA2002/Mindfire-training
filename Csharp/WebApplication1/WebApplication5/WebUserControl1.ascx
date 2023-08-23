<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits=".WebUserControl1" %>
<h3>Notes are displayed Here</h3>
<asp:TextBox ID="TextArea1" runat="server" Text="Add Notes Here"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />

 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
      CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Height="208px" Width="1060px"
    >
    <Columns>
         <asp:TemplateField HeaderText="NOTES" >
        <ItemTemplate>
            <asp:Label ID="lbNote" runat="server" Text='<%# Eval("Note") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Id">
        <ItemTemplate>
            <asp:Label ID="lblNoteID" runat="server" Text='<%# Eval("ID") %>' sortexpression="ID"></asp:Label>
        </ItemTemplate>

    </asp:TemplateField>
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
<br />  
 <asp:Label ID="Label1" runat="server" ForeColor="black" Text=" "></asp:Label> 