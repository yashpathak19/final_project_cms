<%@ Page Title="" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="FinalProject_n01364240.ViewPage" %>
<asp:Content ID="page_view" ContentPlaceHolderID="body" runat="server">
    <h2>Page Details</h2>
    <div id="page_detail" runat="server">
    <div class="viewnav">
        <a class="left" href="ListPages.aspx">Go Back</a>
        <ASP:Button OnClientClick="if(!confirm('Do you really want to delete this?')) return false;" OnClick="Delete_Page" CssClass="right spaced button" Text="Delete" runat="server"/>   
        <a class="right" href="EditPage.aspx?pageid=<%= Request.QueryString["pageid"] %>">Edit</a>   
    </div>
    <div>
        Page Title: <span id="page_title" runat="server"></span>
    </div>
    <div>
        Page Body: <span id="page_body" runat="server"></span>
    </div>
    <div>
        Author Name: <span id="author_name" runat="server"></span>
    </div>
    <div>
        Published Date: <span id="page_published_date" runat="server"></span>
    </div>
    </div>
</asp:Content>
