<%@ Page Title="" Language="C#" MasterPageFile="~/FaultMenu.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="FixTheIncident.WebForm1" %>

<asp:Content ContentPlaceHolderID="ResidentMenu" runat="server">
    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <div class="container">
        <section>
            <div class="lead">
                <label>
                    Submit your service request.
                </label>
                <p>
                    The primary goal of service requests is to ensure effective service delivery.
                If you would like to submit a service request, report a fault in your area or log an issue, you can do so via online service requests.
                </p>
                <hr />
                <section>
                    <div class="container">
                        <article class="container lead">
                            <div class="row">
                                <div class="col-sm-6 col-md-4">
                                    <div class="thumbnail">
                                        <a href="LogAFault.aspx" class="success">
                                            <img src="Image/bw-service-request - Copy.png" alt="Create a new service request." />
                                            <div class="caption">
                                                <h2 class="text-center">Create a new service request.</h2>
                                                <p>You can log a new fault here.</p>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-4">
                                    <div class="thumbnail">
                                        <a href="SearchFault.aspx" class="success">
                                            <img src="Image/search.png" alt="Search Service Request." />
                                            <div class="caption">
                                                <h2 class="text-center">Search a service request.</h2>
                                                <p>Search a service request.</p>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </article>
                    </div>
                </section>

            </div>
        </section>
    </div>
    <div class="container">
    </div>
</asp:Content>
