<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoPage.aspx.cs" Inherits="tronc.Timesheet.Web.DemoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link type="text/css" href="CSS/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
    <link type="text/css" href="CSS/feedback.css" rel="stylesheet" />
    <script src="JS/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="JS/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
    <script src="JS/bootstrapToggle-toggle-min.js"></script>
    <link href="CSS/bootstrapToggle-toggle-min.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#collapseAnchor').click(function () {
                if ($('#demo').is(':hidden')) {
                    $('#addRemoveImage').attr('src', 'Images/icon-remove.png');
                }
                else {
                    $('#addRemoveImage').attr('src', 'Images/icon-add.png');
                }
            });
        });
    </script>
</head>
<body class="backgroundColor">
    <div class="row">
        <div class="col-md-2">
        </div>

        <div class="col-md-3">
            <img class="imageAlign" src="Images/side-img.jpg" />
        </div>
        <div class="col-md-5 backWhite">
            <form class="form-horizontal" role="form" runat="server">
                <div class="row">
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4">
                        <img class="Tronclogo" src="Images/tronc.png" />
                    </div>
                </div>

                <!-- Form Name -->

                <h3>!!Welcome to <strong class="voiceOff">Voice-Off</strong>!!</h3>
                <p class="feedbackText">
                    A platform to express your views, thoughts & opinions on the services rendered by TCS to tronc and 
                                vice-versa. Voice-off or highlight the good/ improvement opportunities/ any suggestions & pave a way 
                                forward to develope a motivated, conducive & collaborative work environment.
                </p>
                <hr />


                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-4 control-label">Name<span class="mandatory">*</span></label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                    </div>

                    <div class="col-sm-2">
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="*Required" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-4 control-label">Employee Organisation</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlEmployeeOrganisation" runat="server" class="form-control"></asp:DropDownList>
                    </div>

                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-4 control-label">Employee Category</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlEmployeeCatagory" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-4 control-label">Feedback On</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlFeedbackOn" runat="server" AutoPostBack="false" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-4 control-label" for="textinput">Emp Name / Group<span class="mandatory">*</span></label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtFeedbackOnEmployeeNameGroup" runat="server" CssClass="form-control" placeholder="Emp Name / Group"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:RequiredFieldValidator ID="rfvEmpGrpName" runat="server" ControlToValidate="txtFeedbackOnEmployeeNameGroup" ErrorMessage="*Required" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-4 control-label">Feedback Category</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlFeedbackCatagory" runat="server" AutoPostBack="false" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <img id="imgSmiley" class="smiley" src="Images/happy.png" alt="Happy" />
                    </div>
                </div>



                <!-- Text input-->

                <div class="form-group">
                    <label class="col-sm-4 control-label">Feedback Note</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtFeedbackNote" class="form-control" ContentCss="richtexteditor.css" TextMode="MultiLine" runat="server" Rows="5" Columns="90" />
                    </div>
                    <%--<div class="col-sm-2">
                    </div>--%>
                </div>

                <div class="form-group">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-6">
                    </div>
                    <div class="col-sm-2">
                        <a href="#demo" data-toggle="collapse" id="collapseAnchor"><img class="arrowIcon" id="addRemoveImage" src="Images/icon-add.png"/></a>
                    </div>
                </div>

                <!-- Text input-->
                <div id="demo" class="collapse">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Feedback Category</label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="ddlSecondFeedbackCatagory" runat="server" CssClass="form-control" AutoPostBack="false" AppendDataBoundItems="true"></asp:DropDownList>

                        </div>
                        <div class="col-sm-2">
                            <img id="imgSecondFeedbackSmiley" class="smiley" src="Images/sorrow.png" alt="Sad" />
                        </div>
                    </div>


                    <!-- Text input-->
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Feedback Note</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSecondFeedbackNote" class="form-control" ContentCss="richtexteditor.css" TextMode="MultiLine" runat="server" Rows="5" Columns="90" />
                        </div>
                        <%--<div class="col-sm-2">
                    </div>--%>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-4 control-label">Feedback Type</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlFeedbackType" runat="server" AutoPostBack="false" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <div class="pull-right">
                            <asp:LinkButton ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary"></asp:LinkButton>
                        </div>
                    </div>
                </div>


            </form>

        </div>

        <!-- /.col-lg-12 -->
        <div class="col-md-2">
        </div>
    </div>
    <!-- /.row -->



</body>
</html>
