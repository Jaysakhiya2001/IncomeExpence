<%@ Page Title="" Language="C#" MasterPageFile="~/web/AdminPanel.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="AdminPanel_Dashbord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageLinks" runat="Server">
    <li class="nav-main-item">
        <a class="nav-main-link active" href="<%= ResolveClientUrl("~/AdminPanel/Dashboard/Dashboard.aspx") %>">
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
    Dashboard
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagebreadcrumb" runat="Server">
    Dashboard
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContant" runat="Server">
    <div class="container-fluid">
        <div class="row row-deck">
            <div class="col-sm-6 col-xl-4">
                <!-- Pending Orders -->
                <div class="block block-rounded d-flex flex-column">
                    <div class="block-content block-content-full flex-grow-1 d-flex justify-content-between align-items-center">
                        <dl class="mb-0">
                            <dt class="font-size-h2 font-w700">
                                <asp:Label runat="server" ID="lblCountCatagory"></asp:Label>
                            </dt>
                            <dd class="text-muted mb-0">Number of Catagory</dd>
                        </dl>
                        <div class="item item-rounded bg-body">
                            <i class="fa fa-list font-size-h3 text-primary"></i>
                        </div>
                    </div>
                    <div class="block-content block-content-full block-content-sm bg-body-light font-size-sm">
                        <a class="font-w500 d-flex align-items-center" href="<%= ResolveClientUrl("~/AdminPanel/Catagory/Catagory.aspx") %>">View all Catagory
                                        <i class="fa fa-arrow-alt-circle-right ml-1 opacity-25 font-size-base"></i>
                        </a>
                    </div>
                </div>
                <!-- END Pending Orders -->
            </div>
            <div class="col-sm-6 col-xl-4">
                <!-- New Customers -->
                <div class="block block-rounded d-flex flex-column">
                    <div class="block-content block-content-full flex-grow-1 d-flex justify-content-between align-items-center">
                        <dl class="mb-0">
                            <dt class="font-size-h2 font-w700">
                                <asp:Label runat="server" ID="lblSumIncome"></asp:Label><sup>&#8377;</sup>
                            </dt>
                            <dd class="text-muted mb-0">Total Income</dd>
                        </dl>
                        <div class="item item-rounded bg-body">
                            <i class="fa fa-coins font-size-h3 text-primary"></i>
                        </div>
                    </div>
                    <div class="block-content block-content-full block-content-sm bg-body-light font-size-sm">
                        <a class="font-w500 d-flex align-items-center" href="<%= ResolveClientUrl("~/AdminPanel/Income/Income.aspx") %>">View all Income
                                        <i class="fa fa-arrow-alt-circle-right ml-1 opacity-25 font-size-base"></i>
                        </a>
                    </div>
                </div>
                <!-- END New Customers -->
            </div>
            <div class="col-sm-6 col-xl-4">
                <!-- Messages -->
                <div class="block block-rounded d-flex flex-column">
                    <div class="block-content block-content-full flex-grow-1 d-flex justify-content-between align-items-center">
                        <dl class="mb-0">
                            <dt class="font-size-h2 font-w700">
                                <asp:Label runat="server" ID="lblSumExpense"></asp:Label><sup>&#8377;</sup>
                            </dt>
                            <dd class="text-muted mb-0">Total Expense</dd>
                        </dl>
                        <div class="item item-rounded bg-body">
                            <i class="fa fa-shopping-cart font-size-h3 text-primary"></i>
                        </div>
                    </div>
                    <div class="block-content block-content-full block-content-sm bg-body-light font-size-sm">
                        <a class="font-w500 d-flex align-items-center" href="<%= ResolveClientUrl("~/AdminPanel/Expense/Expense.aspx") %>">View all Expense
                                        <i class="fa fa-arrow-alt-circle-right ml-1 opacity-25 font-size-base"></i>
                        </a>
                    </div>
                </div>
                <!-- END Messages -->
            </div>

            <div class="col-sm-12 col-xl-12">
                <div class="block block-rounded flex-column" >
                    <div class="block-content block-content-full flex-grow-1 block-content-sm font-size-sm justify-content-between ">
                        <div class="ml-auto">
                            <h3 class="text-center font-w700">This Month</h3>
                        </div>
                        <div class="block-content block-content-full block-content-sm bg-body-light font-size-sm">
                            <div class="row">
                                <div class="col-6 border-right align-self-center">
                                    <div class="d-flex">
                                        <div class="col-12 text-center">
                                            <h1 class="font-w700 mb-0" style="color:#379683">
                                                <asp:Label runat="server" ID="lblThisMonthIncome"></asp:Label><sup>&#8377;</sup>
                                            </h1>
                                            <div class="text-muted font-w500  mb-0">Income</div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-6 text-center">
                                    <h1 class="font-w700 mb-0" style="color:#B23850">
                                        <asp:Label runat="server" ID="lblThisMonthExpense"></asp:Label><sup>&#8377;</sup>
                                        </h1>
                                    <div class="text-muted font-w500 mb-0">Expense</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Column -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

