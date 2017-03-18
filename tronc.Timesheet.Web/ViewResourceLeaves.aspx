<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewResourceLeaves.aspx.cs" Inherits="tronc.Timesheet.Web.ViewResourceLeaves" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Floor Pool Timesheet</title>

    <!-- Bootstrap Core CSS -->
    <link href="CSS/bootstrap.min.css" rel="stylesheet">

    <!-- MetisMenu CSS -->
    <link href="CSS/metisMenu.min.css" rel="stylesheet">

    <!-- DataTables CSS -->
    <link href="CSS/dataTables.bootstrap.css" rel="stylesheet">

    <!-- DataTables Responsive CSS -->
    <link href="CSS/dataTables.responsive.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="CSS/sb-admin-2.css" rel="stylesheet">
    <link href="CSS/custom.css" rel="stylesheet">

    <link href="  https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" rel="stylesheet">
    <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.3.js"></script>

    <style type="text/css">
        .pad-left {
            padding-left: 8px;
        }
    </style>
    <style type="text/css">
        .tooltiptime {
            position: relative;
            display: inline-block;
            /*border-bottom: 1px dotted black;*/
        }

            .tooltiptime .tooltiptimetext {
                visibility: hidden;
                width: 320px;
                background-color: #555;
                color: #fff;
                text-align: center;
                border-radius: 6px;
                padding: 5px 0;
                position: absolute;
                z-index: 1;
                bottom: 125%;
                left: 50%;
                margin-left: -60px;
                opacity: 0;
                transition: opacity 1s;
            }

                .tooltiptime .tooltiptimetext::after {
                    content: "";
                    position: absolute;
                    top: 100%;
                    left: 50%;
                    margin-left: -5px;
                    border-width: 5px;
                    border-style: solid;
                    border-color: #555 transparent transparent transparent;
                }

            .tooltiptime:hover .tooltiptimetext {
                visibility: visible;
                opacity: 1;
            }
    </style>


    <!-- Custom Fonts -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

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
        <div id="mySidenav" class="sidenav">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
            <a href="FloorPoolTimesheet.aspx">Timesheet Management</a>
            <a href="troncApplyLeave.aspx">Apply Leave</a>
            <a href="ViewResourceLeaves.aspx">View Leave</a>

        </div>
        <nav class="navbar navbar-inverse">

            <div class=" row">
                <div class="col-md-3">
                    <span style="font-size: 30px; cursor: pointer; color: white;" onclick="openNav()">&#9776;</span>
                </div>
                <a href="FloorPoolTimesheet.aspx">
                    <div class="col-md-3 navbar-brand">
                        <i class="fa fa-calendar" aria-hidden="true"></i>&nbsp; &nbsp;  View Resource Leave Details
                    </div>
                </a>
                <div class="col-md-1">

                    <img src="Images/tronc-logo.png" alt=" Tronc" width="300" height="50">
                </div>
                <div class="col-md-3">
                </div>

            </div>

        </nav>


        <div id="page-wrapper">

            <!-- Search Criteria -->
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">

                        <div class="col-md-3 col-sm-3 padding-top-bottom">
                            <div class="form-group">
                                <label class="col-lg-4 col-md-4 ">Year</label>
                                <div class="col-lg-8 col-md-8 ">
                                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" AppendDataBoundItems="true" Width="200px" Height="30px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-3 padding-top-bottom">
                            <div class="form-group">
                                <label class="col-lg-4 col-md-4 ">Month</label>
                                <div class="col-lg-8 col-md-8 ">
                                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="false" AppendDataBoundItems="true" Width="200px" Height="30px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-3 padding-top-bottom pull-right">
                            <div class="form-group">
                                <div class="col-lg-4 col-md-4 ">
                                </div>
                                <div class="col-lg-8 col-md-8 ">
                                    <div id="chooseButton" style="cursor: pointer">
                                        <%--<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />--%>
                                        <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-default form-control" OnClick="btnSearch_Click"><i class="fa fa-search" aria-hidden="true"></i>Search</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <!-- Search Criteria -->
            <!-- /.row -->

            <%--<div class='tooltiptime'><span style='color: red'>15</span><span class='tooltiptimetext'>Development and Testing support during QA testing of xactly-commission-processing application. The Mule Server was not responding properly and for that reason QA testing time schedule was disturbed. As a solo developer of this application I have to stay online for late hours for assisting QA teams for their testing.</span></div>--%>

            <div class="row">
                <div style="float: right;">
                    <asp:ImageButton ID="btnExport" runat="server" ImageUrl="Images/export-to-excel-image.png" AlternateText="export" Width="50" Height="30" OnClick="btnExport_Click" />
                </div>

                <div>
                    <asp:GridView ID="grdLeave" runat="server"
                        AutoGenerateColumns="False" BorderWidth="1px" Width="100%"
                        BackColor="White" GridLines="Horizontal"
                        CellPadding="3" BorderStyle="None" BorderColor="#E7E7FF" RowStyle-BackColor="#FFFFFF" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="grdLeave_RowCommand">
                        <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                        <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right"
                            BackColor="#E7E7FF"></PagerStyle>
                        <HeaderStyle ForeColor="#F7F7F7" Font-Bold="True"
                            BackColor="#7f7f7f"></HeaderStyle>
                        <AlternatingRowStyle BackColor="#ffffff"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="pad-left" ItemStyle-Width="5%" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666" ItemStyle-Font-Size="14px">
                                <ItemTemplate>
                                    <div class="pad-left" style="text-align: left">
                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("ResourceName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <div style="text-align: left">
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("ResourceEmail") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Segment" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <div style="text-align: left">
                                        <asp:Label ID="lblSegment" runat="server" Text='<%# Bind("SegmentName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <div style="text-align: left">
                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("ProjectName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Role Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <div style="text-align: left">
                                        <asp:Label ID="lblRole" runat="server" Text='<%# Bind("RoleName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leave Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="7%" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <div style="text-align: left">
                                        <asp:Label ID="lblLeaveDate" runat="server" Text='<%# Bind("LeaveDate") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leave Reason" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="8%" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblLeaveReason" runat="server" Text='<%# Bind("LeaveReason") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Backup Plan" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="15%" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblBackUpPlan" runat="server" Text='<%# Bind("BackupPlan") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ultimatix Id" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="5%" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblUltimatixId" runat="server" Text='<%# Bind("UltimatixId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="3%" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#003399">
                                <ItemTemplate>
                                    <div style="text-align: left">
                                        <asp:LinkButton ID="hlEdit" runat="server" CommandName="Leave" CommandArgument='<%# Bind("ResourceLeaveId") %>' ForeColor="Blue"></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle ForeColor="#F7F7F7" Font-Bold="True"
                            BackColor="#738A9C"></SelectedRowStyle>
                        <RowStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></RowStyle>
                    </asp:GridView>
                </div>
            </div>
            <!-- /.table-responsive -->

            <!-- /.row -->

            <!-- /.row -->
        </div>
        <!-- /#page-wrapper -->



        <!-- /#wrapper -->

        <!-- jQuery -->
        <script src="JS/jquery.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
        <!-- Bootstrap Core JavaScript -->
        <script src="JS/bootstrap.min.js"></script>

        <!-- Metis Menu Plugin JavaScript -->
        <script src="JS/metisMenu.min.js"></script>



        <!-- Custom Theme JavaScript -->
        <script src="JS/sb-admin-2.js"></script>


        <!-- Page-Level Demo Scripts - Tables - Use for reference -->


    </form>
</body>

</html>

