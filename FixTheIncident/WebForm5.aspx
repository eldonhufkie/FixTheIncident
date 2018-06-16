<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="FixTheIncident.WebForm5" %>

<!DOCTYPE html>
<html>
<head>
    <title>Place Autocomplete</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />



    <style>
        #map {
            width: 100%;
            height: 400px;
        }
    </style>
</head>
<body>
    <form runat="server" id="form1">
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-sm-9">
                    <h2>Logged Faults</h2>
                </div>
            </div>
            <%--Sorting--%>
            <%-- <div class="row">
                <div class="row" style="padding-bottom: 10px;">
                    <div class="col-lg-12">
                        <div class="btn-group">
                            <button type="button" class="btn btn-default dropdown-toggle btn-sm btn-warning" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Filter <span>
                                    <img src="/Images/filter-icon.png" style="height: 15px; width: 15px;" /></span>
                            </button>
                            <ul class="dropdown-menu">
                                <li class="dropdown-header">Date</li>
                                <li role="separator" class="divider"></li>
                                <li><a id="btnDateAscending" href="#" runat="server">Date Ascending</a></li>
                                <li><a id="btnDateDescending" href="#" runat="server">Date Descending</a></li>
                                <li role="separator" class="divider"></li>
                                <li class="dropdown-header">Category</li>
                                <li role="separator" class="divider"></li>
                                <asp:ListView ID="lvFaultCategoris" runat="server" DataKeyNames="fCategoryID" OnSelectedIndexChanging="lvFaultCategoris_SelectedIndexChanging">
                                    <ItemTemplate>
                                        <li>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Select" CssClass="pull-left"><%# DataBinder.Eval(Container.DataItem, "fCategory")%></asp:LinkButton></li>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ul>
                            <button id="btnFilterBack" type="button" class="btn btn-default btn-sm btn-warning" runat="server">Back</button>
                        </div>
                    </div>
                </div>
            </div>--%>

            <%-- <asp:ListView ID="lvLoggedPosts" runat="server" DataKeyNames="FaultID">
                <EmptyDataTemplate>
                    <div style="text-align:center">
                        <h4>No Logged Faults</h4>
                    </div>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <div class="row">
                        <div class="col-lg-4 col-md-4" id="itemplaceholder" runat="server">
                        </div>
                    </div>
                    <br />
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-lg-4 col-md-4">
                        <div class="thumbnail">
                            <div class="img-thumbnail">--%>
            <%--Add Image--%>
            <%--  </div>
                            <div class="caption">
                                <div class="row">
                                    <div class="col-xs-7">
                                        <asp:Label runat="server" ID="lblCategory">
                                             <%# DataBinder.Eval(Container.DataItem, "LocationDescription")%>
                                        </asp:Label>
                                        <br />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>--%>
            <%--</asp:ListView>--%>

            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#unassignedFaults">Unassigned Faults</a></li>
                <li><a data-toggle="tab" href="#assignedFaults">Assigned Faults</a></li>
            </ul>
            <div class="tab-content">
                <br />
                <div id="unassignedFaults" class="tab-pane fade in active">
                   <%-- <asp:GridView runat="server" ID="dgUnassignedFaults" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false" >
                    </asp:GridView>--%>
                    <asp:GridView runat="server" ID="dgUnassignedFaults" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="dgUnassignedFaults_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="Fault Category Name" HeaderText="Fault Category Name" />
                            <asp:BoundField DataField="Fault Type" HeaderText="Fault Type" />
                            <asp:BoundField DataField="Fault Description" HeaderText="Fault Description" />
                            <asp:BoundField DataField="Fault Location" HeaderText="Fault Location" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div id="assignedFaults" class="tab-pane fade in active">
                   <%-- <asp:GridView runat="server" ID="dgUnassignedFaults" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false" >
                    </asp:GridView>--%>
                    <asp:GridView runat="server" ID="gvAssignedFaults" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="dgUnassignedFaults_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="Fault Category Name" HeaderText="Fault Category Name" />
                            <asp:BoundField DataField="Fault Type" HeaderText="Fault Type" />
                            <asp:BoundField DataField="Fault Description" HeaderText="Fault Description" />
                            <asp:BoundField DataField="Fault Location" HeaderText="Fault Location" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>

</body>
<script src="https://code.jquery.com/jquery-3.1.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/js/bootstrap.min.js"></script>
<script src="Scripts/GoogleMaps.js" type="text/javascript"></script>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBDsEXDpnekH-CCqnCltaUHRSHp80MSJcU&callback=initMap"></script>
</html>
