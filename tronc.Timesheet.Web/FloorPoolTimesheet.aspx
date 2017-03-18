<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FloorPoolTimesheet.aspx.cs" Inherits="tronc.Timesheet.Web.FloorPoolTimesheet" EnableEventValidation="false" %>

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
                        <i class="fa fa-calendar" aria-hidden="true"></i>&nbsp; &nbsp;  FLOOR POOL EFFORT
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
                                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" AppendDataBoundItems="true" Width="150px" Height="30px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-3 padding-top-bottom">
                            <div class="form-group">
                                <label class="col-lg-4 col-md-4 ">Month</label>
                                <div class="col-lg-8 col-md-8 ">
                                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="false" AppendDataBoundItems="true" Width="150px" Height="30px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-3 padding-top-bottom">
                            <div class="form-group">
                                <label class="col-lg-4 col-md-4 ">Segment</label>
                                <div class="col-lg-8 col-md-8 ">
                                    <asp:DropDownList ID="ddlSegment" runat="server" AutoPostBack="false" AppendDataBoundItems="true" Width="150px" Height="30px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-3 padding-top-bottom">
                            <div class="form-group">
                                <label class="col-lg-4 col-md-4 ">Resource</label>
                                <div class="col-lg-8 col-md-8 ">
                                    <asp:DropDownList ID="ddlResource" runat="server" AutoPostBack="false" AppendDataBoundItems="true" Width="150px" Height="30px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-sm-6 padding-top-bottom ">
                            <div class="col-lg-12" id="documentManagement">
                                <h4>
                                    <asp:Label ID="lblMonth" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblYear" runat="server"></asp:Label>
                                    [Floor:
                                    <asp:Label ID="lblFloor" runat="server"></asp:Label>
                                    Hours] [Pool:
                                    <asp:Label ID="lblPool" runat="server"></asp:Label>
                                    Hours] [Total:
                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                    Hours] </h4>

                            </div>
                        </div>

                        <div class="col-md-3 col-sm-3 padding-top-bottom pull-right">
                            <div class="form-group">
                                <div class="col-lg-4 col-md-4 "></div>
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

           

            <div class="row">
                <div style="float: right;">
                    <asp:ImageButton ID="btnExport" runat="server" ImageUrl="Images/export-to-excel-image.png" AlternateText="export" Width="50" Height="30" OnClick="btnExport_Click" />
                    <asp:ImageButton ID="btnExportPDF" runat="server" ImageUrl="Images/pdf-icon.png" AlternateText="export" Width="40" Height="30" OnClick="btnExportPDF_Click" />
                </div>

                <div>
                    <asp:GridView ID="grdOrder" runat="server"
                        AutoGenerateColumns="False" BorderWidth="1px" Width="100%"
                        BackColor="White" GridLines="Horizontal"
                        CellPadding="3" BorderStyle="None" BorderColor="#E7E7FF" RowStyle-BackColor="#FFFFFF" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="grdOrder_RowCommand">
                        <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                        <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right"
                            BackColor="#E7E7FF"></PagerStyle>
                        <HeaderStyle ForeColor="#F7F7F7" Font-Bold="True"
                            BackColor="#7f7f7f"></HeaderStyle>
                        <AlternatingRowStyle BackColor="#ffffff"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="pad-left" ItemStyle-Width="13%" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666" ItemStyle-Font-Size="14px">
                                <ItemTemplate>
                                    <div class="pad-left" style="text-align: left">
                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("ResourceName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <div style="text-align: left">
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("ResourceEmail") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Segment" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="6%" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <div style="text-align: left">
                                        <asp:Label ID="lblResourceSegment" runat="server" Text='<%# Bind("SegmentName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="1" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblOne" runat="server" Text='<%# Bind("EOne") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwo" runat="server" Text='<%# Bind("ETwo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="3" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblThree" runat="server" Text='<%# Bind("EThree") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="4" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblFour" runat="server" Text='<%# Bind("EFour") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="5" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblFive" runat="server" Text='<%# Bind("EFive") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="6" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblSix" runat="server" Text='<%# Bind("ESix") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="7" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblSeven" runat="server" Text='<%# Bind("ESeven") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="8" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblEight" runat="server" Text='<%# Bind("EEight") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="9" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblNine" runat="server" Text='<%# Bind("ENine") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="10" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTen" runat="server" Text='<%# Bind("ETen") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="11" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblEleven" runat="server" Text='<%# Bind("EEleven") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="12" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwelve" runat="server" Text='<%# Bind("ETwelve") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="13" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblThirteen" runat="server" Text='<%# Bind("EThirteen") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="14" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblFourteen" runat="server" Text='<%# Bind("EFourteen") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="15" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblFiveteen" runat="server" Text='<%# Bind("EFifteen") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="16" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblSixteen" runat="server" Text='<%# Bind("ESixteen") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="17" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblSeventeen" runat="server" Text='<%# Bind("ESeventeen") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="18" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblEighteen" runat="server" Text='<%# Bind("EEighteen") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="19" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblNineteen" runat="server" Text='<%# Bind("ENineteen") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="20" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwenty" runat="server" Text='<%# Bind("ETwenty") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="21" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwentyOne" runat="server" Text='<%# Bind("ETwentyOne") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="22" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwentyTwo" runat="server" Text='<%# Bind("ETwentyTwo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="23" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwentyThree" runat="server" Text='<%# Bind("ETwentyThree") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="24" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwentyFour" runat="server" Text='<%# Bind("ETwentyFour") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="25" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwentyFive" runat="server" Text='<%# Bind("ETwentyFive") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="26" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwentySix" runat="server" Text='<%# Bind("ETwentySix") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="27" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwentySeven" runat="server" Text='<%# Bind("ETwentySeven") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="28" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwentyEight" runat="server" Text='<%# Bind("ETwentyEight") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="29" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblTwentyNine" runat="server" Text='<%# Bind("ETwentyNine") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="30" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblThirty" runat="server" Text='<%# Bind("EThirty") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="31" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <asp:Label ID="lblThirtyOne" runat="server" Text='<%# Bind("EThirtyOne") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <div style="font-weight: bold; color: blue">
                                        <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("TotalEffort") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="5%" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#666">
                                <ItemTemplate>
                                    <div style="font-weight: bold; color: blue">
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("TotalMonthRate") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" ItemStyle-BackColor="#FFFFFF" ItemStyle-Font-Names="Helvetica,Arial,sans-serif" ItemStyle-ForeColor="#003399">
                                <ItemTemplate>
                                    <div style="text-align: left">
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

