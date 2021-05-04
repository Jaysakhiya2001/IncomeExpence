<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Authentication_Login" %>

<!DOCTYPE html>

<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">

    <title>Income &amp; Expense</title>

    <meta name="description" content="OneUI - Bootstrap 4 Admin Template &amp; UI Framework created by pixelcave and published on Themeforest">
    <meta name="author" content="pixelcave">
    <meta name="robots" content="noindex, nofollow">

    <!-- Open Graph Meta -->
    <meta property="og:title" content="OneUI - Bootstrap 4 Admin Template &amp; UI Framework">
    <meta property="og:site_name" content="OneUI">
    <meta property="og:description" content="OneUI - Bootstrap 4 Admin Template &amp; UI Framework created by pixelcave and published on Themeforest">
    <meta property="og:type" content="website">
    <meta property="og:url" content="">
    <meta property="og:image" content="">

    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <%--<link rel="shortcut icon" href="<%= ResolveClientUrl("~/web/AdminPanel/assets/media/favicons/favicon.png")%>" />
    <link rel="icon" type="image/png" sizes="192x192" href="assets/media/favicons/favicon-192x192.png">
    <link rel="apple-touch-icon" sizes="180x180" href="<%= ResolveClientUrl("~/web/AdminPanel/assets/media/favicons/apple-touch-icon-180x180.png")%>" />--%>
    <!-- END Icons -->

    <!-- Stylesheets -->
    <!-- Fonts and OneUI framework -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap">
    <link rel="stylesheet" id="css-main" href="<%= ResolveClientUrl("~/web/AdminPanel/assets/css/oneui.min.css")%>">
</head>
<body>
    <form id="form1" runat="server">
        <div id="page-container">
            <!-- Main Container -->
            <main id="main-container">
                <!-- Page Content -->
                <div class="hero-static">
                    <div class="content">
                        <div class="row justify-content-center">
                            <div class="col-md-8 col-lg-6 col-xl-4">
                                <!-- Sign In Block -->
                                <div class="block block-rounded block-themed mb-0">
                                    <div class="block-header bg-primary-dark">
                                        <h3 class="block-title">Sign In</h3>
                                        <div class="block-options">
                                            <asp:HyperLink runat="server" ID="hlForgotPassword" CssClass="btn-block-option" NavigateUrl="~/AdminPanel/Authentication/ForgotPassword.aspx">
                                                Forgot Password?
                                            </asp:HyperLink>
                                            <asp:HyperLink runat="server" ID="hlCreateNewUser" CssClass="btn-block-option" ToolTip="Create New Account" NavigateUrl="~/AdminPanel/Authentication/CreateNewUser.aspx">
                                                <i class="fa fa-user-plus"></i>
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="block-content">
                                        <div class="p-sm-3 px-lg-4 py-lg-5">
                                            <h1 class="h2 mb-1 text-center">Income Expense</h1>
                                            <p class="text-muted text-center">
                                                Welcome, please login.
                                            </p>
                                            <asp:Label runat="server" ID="lblErrorMessage" />
                                            <div class="js-validation-signin">
                                                <div class="py-3">
                                                    <div class="form-group">
                                                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control form-control-alt form-control-lg" AutoCompleteType="Disabled" placeholder="Username" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="* Enter User Name" CssClass="text-danger" />
                                                        <asp:RegularExpressionValidator runat="server" ID="revUserName" ControlToValidate="txtUserName" Display="Dynamic" CssClass="text-danger" ErrorMessage="Enter Valid Email Address e.g. abc@gmail.com" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  />
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control  form-control-alt form-control-lg" TextMode="Password" placeholder="Password" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="* Enter Password" CssClass="text-danger" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-xl-5">
                                                        <asp:LinkButton runat="server" ID="btnLogin" CssClass="btn btn-block btn-alt-primary" OnClick="btnLogin_Click"><i class="fa fa-fw fa-sign-in-alt mr-1"></i> Sign In</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- END Sign In Form -->
                                    </div>
                                </div>
                            </div>
                            <!-- END Sign In Block -->
                        </div>
                    </div>
                    <div class="content content-full font-size-sm text-muted text-center">
                    Developed By <strong>Commex infotech</strong> &copy; <span data-toggle="year-copy"></span>
                </div>
                </div>
                
                <!-- END Page Content -->
            </main>
            <!-- END Main Container -->
        </div>
        <!-- END Page Container -->

    </form>
</body>

</html>
