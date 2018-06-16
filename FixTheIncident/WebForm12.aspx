<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebForm12.aspx.cs" Inherits="FixTheIncident.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="helpDeskAnalyst" runat="server">
    <div class="container">
        <h2>Logged Faults</h2>
          <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#unassignedFaults">Unassigned Faults</a></li>
            <li><a  data-toggle="tab" href="#assignedFaults">Assigned Faults</a></li>
        </ul>

        <div class="tab-content">
            <br />
            <div id="unassignedFaults" class="tab-pane fade in active">
               <asp:GridView OnPageIndexChanging="dgUnassignedFaults_PageIndexChanging" PageSize="5" AllowPaging="true" runat="server" ID="dgUnassignedFaults" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="dgUnassignedFaults_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Fault Log ID" HeaderText="Fault Log ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                        <asp:BoundField DataField="Fault Category Name" HeaderText="Fault Category Name" />
                        <asp:BoundField DataField="Fault Type" HeaderText="Fault Type" />
                        <asp:BoundField DataField="Fault Description" HeaderText="Fault Description" />
                        <asp:BoundField DataField="Fault Location" HeaderText="Fault Location" />
                        <asp:BoundField DataField="Date and Time" HeaderText="Date and Time" />
                    </Columns>
                    <PagerStyle CssClass="pagination-Eldon" HorizontalAlign="Center" />
                </asp:GridView>
            </div>
            <div id="assignedFaults" class="tab-pane fade">
                <br />
                <asp:GridView runat="server" Visible="false" ID="gvAssignedFaults" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvAssignedFaults_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Fault Log ID" HeaderText="Fault Log ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                        <asp:BoundField DataField="Fault Category Name" HeaderText="Fault Category Name" />
                        <asp:BoundField DataField="Fault Type" HeaderText="Fault Type" />
                        <asp:BoundField DataField="Fault Description" HeaderText="Fault Description" />
                        <asp:BoundField DataField="Fault Location" HeaderText="Fault Location" />
                        <asp:BoundField DataField="Date and Time" HeaderText="Date and Time" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            $(".nav-tabs a").click(function () {
                $(this).tab('show');
            });
        });
    </script>


</asp:Content>
