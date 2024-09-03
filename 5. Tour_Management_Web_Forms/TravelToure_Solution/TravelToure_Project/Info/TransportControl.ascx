<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransportControl.ascx.cs" Inherits="TravelToure_Project.Info.TransportControl" %>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-12">
                    <h1 class=" text-center mt-5">Transports</h1>
                    <span ><a class="btn btn-outline-primary m-3" href="AddTransport.aspx">Add New</a></span>
                    <asp:GridView CssClass=" table table-bordered" ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="dsTransports" DataKeyNames="TransportId" PageSize="5">
                        <Columns>
                            <asp:TemplateField HeaderText="TransportCompany" SortExpression="TransportCompany">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Text='<%# Bind("TransportCompany") %>'></asp:TextBox>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TransportCompany") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TransportType" SortExpression="TransportType">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" Text='<%# Bind("TransportType") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("TransportType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FormCity" SortExpression="FormCity">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" Text='<%# Bind("FormCity") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("FormCity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent" SortExpression="AgentName">
                                <EditItemTemplate>
                                    <asp:DropDownList SelectedValue='<%# Bind("AgentId") %>' AppendDataBoundItems="true" DataSourceID="dsAgent" DataTextField="AgentName" DataValueField="AgentId" CssClass="form-select" ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="" Selected="True">Select one</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("AgentName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton CssClass="btn btn-outline-success" ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
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
                <asp:SqlDataSource ID="dsAgent" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Travelagents]"></asp:SqlDataSource>


            </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div class="spinner-border" role="status">
                <span class="visually-hidden">Loading...</span>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>