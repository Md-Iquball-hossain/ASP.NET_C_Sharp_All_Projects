<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebMasterD.aspx.cs" Inherits="TravelToure_Project.Info.WebMasterD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-12">
            <h1 class="text-center mt-5">Tour Packages</h1>
            <asp:GridView CssClass="table table-bordered" ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="PackageId" DataSourceID="dsPackage" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="Package" InsertVisible="False" SortExpression="PackageId">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("PackageId") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("PackageId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package Name" SortExpression="PackageName">
                        <EditItemTemplate>
                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" Text='<%# Bind("PackageName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("PackageName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package Catagory" SortExpression="PackageCatagory">
                        <EditItemTemplate>
                            <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" Text='<%# Bind("PackageCatagory") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("PackageCatagory") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package Cost" SortExpression="PackageCost">
                        <EditItemTemplate>
                            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" Text='<%# Bind("PackageCost") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("PackageCost","{0:0.00}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Active" SortExpression="Active">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Active") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Active") %>' Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Toure Date" SortExpression="Touredate">
                        <EditItemTemplate>
                            <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" Text='<%# Bind("Touredate","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Touredate","{0:yyyy-MMM-dd}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agent" SortExpression="AgentId">
                        <EditItemTemplate>
                            <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" Text='<%# Bind("AgentId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("AgentName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-success" ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-secondary" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-warning" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-info" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-danger" ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <asp:SqlDataSource ID="dsPackage" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [TourePackages] WHERE [PackageId] = @PackageId" InsertCommand="INSERT INTO [TourePackages] ([PackageName], [PackageCatagory], [PackageCost], [Active], [Touredate], [AgentId]) VALUES (@PackageName, @PackageCatagory, @PackageCost, @Active, @Touredate, @AgentId)" SelectCommand="SELECT TourePackages.PackageId, TourePackages.PackageName, TourePackages.PackageCatagory, TourePackages.PackageCost, TourePackages.Active, TourePackages.Touredate, TourePackages.AgentId, Travelagents.AgentName FROM TourePackages INNER JOIN Travelagents ON TourePackages.AgentId = Travelagents.AgentId" UpdateCommand="UPDATE [TourePackages] SET [PackageName] = @PackageName, [PackageCatagory] = @PackageCatagory, [PackageCost] = @PackageCost, [Active] = @Active, [Touredate] = @Touredate, [AgentId] = @AgentId WHERE [PackageId] = @PackageId">
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
    <div class="row">
        <div class="col-12">
            <h1 class="text-center mt-5">Tourists</h1>
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="TouristId" DataSourceID="dsTourists" InsertItemPosition="LastItem">

                <EditItemTemplate>
                    <tr style="background-color: lightcyan; color: #FFFFFF;">
                        <td>
                            <asp:FileUpload CssClass="form-control" ID="pic" runat="server" />
                            <asp:HiddenField ID="HiddenField1" Value='<%# Bind("Picture") %>' runat="server" />

                        </td>
                        <td>
                            <asp:Label ID="TouristIdLabel1" runat="server" Text='<%# Eval("TouristId") %>' />
                        </td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="TouristNameTextBox" runat="server" Text='<%# Bind("TouristName") %>' />
                        </td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="TouristOcupationTextBox" runat="server" Text='<%# Bind("TouristOcupation") %>' />
                        </td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                        </td>

                        <td>

                            <asp:DropDownList SelectedValue='<%# Bind("PackageId") %>' AppendDataBoundItems="true" DataSourceID="dsPackage" DataTextField="PackageName" DataValueField="PackageId" CssClass="form-select" ID="DropDownList1" runat="server">
                                <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-outline-success" ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button CssClass="btn btn-secondary" ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">


                        <td>

                            <asp:FileUpload CssClass="form-control" ID="pic" runat="server" />
                            <asp:HiddenField ID="HiddenField1" Value='<%# Bind("Picture") %>' runat="server" />

                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="TouristNameTextBox" runat="server" Text='<%# Bind("TouristName") %>' />
                        </td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="TouristOcupationTextBox" runat="server" Text='<%# Bind("TouristOcupation") %>' />
                        </td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                        </td>

                        <td>

                            <asp:DropDownList SelectedValue='<%# Bind("PackageId") %>' AppendDataBoundItems="true" DataSourceID="dsPackage" DataTextField="PackageName" DataValueField="PackageId" CssClass="form-select" ID="DropDownList1" runat="server">
                                <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-primary" ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button CssClass="btn btn-secondary" ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #DCDCDC; color: #000000;">

                        <td>
                            <img src="<%# Eval("Picture","/Images/{0}") %>" class="rounded-circle" style="width: 50px" />
                        </td>
                        <td>
                            <asp:Label ID="TouristIdLabel" runat="server" Text='<%# Eval("TouristId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TouristNameLabel" runat="server" Text='<%# Eval("TouristName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TouristOcupationLabel" runat="server" Text='<%# Eval("TouristOcupation") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                        </td>

                        <td>
                            <asp:Label ID="PackageIdLabel" runat="server" Text='<%# Eval("PackageName") %>' />
                        </td>
                        <td>
                            <asp:Button CssClass="btn btn-outline-danger -danger" ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                            <asp:Button CssClass="btn btn-warning" ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table class="table" runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table class="table table-bordered" id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                        <th runat="server">Picture</th>
                                        <th runat="server">TouristId</th>
                                        <th runat="server">TouristName</th>
                                        <th runat="server">TouristOcupation</th>
                                        <th runat="server">Email</th>
                                        <th runat="server">PackageId</th>
                                        <th style="width: 200px" runat="server"></th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </div>
    <asp:SqlDataSource ID="dsTourists" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Tourists] WHERE [TouristId] = @TouristId" InsertCommand="INSERT INTO [Tourists] ([TouristName], [TouristOcupation], [Email], [Picture], [PackageId]) VALUES (@TouristName, @TouristOcupation, @Email, @Picture, @PackageId)" SelectCommand="SELECT Tourists.TouristId, Tourists.TouristName, Tourists.TouristOcupation, Tourists.Email, Tourists.Picture, Tourists.PackageId, TourePackages.PackageName FROM Tourists INNER JOIN TourePackages ON Tourists.PackageId = TourePackages.PackageId WHERE (Tourists.PackageId = @PackageId)" UpdateCommand="UPDATE [Tourists] SET [TouristName] = @TouristName, [TouristOcupation] = @TouristOcupation, [Email] = @Email, [Picture] = @Picture, [PackageId] = @PackageId WHERE [TouristId] = @TouristId">
        <DeleteParameters>
            <asp:Parameter Name="TouristId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TouristName" Type="String" />
            <asp:Parameter Name="TouristOcupation" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="PackageId" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="PackageId" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="TouristName" Type="String" />
            <asp:Parameter Name="TouristOcupation" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="PackageId" Type="Int32" />
            <asp:Parameter Name="TouristId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
