<%@ Page Title="" Language="C#" MasterPageFile="~/LogFault.Master" AutoEventWireup="true" CodeBehind="LogAFault.aspx.cs" Inherits="FixTheIncident.WebForm2" %>


<asp:Content ContentPlaceHolderID="incidentInfo" runat="server" ClientIDMode="Inherit">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <%--<script src="GoogleMapsAPIScript.js" type="text/javascript"></script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script>
        // This example requires the Places library. Include the libraries=places
        // parameter when you first load the API. For example:
        // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">
        var longitude = 0;
        var latitude = 0;
        function initMap() {
            var map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -33.9914, lng: 25.6569 },
                zoom: 13
            });
            var options = {
                componentRestrictions: { country: "za" }
            };
            var input = document.getElementById('<%=txtSearchInput.ClientID%>');

            //map.controls[google.maps.ControlPosition.TOP_RIGHT].push(card);

            var autocomplete = new google.maps.places.Autocomplete(input, options);

            // Bind the map's bounds (viewport) property to the autocomplete object,
            // so that the autocomplete requests use the current map bounds for the
            // bounds option in the request.
            autocomplete.bindTo('bounds', map);

            var infowindow = new google.maps.InfoWindow();
            var infowindowContent = document.getElementById('infowindow-content');
            var latlngbounds = new google.maps.LatLngBounds();
            google.maps.event.addListener(map, 'click', function (e) {
                latitude = e.latLng.lat();
                longitude = e.latLng.lng();
                document.getElementById('<%=HiddenLat.ClientID%>').value = latitude;
                document.getElementById('<%=HiddenLng.ClientID%>').value = latitude;
                <%--alert('Latitude '+document.getElementById('<%=HiddenLat.ClientID%>').value + ', longitude '+longitude)--%>
            })
            google.maps.event.addListener(autocomplete, 'place_changed', function () {
                var place = autocomplete.getPlace();
                var address = place.formatted_address;
                var lat = parseFloat(place.geometry.location.lat());
                var lng = parseFloat(place.geometry.location.lng());
                document.getElementById('<%=HiddenLat.ClientID%>').value = parseFloat(lat);
                document.getElementById('<%=HiddenLng.ClientID%>').value = parseFloat(lng);

                if (place.geometry.viewport) {
                    map.fitBounds(place.geometry.viewport);
                }
                else {

                    map.setCenter(place.geometry.location);
                    map.setZoom(17);
                }
                marker.setPosition(place.geometry.location);
                marker.setVisible(true);
                infowindow.setContent(place.name);
                infowindow.open(map, marker);
                <%--alert('Latitude ' + document.getElementById('<%=HiddenLat.ClientID%>').value + ', longitude ' + document.getElementById('<%=HiddenLng.ClientID%>').value);--%>
            });
            infowindow.setContent(infowindowContent);
            var marker = new google.maps.Marker({
                map: map,
                anchorPoint: new google.maps.Point(0, -29)
            });

            autocomplete.addListener('place_changed', function () {
                infowindow.close();
                marker.setVisible(false);
                var place = autocomplete.getPlace();
                if (!place.geometry) {
                    // User entered the name of a Place that was not suggested and
                    // pressed the Enter key, or the Place Details request failed.
                    window.alert("No details available for input: '" + place.name + "'");
                    return;
                }

                // If the place has a geometry, then present it on a map.
                if (place.geometry.viewport) {
                    map.fitBounds(place.geometry.viewport);
                } else {
                    map.setCenter(place.geometry.location);
                    map.setZoom(17);  // Why 17? Because it looks good.
                }
                marker.setPosition(place.geometry.location);
                marker.setVisible(true);

                var address = '';
                if (place.address_components) {
                    address = [
                      (place.address_components[0] && place.address_components[0].short_name || ''),
                      (place.address_components[1] && place.address_components[1].short_name || ''),
                      (place.address_components[2] && place.address_components[2].short_name || '')
                    ].join(' ');
                }

                //infowindowContent.children['place-icon'].src = place.icon;
                //infowindowContent.children['place-name'].textContent = place.name;
                //infowindowContent.children['place-address'].textContent = address;
                //infowindow.open(map, marker);
            });

            //// Sets a listener on a radio button to change the filter type on Places
            //// Autocomplete.
            //function setupClickListener(id, types) {
            //  var radioButton = document.getElementById(id);
            //  radioButton.addEventListener('click', function() {
            //    autocomplete.setTypes(types);
            //  });
            //}

            //setupClickListener('changetype-all', []);
            //setupClickListener('changetype-address', ['address']);
            //setupClickListener('changetype-establishment', ['establishment']);
            //setupClickListener('changetype-geocode', ['geocode']);

            //document.getElementById('use-strict-bounds')
            //    .addEventListener('click', function() {
            //      console.log('Checkbox clicked! New state=' + this.checked);
            //      autocomplete.setOptions({strictBounds: this.checked});
            //    });
        }
    </script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <asp:HiddenField ID="HiddenLat" runat="server" />
    <asp:HiddenField ID="HiddenLng" runat="server" />
    <div class="container">
        <%--Part 1: Select Service--%>
        <div class="row ">
            <div class="col-lg-12 col-sm-12">
                <h3>1. Service</h3>
                <div class="alert-info" role="alert">
                    <h4>What is the nature of your request?
                        <a href="#" data-toggle="modal" data-target="#myModal" class="text-right right list-inline" title="Please select a fault category and then the desired fault">
                            <span class="glyphicon glyphicon-question-sign  pull-right" aria-hidden="true"></span></a>
                    </h4>
                    <!-- Modal -->
                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="myModalLabel">Selection of faults</h4>
                                </div>
                                <div class="modal-body">
                                    <strong>1.) Select the a category that the perceived fault is associated to.
                                        <br />
                                        2.) Select a fault type from the derived category.
                                    </strong>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="ModalDescription" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="ModalDescriptionLabel">Describing the fault</h4>
                                </div>
                                <div class="modal-body">
                                    <strong>1.) Give a detailed description of what the fault is and any relevant information.
                                    </strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="ModalLocation" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="ModalLocationLabel">Enter the location the fault</h4>
                                </div>
                                <div class="modal-body">
                                    <strong>1.) Type in the desired address of where the fault has occured.
                                    </strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="ModalBio" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="ModalBioLabel">Enter your biographical information.</h4>
                                </div>
                                <div class="modal-body">
                                    <strong>1.) Enter your biographical information in the textboxes below.
                                    </strong>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--populated drop down lists--%>
        <div class="input-group form-control">
            <div class="row">
                <div class="col-md-5 col-sm-4">
                    <label class="text-primary">Fault Category <span class="text-danger">*</span>:</label>
                </div>
                <div class="col-md-7 col-sm-8">
                    <asp:DropDownList CssClass="dropdown form-control" ID="ddlFaultCategory" runat="server" OnSelectedIndexChanged="ddlFaultCategory_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>

                    <%--<asp:DropDownList CssClass="dropdown" ID="ddlFaultType" runat="server" OnSelectedIndexChanged="ddlFaultType_SelectedIndexChanged"></asp:DropDownList>--%>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5 col-sm-4">
                    <label class="text-primary">Fault Type <span class="text-danger">*</span>:</label>
                </div>
                <div class="col-md-7 col-sm-8">
                    <asp:DropDownList CssClass="dropdown form-control" ID="ddlFaultType" OnSelectedIndexChanged="ddlFaultType_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5 col-sm-4">
                    <label id="lblOther" class="text-primary" runat="server">Other <span class="text-danger">*</span>:</label>
                </div>
                <div class="col-md-7 col-sm-8">
                    <asp:TextBox ID="txtOther" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <%--<br />--%>
        </div>

        <%--Part 2: Description--%>
        <div class="row ">
            <div class="col-lg-12 col-sm-12">
                <h3>2. Describe the fault.</h3>
                <div class="alert-info" role="alert">
                    <%--<h4>
                        <span class="glyphicon glyphicon-question-sign" aria-hidden="true">Please describe the fault.</span>
                    </h4>--%>
                    <h4>Please describe the fault
                        <a href="#" data-toggle="modal" data-target="#ModalDescription" class="text-right right list-inline" title="Please describe the fault">
                            <span class="glyphicon glyphicon-question-sign  pull-right" aria-hidden="true"></span></a>
                    </h4>
                </div>
            </div>
        </div>
        <%--Text Area--%>
        <div class="input-group form-control">
            <label for="comment">Describe the fault.<span class="text-danger">*</span></label>
            <%--<textarea class="form-control form-group-lg input-control" rows="5" id="comment"></textarea>--%>
            <asp:TextBox CssClass="form-control input-contol" Rows="5" ID="txtDescription" type="text" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ControlToValidate="txtDescription" ErrorMessage="This field cannot be empty" runat="server"></asp:RequiredFieldValidator>
        </div>


        <%--Part 3: Google Maps--%>
        <div class="row ">
            <div class="col-lg-12 col-sm-12">
                <h3>3. Where is this fault located?</h3>
                <div class="alert-info" role="alert">
                    <%--<h4>
                        <span class="glyphicon glyphicon-question-sign" aria-hidden="true">Where is the fault situated?</span>
                    </h4>--%>
                    <h4>Where is the fault situated?
                        <a href="#" data-toggle="modal" data-target="#ModalLocation" class="text-right right list-inline" title="Where is the fault situated?">
                            <span class="glyphicon glyphicon-question-sign  pull-right" aria-hidden="true"></span></a>
                    </h4>
                </div>
            </div>
        </div>
        <%--Map Area & Textbox--%>
        <div class="form-control input-group">
            <div class="input-group form-group center-block ">
                <%--<input type="text" placeholder="Enter your location" class="form-control" id="txtSearchInput" name="txtSearchInput" size="50" />--%>
                <asp:TextBox runat="server" ID="txtSearchInput" CssClass="form-control" placeholder="Enter your location" type="text"></asp:TextBox><span class="text-danger">*</span>
                <asp:RequiredFieldValidator ControlToValidate="txtSearchInput" ErrorMessage="This field cannot be empty" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div id="map" style="width: 100%; height: 300px;"></div>
        </div>

        <%--Part 4: Biographical Information--%>
        <div class="row ">
            <div class="col-lg-12 col-sm-12">
                <h3>4. Enter your contact information</h3>
                <div class="alert-info" role="alert">
                    <%--   <h4>
                        <span class="glyphicon glyphicon-question-sign" aria-hidden="true">Please enter your contact details.</span>
                    </h4>--%>
                    <h4>Please enter your contact details
                        <a href="#" data-toggle="modal" data-target="#ModalBio" class="text-right right list-inline" title="Please enter your contact details">
                            <span class="glyphicon glyphicon-question-sign  pull-right" aria-hidden="true"></span></a>
                    </h4>
                </div>
            </div>
        </div>
        <%--Map Area & Textbox--%>
        <div class="row">
            <div class="col-md-5 col-sm-4">
                <h4 class="text-primary">First Name<span class="text-danger">*</span>:</h4>
            </div>
            <div class="col-md-7 col-sm-8">
                <div class="form-control input-group">
                    <%--<input type="text" id="txtName" class="form-control input-sm" />--%>
                    <asp:TextBox CssClass="form-control input-sm" runat="server" placeholder="First Name" ID="txtName"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtName" ForeColor="Red" CssClass="alert-danger alert-link" ErrorMessage="This field cannot be empty" runat="server"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5 col-sm-4">
                <h4 class="text-primary">Last Name<span class="text-danger">*</span>:</h4>
            </div>
            <div class="col-md-7 col-sm-8">
                <div class="form-control input-group">
                    <%--<input type="text" id="txtSurname" class="form-control input-sm" />--%>
                    <asp:TextBox CssClass="form-control input-sm" runat="server" placeholder="Surname" ID="txtSurname"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtSurname" ForeColor="Red" ErrorMessage="This field cannot be empty" runat="server"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5 col-sm-4">
                <h4 class="text-primary">E-mail Address<span class="text-danger">*</span>:</h4>
            </div>
            <div class="col-md-7 col-sm-8">
                <div class="form-control input-group">
                    <%--<input type="email" id="txtemail" class="form-control input-sm" />--%>
                    <asp:TextBox CssClass="form-control input-sm" runat="server" placeholder="E-Mail Address" ID="txtemailAddress"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtemailAddress" ForeColor="Red" ErrorMessage="This field cannot be empty" runat="server"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ControlToValidate="txtemailAddress" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please enter valid E-mail address!" runat="server"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5 col-sm-4">
                <h4 class="text-primary">Phone Number<span class="text-danger">*</span>:</h4>
            </div>
            <div class="col-md-7 col-sm-8">
                <div class="form-control input-group">
                    <%--<input type="text" id="txtPhoneNumber" class="form-control input-sm" />--%>
                    <asp:TextBox CssClass="form-control input-sm" runat="server" placeholder="Phone Number" ID="txtPhoneNo"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtPhoneNo" ForeColor="Red" ErrorMessage="This field cannot be empty" runat="server"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="txtPhoneNo" ErrorMessage="The number doesn't meet the lenth requirements"
                        ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>
        <%--<div class="row">
            <div class="col-md-5 col-sm-4">
                <h3 class="text-primary">Fault Type:</h3>
            </div>
            <div class="col-md-7 col-sm-8">
                <div class="form-control input-group">
                    <input type="text" id="txtSurname" class="form-control input-sm" />
                </div>
            </div>
        </div>--%>
        <br />
        <div class="row">
            <div class="col-md-5 col-sm-4">
                <h3 class="text-primary"></h3>
            </div>
            <div class="col-md-7 col-sm-8">
                <div class="form-control input-group">
                    <asp:Button runat="server" ID="btnAddFault" Text="Submit" OnClick="btnAddFault_Click" CssClass="form-control" />
                </div>
                <br />
                <br />

            </div>
        </div>
    </div>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBDsEXDpnekH-CCqnCltaUHRSHp80MSJcU&libraries=places&callback=initMap"
        async defer></script>
    <%--<script src="Scripts/GoogleMaps.js" type="text/javascript"></script>--%>
</asp:Content>
