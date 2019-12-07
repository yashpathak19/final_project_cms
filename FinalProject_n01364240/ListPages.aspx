<%@ Page Title="Pages" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="FinalProject_n01364240.ListPages" %>
<asp:Content ID="pages_list" ContentPlaceHolderID="body" runat="server">
    <h1>Pages</h1>
    <div id="pages_nav">
        <asp:label for="page_search" runat="server">Search:</asp:label>
        <asp:TextBox ID="page_search" runat="server"></asp:TextBox>
        <asp:Button runat="server" CssClass="search_button" text="Search"/>
    </div>
    <button type="button" class="add_button"><a href="AddPage.aspx">Add New</a></button>
    <div class="_table" runat="server">
        <div class="listitem">
            <div class="col5">Title</div>
            <div class="col5">Author</div>
            <div class="col5">Page Published Date</div>
            <div class="col5last">Action</div>
        </div>
        <div id="pages_result" runat="server">

        </div>
    </div>
</asp:Content>
