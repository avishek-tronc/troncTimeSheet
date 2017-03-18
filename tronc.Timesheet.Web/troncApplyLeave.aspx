<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="troncApplyLeave.aspx.cs" Inherits="tronc.Timesheet.Web.troncApplyLeave" ValidateRequest="false" EnableEventValidation="false" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <title>tronc Apply Leave</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link type="text/css" href="CSS/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
    <script src="JS/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="JS/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#datepicker").datepicker();
        });

    </script>

    <link href="CSS/custom.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <style>
        .margin-top {
            padding-bottom: 30px;
            margin-top: 20px;
        }
    </style>
    <script>
        function openNav() {
            document.getElementById("mySidenav").style.width = "250px";
        }

        function closeNav() {
            document.getElementById("mySidenav").style.width = "0";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdnDate" runat="server" />
        <div id="mySidenav" class="sidenav">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
            <a href="FloorPoolTimesheet.aspx">Timesheet Management</a>
            <a href="troncApplyLeave.aspx">Apply Leave</a>
            <a href="ViewResourceLeaves.aspx">View Leave</a>

        </div>
        <nav class="navbar navbar-inverse">

            <div class=" row">
                <div class="col-md-4">
                    <span style="font-size: 30px; cursor: pointer; color: white;" onclick="openNav()">&#9776;</span>
                </div>
                <div class="col-md-2 navbar-brand">
                    <i class="fa fa-calendar" aria-hidden="true"></i>&nbsp; &nbsp;  APPLY LEAVE
                </div>
                <div class="col-md-1">
                    <img src="Images/tronc-logo.png" alt=" Tronc" width="300" height="50">
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </nav>

        <div class="container">

            <div class="col-md-8 col-md-offset-2" style="background-color: rgb(240, 240, 240);">
                <div id="subhead">
                    <h4>Leave Details</h4>
                </div>


                <fieldset>
                    <div class="form-group properties col-md-10">
                        <div class="property col-md-4">Resource<span style="color: red">*</span> </div>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlResource" runat="server" AutoPostBack="false" Width="250" Height="30" AppendDataBoundItems="true"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group properties col-md-10">
                        <div class="property col-md-4">Date<span style="color: red">*</span></div>
                        <div class="col-md-8">
                            <div>
                                <%--<asp:TextBox ID="txtDate" name="datepickernm" ReadOnly="true" Width="250" Height="30" runat="server"></asp:TextBox>--%>
                                <input type="text" id="datepicker" readonly="readonly" name="datepicker" />
                            </div>

                        </div>
                    </div>

                    <div class="form-group properties col-md-10">
                        <div class="property col-md-4">Ultimatix ID<span style="color: red">*</span></div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtUltimatixID" TextMode="SingleLine" Width="250" Height="30" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group properties col-md-10">
                        <div class="property col-md-4">Leave Reason<span style="color: red">*</span></div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtLeaveReason" TextMode="MultiLine" Width="250" Height="80" runat="server"></asp:TextBox>

                        </div>
                    </div>

                    <div class="form-group properties col-md-10">
                        <div class="property col-md-4">Backup Plan<span style="color: red">*</span></div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtBackUpPlan" TextMode="MultiLine" Width="250" Height="80" runat="server"></asp:TextBox>
                        </div>
                    </div>



                </fieldset>

                <div class="col-md-4">
                    <asp:Label ID="lblSaveStatus" ForeColor="Red" runat="server"></asp:Label>
                </div>
                <div class="pull-right">
                    <asp:LinkButton ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-raised"><i class="fa fa-check-circle fa-1"></i>Save</asp:LinkButton>
                    <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-raised" OnClick="btnCancel_Click"><i class="fa fa-check-circle fa-1"></i>Cancel</asp:LinkButton>
                </div>

            </div>

        </div>
    </form>

    <script>
        var hdnDate = document.getElementById('<%= hdnDate.ClientID%>').value;
        if (hdnDate != '') {
            document.getElementById('datepicker').value = hdnDate;
        }
    </script>
</body>
</html>
