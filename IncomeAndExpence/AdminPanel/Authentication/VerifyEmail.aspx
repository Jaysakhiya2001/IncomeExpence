<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerifyEmail.aspx.cs" Inherits="AdminPanel_Authentication_VerifyEmail" %>

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

    
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap">
    <link rel="stylesheet" id="css-main" href="<%= ResolveClientUrl("~/web/AdminPanel/assets/css/oneui.min.css")%>" />

</head>
<body>
    <form id="form1" runat="server">
        <div id="page-container">

            <!-- Main Container -->
            <main id="main-container">
                <!-- Page Content -->
                <div class="bg-image" style="background-image: url('assets/media/photos/photo34@2x.jpg');">
                    <div class="hero-static bg-white-90">
                        <div class="content">
                            <div class="row justify-content-center">
                                <div class="col-md-8 col-lg-6 col-xl-4">
                                    <!-- Unlock Block -->
                                    <div class="block block-rounded block-themed mb-0">
                                        <div class="block-header bg-primary-dark">
                                            <h3 class="block-title">Verify Email</h3>
                                            <div class="block-options">
                                                <asp:HyperLink runat="server" ID="hlSignIn" CssClass="btn-block-option" ToolTip="Sign In" NavigateUrl="~/AdminPanel/Login.aspx">
                                                <i class="fa fa-sign-in-alt"></i>
                                            </asp:HyperLink>
                                            </div>
                                        </div>
                                        
                                        <div class="block-content">
                                            <div class="p-sm-3 px-lg-4 py-lg-5 text-center">
                                                <asp:Image runat="server" ID="imgProfile" CssClass="img-avatar img-avatar96" />
                                                <p class="font-w600 my-2">
                                                    <asp:Label runat="server" ID="lblUserName" ></asp:Label>
                                                </p>
                                                <asp:Label runat="server" ID="lblMessage" ></asp:Label>
                                                    <div class="form-group py-3">
                                                        <asp:TextBox runat="server" ID="txtOTP" CssClass="form-control form-control-lg form-control-alt"  placeholder="OTP.."></asp:TextBox>
                                                        <asp:LinkButton ID="lbtnResendOTP" runat="server" Text="Resend OTP?" OnClick="lbtnResendOTP_Click" ></asp:LinkButton>
                                                    </div>
                                                
                                                    <div class="form-group row justify-content-center">
                                                        <div class="col-md-6 col-xl-5">
                                                            <asp:LinkButton runat="server" ID="btnSignUp" ValidationGroup="register" 
                                                                CssClass="btn btn-block btn-alt-info" OnClick="btnSignUp_Click" >
                                                                <i class="fa fa-fw fa-plus mr-1"></i>
                                                                Sign Up
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                <!-- END Unlock Form -->
                                            </div>
                                        </div>
                                    </div>
                                    <!-- END Unlock Block -->
                                </div>
                            </div>
                        </div>
                        <div class="content content-full font-size-sm text-muted text-center">
                        Developed By <strong>Commex infotech</strong> &copy; <span data-toggle="year-copy"></span>
                    </div>
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
