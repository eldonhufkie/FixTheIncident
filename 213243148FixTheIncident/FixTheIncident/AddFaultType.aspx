<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddFaultType.aspx.cs" Inherits="FixTheIncident.WebForm17" %>

<asp:Content ID="Content1" ContentPlaceHolderID="helpDeskAnalyst" runat="server">
    <div class="container">
        <asp:Label ID="Label1" runat="server" Text="Add Fault Type" CssClass="h2"></asp:Label>
        <br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView OnPageIndexChanging="gvOtherFaults_PageIndexChanging" PageSize="5" AllowPaging="true" runat="server" ID="gvOtherFaults" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvOtherFaults_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="FaultOtherID" HeaderText="FaultOtherID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                <asp:BoundField DataField="FaultOtherText" HeaderText="Other Faults" />
            </Columns>
            <PagerStyle CssClass="pagination-Eldon pagination-lg" HorizontalAlign="Center" />

        </asp:GridView>
    </div>
</asp:Content>
