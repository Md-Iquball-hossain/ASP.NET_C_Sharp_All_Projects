<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transports.aspx.cs" Inherits="TravelToure_Project.Info.Transports" %>

<%@ Register Src="~/Info/TransportControl.ascx" TagPrefix="uc1" TagName="TransportControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <uc1:TransportControl runat="server" id="TransportControl" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
