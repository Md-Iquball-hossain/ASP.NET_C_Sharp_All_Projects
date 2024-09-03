<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTourists.aspx.cs" Inherits="TravelToure_Project.Info.Turists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class=" row">
        <div class="col-12">
            <h3 class=" mt-5">Add New Tourist</h3>
            <asp:FormView ID="FormView1" runat="server"  DataKeyNames="TouristId" DataSourceID="dsTourists" DefaultMode="Insert" RenderOuterTable="False" OnItemInserting="FormView1_ItemInserting">

                
                <InsertItemTemplate>

                    <div class="form-group row mb-1">
                        <label class="col-form-label col-2">
                            TouristName
                        </label>
                        <div class="col-4">
                            <asp:TextBox ValidationGroup="ins" CssClass="form-control" ID="PackageNameTextBox" runat="server" Text='<%# Bind("TouristName") %>' />
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="PackageNameTextBox" CssClass="text-danger" Text="Tourist Name is required" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tourist Name  is required"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row mb-1">
                        <label class="col-form-label col-2">
                            TouristOcupation
                        </label>
                        <div class="col-4">
                            <asp:TextBox ValidationGroup="ins" CssClass="form-control" ID="TextBox1" runat="server" Text='<%# Bind("TouristOcupation")%>' />
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="PackageNameTextBox" CssClass="text-danger" Text="Tourist Ocupation is required" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tourist Ocupation is required"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row mb-1">
                        <label class="col-form-label col-2">
                            Email
                        </label>
                        <div class="col-4">
                            <asp:TextBox ValidationGroup="ins" CssClass="form-control" ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="PackageNameTextBox" CssClass="text-danger" Text="Emailis required" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row mb-1">
                        <label class="col-form-label col-2">
                            Picture
                        </label>
                        <div class="col-4">
                            <asp:FileUpload ValidationGroup="ins" ID="pic" runat="server" />
                            <asp:HiddenField  ID="HiddenField1" Value='<%# Bind("Picture") %>' runat="server" />
                            <asp:RequiredFieldValidator ControlToValidate="pic" ValidationGroup="ins"  CssClass="text-danger" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Picture is required"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row mb-1">
                        <label class="col-form-label col-2">
                            Package
                        </label>
                        <div class="col-4">
                            <asp:DropDownList ValidationGroup="ins" SelectedValue='<%# Bind("PackageId") %>' AppendDataBoundItems="true" DataSourceID="dsPackage" DataTextField="PackageName" DataValueField="PackageId" CssClass="form-select" ID="DropDownList1" runat="server">
                                <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="DropDownList1" CssClass="text-danger" Text="Agent is required" ID="RequiredFieldValidator6" runat="server" ErrorMessage=" Agent is required"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                <div class="form-group row mb-1">
                      <div class="col-4">
                          <asp:LinkButton CssClass="btn btn-outline-primary" ValidationGroup="ins" ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                                <asp:LinkButton CssClass="btn btn-outline-secondary" ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                          </div>
                    </div>
                     </InsertItemTemplate>
                

            </asp:FormView>
            <asp:SqlDataSource ID="dsTourists" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Tourists] WHERE [TouristId] = @TouristId" InsertCommand="INSERT INTO [Tourists] ([TouristName], [TouristOcupation], [Email], [Picture], [PackageId]) VALUES (@TouristName, @TouristOcupation, @Email, @Picture, @PackageId)" SelectCommand="SELECT * FROM [Tourists]" UpdateCommand="UPDATE [Tourists] SET [TouristName] = @TouristName, [TouristOcupation] = @TouristOcupation, [Email] = @Email, [Picture] = @Picture, [PackageId] = @PackageId WHERE [TouristId] = @TouristId">
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
