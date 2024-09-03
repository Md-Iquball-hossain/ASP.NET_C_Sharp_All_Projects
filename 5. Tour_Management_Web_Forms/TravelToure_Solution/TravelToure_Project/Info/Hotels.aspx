<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hotels.aspx.cs" Inherits="TravelToure_Project.Info.Hotels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="row">
        <div class="col-12">
            <h1 class="text-center mt-5 ">Hotels</h1>
            <span><a class="btn btn-outline-primary m-3" href="AddHotel.aspx">Add New</a></span>
            <asp:GridView CssClass="table table-bordered" ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="dsHotels" DataKeyNames="HotelId">
                <Columns>
                    <asp:TemplateField HeaderText="Hotel Name" SortExpression="HotelName">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="Edit" CssClass="form-control" ID="TextBox1" runat="server" Text='<%# Bind("HotelName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Edit" ControlToValidate="TextBox1" CssClass="text-danger" Text="Hotel Name is required" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Hotel Name  is required"></asp:RequiredFieldValidator>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("HotelName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address" SortExpression="Address">
                        <EditItemTemplate>
                            <asp:TextBox ValidationGroup="Edit" CssClass="form-control" ID="TextBox2" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Edit" ControlToValidate="TextBox2" CssClass="text-danger" Text="Address is required" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Address is required"></asp:RequiredFieldValidator>


                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Booking Date" SortExpression="BookingDate">
                        <EditItemTemplate>
                            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" Text='<%# Bind("BookingDate") %>'></asp:TextBox>

                            <asp:CompareValidator Display="Dynamic" ValidationGroup="Edit" CssClass="text-danger" ID="CompareValidator1" Operator="DataTypeCheck" Type="Date" ControlToValidate="TextBox3" runat="server" ErrorMessage="Date Invalid"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ValidationGroup="Edit" ControlToValidate="TextBox3" CssClass="text-danger" Text="Booking Date is required" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Booking Date is required"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("BookingDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tourist" SortExpression="TouristId">
                        <EditItemTemplate>
                            <asp:DropDownList SelectedValue='<%# Bind("TouristId") %>' AppendDataBoundItems="true" DataSourceID="dsTourists" DataTextField="TouristName" DataValueField="TouristId" CssClass="form-select" ID="DropDownList1" runat="server">
                                <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                            </asp:DropDownList>


                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("TouristName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ValidationGroup="Edit" CssClass="btn btn-outline-success" ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-secondary" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-outline-warning" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            &nbsp;<asp:LinkButton CssClass="btn btn-outline-danger" ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
