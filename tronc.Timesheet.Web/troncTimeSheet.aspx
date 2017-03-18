<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="troncTimeSheet.aspx.cs" Inherits="tronc.Timesheet.Web.troncTimeSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlResource" runat="server" AutoPostBack="false" AppendDataBoundItems="true"></asp:DropDownList>
            <br />
            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" AppendDataBoundItems="true"></asp:DropDownList>
            <br />
            <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="false" AppendDataBoundItems="true"></asp:DropDownList>
            <br />
            <asp:DropDownList ID="ddlSegment" runat="server" AutoPostBack="false" AppendDataBoundItems="true"></asp:DropDownList>
            <br />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
        <div>
            <table>
                <tr>
                    <td>Floor Effort</td>
                    <td>
                        <asp:Label ID="lblFloor" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Pool Effort</td>
                    <td>
                        <asp:Label ID="lblPool" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>Total Effort</td>
                    <td>
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>

                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="grdOrder" runat="server"
                AutoGenerateColumns="False" BorderWidth="1px" Width="100%"
                BackColor="White" GridLines="Horizontal"
                CellPadding="3" BorderStyle="None" BorderColor="#E7E7FF" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="grdOrder_RowCommand">
                <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right"
                    BackColor="#E7E7FF"></PagerStyle>
                <HeaderStyle ForeColor="#F7F7F7" Font-Bold="True"
                    BackColor="#4A3C8C"></HeaderStyle>
                <AlternatingRowStyle BackColor="#F7F7F7"></AlternatingRowStyle>
                <Columns>
                    <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div style="text-align: left">
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("ResourceName") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div style="text-align: left">
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("ResourceEmail") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Segment" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div style="text-align: left">
                                <asp:Label ID="lblResourceSegment" runat="server" Text='<%# Bind("SegmentName") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="1">
                        <ItemTemplate>
                            <asp:Label ID="lblOne" runat="server" Text='<%# Bind("EOne") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="2">
                        <ItemTemplate>
                            <asp:Label ID="lblTwo" runat="server" Text='<%# Bind("ETwo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="3">
                        <ItemTemplate>
                            <asp:Label ID="lblThree" runat="server" Text='<%# Bind("EThree") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="4">
                        <ItemTemplate>
                            <asp:Label ID="lblFour" runat="server" Text='<%# Bind("EFour") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="5">
                        <ItemTemplate>
                            <asp:Label ID="lblFive" runat="server" Text='<%# Bind("EFive") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="6">
                        <ItemTemplate>
                            <asp:Label ID="lblSix" runat="server" Text='<%# Bind("ESix") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="7">
                        <ItemTemplate>
                            <asp:Label ID="lblSeven" runat="server" Text='<%# Bind("ESeven") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="8">
                        <ItemTemplate>
                            <asp:Label ID="lblEight" runat="server" Text='<%# Bind("EEight") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="9">
                        <ItemTemplate>
                            <asp:Label ID="lblNine" runat="server" Text='<%# Bind("ENine") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="10">
                        <ItemTemplate>
                            <asp:Label ID="lblTen" runat="server" Text='<%# Bind("ETen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="11">
                        <ItemTemplate>
                            <asp:Label ID="lblEleven" runat="server" Text='<%# Bind("EEleven") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="12">
                        <ItemTemplate>
                            <asp:Label ID="lblTwelve" runat="server" Text='<%# Bind("ETwelve") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="13">
                        <ItemTemplate>
                            <asp:Label ID="lblThirteen" runat="server" Text='<%# Bind("EThirteen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="14">
                        <ItemTemplate>
                            <asp:Label ID="lblFourteen" runat="server" Text='<%# Bind("EFourteen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="15">
                        <ItemTemplate>
                            <asp:Label ID="lblFiveteen" runat="server" Text='<%# Bind("EFifteen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="16">
                        <ItemTemplate>
                            <asp:Label ID="lblSixteen" runat="server" Text='<%# Bind("ESixteen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="17">
                        <ItemTemplate>
                            <asp:Label ID="lblSeventeen" runat="server" Text='<%# Bind("ESeventeen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="18">
                        <ItemTemplate>
                            <asp:Label ID="lblEighteen" runat="server" Text='<%# Bind("EEighteen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="19">
                        <ItemTemplate>
                            <asp:Label ID="lblNineteen" runat="server" Text='<%# Bind("ENineteen") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="20">
                        <ItemTemplate>
                            <asp:Label ID="lblTwenty" runat="server" Text='<%# Bind("ETwenty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="21">
                        <ItemTemplate>
                            <asp:Label ID="lblTwentyOne" runat="server" Text='<%# Bind("ETwentyOne") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="22">
                        <ItemTemplate>
                            <asp:Label ID="lblTwentyTwo" runat="server" Text='<%# Bind("ETwentyTwo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="23">
                        <ItemTemplate>
                            <asp:Label ID="lblTwentyThree" runat="server" Text='<%# Bind("ETwentyThree") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="24">
                        <ItemTemplate>
                            <asp:Label ID="lblTwentyFour" runat="server" Text='<%# Bind("ETwentyFour") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="25">
                        <ItemTemplate>
                            <asp:Label ID="lblTwentyFive" runat="server" Text='<%# Bind("ETwentyFive") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="26">
                        <ItemTemplate>
                            <asp:Label ID="lblTwentySix" runat="server" Text='<%# Bind("ETwentySix") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="27">
                        <ItemTemplate>
                            <asp:Label ID="lblTwentySeven" runat="server" Text='<%# Bind("ETwentySeven") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="28">
                        <ItemTemplate>
                            <asp:Label ID="lblTwentyEight" runat="server" Text='<%# Bind("ETwentyEight") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="29">
                        <ItemTemplate>
                            <asp:Label ID="lblTwentyNine" runat="server" Text='<%# Bind("ETwentyNine") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="30">
                        <ItemTemplate>
                            <asp:Label ID="lblThirty" runat="server" Text='<%# Bind("EThirty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="31">
                        <ItemTemplate>
                            <asp:Label ID="lblThirtyOne" runat="server" Text='<%# Bind("EThirtyOne") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("TotalEffort") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <div style="text-align: center">
                                <asp:LinkButton ID="hlEdit" runat="server" CommandName="Resource" CommandArgument='<%# Bind("QueryParameters") %>' ForeColor="Blue"></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle ForeColor="#F7F7F7" Font-Bold="True"
                    BackColor="#738A9C"></SelectedRowStyle>
                <RowStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></RowStyle>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
