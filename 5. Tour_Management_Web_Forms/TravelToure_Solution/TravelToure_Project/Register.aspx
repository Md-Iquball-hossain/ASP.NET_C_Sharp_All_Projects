<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TravelToure_Project.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12 mt-5">
            <h3>Register</h3>
            <div class="alert alert-warning alert-dismissible fade show" role="alert" id="alert" runat="server" visible="false">
                <strong>Error!</strong> Registration failed.
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
            <div class="form-group row mb-1">
                <label class="col-form-label col-form-label-sm col-2 text-end">
                    Username
                </label>
                <div class="col-4">
                    <asp:TextBox ID="username" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger small" ID="RequiredFieldValidator1" ControlToValidate="username" runat="server" ErrorMessage="Username is required." Text="Username is required."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group row mb-1">
                <label class="col-form-label col-form-label-sm col-2 text-end">
                    Password
                </label>
                <div class="col-4">
                    <asp:TextBox TextMode="Password" ID="password" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger small" ID="RequiredFieldValidator2" ControlToValidate="password" runat="server" ErrorMessage="Password is required." Text="Password is required."></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="form-group row mb-1">
                <label class="col-form-label col-form-label-sm col-2 text-end">
                   Re-type Password
                </label>
                <div class="col-4">
                    <asp:TextBox TextMode="Password" ID="confirmPassword" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger small" ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="confirmPassword" runat="server" ErrorMessage="Password is required." Text="Password is required."></asp:RequiredFieldValidator>
                    <asp:CompareValidator  ControlToValidate="confirmPassword" ControlToCompare="password" Operator="Equal" Type="String" ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match." Text="Passwords do not match."></asp:CompareValidator>
                </div>
            </div>
            <div class="form-group row mb-1">
                
                <div class="col-4 offset-2 ">
                    <asp:Button ID="Button1" CssClass="btn btn-primary btn-sm" runat="server" Text="Register" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
