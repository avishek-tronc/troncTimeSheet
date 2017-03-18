<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndividualResourceTimeSheet.aspx.cs" EnableEventValidation="false" Inherits="tronc.Timesheet.Web.IndividualResourceTimeSheet" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Resource Timesheet</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>



    <link href="CSS/custom.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <style>
        .margin-top {
            padding-bottom: 10px;
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

        <div class="container">

            <div class="col-md-8 col-md-offset-2" style="background-color: rgb(240, 240, 240);">
                <div id="subhead">
                    <h4>Resource Effort Details</h4>
                </div>


                <div class="row margin-top">
                    <div class=" form-group properties col-md-10">
                        <div class="col-md-4">Name:</div>
                        <div class="col-md-8">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class=" form-group properties col-md-10">
                        <div class="col-md-4">Email:</div>
                        <div class="col-md-8">
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div class="form-group properties col-md-10">
                        <div class="col-md-4">Contact:</div>
                        <div class="col-md-8">
                            <asp:Label ID="lblContact" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div class="form-group properties col-md-10">
                        <div class="col-md-4">Segment:</div>
                        <div class="col-md-8">
                            <asp:Label ID="lblSegment" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group properties col-md-10">
                        <div class="col-md-4">Duration:</div>
                        <div class="col-md-8">
                            <asp:Label ID="lblMonth" runat="server"></asp:Label>
                            <asp:Label ID="lblYear" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        <a href="#one">1 to 10</a>
                    </div>
                    <div class="col-md-2">
                        <a href="#eleven">11 to 20</a>
                    </div>
                    <div class="col-md-2">
                        <a href="#twentyone">21 to rest</a>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblSaveStatus" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <span class="pull-right">
                            <asp:ImageButton ID="btnExport" runat="server" ImageUrl="Images/export-to-excel-image.png" AlternateText="export" Width="60" Height="40" OnClick="btnExport_Click" />
                        </span>
                    </div>
                </div>


                <div class="panel panel-default">

                    <div class="panel-body ">



                        <div id="table" class="table-editable">

                            <table class="table" style="table-layout: fixed; width: 100%">
                                <tr>
                                    <th style="width: 25%">Date</th>
                                    <th style="width: 5%">Effort</th>
                                    <th style="width: 70%; text-align: center;">Comments For Additional Effort</th>

                                </tr>
                                <tr>
                                    <td id="one"><span id="spnFirst" runat="server">1.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnFirst" runat="server" Value="1" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: right">

                                            <asp:TextBox ID="txtFirst" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtFirstComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td><span id="spnSecond" runat="server">2.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnSecond" runat="server" Value="2" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtSecond" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtSecondComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td><span id="spnThird" runat="server">3.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnThird" runat="server" Value="3" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtThird" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtThirdComment" MaxLength="2" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td><span id="spnFourth" runat="server">4.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnFourth" runat="server" Value="4" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtFourth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtFourthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnFifth" runat="server">5.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnFifth" runat="server" Value="5" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtFifth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtFifthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td><span id="spnsixth" runat="server">6.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnsixth" runat="server" Value="6" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtsixth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtsixthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td><span id="spnseventh" runat="server">7.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnseventh" runat="server" Value="7" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtseventh" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtseventhComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td><span id="spneighth" runat="server">8.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdneighth" runat="server" Value="8" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txteighth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txteighthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnnineth" runat="server">.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnnineth" runat="server" Value="9" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtnineth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtninethComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntenth" runat="server">10.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntenth" runat="server" Value="10" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttenth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttenthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="eleven"><span id="spneleventh" runat="server">11.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdneleventh" runat="server" Value="11" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txteleventh" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txteleventhComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnetwelveth" runat="server">12.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwelveth" runat="server" Value="12" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwelveth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwelvethComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntirteenth" runat="server">13.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntirteenth" runat="server" Value="13" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttirteen" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttirteenComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnfourteenth" runat="server">14.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnfourteenth" runat="server" Value="14" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtfourteenth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtfourteenthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnfifteenth" runat="server">15.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnfifteenth" runat="server" Value="15" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtfifteenth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtfifteenthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnsixteenth" runat="server">16.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnsixteenth" runat="server" Value="16" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtsixteenth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtsixteenthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnseventeenth" runat="server">17.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnseventeenth" runat="server" Value="17" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtseventeenth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtseventeenthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spneighteenth" runat="server">18.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdneighteenth" runat="server" Value="18" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txteighteenth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txteighteenthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnninteenth" runat="server">19.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnninteenth" runat="server" Value="19" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtninteenth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtninteenthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntwenty" runat="server">20.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwenty" runat="server" Value="20" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwenty" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwentyComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="twentyone"><span id="spntwenty1st" runat="server">21.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwenty1st" runat="server" Value="21" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwenty1st" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwenty1stComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntwenty2nd" runat="server">22.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwenty2nd" runat="server" Value="22" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwenty2nd" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwenty2ndComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntwenty3rd" runat="server">23.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwenty3rd" runat="server" Value="23" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwenty3rd" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwenty3rdComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntwentyfourth" runat="server">24.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwentyfourth" runat="server" Value="24" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwentyfourth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwentyfourthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntwentyfifth" runat="server">25.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwentyfifth" runat="server" Value="25" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwentyfifth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwentyfifthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntwentysixth" runat="server">26.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwentysixth" runat="server" Value="26" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwentysixth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwentysixthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntwentyseventh" runat="server">27.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwentyseventh" runat="server" Value="27" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwentyseventh" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwentyseventhComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntwentyeighth" runat="server">28.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwentyeighth" runat="server" Value="28" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwentyeighth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwentyeighthComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spntwentynineth" runat="server">29.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdntwentynineth" runat="server" Value="29" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txttwentynineth" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txttwentyninethComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnthirty" runat="server">30.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnthirty" runat="server" Value="30" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txtthirty" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtthirtyComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span id="spnthirtyone" runat="server">31.10.2016 
                                    </span>
                                        <asp:HiddenField ID="hdnthirtyone" runat="server" Value="31" />
                                    </td>
                                    <td contenteditable="false">
                                        <div style="text-align: center">
                                            <asp:TextBox ID="txthirtyone" MaxLength="2" Width="30px" Height="40px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>

                                    <td contenteditable="false" style="word-wrap: break-word">
                                        <div style="padding-left: 15px">
                                            <asp:TextBox ID="txtthirtyoneComment" TextMode="MultiLine" Height="40px" Width="450px" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>


                            </table>
                        </div>

                        <asp:LinkButton ID="btnCancel" CssClass="btn btn-primary" runat="server" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
                        <asp:LinkButton ID="btnSubmit" CssClass="btn btn-primary" runat="server" OnClick="btnSubmit_Click">Submit</asp:LinkButton>
                    </div>

                </div>
            </div>
        </div>

        <div style="display: none">
            <asp:GridView ID="grdOrder" runat="server"
                AutoGenerateColumns="true" BorderWidth="1px"
                BackColor="White" GridLines="Horizontal"
                CellPadding="3" BorderStyle="None" BorderColor="#E7E7FF" RowStyle-BackColor="#FFFFFF">
                <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right"
                    BackColor="#E7E7FF"></PagerStyle>
                <HeaderStyle ForeColor="#F7F7F7" Font-Bold="True"
                    BackColor="#7f7f7f"></HeaderStyle>
                <AlternatingRowStyle BackColor="#ffffff"></AlternatingRowStyle>
            </asp:GridView>

        </div>
        <script>
            var $TABLE = $('#table');
            var $BTN = $('#export-btn');
            var $EXPORT = $('#export');

            $('.table-add').click(function () {
                var $clone = $TABLE.find('tr.hide').clone(true).removeClass('hide table-line');
                $TABLE.find('table').append($clone);
            });

            $('.table-remove').click(function () {
                $(this).parents('tr').detach();
            });

            $('.table-up').click(function () {
                var $row = $(this).parents('tr');
                if ($row.index() === 1) return; // Don't go above the header
                $row.prev().before($row.get(0));
            });

            $('.table-down').click(function () {
                var $row = $(this).parents('tr');
                $row.next().after($row.get(0));
            });

            // A few jQuery helpers for exporting only
            jQuery.fn.pop = [].pop;
            jQuery.fn.shift = [].shift;

            $BTN.click(function () {
                var $rows = $TABLE.find('tr:not(:hidden)');
                var headers = [];
                var data = [];

                // Get the headers (add special header logic here)
                $($rows.shift()).find('th:not(:empty)').each(function () {
                    headers.push($(this).text().toLowerCase());
                });

                // Turn all existing rows into a loopable array
                $rows.each(function () {
                    var $td = $(this).find('td');
                    var h = {};

                    // Use the headers from earlier to name our hash keys
                    headers.forEach(function (header, i) {
                        h[header] = $td.eq(i).text();
                    });

                    data.push(h);
                });

                // Output the result
                $EXPORT.text(JSON.stringify(data));
            });
        </script>
    </form>
</body>
</html>
