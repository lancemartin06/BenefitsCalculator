<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BenCalc.aspx.cs" Inherits="BenCalcWebApp.BenCalc" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                       <Scripts>
                        <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%><%--Framework Scripts--%>
                        <asp:ScriptReference Name="MsAjaxBundle" />
                        <asp:ScriptReference Name="jquery" />
                        <asp:ScriptReference Name="bootstrap" />
                        <asp:ScriptReference Name="respond" />
                        <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                        <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                        <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                        <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                        <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                        <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                        <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                        <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                        <asp:ScriptReference Name="WebFormsBundle" />
                        <%--Site Scripts--%>
                    </Scripts>
                    </asp:ScriptManager>
        <div class="jumbotron" id="Main" aria-orientation="horizontal" style="height: 746px; width: 100%; background-color: #333333;">
            <asp:Panel ID="MainPanel" runat="server" BackColor="#3580BF" BorderStyle="None" Height="683px" Width="100%" Wrap="true">
                
                
                
                <div id="LeftDiv" style="height: 681px; width: 278px; float: left;">
                    
                    <asp:UpdatePanel ID="UpdatePanelNav" runat="server" RenderMode="Block">
                    
                        <ContentTemplate>
                            <asp:Panel ID="NavPanel" runat="server" BorderStyle="solid" Height="681px" BackColor="DimGray" style="margin-left: 0px" Width="270px" HorizontalAlign="Left" Direction="LeftToRight" BorderColor="White">
                                <asp:Button ID="NewEmployeeButton" runat="server" BackColor="DimGray" EnableTheming="True" Font-Names="Century Gothic" Font-Overline="False" ForeColor="White" Height="54px" OnClick="NewEmployee_Click" Text="✚ Employee" Width="100%" BorderStyle="None" />
                                <asp:Button ID="NewDependentButton" runat="server" BackColor="DimGray" EnableTheming="True" Font-Names="Century Gothic" Font-Overline="False" ForeColor="White" Height="54px" OnClick="NewDependentButton_Click" Text="✚ Dependent" Width="100%" Visible="False" BorderStyle="None" />
                            </asp:Panel>
                        </ContentTemplate>
                    
                    </asp:UpdatePanel>
                </div>

                <div id="CenterDiv" style="height: 678px; width: 480px; float: left; display: normal; position: center;">

                    <asp:Panel ID="CenterPanel" runat="server" Height="678px" Style="margin-left: 0px" Width="480px" HorizontalAlign="Left" Direction="LeftToRight" Font-Names="Century Gothic">
                        <asp:Label ID="HeaderLabel" runat="server" BorderStyle="None" Font-Names="Century Gothic" Font-Overline="False" Font-Size="XX-Large" ForeColor="White" Height="70px" Text="Benefits Calculator" Width="399px" Font-Underline="True"></asp:Label>

                        <div aria-orientation="horizontal" style="height: 25px; width: 477px;">
                        </div>
                        <asp:UpdatePanel runat="server" RenderMode="Block">
                            <ContentTemplate>
                                <div id="nameDiv" class="container" aria-orientation="horizontal" style="height: 50px; width: 477px;">

                                    <asp:Label ID="EmployeeNameLabel" runat="server" Text="Name:" Font-Names="Century Gothic" ForeColor="White" Visible="False"></asp:Label>

                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                    &nbsp;
                                    <asp:TextBox ID="EmployeeNameTextBox" runat="server" ForeColor="Black" Height="25px" Width="189px" Visible="False" ControlToValidate="EmployeeNameTextBox"></asp:TextBox>

                                </div>
                                <div aria-orientation="horizontal" style="height: 25px; width: 477px;">
                                </div>

                                <div id="employeeDiv" class="container" aria-orientation="horizontal" style="height: 50px; width: 477px;">

                                    <asp:Label ID="EmployeeIdLabel" runat="server" Text="Employee ID" Font-Names="Century Gothic" ForeColor="White" Visible="False"></asp:Label>

                                    :&nbsp;
                                <asp:TextBox ID="EmployeeIDTextBox" runat="server" ForeColor="Black" Height="25px" Width="189px" Visible="False"></asp:TextBox>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel runat="server" RenderMode="Block">
                            <ContentTemplate>

                                <asp:Panel ID="DependentPanel" runat="server" Visible="False">


                                    <div aria-orientation="horizontal" style="height: 60px; width: 477px;">
                                    </div>

                                    <div class="container" aria-orientation="horizontal" style="height: 50px; width: 477px;">

                                        <asp:Label ID="Label8" runat="server" Text="Name" Font-Names="Century Gothic" ForeColor="White"></asp:Label>

                                        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:TextBox ID="DependentNameTextBox" runat="server" ForeColor="Black" Height="25px" Width="189px"></asp:TextBox>

                                    </div>


                                    <div aria-orientation="horizontal" style="height: 25px; width: 477px;">
                                    </div>

                                    <div class="container" aria-orientation="horizontal" style="height: 50px; width: 477px;">

                                        <asp:Label ID="Label9" runat="server" Text="Relationship" Font-Names="Century Gothic" ForeColor="White"></asp:Label>

                                        : &nbsp;

                                <asp:DropDownList ID="RelationshipDropDownList" runat="server" Width="189px">
                                    <asp:ListItem>Spouse</asp:ListItem>
                                    <asp:ListItem>Child</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>

                                    </div>
                                    <div aria-orientation="horizontal" style="height: 20px; width: 477px;">
                                    </div>
                                    <asp:Button ID="AddDependentButton" runat="server" Height="30px" Text="Add Dependent" Width="144px" BackColor="#666699" BorderStyle="None" Font-Size="Medium" ForeColor="White" Font-Overline="False" ToolTip="Click to add this dependent to your list." OnClick="AddDependentButton_Click" />

                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel runat="server" RenderMode="Block">
                            <ContentTemplate>
                                <div aria-orientation="horizontal" style="height: 70px; width: 477px; padding-top: 40px; padding-left: 250px;">
                            <asp:Button ID="UpdateButton" runat="server" Height="28px" Text="Update" Width="98px" BackColor="#FF2BB073" BorderStyle="None" Font-Size="Medium" ForeColor="White" Font-Overline="False" ToolTip="Click to update your employees's cost." OnClick="UpdateButton_Click" Visible="False" ViewStateMode="Enabled" />

                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        

                    </asp:Panel>



                </div>

                <div id="RightDiv" style="height: 681px; width: 278px; float: right; padding-left: 6px;">

                    <asp:UpdatePanel ID="UpdatePanelSummary" runat="server">

                        <ContentTemplate>
                            <asp:Panel ID="SummaryPanel" runat="server" Height="682px" BackColor="#ECECF3" CssClass="container">

                                <asp:Label ID="SummaryLabel" runat="server" Text="Summary" Font-Names="Century Gothic" Font-Overline="False" ForeColor="Blue" Width="100%" BorderStyle="Ridge" Font-Size="Large" Height="33px" AssociatedControlID="SummaryPanel" CssClass="input-group-addon"></asp:Label>

                                <div aria-orientation="horizontal" style="height: 6px; background-color: #000080;">
                                </div>
                                <div aria-orientation="horizontal" style="height: 50px">
                                </div>
                                <asp:Label ID="SummaryLabel0" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Large" ForeColor="black" Height="35px" Text="Total Annual Cost:" Width="100%"></asp:Label>

                                <div aria-orientation="horizontal" style="height: 50px">
                                    <asp:Label ID="Label3" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Large" ForeColor="Green" Height="35px" Text="$" Width="6%"></asp:Label>
                                    <asp:Label ID="TotalAnnualCostLabel" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Large" ForeColor="Green" Height="35px" Text="" Width="90%"></asp:Label>
                                </div>
                                <div aria-orientation="horizontal" style="height: 50px">
                                </div>
                                <asp:Label ID="Label1" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Large" ForeColor="black" Height="35px" Text="Discounts:" Width="100%"></asp:Label>

                                <div aria-orientation="horizontal" style="height: 50px">
                                    <asp:Label ID="Label2" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Large" ForeColor="Green" Height="35px" Text="$" Width="6%"></asp:Label>
                                    <asp:Label ID="DiscountLabel" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Large" ForeColor="Green" Height="35px" Text="" Width="90%"></asp:Label>
                                </div>
                                <div aria-orientation="horizontal" style="height: 50px">
                                </div>
                                <asp:Label ID="Label5" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Large" ForeColor="black" Height="35px" Text="Cost Per Paycheck:" Width="100%"></asp:Label>

                                <div aria-orientation="horizontal" style="height: 50px">
                                    <asp:Label ID="Label6" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Large" ForeColor="Green" Height="35px" Text="$" Width="6%"></asp:Label>
                                    <asp:Label ID="CostPerPaycheckLabel" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Large" ForeColor="Green" Height="35px" Text="" Width="90%"></asp:Label>



                                </div>


                                <div aria-orientation="horizontal" style="height: 30px">
                                </div>
                                <asp:Label ID="Label11" runat="server" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Medium" ForeColor="Blue" Height="35px" Text="Dependents" Width="90%"></asp:Label>

                                <asp:ListBox ID="DependentListBox" runat="server" Height="100px" Width="227px" Font-Names="Century Gothic" Font-Size="Smaller"></asp:ListBox>


                            </asp:Panel>
                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
        </div>
</asp:Content>

