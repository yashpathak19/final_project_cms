<%@ Page Title="Delete Page" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="FinalProject_n01364240.DeletePage" %>
<asp:Content ID="delete_page" ContentPlaceHolderID="body" runat="server">
    <h2>Page Details</h2>
    <div id="page_detail" runat="server">
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
        <div id="confirmation">Are you sure you want to delete?</div>
        <asp:button type="button" runat="server" text="Delete" onclick="Remove_Page" CssClass="delete_button" />
        <asp:button type="button" runat="server" text="Cancel" onclick="Cancel" CssClass="cancel_button" />
    </div>
</asp:Content>
