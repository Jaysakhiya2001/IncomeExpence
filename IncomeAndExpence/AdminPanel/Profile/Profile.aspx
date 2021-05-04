<%@ Page Title="" Language="C#" MasterPageFile="~/web/AdminPanel.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="AdminPanel_Profile_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageLinks" runat="Server">
    <li class="nav-main-item">
        <a class="nav-main-link" href="<%= ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>">
            <i class="nav-main-link-icon si si-speedometer"></i>
            <span class="nav-main-link-name">&nbsp;Dashboard</span>
        </a>
    </li>
    <li class="nav-main-item">
        <a class="nav-main-link" href="<%= ResolveClientUrl("~/AdminPanel/Catagory/Catagory.aspx") %>">
            <i class="nav-main-link-icon fa fa-x fa-list-ul"></i>
            <span class="nav-main-link-name">&nbsp;Catagory</span>
        </a>
    </li>
    <li class="nav-main-item">
        <a class="nav-main-link" href="<%= ResolveClientUrl("~/AdminPanel/Income/Income.aspx") %>">
            <i class="nav-main-link-icon far fa-x fa-money-bill-alt"></i>
            <span class="nav-main-link-name">&nbsp;Income</span>
        </a>
    </li>
    <li class="nav-main-item">
        <a class="nav-main-link" href="<%= ResolveClientUrl("~/AdminPanel/Expense/Expense.aspx") %>">
            <i class="nav-main-link-icon fa fa-shopping-cart"></i>
            <span class="nav-main-link-name">&nbsp;Expense</span>
        </a>
    </li>
    <li class="nav-main-item">
        <a class="nav-main-link" href="<%= ResolveClientUrl("~/AdminPanel/Report/Report.aspx") %>">
            <i class="nav-main-link-icon fa fa-x fa-chart-bar"></i>
            <span class="nav-main-link-name">&nbsp;Report</span>
        </a>
    </li>
    <li class="nav-main-item">
        <a class="nav-main-link active" href="<%= ResolveClientUrl("~/AdminPanel/Profile/Profile.aspx") %>">
            <i class="nav-main-link-icon fa fa-x fa-users  "></i>
            <span class="nav-main-link-name">&nbsp;Profile</span>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
    Profile
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagebreadcrumb" runat="Server">
    Profile
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContant" runat="Server">

    <!-- Modal -->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Update Profile Image</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    </div>
                    <div class="modal-body">
                            <asp:FileUpload runat="server" ID="fuProfile" />
                    </div>
                    <div class="modal-footer">
                    <asp:Button runat="server" ID="btnClose" CssClass="btn btn-secondary" data-dismiss="modal" Text="Close"></asp:Button>
                    <asp:Button runat="server" ID="btnUpdateProfileImage" CssClass="btn btn-primary" Text="Save Profile Image" OnClick="btnUpdateProfileImage_Click"></asp:Button>
                    </div>
                </div>
                </div>
            </div>
     <!-- END Modal -->

    <div class="row" style="padding-bottom: 20px;">
        <!-- Column -->
        <div class="col-lg-4 col-xlg-3 col-md-5">
            <div class="card">
                <div class="card-body" style="padding-bottom: 0px;">
                    <center class="mt-4">
                        <asp:Image runat="server" ID="imgProfile" CssClass="rounded-circle"  Width="200" Height="200"  />
                        <h4 class="card-title mt-2">
                            <asp:Label runat="server" ID="lblName"></asp:Label>
                        </h4>
                        <asp:HyperLink runat="server" ID="btnUpadateProfile" data-toggle="modal" data-target="#exampleModalCenter"
                            CssClass="btn btn-primary" Text="Update Profile" ToolTip="Change Profile">
                        </asp:HyperLink>
                    </center>
                    <hr />

                    <ul class="nav nav-pills flex-column push" id="pills-tab" role="tablist" style="padding-top: 3px;">
                        <li class="nav-item">
                            <a class="nav-link active" id="pills-timeline-tab" data-toggle="pill" href="#current-month" role="tab" aria-controls="pills-timeline" aria-selected="true"><i class="fa fa-fw fa-home mr-1"></i>Profile</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="pills-profile-tab" data-toggle="pill" href="#last-month" role="tab" aria-controls="pills-profile" aria-selected="false"><i class="fa fa-fw fa-pencil-alt mr-1"></i>Profile Edit</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="pills-setting-tab" data-toggle="pill" href="#previous-month" role="tab" aria-controls="pills-setting" aria-selected="false"><i class="fa fa-fw fa-wrench mr-1"></i>Chenage Password</a>
                        </li>
                    </ul>

                </div>
            </div>
        </div>
        <!-- Column -->
        <!-- Column -->
        <div class="col-lg-8 col-xlg-9 col-md-7" style="padding-bottom: 20px;">
            <div class="card">
                <div class="tab-content" id="pills-tabContent">
                    <div class="tab-pane fade show active" id="current-month" role="tabpanel" aria-labelledby="pills-timeline-tab">
                        <div class="block-header">
                            <h3 class="block-title">Profile
                            </h3>
                        </div>
                        <div class="card-body">
                            <div class="profiletimeline mt-0">
                                <small class="text-muted">UserName</small>
                                <h6>
                                    <asp:Label runat="server" ID="lblUserName"></asp:Label>
                                </h6>
                                <small class="text-muted pt-4 db">Display Name</small>
                                <h6>
                                    <asp:Label runat="server" ID="lblDisplayName"></asp:Label>
                                </h6>
                                <small class="text-muted">Address</small>
                                <h6>
                                    <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                </h6>
                                <small class="text-muted pt-4 db">Mobile Phone</small>
                                <h6>+91 
                                    <asp:Label runat="server" ID="lblMobilePhone"></asp:Label>
                                </h6>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="last-month" role="tabpanel" aria-labelledby="pills-profile-tab">
                        <div class="block-header">
                            <h3 class="block-title">Profile Edit
                            </h3>
                        </div>

                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="alert alert-success " id="divMessage" runat="server" visible="false">
                                        <asp:Label runat="server" ID="lblMessageProfile"></asp:Label>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal form-material">
                                <div class="form-group">
                                    <label class="col-md-12"><span class="text-danger">*</span> User Name</label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvUserName" Display="Dynamic" ControlToValidate="txtUserName"
                                            ErrorMessage="Please Enter User Name" CssClass="text-danger" ValidationGroup="updateProfile"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-12"><span class="text-danger">*</span> Display Name</label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="txtDisplayName" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvDisplayName" Display="Dynamic" ControlToValidate="txtDisplayName"
                                            ErrorMessage="Please Enter Display Name" CssClass="text-danger" ValidationGroup="updateProfile"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-12">Address</label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-12"><span class="text-danger">*</span> Mobile No</label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvMobileNo" Display="Dynamic" ControlToValidate="txtMobileNo"
                                            ErrorMessage="Please Enter Mobile Number" CssClass="text-danger" ValidationGroup="updateProfile"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="revMobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" CssClass="text-danger"
                                            ValidationExpression="[0-9]{10}" SetFocusOnError="true" ErrorMessage="Enter valid Mobile No(10 digit mobile No)" ValidationGroup="updateProfile" />
                                    </div>
                                </div>
                                
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:Button runat="server" ID="btnUpdateProfile" CssClass="btn btn-success" Text="Update Profile" OnClick="btnUpdateProfile_Click" ValidationGroup="updateProfile" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="previous-month" role="tabpanel" aria-labelledby="pills-setting-tab">
                        <div class="block-header">
                            <h3 class="block-title">Change Password
                            </h3>
                        </div>

                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="alert alert-success " id="divMessageLable" runat="server" visible="false">
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal form-material">
                                <div class="form-group">
                                    <label class="col-md-12"><span class="text-danger">*</span>Current Password</label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="txtCurrentPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvCurrentPassword" Display="Dynamic" ControlToValidate="txtCurrentPassword"
                                            ErrorMessage="Please Enter Current Password <br />" CssClass="text-danger" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:HyperLink runat="server" ID="hlLink" Text="Forget Password?" NavigateUrl="~/AdminPanel/Authentication/ForgotPassword.aspx"></asp:HyperLink>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-12"><span class="text-danger">*</span>New Password</label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvNewPassword" Display="Dynamic" ControlToValidate="txtNewPassword"
                                            ErrorMessage="Please Enter New Password" CssClass="text-danger" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-12"><span class="text-danger">*</span>Verify Password</label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="txtVerifyPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvVerifyPassword" Display="Dynamic" ControlToValidate="txtVerifyPassword"
                                            ErrorMessage="Please Enter Verify Password" CssClass="text-danger" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator runat="server" ID="cvVerifyPassword" ControlToValidate="txtVerifyPassword" Display="Dynamic" CssClass="text-danger"
                                            ControlToCompare="txtNewPassword" ErrorMessage="Password & Retype Password should be not matched" ValidationGroup="Save" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" ValidationGroup="Save" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Tabs -->
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

