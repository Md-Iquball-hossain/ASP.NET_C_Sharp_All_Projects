<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tourists.aspx.cs" Inherits="TravelToure_Project.Info.Tourists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class=" row">
        <div class="col-12">
            <h1 class="text-center mt-5">Tourist</h1>
            <span><a class="btn btn-outline-primary m-3" href="AddTourists.aspx">Add New</a></span>
            <asp:GridView CssClass="table table-bordered text-center" ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="TouristId" DataSourceID="dsTourists" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="Tourist Name" SortExpression="TouristName">
                        <EditItemTemplate>
                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" Text='<%# Bind("TouristName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="TextBox1" CssClass="text-danger" Text="Package Name is required" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tourist Name  is required"></asp:RequiredFieldValidator>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TouristName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tourist Ocupation" SortExpression="TouristOcupation">
                        <EditItemTemplate>
                            <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" Text='<%# Bind("TouristOcupation") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="TextBox2" CssClass="text-danger" Text="Package Name is required" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tourist Ocupation is required"></asp:RequiredFieldValidator>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TouristOcupation") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address" SortExpression="Address">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="ins" CssClass="form-control" ID="TextBox3" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                            <asp:RegularExpressionValidator ValidationGroup="ins" CssClass="text-danger" ControlToValidate="TextBox3" ValidationExpression="Email" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package " SortExpression="PackageName">
                        <EditItemTemplate>
                            <asp:DropDownList SelectedValue='<%# Bind("PackageId") %>' AppendDataBoundItems="true" DataSourceID="dsPackage" DataTextField="PackageName" DataValueField="PackageId" CssClass="form-select" ID="DropDownList1" runat="server">
                                <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("PackageName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package Catagory" SortExpression="PackageCatagory">
                        <EditItemTemplate>
                            <asp:DropDownList SelectedValue='<%# Bind("PackageCatagory") %>' AppendDataBoundItems="true" DataSourceID="dsPackage" DataTextField="PackageCatagory" DataValueField="PackageCatagory" CssClass="form-select" ID="DropDownList2" runat="server">
                                <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("PackageCatagory") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Picture" SortExpression="Picture">
                        <EditItemTemplate>
                            <asp:FileUpload ID="pic" runat="server" />
                            <asp:HiddenField ID="HiddenField1" Value='<%# Bind("Picture") %>' runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <img src="<%# Eval("Picture","/Images/{0}") %>" class="rounded-circle" style="width: 50px" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ValidationGroup="ins" CssClass="btn btn-outline-success" ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-secondary" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-warning" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-danger" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="190px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="dsTourists" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Tourists] WHERE [TouristId] = @TouristId" InsertCommand="INSERT INTO [Tourists] ([TouristName], [TouristOcupation], [Email], [Picture], [PackageId]) VALUES (@TouristName, @TouristOcupation, @Email, @Picture, @PackageId)" SelectCommand="SELECT Tourists.TouristId, Tourists.TouristName, Tourists.TouristOcupation, Tourists.Email, Tourists.Picture, Tourists.PackageId, TourePackages.PackageName, TourePackages.PackageCatagory FROM Tourists INNER JOIN TourePackages ON Tourists.PackageId = TourePackages.PackageId" UpdateCommand="UPDATE [Tourists] SET [TouristName] = @TouristName, [TouristOcupation] = @TouristOcupation, [Email] = @Email, [Picture] = @Picture, [PackageId] = @PackageId WHERE [TouristId] = @TouristId">
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
                <UpdateParameters>
                    <asp:Parameter Name="TouristName" Type="String" />
                    <asp:Parameter Name="TouristOcupation" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Picture" Type="String" />
                    <asp:Parameter Name="PackageId" Type="Int32" />
                    <asp:Parameter Name="TouristId" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsPackage" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TourePackages]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
