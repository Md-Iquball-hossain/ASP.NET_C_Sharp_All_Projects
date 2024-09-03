<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPackage.aspx.cs" Inherits="TravelToure_Project.Info.AddPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link href="Content/bootstrap-datepicker.standalone.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class=" row">
        <div class="col-12">
            <asp:ValidationSummary CssClass="text-danger text-decoration-none" ValidationGroup="ins" ID="ValidationSummary1" runat="server" />
            <h3 class="m-5">Add New Packages</h3>
            <asp:FormView runat="server" AllowPaging="True" DataKeyNames="PackageId" DataSourceID="dsTourePackages" DefaultMode="Insert" RenderOuterTable="False">

                <InsertItemTemplate>

                    <div class="form-group row mb-1">
                        <label class="col-form-label col-2">
                            PackageName
                        </label>
                        <div class="col-4">
                            <asp:TextBox CssClass="form-control" ID="PackageNameTextBox" runat="server" Text='<%# Bind("PackageName")%>' />
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="PackageNameTextBox" CssClass="text-danger" Text="Package Name is required" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Package Name is required"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group row mb-1">
                        <label class="col-form-label col-2">
                            PackageCatagory
                        </label>
                        <div class="col-4">
                            <asp:TextBox CssClass="form-control" ID="PackageCatagoryTextBox" runat="server" Text='<%# Bind("PackageCatagory")%>' />
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="PackageCatagoryTextBox" CssClass="text-danger" Text="Package Catagory is required" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Package Catagory is required"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group row mb-1">
                        <label class="col-form-label col-2">
                            PackageCost
                        </label>
                        <div class="col-4">
                            <asp:TextBox CssClass="form-control" ID="PackageCostTextBox" runat="server" Text='<%# Bind("PackageCost")%>' />
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="PackageCostTextBox" CssClass="text-danger" Text="Package Cost is required" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Package Cost is required"></asp:RequiredFieldValidator>
                            <asp:CompareValidator CssClass="text-danger" ControlToValidate="PackageCostTextBox" ValidationGroup="ins" Type="Double" Operator="DataTypeCheck" ID="CompareValidator1" runat="server" ErrorMessage="Must be Number"></asp:CompareValidator>
                        </div>


                        <div class="form-group row mb-1">
                            <label class="col-form-label col-2">
                                Active:
                            </label>
                            <div class="col-4">
                                <asp:CheckBox ValidationGroup="ins" CssClass="form-check" ID="ActiveCheckBox" runat="server" Checked='<%# Bind("Active")%>' />

                            </div>

                            <div class="form-group row mb-1">
                                <label class="col-form-label col-2">
                                    Touredate:
                                </label>
                                <div class="col-4">
                                    <asp:TextBox CssClass="form-control date" ID="TouredateTextBox" runat="server" Text='<%# Bind("Touredate") %>' />
                                    <asp:CompareValidator Display="Dynamic" ValidationGroup="ins" CssClass="text-danger" ID="CompareValidator2" Operator="DataTypeCheck" Type="Date" ControlToValidate="TouredateTextBox" runat="server" ErrorMessage="Date Invalid"></asp:CompareValidator>

                                    <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="TouredateTextBox" CssClass="text-danger" Text=" Touredate is required" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Touredate: is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group row mb-1">
                                <label class="col-form-label col-2">
                                    Agent
                                </label>
                                <div class="col-4">
                                    <asp:DropDownList SelectedValue='<%# Bind("AgentId") %>' AppendDataBoundItems="true" DataSourceID="dsAgent" DataTextField="AgentName" DataValueField="AgentId" CssClass="form-select" ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="DropDownList1" CssClass="text-danger" Text="Agent is required" ID="RequiredFieldValidator6" runat="server" ErrorMessage=" Agent is required"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class=" offset-2 col-12">
                                <asp:LinkButton CssClass="btn btn-outline-primary" ValidationGroup="ins" ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                                <asp:LinkButton CssClass="btn btn-outline-secondary" ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                            </div>
                </InsertItemTemplate>
            </asp:FormView>
        </div>
    </div>
    <asp:SqlDataSource ID="dsTourePackages" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [TourePackages] WHERE [PackageId] = @PackageId" InsertCommand="INSERT INTO [TourePackages] ([PackageName], [PackageCatagory], [PackageCost], [Active], [Touredate], [AgentId]) VALUES (@PackageName, @PackageCatagory, @PackageCost, @Active, @Touredate, @AgentId)" SelectCommand="SELECT TourePackages.PackageId, TourePackages.PackageName, TourePackages.PackageCatagory, TourePackages.PackageCost, TourePackages.Active, TourePackages.Touredate, TourePackages.AgentId, Travelagents.AgentName FROM TourePackages INNER JOIN Travelagents ON TourePackages.AgentId = Travelagents.AgentId" UpdateCommand="UPDATE [TourePackages] SET [PackageName] = @PackageName, [PackageCatagory] = @PackageCatagory, [PackageCost] = @PackageCost, [Active] = @Active, [Touredate] = @Touredate, [AgentId] = @AgentId WHERE [PackageId] = @PackageId">
        <DeleteParameters>
            <asp:Parameter Name="PackageId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="PackageName" Type="String" />
            <asp:Parameter Name="PackageCatagory" Type="String" />
            <asp:Parameter Name="PackageCost" Type="Decimal" />
            <asp:Parameter Name="Active" Type="Boolean" />
            <asp:Parameter DbType="Date" Name="Touredate" />
            <asp:Parameter Name="AgentId" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="PackageName" Type="String" />
            <asp:Parameter Name="PackageCatagory" Type="String" />
            <asp:Parameter Name="PackageCost" Type="Decimal" />
            <asp:Parameter Name="Active" Type="Boolean" />
            <asp:Parameter DbType="Date" Name="Touredate" />
            <asp:Parameter Name="AgentId" Type="Int32" />
            <asp:Parameter Name="PackageId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsAgent" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Travelagents]"></asp:SqlDataSource>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script src="Scripts/jquery-3.6.3.js"></script>
    <script src="Scripts/bootstrap-datepicker.js"></script>
    <script>
        $(".date").datepicker({
            format: 'yyyy-mm-dd'
        });
    </script>
</asp:Content>
