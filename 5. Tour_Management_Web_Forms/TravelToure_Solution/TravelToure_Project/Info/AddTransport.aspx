<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTransport.aspx.cs" Inherits="TravelToure_Project.Info.AddTransport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div >
                        <div class="col-6">
                    <h3 class="text-center">Add Transport</h3>
                    <asp:DetailsView ID="DetailsView1" Width="800px" Height="400px" CssClass="p-5 bg-light table-success border-0" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="TransportId" DataSourceID="dsTransports" DefaultMode="Insert">
                        <Fields>
                            <asp:TemplateField HeaderText="Transport Company" SortExpression="TransportCompany">

                                <InsertItemTemplate>

                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" Text='<%# Bind("TransportCompany")%>' />
                                    <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="TextBox1" CssClass="text-danger" Text="Company Name is required" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Company Name is required"></asp:RequiredFieldValidator>

                                </InsertItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transport Type" SortExpression="TransportType">

                                <InsertItemTemplate>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" Text='<%# Bind("TransportType")%>' />
                                    <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="TextBox2" CssClass="text-danger" Text="Transport Type is required" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Transport Type is required"></asp:RequiredFieldValidator>

                                </InsertItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Form City" SortExpression="FormCity">

                                <InsertItemTemplate>

                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" Text='<%# Bind("FormCity")%>' />
                                    <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="TextBox3" CssClass="text-danger" Text=" City is required" ID="RequiredFieldValidator3" runat="server" ErrorMessage=" City is required"></asp:RequiredFieldValidator>
                                </InsertItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent" SortExpression="AgentId">

                                <InsertItemTemplate>

                                    <asp:DropDownList SelectedValue='<%# Bind("AgentId") %>' AppendDataBoundItems="true" DataSourceID="dsAgent" DataTextField="AgentName" DataValueField="AgentId" CssClass="form-select" ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ValidationGroup="ins" ControlToValidate="DropDownList1" CssClass="text-danger" Text="Agent is required" ID="RequiredFieldValidator4" runat="server" ErrorMessage=" Agent is required"></asp:RequiredFieldValidator>

                                </InsertItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">

                                <InsertItemTemplate>
                                    <div class=" offset-2 col-12">
                                        <asp:LinkButton CssClass="btn btn-outline-primary" ValidationGroup="ins" ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                                        <asp:LinkButton CssClass="btn btn-outline-secondary" ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                    </div>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                        </Fields>
                    </asp:DetailsView>
                </div>
                <asp:SqlDataSource ID="dsAgent" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Travelagents]"></asp:SqlDataSource>

        <asp:SqlDataSource ID="dsTransports" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Transports] WHERE [TransportId] = @TransportId" InsertCommand="INSERT INTO [Transports] ([TransportCompany], [TransportType], [FormCity], [AgentId]) VALUES (@TransportCompany, @TransportType, @FormCity, @AgentId)" SelectCommand="SELECT Transports.TransportId, Transports.TransportCompany, Transports.TransportType, Transports.FormCity, Transports.AgentId, Travelagents.AgentName FROM Transports INNER JOIN Travelagents ON Transports.AgentId = Travelagents.AgentId" UpdateCommand="UPDATE [Transports] SET [TransportCompany] = @TransportCompany, [TransportType] = @TransportType, [FormCity] = @FormCity, [AgentId] = @AgentId WHERE [TransportId] = @TransportId">
                <DeleteParameters>
                    <asp:Parameter Name="TransportId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="TransportCompany" Type="String" />
                    <asp:Parameter Name="TransportType" Type="String" />
                    <asp:Parameter Name="FormCity" Type="String" />
                    <asp:Parameter Name="AgentId" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="TransportCompany" Type="String" />
                    <asp:Parameter Name="TransportType" Type="String" />
                    <asp:Parameter Name="FormCity" Type="String" />
                    <asp:Parameter Name="AgentId" Type="Int32" />
                    <asp:Parameter Name="TransportId" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
