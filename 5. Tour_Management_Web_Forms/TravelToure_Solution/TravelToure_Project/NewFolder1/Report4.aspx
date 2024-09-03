<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report4.aspx.cs" Inherits="TravelToure_Project.NewFolder1.Report4" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"  Height="50px" ReportSourceID="CrystalReportSource1" ToolPanelWidth="200px" Width="350px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="NewFolder1\CrystalReport4.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
