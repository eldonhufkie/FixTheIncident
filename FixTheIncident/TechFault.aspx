﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TechFault.Master" AutoEventWireup="true" CodeBehind="TechFault.aspx.cs" Inherits="FixTheIncident.TechFault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TechFault" runat="server">
    <asp:HiddenField ID="HiddenLat" runat="server" />
    <asp:HiddenField ID="HiddenLng" runat="server" />
    <script type="text/javascript">
        function initMap() {
            var lat = document.getElementById('<%=HiddenLat.ClientID%>').value;
            var lng = document.getElementById('<%=HiddenLng.ClientID%>').value;
            var myCenter = new google.maps.LatLng(lat, lng);
            var mapProp = {
                center: myCenter,
                zoom: 17,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var mapInit = new google.maps.Map(document.getElementById("map"), mapProp);
            var marker = new google.maps.Marker({
                position: myCenter,
                title: 'Click to zoom'
            });
            marker.setMap(mapInit);
        }
        <%--       $('<%=txtSearchFault.ClientID%>').on('click', initMap);--%>
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <div class="container">
        <div class="row">
            <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-4 col-xs-4">
                <h4 class="pull-left" runat="server">Status:</h4>
            </div>
            <div class="col-md-4 col-sm-4">
                <%--logged fault details--%>
                <%--<h4 class="text-primary">Reference Number:</h4><span>--%>
                <h4 class="alert-primary text-center active" runat="server" style="word-wrap: break-word;">Reference Number:</h4>
            </div>
            <div class="col-md-4 col-xs-4">
                <h4 class="pull-right" runat="server">Date Logged:</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-xs-4">
                <h4 class="pull-left" id="lblStatus" runat="server"></h4>
            </div>

            <div class="col-md-4 col-sm-4">
                <%--logged fault details--%>
                <%--<h4 class="text-primary">Reference Number:</h4><span>--%>
                <h4 class="alert-primary text-center" runat="server" id="lblReferenceNumber" style="word-wrap: break-word;"></h4>
            </div>
            <div class="col-md-4 col-xs-4">
                <h4 class="pull-right" id="lblDate" runat="server"></h4>
            </div>
        </div>

        <%--Part 1: Resident Details--%>
        <div class="row ">
            <div class="col-lg-6 col-sm-6">
                <%--populated drop down lists--%>
                <%--panel--%>

                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4>Resident Details:</h4>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-5 col-sm-4">
                                <p class="text-primary">Resident Name:</p>
                            </div>
                            <div class="col-md-7 col-sm-8">
                                <%--logged fault details--%>
                                <p class="alert-primary" runat="server" id="lblResidentName"></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5 col-sm-4">
                                <p class="text-primary">Resident Surname:</p>
                            </div>
                            <div class="col-md-7 col-sm-8">
                                <%--logged fault details--%>
                                <p class="alert-primary" runat="server" id="lblResidentSurname"></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5 col-sm-4">
                                <p class="text-primary">Resident E-Mail Address:</p>
                            </div>
                            <div class="col-md-7 col-sm-8">
                                <%--logged fault details--%>
                                <p class="alert-primary" runat="server" id="lblEmail"></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5 col-sm-4">
                                <p class="text-primary">Resident Phone Number:</p>
                            </div>
                            <div class="col-md-7 col-sm-8">
                                <%--logged fault details--%>
                                <p class="alert-primary" runat="server" id="lblPhoneNo"></p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-sm-6">
                <%--FAULT DETAILS--%>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4>Fault Details:</h4>
                    </div>
                    <h5 class="label-info pull-right" id="H1" runat="server"></h5>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-5 col-sm-4">
                                <p class="text-primary">Fault Category:</p>
                            </div>
                            <div class="col-md-7 col-sm-8">
                                <%--logged fault details--%>
                                <p class="alert-primary" runat="server" id="lblFaultCategory"></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5 col-sm-4">
                                <p class="text-primary">Fault Type:</p>
                            </div>
                            <div class="col-md-7 col-sm-8">
                                <%--logged fault details--%>
                                <p class="alert-primary" runat="server" id="lblFaultType"></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5 col-sm-4">
                                <p class="text-primary">Fault Description:</p>
                            </div>
                            <div class="col-md-7 col-sm-8">
                                <%--logged fault details--%>
                                <p class="alert-primary" runat="server" id="lblFaultDescription"></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5 col-sm-4">
                                <p class="text-primary">Fault Location:</p>
                            </div>
                            <div class="col-md-7 col-sm-8">
                                <%--logged fault details--%>
                                <p class="alert-primary" runat="server" id="lblFaultLocation"></p>
                            </div>
                        </div>
                        <%-- <div class="row">
                            
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                <h4>Location</h4>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div id="map" style="width: 100%; height: 250px;"></div>
                </div>
            </div>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3>Comment: </h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-8">
                        <p>Comment any additional information about the fault</p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <textarea id="txtComment" runat="server" cols="20" rows="2" class="form-control text-info"></textarea>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3>Fault Status</h3>
            </div>
            <div class="panel-body">
                <div class="col-md-3">
                    <p>Status</p>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlStatus" CssClass="dropdown" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                </div>
                <div class="row" style="padding-right: 5px;">
                    <div class="col-md-12 ">
                        <asp:Button runat="server" ID="btnUpdateorClose" CssClass="btn btn-info pull-right" Text="Update" OnClick="btnUpdateorClose_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBDsEXDpnekH-CCqnCltaUHRSHp80MSJcU&libraries=places&callback=initMap"
        async defer></script>
</asp:Content>
