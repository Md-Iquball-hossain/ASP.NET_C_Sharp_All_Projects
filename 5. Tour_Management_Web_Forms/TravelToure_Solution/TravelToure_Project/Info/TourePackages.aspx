<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TourePackages.aspx.cs" Inherits="TravelToure_Project.TourePackages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class=" row">
        <div class="col-12">
            <h1 class="text-center mt-5">Tour Packages</h1>
            <span><a class="btn btn-outline-primary mb-3" href="AddPackage.aspx">Add New</a></span>
            <asp:GridView CssClass="table table-bordered text-center" ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="dsTourePackages" PageSize="5" DataKeyNames="PackageId">
                <HeaderStyle CssClass="text-dark text-center" />
                <Columns>

                    <asp:TemplateField HeaderText="PackageName" SortExpression="PackageName">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="Edit" CssClass="form-control" ID="TextBox1" runat="server" Text='<%# Bind("PackageName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Edit" ControlToValidate="TextBox1" CssClass="text-danger" Text="Package Name is required" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Package Name is required"></asp:RequiredFieldValidator>


                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("PackageName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PackageCatagory" SortExpression="PackageCatagory">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="Edit" CssClass="form-control" ID="TextBox2" runat="server" Text='<%# Bind("PackageCatagory") %>'></asp:TextBox>

                            <asp:RequiredFieldValidator ValidationGroup="Edit" ControlToValidate="TextBox2" CssClass="text-danger" Text="Package Catagory is required" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Package Catagory is required"></asp:RequiredFieldValidator>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("PackageCatagory") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PackageCost" SortExpression="PackageCost">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="Edit" CssClass="form-control" ID="TextBox3" runat="server" Text='<%# Bind("PackageCost") %>'></asp:TextBox>

                            <asp:RequiredFieldValidator ValidationGroup="Edit" ControlToValidate="TextBox3" CssClass="text-danger" Text="Package Cost is required" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Package Cost is required"></asp:RequiredFieldValidator>
                            <asp:CompareValidator CssClass="text-danger" ControlToValidate="TextBox3" ValidationGroup="Edit" Type="Double" Operator="DataTypeCheck" ID="CompareValidator1" runat="server" ErrorMessage="Must be Number"></asp:CompareValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("PackageCost","{0:0.00}") %>'></asp:Label>


                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Touredate" SortExpression="Touredate">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="Edit" CssClass="form-control date" ID="TextBox4" runat="server" Text='<%# Bind("Touredate","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Edit" ControlToValidate="TextBox4" CssClass="text-danger" Text=" Touredate is required" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Touredate: is required"></asp:RequiredFieldValidator>


                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Touredate","{0:yyyy-MM-dd}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Active" SortExpression="Active">
                        <EditItemTemplate>
                            <asp:CheckBox CssClass="form-check" ID="ActiveCheckBox" runat="server" Checked='<%# Bind("Active")%>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agent" SortExpression="AgentId">
                        <EditItemTemplate>
                            <asp:DropDownList SelectedValue='<%# Bind("AgentId") %>' AppendDataBoundItems="true" DataSourceID="dsAgent" DataTextField="AgentName" DataValueField="AgentId" CssClass="form-select" ID="DropDownList1" runat="server">
                                <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="DropDownList1" CssClass="text-danger" Text="Agent is required" ID="RequiredFieldValidator6" runat="server" ErrorMessage=" Agent is required"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="publisherId" runat="server" Text='<%# Bind("AgentName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="200px" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ValidationGroup="Edit" CssClass="btn btn-outline-success btn-sm" ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-secondary btn-sm" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-warning" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-danger" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>

                        </ItemTemplate>

<ItemStyle Width="200px"></ItemStyle>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
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
