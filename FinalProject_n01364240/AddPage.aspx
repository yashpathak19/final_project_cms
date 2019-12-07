<%@ Page Title="Add Page" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="FinalProject_n01364240.AddPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <section>
            <h1>Add New Page</h1>
            <div>
                <label for="page_title">Page Title:</label>
                <asp:TextBox id="page_title" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                <asp:RequiredFieldValidator  runat="server" EnableClientScript="true" ErrorMessage="Please provide Page title!" ControlToValidate="page_title"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="page_body">Page Body:</label>
                <asp:TextBox id="page_body" TextMode="multiline" Columns="100" Rows="10" runat="server" />
                <asp:RequiredFieldValidator  runat="server" EnableClientScript="true" ErrorMessage="Please provide Page Body!" ControlToValidate="page_body"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="author_name">Author Name:</label>
                <asp:TextBox id="author_name" runat="server" />
                <asp:RequiredFieldValidator  runat="server" EnableClientScript="true" ErrorMessage="Please provide Author Name!" ControlToValidate="author_name"></asp:RequiredFieldValidator>
            </div>
            <asp:Button OnClick="Add_Page" Text="Add Page" runat="server" CssClass="search_button"/>
        </section>
</asp:Content>
