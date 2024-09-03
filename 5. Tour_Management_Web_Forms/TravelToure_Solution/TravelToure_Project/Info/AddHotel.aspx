<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHotel.aspx.cs" Inherits="TravelToure_Project.Info.AddHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Content/bootstrap-datepicker.standalone.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="row">
        <div class="col-6">
            <asp:DetailsView ID="DetailsView1" CssClass="text-bg-light border-0 mt-5" runat="server" Width="600px" Height="400px" AutoGenerateRows="False" DataKeyNames="HotelId" DataSourceID="dsHotels" DefaultMode="Insert">
                <Fields>
                    <asp:TemplateField HeaderText="Hotel Name" SortExpression="HotelName">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="edit" ID="TextBox1" runat="server" Text='<%# Bind("HotelName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="edit" ControlToValidate="TextBox1" CssClass="text-danger" Text="Hotel Name is required" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Hotel Name  is required"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ValidationGroup="ins" CssClass="form-control" ID="TextBox1" runat="server" Text='<%# Bind("HotelName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="TextBox1" CssClass="text-danger" Text="Hotel Name is required" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Hotel Name  is required"></asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("HotelName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address" SortExpression="Address">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="edit" ID="TextBox2" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="edit" ControlToValidate="PackageNameTextBox" CssClass="text-danger" Text="Address is required" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ValidationGroup="ins" CssClass="form-control" ID="TextBox2" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>

                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="TextBox2" CssClass="text-danger" Text="Address is required" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Booking Date" SortExpression="BookingDate">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="edit" ID="TextBox3" runat="server" Text='<%# Bind("BookingDate") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="edit" ControlToValidate="PackageNameTextBox" CssClass="text-danger" Text="Address is required" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ValidationGroup="ins" CssClass="form-control date" ID="TextBox3" runat="server" Text='<%# Bind("BookingDate") %>'></asp:TextBox>
                            <asp:CompareValidator Display="Dynamic" ValidationGroup="ins" CssClass="text-danger" ID="CompareValidator1" Operator="DataTypeCheck" Type="Date" ControlToValidate="TextBox3" runat="server" ErrorMessage="Date Invalid"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="TextBox3" CssClass="text-danger" Text="Booking Date is required" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Booking Date is required"></asp:RequiredFieldValidator>

                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("BookingDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tourist" SortExpression="TouristId">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("TouristId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:DropDownList ValidationGroup="ins" SelectedValue='<%# Bind("TouristId") %>' AppendDataBoundItems="true" DataSourceID="dsTourists" DataTextField="TouristName" DataValueField="TouristId" CssClass="form-select" ID="DropDownList1" runat="server">
                                <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="DropDownList1" CssClass="text-danger" Text="Tourist is required" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Booking Date is required"></asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("TouristId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <InsertItemTemplate>
                            <asp:LinkButton ValidationGroup="ins" CssClass="btn btn-outline-primary" ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-secondary" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="New" Text="New"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </div>
        <asp:SqlDataSource ID="dsHotels" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Hotels] WHERE [HotelId] = @HotelId" InsertCommand="INSERT INTO [Hotels] ([HotelName], [Address], [BookingDate], [TouristId]) VALUES (@HotelName, @Address, @BookingDate, @TouristId)" SelectCommand="SELECT Hotels.HotelId, Hotels.HotelName, Hotels.Address, Hotels.BookingDate, Hotels.TouristId, Tourists.TouristName FROM Hotels INNER JOIN Tourists ON Hotels.TouristId = Tourists.TouristId" UpdateCommand="UPDATE [Hotels] SET [HotelName] = @HotelName, [Address] = @Address, [BookingDate] = @BookingDate, [TouristId] = @TouristId WHERE [HotelId] = @HotelId">
            <DeleteParameters>
                <asp:Parameter Name="HotelId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="HotelName" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter DbType="Date" Name="BookingDate" />
                <asp:Parameter Name="TouristId" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="HotelName" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter DbType="Date" Name="BookingDate" />
                <asp:Parameter Name="TouristId" Type="Int32" />
                <asp:Parameter Name="HotelId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dsTourists" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Tourists]"></asp:SqlDataSource>
    </div>
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
