<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="FixTheIncident.WebForm3" %>

<!DOCTYPE html>
<html>
<head>
    <title>Place Autocomplete</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" />

    
    <style>
        #map {
            width: 100%;
            height: 400px;
        }
    </style>
</head>
<body>
    <form runat="server" id="form1">
      
        <%--  <br />
    <div class="container">
        <div class="input-group text-justify">
            <input type="text" id="txtSearchInput" class="form-control" placeholder="Search for...">
            <span class="input-group-btn">
                <button class="btn btn-default" type="button">Go!</button>
            </span>
        </div>
    </div>
    <br />
    <div class="container">
        <div id="map" class="container"></div>
        <div id="infowindow-content">
            <img src="" width="16" height="16" id="place-icon">
            <span id="place-name" class="title"></span>
            <br>
            <span id="place-address"></span>
        </div>
      </div>--%>
        <div class="container">
            <div id="accordion" role="tablist" aria-multiselectable="true">
                <div class="card">
                    <div class="card-header" role="tab" id="headingOne">
                        <h5 class="mb-0">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">1. Select a service
                            </a>
                        </h5>
                    </div>

                    <div id="collapseOne" class="collapse show" role="tabpanel" aria-labelledby="headingOne">
                        <div class="card-block">
                            <div class="dropdown">
                                <div class="container">

                                    <div class="row">
                                        <div class="col-md-5 col-sm-4">
                                            <asp:Label runat="server" CssClass="form-control-label">Select a fault category</asp:Label>
                                        </div>
                                        <div class="col-md-7 col-sm-8">
                                            <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle" runat="server" ID="ddlSelectFaultCategory" OnSelectedIndexChanged="ddlSelectFaultCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <br />
                                    <div class="row">
                                        <div class="col-md-5 col-sm-4">
                                            <asp:Label runat="server" CssClass="form-control-label">Select a fault</asp:Label>
                                        </div>
                                        <div class="col-md-7 col-sm-8">

                                            <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle" runat="server" ID="ddlFaultType" OnSelectedIndexChanged="ddlFaultType_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header" role="tab" id="headingTwo">
                        <h5 class="mb-0">
                            <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Collapsible Group Item #2
                            </a>
                        </h5>
                    </div>
                    <div id="collapseTwo" class="collapse" role="tabpanel" aria-labelledby="headingTwo">
                        <div class="card-block">
                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header" role="tab" id="headingThree">
                        <h5 class="mb-0">
                            <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">Collapsible Group Item #3
                            </a>
                        </h5>
                    </div>
                    <div id="collapseThree" class="collapse" role="tabpanel" aria-labelledby="headingThree">
                        <div class="card-block">
                            <div class="container">
                                <div class="input-group">
                                    <input type="text" class="form-control active" id="txtSearchInput" placeholder="Enter your address." />
                                </div>
                                <div id="map" class="container"></div>
                                <div id="infowindow-content">
                                    <img src="" width="16" height="16" id="place-icon">
                                    <span id="place-name" class="title"></span>
                                    <br>
                                    <span id="place-address"></span>
                                </div>
                            </div>
                        </div>
                    </div>
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
