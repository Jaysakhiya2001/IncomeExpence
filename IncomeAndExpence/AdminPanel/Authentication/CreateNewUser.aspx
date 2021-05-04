<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateNewUser.aspx.cs" Inherits="AdminPanel_Authentication_CreateNewUser" %>

<!DOCTYPE html>

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
    <%--<link rel="shortcut icon" href="assets/media/favicons/favicon.png">
        <link rel="icon" type="image/png" sizes="192x192" href="assets/media/favicons/favicon-192x192.png">
        <link rel="apple-touch-icon" sizes="180x180" href="assets/media/favicons/apple-touch-icon-180x180.png">--%>
    <!-- END Icons -->

    <!-- Stylesheets -->
    <!-- Fonts and OneUI framework -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap">
    <link rel="stylesheet" id="css-main" href="<%= ResolveClientUrl("~/web/AdminPanel/assets/css/oneui.min.css")%>" />

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
                                <!-- Sign Up Block -->
                                <div class="block block-rounded block-themed mb-0">
                                    <div class="block-header bg-primary-dark">
                                        <h3 class="block-title">Create Account</h3>
                                        <div class="block-options">

                                            <asp:HyperLink runat="server" ID="hlSignIn" CssClass="btn-block-option" ToolTip="Sign In" NavigateUrl="~/AdminPanel/Authentication/Login.aspx">
                                                <i class="fa fa-sign-in-alt"></i>
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="block-content">
                                        <div class="p-sm-3 px-lg-4 py-lg-5">
                                            <h1 class="h2 mb-1 text-center">Income Expense</h1>
                                            <p class="text-muted text-center">
                                                Please fill the following details to create a new account.
                                            </p>
                                            <asp:Label runat="server" ID="lblMassage" />
                                            <!-- Sign Up Form -->
                                            <!-- jQuery Validation (.js-validation-signup class is initialized in js/pages/op_auth_signup.min.js which was auto compiled from _js/pages/op_auth_signup.js) -->
                                            <!-- For more info and examples you can check out https://github.com/jzaefferer/jquery-validation -->
                                            <div class="js-validation-signup">
                                                <div class="py-3">
                                                    <div class="form-group">
                                                        <asp:TextBox runat="server" ID="txtUserName" AutoCompleteType="Disabled" CssClass="form-control form-control-lg form-control-alt" placeholder="Username" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="* Enter User Name" CssClass="text-danger" ValidationGroup="register" />
                                                        <asp:RegularExpressionValidator runat="server" ID="revUserName" ControlToValidate="txtUserName" Display="Dynamic" CssClass="text-danger" ErrorMessage="Enter Valid Email Address   e.g. abc@gmail.com" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  />
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control form-control-lg form-control-alt" TextMode="Password" placeholder="Password" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="* Enter Password" CssClass="text-danger" ValidationGroup="register" />
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:TextBox runat="server" ID="txtDisplayName" CssClass="form-control form-control-lg form-control-alt" placeholder="Display Name" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvDisplayName" ControlToValidate="txtDisplayName" Display="Dynamic" ErrorMessage="* Enter Display Name" CssClass="text-danger" ValidationGroup="register" />
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control  form-control-lg form-control-alt" TextMode="MultiLine" placeholder="Address" />
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control form-control-lg form-control-alt" placeholder="Mobile Number" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvMobileNo" Display="Dynamic" ControlToValidate="txtMobileNo"
                                                            ErrorMessage="Please Enter Mobile Number" CssClass="text-danger" ValidationGroup="register"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="revMobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" CssClass="text-danger"
                                                            ValidationExpression="[0-9]{10}" SetFocusOnError="true" ErrorMessage="Enter valid Mobile No(10 digit mobile No)" ValidationGroup="register" />
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:FileUpload runat="server" ID="fuUserProfileImage" ToolTip="Upload User Profile" />
                                                    </div>

                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-xl-5">
                                                        <asp:LinkButton runat="server" ID="btnRegister" ValidationGroup="register" CssClass="btn btn-block btn-alt-success" OnClick="btnRegister_Click"><i class="fa fa-fw fa-envelope mr-1"></i> Verify Email</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END Sign Up Form -->
                                        </div>
                                    </div>
                                </div>
                                <!-- END Sign Up Block -->
                            </div>
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


