<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BenCalc.aspx.cs" Inherits="BenCalcWebApp.BenCalc" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div id="Main" aria-orientation="horizontal" style="height: 746px; width: 100%">
            <asp:Panel ID="MainPanel" runat="server" BackColor="#3580BF" BorderStyle="None" Height="100%" Width="100%" Wrap="False">
                
                <div id="RightDiv" style="height: 100%; width: 25%; float: right;">
                    
                    <asp:UpdatePanel ID="UpdatePanelSummary" runat="server">

                        <ContentTemplate>
                            <asp:Panel ID="SummaryPanel" runat="server" Height="100%">
                                
                            </asp:Panel>
                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>
                
                <div id="LeftDiv" style="height: 100%; width: 18%; float: left; margin-left: 0px;">
                    
                    <asp:UpdatePanel ID="UpdatePanelNav" runat="server">
                    
                        <ContentTemplate>
                            <asp:Panel ID="NavPanel" runat="server" BorderStyle="None" Height="100%" BackColor="DimGray" style="margin-left: 0px">
                                <asp:Button ID="NewEmployeeButton" runat="server" BackColor="DimGray" EnableTheming="True" Font-Names="Century Gothic" Font-Overline="False" Font-Underline="True" ForeColor="White" Height="54px" OnClick="NewEmployee_Click" Text="✚ Employee" Width="100%" />
                            </asp:Panel>
                        </ContentTemplate>
                    
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
        </div>
</asp:Content>

