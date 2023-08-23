<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication5._Default"  %>
<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc" TagName="Student"%>  
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <p>
                   <uc:Student ID="studentcontrol" runat="server" ObjType="User" /> 
            </section>

        </div>
    </main>

</asp:Content>
