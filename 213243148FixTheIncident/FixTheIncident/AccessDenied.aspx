<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="FixTheIncident.WebForm15" %>

<asp:Content ID="Content1" ContentPlaceHolderID="helpDeskAnalyst" runat="server">
    <div class="container">
        <asp:Label Text="403 - Forbidden: Access is denied." CssClass="h3" runat="server"></asp:Label>
        <br />
        <asp:Label Text="You do not have permission to view this directory or page using the credentials that you supplied." CssClass="h4" runat="server"></asp:Label>
    </div>
</asp:Content>
