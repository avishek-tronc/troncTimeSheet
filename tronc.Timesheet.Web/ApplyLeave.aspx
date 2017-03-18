<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyLeave.aspx.cs" Inherits="tronc.Timesheet.Web.ApplyLeave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="CSS/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
    <script src="JS/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="JS/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $('#<%= txtDate.ClientID %>').datepicker();
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Select Resource:
                </td>
                <td>
                    <asp:DropDownList ID="ddlResource" runat="server" AutoPostBack="false" AppendDataBoundItems="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Select Leave Date:
                </td>
                <td>
                    <div>
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>Provide Leave Reason:
                </td>
                <td>
                    <div>
                        <asp:TextBox ID="txtLeaveReason" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>Provide Back up and Contingency Plan for leave:
                </td>
                <td>
                    <div>
                        <asp:TextBox ID="txtBackUpPlan" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
