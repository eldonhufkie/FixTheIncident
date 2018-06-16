<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="FixTheIncident.WebForm14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="helpDeskAnalyst" runat="server">

    <div class="container">
        <h2>Add Employee</h2>
        <br />
        <div class="row">
            <div class="col-md-8">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label1" CssClass="h4" runat="server" Text="First Name:"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label2" CssClass="h4" runat="server" Text="Surname:"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtSurname" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label3" CssClass="h4" runat="server" Text="ID Number:"></asp:Label>
            </div>
            <div class="col-md-4 col-sm-6">
                <asp:TextBox ID="txtIDNumber" CssClass="form-control" OnTextChanged="txtIDNumber_TextChanged" runat="server" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label4" CssClass="h4" runat="server" Text="E-mail Address:"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmail" OnTextChanged="txtEmail_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label5" CssClass="h4" runat="server" Text="Phone Number:"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPhone" CssClass="form-control" OnTextChanged="txtPhone_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label6" CssClass="h4" runat="server" Text="Address Line 1:"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtAddressLineOne" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label7" CssClass="h4" runat="server" Text="Address Line 2:"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtAddressLineTwo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label8" CssClass="h4" runat="server" Text="Suburb:    "></asp:Label>
                <a href="#" data-toggle="modal" data-target="#ModalSuburb" class="text-right right list-inline" title="If the new employee stays in a region where no suburb is given, add the city or town where they currently reside in.">
                    <span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span></a>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtSuburb" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="modal fade" id="ModalSuburb" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ModalDescriptionLabel">Not sure about your suburb?</h4>
                    </div>
                    <div class="modal-body">
                        <strong>If the new employee stays in a region where no suburb is given, add the city or town where they currently reside in.
                        </strong>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label9" CssClass="h4" runat="server" Text="City:"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label10" CssClass="h4" runat="server" Text="Postal Code:"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPostalCode" OnTextChanged="txtPostalCode_TextChanged" AutoPostBack="true"    CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label11" CssClass="h4" runat="server" Text="Employee Type:"></asp:Label>
            </div>
            <div class="col-md-4 col-sm-8">
                <asp:DropDownList CssClass="dropdown form-control" OnSelectedIndexChanged="ddlEmployeeType_SelectedIndexChanged" ID="ddlEmployeeType" runat="server" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lblExpertise" CssClass="h4" runat="server" Text="Expertise:"></asp:Label>
            </div>
            <div class="col-md-4 col-sm-8">
                <asp:DropDownList CssClass="dropdown form-control" ID="ddlExpertiseList" runat="server"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnAddEmployee" CssClass="btn btn-block btn-primary" Text="Submit" OnClick="btnAddEmployee_Click" runat="server" />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
