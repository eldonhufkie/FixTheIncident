<%@ Page Title="" Language="C#" MasterPageFile="~/FaultMenu.Master" AutoEventWireup="true" CodeBehind="SearchFault.aspx.cs" Inherits="FixTheIncident.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ResidentMenu" runat="server">
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
        $('<%=txtSearchFault.ClientID%>').on('click', initMap);
    </script>
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-s7">
                <h4>Enter reference number: </h4>
            </div>
            <div class="col-lg-4 col-sm-7">
                <div class="form-group input-group">
                    <asp:TextBox runat="server" ID="txtSearchFault" onKeyUp="KeyReleased()" CssClass="text-info form-control" Width="600px" placeholder="Enter reference number">
                    </asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button runat="server" ID="btnSearchFault" CssClass="btn btn-default" type="button" Text="Search" OnClick="btnSearchFault_Click" />
                    </span>
                </div>
            </div>
        </div>
        <div class="row">
        </div>
        <br />
        <asp:GridView runat="server" CssClass="table table-striped table-bordered table-condensed" Font-Size="Large" ID="gvSearchResults" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="FaultCategoryName" HeaderText="Fault Category" Visible="true" />
                <asp:BoundField DataField="TypeDescription" HeaderText="Fault Type" Visible="true" />
                <asp:BoundField DataField="FaultLogDescription" HeaderText="Fault Description" Visible="true" />
                <asp:BoundField DataField="LocationInformation" HeaderText="Fault Location" Visible="true" />
                <asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" Visible="true" />
                <asp:BoundField DataField="FaultLatitude" HeaderText="Fault Latitude" Visible="false" />
                <asp:BoundField DataField="FaultLongitude" HeaderText="Fault Longitude" Visible="false" />
            </Columns>
        </asp:GridView>
        <br />
        <div id="map" style="height: 400px; width: 100%"></div>
        <br />
        <div class="panel panel-info">
            <div class="panel-heading">
                <h4>Comments: </h4>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-sm-4">
                        <asp:Label ID="lblCommentDate" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblCommentText" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenLat" runat="server" />
    <asp:HiddenField ID="HiddenLng" runat="server" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBDsEXDpnekH-CCqnCltaUHRSHp80MSJcU&libraries=places&callback=initMap"
        async defer></script>


</asp:Content>
