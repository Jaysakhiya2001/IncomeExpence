<%@ Page Title="" Language="C#" MasterPageFile="~/web/AdminPanel.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="AdminPanel_Report_Report" %>

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
        <a class="nav-main-link active" href="<%= ResolveClientUrl("~/AdminPanel/Report/Report.aspx") %>">
            <i class="nav-main-link-icon far fa-x fa-chart-bar"></i>
            <span class="nav-main-link-name">&nbsp;Report</span>
        </a>
    </li>
    <li class="nav-main-item">
        <a class="nav-main-link" href="<%= ResolveClientUrl("~/AdminPanel/Profile/Profile.aspx") %>">
            <i class="nav-main-link-icon fa fa-x fa-users  "></i>
            <span class="nav-main-link-name">&nbsp;Profile</span>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
    Report
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagebreadcrumb" runat="Server">
    Report
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContant" runat="Server">
    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col-2 text-right"><span class="text-danger">*</span>Starting Date: </div>
                <div class="col-4">
                    <asp:TextBox runat="server" ID="txtStartingdate" CssClass="form-control" placeholder="Date" TextMode="Date" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvStartingdate" Display="Dynamic" ControlToValidate="txtStartingdate"
                        ErrorMessage="Please Enter Starting Date" CssClass="text-danger" ValidationGroup="Show"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row" style="padding-top: 20px;">
                <div class="col-2 text-right"><span class="text-danger">*</span>Ending Date: </div>
                <div class="col-4">
                    <asp:TextBox runat="server" ID="txtEndingdate" CssClass="form-control" placeholder="Date" TextMode="Date" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvEndingdate" Display="Dynamic" ControlToValidate="txtEndingdate"
                        ErrorMessage="Please Enter Ending Date" CssClass="text-danger" ValidationGroup="Show"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row" style="padding-top: 20px;">
                <div class="col-md-6">
                    <asp:Button runat="server" ID="btnShow" CssClass="btn btn-info float-right" Text="Show" OnClick="btnShow_Click" ValidationGroup="Show" />
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-12">
                    <div class="alert alert-success " id="divMessage" runat="server" visible="false">
                       <asp:Label runat="server" ID="lblMessage"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>
            <div class="row" style="padding-top: 30px;">
                <div class="col-12">
                    <div class="table-responsive">
                        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-borderless table-striped table-vcenter" ShowFooter="True" OnRowDataBound="gvReport_RowDataBound" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Descripation" HeaderText="Descripation" />
                                <asp:BoundField DataField="Type" HeaderText="Type" FooterStyle-Font-Bold="true" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" FooterStyle-Font-Bold="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

