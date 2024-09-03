<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Travelagents.aspx.cs" Inherits="TravelToure_Project.Info.Travelagents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container row">
        <div class="col-12">
             <h1 class="text-center mt-5">Travel Agent</h1>
            <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" DataKeyNames="AgentId" InsertItemPosition="LastItem">

                <EditItemTemplate>
                    <tr style="background-color: lightyellow;">

                        <td>
                            <asp:Label ID="AgentIdLabel1" runat="server" Text='<%# Eval("AgentId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ValidationGroup="update" CssClass="form-control" ID="AgentNameTextBox2" runat="server" Text='<%# Bind("AgentName") %>' />
                            <asp:RequiredFieldValidator ValidationGroup="update" CssClass="text-danger" ControlToValidate="AgentNameTextBox2" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is Required"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ValidationGroup="update" CssClass="btn btn-outline-success" ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button CssClass="btn btn-outline-secondary" ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: red; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td></td>
                        <td>
                            <asp:TextBox ValidationGroup="insert" CssClass="form-control" ID="AgentNameTextBox" runat="server" Text='<%# Bind("AgentName") %>' />
                            <asp:RequiredFieldValidator ValidationGroup="insert" CssClass="text-danger" ControlToValidate="AgentNameTextBox" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is Required"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-outline-primary" ValidationGroup="insert" ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button CssClass="btn btn-outline-secondary" ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: lightcyan; color: #333333;">

                        <td>
                            <asp:Label ID="AgentIdLabel" runat="server" Text='<%# Eval("AgentId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AgentNameLabel" runat="server" Text='<%# Eval("AgentName") %>' />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-outline-warning" ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button CssClass="btn btn-outline-danger" ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table class="table" runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table class="table table-bordered table-hover" id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color: #E0FFFF; color: #333333;">

                                        <th class="text-center" runat="server">AgentId</th>
                                        <th class="text-center" runat="server">AgentName</th>
                                        <th class="text-center" runat="server"></th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: transparent; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="10">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonCssClass="btn text-bg-dark" ButtonType="Button" ShowFirstPageButton="false" ShowLastPageButton="false" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>

            </asp:ListView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="TravelToure_Project.Models.Travelagent" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Get" TypeName="TravelToure_Project.Models.TravelagentRepo" UpdateMethod="Update"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
