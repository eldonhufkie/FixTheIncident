<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechFaults.aspx.cs" Inherits="FixTheIncident.TechFaults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title runat="server" id="helpDeskTitle">Home</title>
    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Playball" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Rubik" rel="stylesheet" />
</head>
<body style="font-family: 'Rubik', serif;">
    <form id="frmHelpD" runat="server">
        <header class="navbar navbar-default">
            <!-- Brand and toggle get grouped for better mobile display -->
            div class="container-fluid">
                <nav class="navbar navbar-default navbar-fixed-top">
                    <div class="container">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar-collapse" aria-haspopup="true" aria-expanded="false">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a href="MainMenu.aspx" class="navbar-brand" style="font-family: 'Playball', cursive; font-size: xx-large">FixTheIncident </a>
                        </div>
                        <!-- Collect the nav links, forms, and other content for toggling -->
                        <div class="collapse navbar-collapse" id="bs-example-navbar-1">
                            <ul class="nav navbar-nav ">
                                <li class="active"><a href="HelpDeskFaults.aspx">Home</a></li>
                                <li><a href="TechFaults.aspx">Faults</a></li>

                            </ul>
                            <ul class="nav navbar-nav navbar-right">
                                <li>
                                    <div>
                                        <asp:Label Text="Logged in as:" CssClass="navbar-text" runat="server"></asp:Label>
                                        <label class="navbar-text" id="lblUsername" runat="server"></label>
                                    </div>
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle glyphicon glyphicon-user " data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><span class="caret"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">Change password</a></li>
                                        <%--<li><a href="#"></a></li>--%>
                                        <%--<li role="separator" class="divider"></li>--%>
                                        <%--<li><a href="#">Separated link</a></li>--%>
                                    </ul>
                                </li>
                                <li>
                                    <asp:Button ID="btnLogOff" CssClass="btn navbar-btn navbar-right pull-right" OnClick="btnLogOff_Click" runat="server" Text="Sign Out" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>

        </header>
        <div class="container">
            <h2>Logged Faults</h2>
            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#unassignedFaults">Unattended Faults</a></li>
                <li><a data-toggle="tab" href="#assignedFaults">Faults Attended to</a></li>
            </ul>
            <div class="tab-content">
                <br />
                <div id="unassignedFaults" class="tab-pane fade in active">
                    <asp:GridView OnPageIndexChanging="dgUnassignedFaults_PageIndexChanging" PageSize="5" AllowPaging="true" runat="server" ID="dgUnattendedFaults" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="dgUnassignedFaults_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="FaultLogID" HeaderText="Fault Log ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="LocationInformation" HeaderText="Fault Location" />
                            <asp:BoundField DataField="FaultLatitude" HeaderText="Latitude" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="FaultLongitude" HeaderText="Longitude" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" />
                            <asp:BoundField DataField="FaultCategoryName" HeaderText="Fault Category" />
                            <asp:BoundField DataField="TypeDescription" HeaderText="Fault Description" />
                            <asp:BoundField DataField="PriorityDecription" HeaderText="Priority" />
                            <asp:BoundField DataField="employeeName" HeaderText="Employee Name" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="employeeSurname" HeaderText="Employee Surname" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="employeeID" HeaderText="Employee ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="FaultStatusDescription" HeaderText="Status" />
                        </Columns>
                           <PagerStyle CssClass="pagination-Eldon pagination-lg" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
                <div id="assignedFaults" class="tab-pane fade">
                    <br />
                    <asp:GridView runat="server" Visible="false" ID="gvFaultsAttendedTo" OnPageIndexChanging="gvAssignedFaults_PageIndexChanging" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvAssignedFaults_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="FaultLogID" HeaderText="Fault Log ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="LocationInformation" HeaderText="Fault Location" />
                            <asp:BoundField DataField="FaultLatitude" HeaderText="Latitude" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="FaultLongitude" HeaderText="Longitude" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" />
                            <asp:BoundField DataField="FaultCategoryName" HeaderText="Fault Category" />
                            <asp:BoundField DataField="TypeDescription" HeaderText="Fault Description" />
                            <asp:BoundField DataField="PriorityDecription" HeaderText="Priority" />
                            <asp:BoundField DataField="employeeName" HeaderText="Employee Name" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="employeeSurname" HeaderText="Employee Surname" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="employeeID" HeaderText="Employee ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField DataField="FaultStatusDescription" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </div>

            </div>

        </div>
    </form>
    <script>
        $(document).ready(function () {
            $(".nav-tabs a").click(function () {
                $(this).tab('show');
            });
        });
    </script>
</body>
</html>
