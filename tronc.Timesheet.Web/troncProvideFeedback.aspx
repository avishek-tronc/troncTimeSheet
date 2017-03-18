<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="troncProvideFeedback.aspx.cs" Inherits="tronc.Timesheet.Web.troncProvideFeedback" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Tronc Provide Feedback</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link type="text/css" href="CSS/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
    <script src="JS/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="JS/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#<%=txtIncidentNumber.ClientID%>').attr("disabled", true);
            $('#<%=txtContactNumber.ClientID%>').attr("disabled", true);           

            $('#<%=chkIncident.ClientID%>').change(function () {
                $('#<%=txtIncidentNumber.ClientID%>').attr("disabled", !this.checked);
                if (!this.checked)
                    $('#<%=txtIncidentNumber.ClientID%>').val("");
            });

            $('#<%=chkFollowUp.ClientID%>').change(function () {
                $('#<%=txtContactNumber.ClientID%>').attr("disabled", !this.checked);
                if (!this.checked)
                    $('#<%=txtContactNumber.ClientID%>').val("");
            });

            $('#closeButton').click(function () {
                if (!($('#thankYouText').is(':hidden'))) {
                    window.location.href = 'troncProvideFeedback.aspx';
                }
            });

        });         

        function openModal() {
            $('#btnShowPopup').click();
        }
    </script>

    <link href="CSS/custom.css" rel="stylesheet">
    <link href="CSS/modalPopUp.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="CSS/feedback.css" rel="stylesheet" />


</head>
<body class="backgroundColor">
    <div class="wrapper container">

        <div class="row">
            <div class="col-md-2">
            </div>

            <div class="col-md-8 col-xs-12 backWhite">
                <form id="Form1" class="form-horizontal" role="form" runat="server">

                    <div class="row">
                        <div class="col-md-5 hidden-xs hidden-sm">
                            <img class="imageAlign img-responsive " src="Images/side-img.jpg" />
                        </div>

                        <div class="col-md-7 col-xs-12 col-sm-12">
                            <div class="row">

                                <div class="col-md-6 col-xs-6 col-sm-6">
                                    <img class="TcsLogo img-responsive" src="Images/logo-tcs.jpg" />
                                </div>
                                <div class="col-sm-6 col-md-6 col-xs-6  ">
                                    <img class="Tronclogo img-responsive" src="Images/tronc.png" />
                                </div>
                            </div>

                            <!-- Form Name -->
                            <div class="form-group">
                                <div class="col-sm-12 col-md-12 col-xs-12">
                                    <h3>!!Welcome to <strong class="voiceOff">Voice-Off</strong>!!</h3>
                                    <p class="feedbackText">
                                        A platform to express your views, thoughts & opinions on the services rendered by tronc to TCS. Voice-off or highlight the good/ improvement opportunities/ any suggestions & pave a way 
                                forward to develop a motivated, conducive & collaborative work environment
                                    </p>
                                    <hr />
                                </div>
                            </div>

                            <!-- Text input-->
                            <div class="form-group">
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Name</label>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Name" title="Name" Text="Anonymous"></asp:TextBox>
                                </div>

                                <%--<div class="col-sm-2 col-md-2 col-xs-2">
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="*Required" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                                </div>--%>
                            </div>


                            <!-- Text input-->
                            <div class="form-group">
                                <%--<label class="col-sm-4 col-md-4 col-xs-4 control-label">Employee Organisation</label>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:DropDownList ID="ddlEmployeeOrganisation" runat="server" class="form-control"></asp:DropDownList>
                                </div>--%>
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Purpose<span class="mandatory">*</span></label>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:TextBox ID="txtFeedbackPurpose" runat="server" class="form-control" placeholder="Why are you giving?" title="Why are you giving?"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-md-2 col-xs-2">
                                    <asp:RequiredFieldValidator ID="rfvFeedbackPurpose" runat="server" ControlToValidate="txtFeedbackPurpose" ErrorMessage="*Required" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <!-- Text input-->
                            <%--<div class="form-group">
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Employee Category</label>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:DropDownList ID="ddlEmployeeCatagory" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Employee Category</label>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2 col-md-2 col-xs-2">
                                </div>
                            </div>

                            <!-- Text input-->
                            <div class="form-group">
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Feedback On</label>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:DropDownList ID="ddlFeedbackOn" runat="server" AutoPostBack="false" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2 col-md-2 col-xs-2">
                                </div>
                            </div>

                            <!-- Text input-->
                            <div class="form-group">
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label" for="textinput">Emp Name / Group<span class="mandatory">*</span></label>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:TextBox ID="txtFeedbackOnEmployeeNameGroup" runat="server" CssClass="form-control" placeholder="Emp Name / Group"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-md-2 col-xs-2">
                                    <asp:RequiredFieldValidator ID="rfvEmpGrpName" runat="server" ControlToValidate="txtFeedbackOnEmployeeNameGroup" ErrorMessage="*Required" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                                </div>
                            </div>--%>

                            <!-- Text input-->
                            <div class="form-group">
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Category</label>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:DropDownList ID="ddlFeedbackCategory" runat="server" AutoPostBack="false" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                </div>
                                <%--<div class="col-sm-2 col-md-2 col-xs-2">
                                    <img id="imgSmiley" class="smiley img-responsive" src="Images/sorrow.png" alt="Sorrow" />
                                </div>--%>
                            </div>

                            <!-- Text input-->

                            <div class="form-group">
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Feedback</label>
                                <div class="col-sm-8 col-md-8 col-xs-8">
                                    <asp:TextBox ID="txtFeedbackNote" class="form-control" ContentCss="richtexteditor.css" TextMode="MultiLine" runat="server" Rows="5" Columns="90" />
                                </div>
                                <%--<div class="col-sm-2">
                    </div>--%>
                            </div>

                            <%--<div class="form-group">
                                <div class="col-sm-4 col-md-4 col-xs-3"></div>
                                <div class="col-sm-4 col-md-4 col-xs-3">
                                </div>
                                <div class="col-sm-4 col-md-4 col-xs-6">
                                    <a href="#demo" data-toggle="collapse" id="collapseAnchor" class="anchorClass">
                                        <img class="arrowIcon img-responsive" id="addRemoveImage" src="Images/icon-add.png" />&nbsp;&nbsp;<span class="feedbackCatagoryText">Feedback Category</span></a>
                                </div>
                            </div>

                            <!-- Text input-->
                            <div id="demo" class="collapse">
                                <div class="form-group">
                                    <label class="col-sm-4 col-md-4 col-xs-4 control-label">Feedback Category</label>
                                    <div class="col-sm-6 col-md-6 col-xs-6">
                                        <asp:DropDownList ID="ddlSecondFeedbackCatagory" runat="server" CssClass="form-control" AutoPostBack="false" AppendDataBoundItems="true"></asp:DropDownList>

                                    </div>
                                    <div class="col-sm-2 col-md-2 col-xs-2">
                                        <img id="imgSecondFeedbackSmiley" class="smiley img-responsive" src="Images/sorrow.png" alt="Sad" />
                                    </div>
                                </div>


                                <!-- Text input-->
                                <div class="form-group">
                                    <label class="col-sm-4 col-md-4 col-xs-4 control-label">Feedback Note</label>
                                    <div class="col-sm-8 col-md-8 col-xs-8">
                                        <asp:TextBox ID="txtSecondFeedbackNote" class="form-control" ContentCss="richtexteditor.css" TextMode="MultiLine" runat="server" Rows="5" Columns="90" />
                                    </div>

                                </div>
                            </div>
                            <!-- Text input-->
                            <div class="form-group">
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Feedback Type</label>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:DropDownList ID="ddlFeedbackType" runat="server" AutoPostBack="false" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2 col-md-2 col-xs-2">
                                </div>
                            </div>--%>

                            <div class="form-group">
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Is it for an Incident?</label>
                                <div class="col-sm-1 col-md-1 col-xs-1">
                                    <input type="checkbox" id="chkIncident" runat="server"/>
                                </div>
                                <div class="col-sm-5 col-md-5 col-xs-5 noSpacing">
                                    
                                    <asp:TextBox ID="txtIncidentNumber" runat="server" class="form-control" title="Incident Number" placeholder="INC-XXXXXX"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 col-md-4 col-xs-4 control-label">Follow-Up Contact Number</label>
                                <div class="col-sm-1 col-md-1 col-xs-1">
                                    <input type="checkbox" id="chkFollowUp" runat="server"/>
                                </div>
                                <div class="col-sm-5 col-md-5 col-xs-5 noSpacing">
                                    
                                    <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" title="Contact Number" placeholder="+1 XXXXXXXXXX"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-sm-4 col-md-4 col-xs-4"></div>
                                <div class="col-sm-6 col-md-6 col-xs-6">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btnSubmit" OnClick="btnSubmit_Click"></asp:Button>
                                </div>
                                <div class="col-sm-2 col-md-2 col-xs-2"></div>
                            </div>

                            <asp:HiddenField ID="hdnSecondField" runat="server" />
                            <input type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
                                data-toggle="modal" data-target="#myModal">
                            <!-- Modal -->
                            <div class="modal fade" id="myModal" role="dialog">
                                <div class="modal-dialog">

                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header modal-header-reddish">
                                            <button type="button" class="close closeIcon" id="closeButton" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title"></h4>
                                        </div>
                                        <div class="modal-body">
                                            <p class="alignment">
                                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                            </p>
                                            <h3 class="alignment" id="thankYouText"><strong>!! Thank You !! </strong></h3>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </form>

            </div>

            <!-- /.col-lg-12 -->
            <div class="col-md-2">
            </div>
        </div>
    </div>
    <!-- /.row -->




</body>
</html>
