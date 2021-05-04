<%@ Page Title="" Language="C#" MasterPageFile="~/web/AdminPanel.master" AutoEventWireup="true" CodeFile="Income.aspx.cs" Inherits="AdminPanel_Income_Income" %>

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
        <a class="nav-main-link active" href="<%= ResolveClientUrl("~/AdminPanel/Income/Income.aspx") %>">
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
    Income
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagebreadcrumb" runat="Server">
    Income
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContant" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-body">
                   
                    <h6 class="card-subtitle" style="padding-top: 10px;"></h6>
                    <asp:ScriptManager ID="ModalScriptManager" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="ModalUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="lbtnAddIncome" Text="Add" CssClass="btn btn-primary" data-toggle="modal" data-target="#add-contact" />
                            <asp:LinkButton runat="server" ID="lbtnEditIncome" Text="Edit"
                                CssClass="btn btn-warning" data-toggle="modal" data-target="#add-contact"  />
                            <asp:LinkButton runat="server" ID="lbtnDeleteIncome" Text="Delete" CssClass="btn btn-danger" OnClick="lbtnDeleteIncome_Click" />
                            <br />
                            <br />
                            <!-- Add Contact Popup Model -->
                            <div id="add-contact" class="modal fade in" tabindex="-1" role="dialog"
                                aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title" id="myModalLabel">Add / Edit Income</h4>
                                            <button type="button" class="close" data-dismiss="modal"
                                                aria-hidden="true">
                                                ×</button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-horizontal form-material">
                                                <div class="form-group">
                                                    <asp:HiddenField runat="server" ID="hfIncomeID" />
                                                    <div class="col-md-12 m-b-20" style="padding-top: 20px;">
                                                        <asp:TextBox runat="server" ID="txtIncomeName" CssClass="form-control" placeholder="Income Name" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvIncomeName" Display="Dynamic" ControlToValidate="txtIncomeName"
                                                            ErrorMessage="Please Enter Income Source" CssClass="text-danger" ValidationGroup="SaveIncome"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 m-b-20" style="padding-top: 20px;">
                                                        <asp:DropDownList runat="server" ID="ddlCatagoryList" CssClass="form-control"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvCatagory" Display="Dynamic" ControlToValidate="ddlCatagoryList"
                                                            ErrorMessage="Please Enter Catagory" CssClass="text-danger" InitialValue="-1" ValidationGroup="SaveIncome"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 m-b-20" style="padding-top: 20px;">
                                                        <asp:TextBox runat="server" ID="txtdate" CssClass="form-control" placeholder="Date" TextMode="Date" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvDate" Display="Dynamic" ControlToValidate="txtdate"
                                                            ErrorMessage="Please Enter Date" CssClass="text-danger" ValidationGroup="SaveIncome"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 m-b-20" style="padding-top: 20px;">
                                                        <asp:TextBox runat="server" ID="txtDescripation" CssClass="form-control" placeholder="Descripation" TextMode="MultiLine" />
                                                    </div>
                                                    <div class="col-md-12 m-b-20" style="padding-top: 20px;">
                                                        <asp:TextBox runat="server" ID="txtIncomeAmount" CssClass="form-control" placeholder="Income Amount" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvIncomeAmount" Display="Dynamic" ControlToValidate="txtIncomeAmount"
                                                            ErrorMessage="Please Enter Income Amount" CssClass="text-danger" ValidationGroup="SaveIncome"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator runat="server" ID="rvIncome" Display="Dynamic" ControlToValidate="txtIncomeAmount" CssClass="text-danger" ErrorMessage="Please Enter Proper formate Income"  SetFocusOnError="True" Type="Double" ValidationGroup="SaveIncome" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info waves-effect" Text="Save" OnClick="btnSave_Click" ValidationGroup="SaveIncome" />
                                            <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger waves-effect" Text="Cancel" data-dismiss="modal" />
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>

                            <script>

                                function setvalue(el) {

                                    $('input[type="checkbox"]').on('change', function () {
                                        $('input[type="checkbox"]').not(this).prop('checked', false);
                                    });

                                    $("#PageContant_lbtnAddIncome").click(function () {
                                        $("#PageContant_hfIncomeID").val(null);
                                        $("#PageContant_txtIncomeName").val(null);
                                        $("#PageContant_ddlCatagoryListoption:contains(" + $(el).parent().find("#hlCategoryID").val(-1) + ")").attr('selected', 'selected');
                                        $("#PageContant_txtdate").val(null);
                                        $("#PageContant_txtDescripation").val(null);
                                        $("#PageContant_txtIncomeAmount").val(null);
                                    });

                                    $("#PageContant_lbtnEditIncome").click(function () {
                                        var d = new Date($(el).parent().find("#hlDate").val().split(' ')[0]),
                                            month = '' + (d.getMonth() + 1),
                                            day = '' + d.getDate(),
                                            year = d.getFullYear();
                                        if (month.length < 2)
                                            month = '0' + month;
                                        if (day.length < 2)
                                            day = '0' + day;
                                        var newdate = [year, month, day].join('-');

                                        $("#PageContant_hfIncomeID").val($(el).parent().find("#hlIncomeID").val());
                                        $("#PageContant_txtIncomeName").val($(el).parent().find("#hlIncomeName").val());
                                        $("#PageContant_ddlCatagoryList option:contains(" + $(el).parent().find("#hlCategoryID").val() + ")").attr('selected', 'selected');
                                        $("#PageContant_txtdate").val(newdate);
                                        $("#PageContant_txtDescripation").val($(el).parent().find("#hlDescripation").val());
                                        $("#PageContant_txtIncomeAmount").val($(el).parent().find("#hlIncomeAmount").val());
                                    });
                                }

                            </script>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="alert alert-success " id="divMessage" runat="server" visible="false">
                                         <asp:Label runat="server" ID="lblErrorMessage"/>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </div>
                            </div>

                            <div class="table-responsive">
                                <asp:GridView ID="gvIncome" runat="server" AutoGenerateColumns="false" DataKeyNames="IncomeID"
                                    CssClass="table table-borderless table-striped table-vcenter" ShowFooter="True" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="n-chk align-self-center text-center">
                                                    <div class="checkbox checkbox-info">
                                                        <asp:HiddenField runat="server" ID="hlIncomeID" ClientIDMode="Static" Value='<%# Eval("IncomeID") %>' />
                                                        <asp:HiddenField runat="server" ID="hlIncomeName" ClientIDMode="Static" Value='<%# Eval("IncomeName") %>' />
                                                        <asp:HiddenField runat="server" ID="hlCategoryID" ClientIDMode="Static" Value='<%# Eval("CatagoryName") %>' />
                                                        <asp:HiddenField runat="server" ID="hlDate" ClientIDMode="Static" Value='<%# Eval("Date") %>' />
                                                        <asp:HiddenField runat="server" ID="hlDescripation" ClientIDMode="Static" Value='<%# Eval("Descripation") %>' />
                                                        <asp:HiddenField runat="server" ID="hlIncomeAmount" ClientIDMode="Static" Value='<%# Eval("IncomeAmount") %>' />
                                                        <asp:CheckBox runat="server" ID="chkIncome" onclick='javascript:setvalue(this)' />
                                                        <asp:Label runat="server" ID="lblchackbox" AssociatedControlID="chkIncome"></asp:Label>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IncomeName" HeaderText="Name" />
                                        <asp:BoundField DataField="CatagoryName" HeaderText="Catagory" />
                                        <asp:BoundField DataField="Date" HeaderText="Income Date" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Descripation" HeaderText="Descripation" FooterStyle-Font-Bold="true" />
                                        <asp:BoundField DataField="IncomeAmount" HeaderText="Amount" FooterStyle-Font-Bold="true" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lbtnAddIncome" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnDeleteIncome" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnEditIncome" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
