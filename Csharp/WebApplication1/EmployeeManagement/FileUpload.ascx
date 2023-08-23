<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.ascx.cs" Inherits="EmployeeManagement.FileUpload" %>
<div class="form-container2">
<h3>Files are displayed here</h3>
   <div class="fieldset">
          <asp:FileUpload ID="FileUpload1" runat="server"/>
            <asp:Button ID="btnUpload" runat="server" Text="Upload" Onclick="BtnUpload_Click"/>
     </div>
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
    >
    <Columns>
        <asp:BoundField DataField="fileName" HeaderText="File Name"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"
                    CommandArgument='<%# Eval("fileid") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</div>
 