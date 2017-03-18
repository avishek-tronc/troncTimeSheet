<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RichTextEditor.aspx.cs" Inherits="tronc.Timesheet.Web.richtexteditor.RichTextEditor" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <RTE:Editor ID="Editor1" ContentCss="richtexteditor.css" Text="Type here" runat="server" />
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="GetHTMLContent" OnClick="btnSubmit_Click" />
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:TextBox ID="txtHTMLContent" TextMode="MultiLine" runat="server" Height="300" Width="500"></asp:TextBox>
        </div>
    </form>
</body>
</html>
