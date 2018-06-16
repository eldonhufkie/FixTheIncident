<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="FixTheIncident.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap -->
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" />--%>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Playball" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Rubik" rel="stylesheet" />


</head>
<body style="font-family: 'Rubik', serif;">
    <header class="navbar navbar-default">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="container-fluid">
            <nav class="navbar navbar-default navbar-fixed-top">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar-collapse" aria-haspopup="true" aria-expanded="false">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a href="Login.aspx" class="navbar-brand" style="font-family: 'Playball', cursive; font-size: xx-large">FixTheIncident </a>
                    </div>
                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <%--            <div class="collapse navbar-collapse" id="navbar-collapse">
                            <ul class="nav navbar-nav ">
                                <li class="active alert-info"><a href="MainMenu.aspx">Home</a></li>
                            </ul>
                        </div>--%>
                </div>
            </nav>
        </div>
    </header>

    <form id="form1" runat="server">
        <div class="container">
            <br />
            <br />
            <h1 style="padding-left:35%;" class="h1">Sign In</h1>
            <hr />
            <asp:Label ID="lblErrorMessage" runat="server" Text="" style="padding-left:30%;"  CssClass="text-danger" Visible="true"></asp:Label>
            <div class="row" style="padding-left: 20%;">
                <div class="form-group form-horizontal">
                    <asp:Label ID="Label1" runat="server" Text="Username: " Font-Size="Larger" CssClass="col-md-2 form-control-label"></asp:Label>
                    <div class="col-md-3 input-group">
                        <asp:TextBox ID="txtUsername" CssClass="form-control " runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <%--<br />--%>
            <div class="row" style="padding-left: 20%;">
                <div class="form-group form-horizontal">
                    <asp:Label ID="Label2" runat="server" Text="Password: " Font-Size="Larger" CssClass="col-md-2 form-control-label"></asp:Label>

                    <div class="col-md-3 input-group">
                        <asp:TextBox ID="txtPassword" type="password" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <%--<br />--%>
            <div class="row" style="padding-left: 20%;">
                <div class="col-md-2"></div>
                <div class="col-md-6 col-xs-6 checkbox">
                    <asp:CheckBox runat="server" ID="chkRemeberMe" Font-Size="Larger" CssClass="col-md-6" Text="Remember Me" />
                </div>
            </div>
            <div class="row" style="padding-left: 20%;">
                <div class="col-md-2"></div>
                <div class="btn-group input-group col-md-6 ">
                    <asp:Button runat="server" ID="btnSignIn" Font-Size="Larger" CssClass="btn btn-primary" onclick="btnSignIn_Click" Text="Sign In" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
