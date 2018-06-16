<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddOtherFault.aspx.cs" Inherits="FixTheIncident.WebForm18" %>

<asp:Content ID="Content1" ContentPlaceHolderID="helpDeskAnalyst" runat="server">
    <div class="container">
        <asp:Label ID="Label1" runat="server" CssClass="h2" Text="Add Other Fault Type"></asp:Label>
        <br />
        <asp:Label ID="lblError" Text="" runat="server"></asp:Label>
        <br />
               <%--ddl--%>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label2" runat="server" CssClass="h4" Text="Select Fault Category: "></asp:Label>
            </div>
            <div class="col-md-4">
            <%--    <asp:DropDownList ID="ddlCategories" AutoPostBack="true" CssClass="dropdown form-control" runat="server"></asp:DropDownList>--%>
                 <asp:DropDownList CssClass="dropdown form-control" ID="ddlCategories" runat="server" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
            </div>
        </div>
        <br />
               <%--txtbox--%>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label3" runat="server" CssClass="h4" Text="Selected Other Fault: "></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtOther" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
         <%--buttonRow--%>
        <div class="row">
            <div class="col-md-4">
                <%--<asp:Label ID="Label4" runat="server" Text="Selected Other Fault: "></asp:Label>--%>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnAddOtherFault" OnClick="btnAddOtherFault_Click" runat="server" Text="Submit" CssClass="btn btn-block btn-primary" />
            </div>
        </div>
    </div>

</asp:Content>
