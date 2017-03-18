<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TroncLogin.aspx.cs" Inherits="tronc.Timesheet.Web.TroncLogin" %>

<!DOCTYPE html>

<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>FP Timesheet - Login</title>

    <!-- Bootstrap Core CSS -->
    <link href="CSS/bootstrap.min.css" rel="stylesheet">

    <!-- MetisMenu CSS -->


    <!-- Custom CSS -->

    <link href="CSS/login.css" rel="stylesheet">


    <!-- Custom Fonts -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4 mobile-view">

                    <div class="tronc-logo">
                        <img src="Images/tronc.png">
                    </div>

                    <div class="login-panel panel panel-default">
                        <div class="upper_bar">
                            <div class="color_bar" id="color1"></div>
                            <div class="color_bar" id="color2"></div>
                            <div class="color_bar" id="color3"></div>
                            <div class="color_bar" id="color4"></div>
                            <div class="user_login_icon">
                                <img src="Images/user_login.png">
                            </div>
                        </div>


                        <div class="heading">
                            <p class="line1">Floor Pool Resource Management</p>
                            <p class="line2">Please Sign in to get access</p>
                        </div>

                        <div class="form-body">

                            <div class="login-form">
                                <span class="loginSpan">Please Enter Tronc Email Address</span>
                                <%--<input type="text" placeholder="User Name">--%>
                                <asp:TextBox ID="txtUserId" TextMode="Email" placeholder="User Name" runat="server"></asp:TextBox>

                                <%--<input type="password" placeholder="Password">--%>
                                <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
                                <%--<button class="sign-in">SIGN IN <i class="fa fa-chevron-circle-right" aria-hidden="true"></i></button>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />--%>
                                <asp:LinkButton ID="btnSubmit" runat="server" CssClass="sign-in" Width="270px" OnClick="btnSubmit_Click"><div><div style="padding:10px 20px 10px 90px">  SIGN IN <i class="fa fa-chevron-circle-right" aria-hidden="true"></i></div> </div></asp:LinkButton>
                                <br />
                                <br />
                                <span style="color: white">
                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- jQuery -->
    </form>

</body>

</html>
