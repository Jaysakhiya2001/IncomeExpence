<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="AdminPanel_Authentication_ForgotPassword" %>

<!DOCTYPE html>

<html>
<head runat="server">
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
                                <!-- Reminder Block -->
                                <div class="block block-rounded block-themed mb-0">
                                    <div class="block-header bg-primary-dark">
                                        <h3 class="block-title">Password Reminder</h3>
                                        <div class="block-options">
                                            <asp:HyperLink runat="server" ID="hlSignIn" CssClass="btn-block-option" ToolTip="Sign In" NavigateUrl="~/AdminPanel/Authentication/Login.aspx">
                                                <i class="fa fa-sign-in-alt"></i>
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="block-content">
                                        <div class="p-sm-3 px-lg-4 py-lg-5 text-center">
                                            <h1 class="h2 mb-1">Income Expense</h1>
                                            <p class="text-muted">
                                                Please provide your Mobile Number and change your password.
                                            </p>
                                            <asp:Label runat="server" ID="lblResult" />
                                            <!-- Reminder Form -->
                                            <!-- jQuery Validation (.js-validation-reminder class is initialized in js/pages/op_auth_reminder.min.js which was auto compiled from _js/pages/op_auth_reminder.js) -->
                                            <!-- For more info and examples you can check out https://github.com/jzaefferer/jquery-validation -->
                                            <div class="py-3">
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="txtMobileNumber" CssClass="form-control form-control-alt form-control-lg" AutoCompleteType="Disabled" placeholder="Phone Number" />
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvMobileNo" Display="Dynamic" ControlToValidate="txtMobileNumber"
                                                        ErrorMessage="Please Enter Mobile Number" CssClass="text-danger" ValidationGroup="SaveChanges"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="revMobileNo" ControlToValidate="txtMobileNumber" Display="Dynamic" CssClass="text-danger"
                                                        ValidationExpression="[0-9]{10}" SetFocusOnError="true" ErrorMessage="Enter valid Mobile No(10 digit mobile No)" ValidationGroup="SaveChanges" />

                                                </div>
                                                <div class="form-group ">
                                                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control form-control-alt form-control-lg" AutoCompleteType="Disabled" TextMode="Password" placeholder="Password" />
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPassword" Display="Dynamic" ControlToValidate="txtPassword"
                                                        ErrorMessage="Please Enter Password" CssClass="text-danger" ValidationGroup="SaveChanges"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group ">
                                                    <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control form-control-alt form-control-lg" AutoCompleteType="Disabled" TextMode="Password" placeholder="Confirm Password" />
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvConfirmPassword" Display="Dynamic" ControlToValidate="txtConfirmPassword"
                                                        ErrorMessage="Please Enter Confirm Password" CssClass="text-danger" ValidationGroup="SaveChanges"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator runat="server" ID="cvConfirmPassword" ControlToValidate="txtConfirmPassword" Display="Dynamic" CssClass="text-danger"
                                                        ControlToCompare="txtPassword" ErrorMessage="Password & Retype Password should be not matched" ValidationGroup="SaveChanges"/>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-xl-5">
                                                        <asp:LinkButton runat="server" ID="btnLogin" CssClass=" btn btn-alt-primary " OnClick="btnLogin_Click" ValidationGroup="SaveChanges" ><i class="fa fa-check"></i> Save Changes</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END Reminder Form -->
                                        </div>
                                    </div>
                                </div>
                                <!-- END Reminder Block -->
                            </div>
                        </div>
                    </div>
                    <div class="content content-full font-size-sm text-muted text-center">
                        Developed By<strong> Commex infotech </strong>&copy; <span data-toggle="year-copy"></span>
                    </div>
                </div>
                <!-- END Page Content -->
            </main>
            <!-- END Main Container -->
        </div>
    </form>
</body>
</html>
