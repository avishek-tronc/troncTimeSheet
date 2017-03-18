<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="troncGetFeedback.aspx.cs" Inherits="tronc.Timesheet.Web.troncGetFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get Your Feedback</title>
    <link href="CSS/feedback.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link type="text/css" href="CSS/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
    <script src="JS/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="JS/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
    <!--Font Awesome (added because you use icons in your prepend/append)-->
    <link rel="stylesheet" href="https://formden.com/static/cdn/font-awesome/4.4.0/css/font-awesome.min.css" />
    <!-- Extra JavaScript/CSS added manually in "Settings" tab -->
    <!-- Include jQuery -->
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.11.3.min.js"></script>
    <link href="../CSS/feedback.css" rel="stylesheet" />
    <!-- Include Date Range Picker -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/css/bootstrap-datepicker3.css" />


    <script>
        $(document).ready(function () {
            var fromDate = $('input[name="txtFromDate"]'); //From Date
            var toDate = $('input[name="txtToDate"]');
            var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
            fromDate.datepicker({
                format: 'mm/dd/yyyy',
                container: container,
                todayHighlight: true,
                autoclose: true,
            });
            toDate.datepicker({
                format: 'mm/dd/yyyy',
                container: container,
                todayHighlight: true,
                autoclose: true,
            });
        });

    </script>

    <script>
        jQuery(function () {

            var minimized_elements = $('p.minimize');

            minimized_elements.each(function () {
                var t = $(this).text();
                if (t.length < 30) return;

                $(this).html(
                    t.slice(0, 30) + '<span>... </span><a href="#" class="more">More</a>' +
                    '<span style="display:none;">' + t.slice(30, t.length) + ' <a href="#" class="less">Less</a></span>'
                );

            });

            $('a.more', minimized_elements).click(function (event) {
                event.preventDefault();
                $(this).hide().prev().hide();
                $(this).next().show();
            });

            $('a.less', minimized_elements).click(function (event) {
                event.preventDefault();
                $(this).parent().hide().prev().show().prev().show();
            });

        });
    </script>

</head>
<body class="backgroundColor">
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                </div>
                <div class="col-md-8">
                    <div class="row">
                        <div class="col-md-1 hidden-xs hidden-sm">
                            <img src="Images/left-img-gray1.jpg" />
                        </div>
                        <div class="col-md-11">
                            <img class="img-responsive" style="width: 100%" src="Images/get_feedback_top.jpg" />
                            <div class="panel panel-info">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3 class="text-Centre-Align">Feedback Report</h3>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="coupon">

                                        <div class="row">

                                            <div class="col-md-6 padding-top-bottom">
                                                <div class="form-group">
                                                    <label class="col-lg-4 col-md-4 ">From</label>
                                                    <div class="col-lg-8 col-md-8 ">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">
                                                                <img src="Images/date-icon.png" />
                                                                <%--<i class="fa fa-calendar"></i>--%>
                                                            </div>
                                                            <asp:TextBox ID="txtFromDate" CssClass="form-control" title="From Date" runat="server" placeholder="MM/DD/YYYY"></asp:TextBox>
                                                            <%-- <input class="form-control" id="date" name="date" placeholder="MM/DD/YYYY" type="text" />--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-6 padding-top-bottom">
                                                <div class="form-group">
                                                    <label class="col-lg-4 col-md-4">To</label>
                                                    <div class="col-lg-8 col-md-8">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">
                                                                <img src="Images/date-icon.png" />
                                                                <%--<i class="fa fa-calendar"></i>--%>
                                                            </div>
                                                            <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server" title="To Date" placeholder="MM/DD/YYYY"></asp:TextBox>
                                                            <%--<input class="form-control" id="Text1" name="date" placeholder="MM/DD/YYYY" type="text" />--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 padding-top-bottom">
                                                <div class="form-group">
                                                    <label class="col-lg-4 col-md-4">Incident #</label>
                                                    <div class="col-lg-8 col-md-8">
                                                        <%--<asp:DropDownList ID="ddlEmployeeOrganisation" runat="server" class="form-control"></asp:DropDownList>--%>
                                                        <asp:TextBox ID="txtIncidentNumber" runat="server" class="form-control" placeholder="INC-XXXX" title="Incident Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-6 padding-top-bottom">
                                                <div class="form-group">
                                                    <label class="col-lg-4 col-md-4">Category</label>
                                                    <div class="col-lg-8 col-md-8">
                                                        <asp:DropDownList ID="ddlFeedbackCategory" runat="server" class="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6 padding-top-bottom">
                                                <div class="form-group">
                                                    <label class="col-lg-4 col-md-4">Name</label>
                                                    <div class="col-lg-8 col-md-8">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Name" title="Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-6 padding-top-bottom">
                                                <div class="form-group">
                                                    <label class="col-lg-4 col-md-4">Follow-Up</label>
                                                    <div class="col-lg-8 col-md-8">
                                                        <asp:DropDownList ID="ddlFollowUp" runat="server" class="form-control">
                                                            <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3"></div>
                                            <div class="col-md-3  padding-top-bottom">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn search_btn" OnClick="btnSearch_Click" />
                                                <%--<button type="button" class="btn search_btn">
                                                    Search&nbsp;<i class="fa fa-search" aria-hidden="true"></i>
                                                </button>--%>
                                            </div>
                                            <div class="col-md-3  padding-top-bottom">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn search_btn" OnClick="btnCancel_Click" />
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-10">
                                            <asp:Label ID="lblTotalCount" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-1"><span>Export</span></div>
                                        <div class="col-md-1" style="float: right;padding:0;">
                                            <asp:ImageButton ID="btnExport" runat="server" ImageUrl="Images/export-to-excel-image.png" AlternateText="export" Width="50" Height="30" OnClick="btnExport_Click" Style="padding-right: 10px;" />
                                        </div>
                                        <div style="overflow-x: auto;" class="col-sm-12">
                                            <div class="dataTable_wrapper padding-top-bottom">
                                                <asp:GridView ID="grdFeedback" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    class="table table-hover table-responsive display" OnRowDataBound="grdFeedback_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Date" DataField="CreatedDate" DataFormatString="{0:MM-dd-yyyy}" HeaderStyle-CssClass="thead_color" ItemStyle-CssClass="center" />
                                                        <asp:BoundField HeaderText="Name" DataField="FeedbackName" HeaderStyle-CssClass="thead_color" ItemStyle-CssClass="center" />
                                                        <asp:BoundField HeaderText="Category" DataField="FeedbackCategory" HeaderStyle-CssClass="thead_color" ItemStyle-CssClass="center" />
                                                        <asp:BoundField HeaderText="Purpose" DataField="FeedbackPurpose" HeaderStyle-CssClass="thead_color" ItemStyle-CssClass="center" />
                                                        <asp:TemplateField HeaderText="Feedback" HeaderStyle-CssClass="thead_color" ItemStyle-CssClass="center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFeedback" runat="server" Text='<%# Bind("FeedbackNote") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:BoundField HeaderText="Feedback" DataField="FeedbackNote" HeaderStyle-CssClass="thead_color" ItemStyle-CssClass="center" />--%>
                                                        <asp:BoundField HeaderText="Incident #" DataField="IncidentNumber" HeaderStyle-CssClass="thead_color" ItemStyle-CssClass="center" />
                                                        <asp:BoundField HeaderText="Follow-Up" DataField="FeedbackFollowUp" HeaderStyle-CssClass="thead_color" ItemStyle-CssClass="center" />                                                 
                                                    </Columns>
                                                    <EmptyDataTemplate>No Feedback Found</EmptyDataTemplate>
                                                </asp:GridView>
                                                <%--<table class="table table-hover table-responsive display" id="Table1">
                                                    <thead class="thead_color">
                                                        <tr>
                                                            <th>Feedback By</th>
                                                            <th>Feedback For</th>
                                                            <th>Date</th>
                                                            <th>Feedback Category</th>
                                                            <th>Description</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td class="center">TCS</td>
                                                            <td class="center">Tronc</td>
                                                            <td class="center">1/12/2015</td>
                                                            <td class="center">Others</td>
                                                            <td>
                                                                <p class="minimize">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text.</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="center">TCS</td>
                                                            <td class="center">Tronc</td>
                                                            <td class="center">1/12/2015</td>
                                                            <td class="center">Others</td>
                                                            <td>
                                                                <p class="minimize">In publishing and graphic design, lorem ipsum (derived from Latin dolorem ipsum, translated as "pain itself") is a filler text commonly used to demonstrate the graphic elements of a document or visual presentation. Replacing meaningful content with placeholder text allows designers to design the form of the content before the content itself has been produced.</p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>--%>
                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-2">
            </div>
        </div>
    </form>
</body>
</html>
