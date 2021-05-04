<%@ Page Title="" Language="C#" MasterPageFile="~/web/AdminPanel.master" AutoEventWireup="true" CodeFile="Catagory.aspx.cs" Inherits="AdminPanel_Catagory_Catagory" %>

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
        <a class="nav-main-link active" href="<%= ResolveClientUrl("~/AdminPanel/Catagory/Catagory.aspx") %>">
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
    Catagory
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagebreadcrumb" runat="Server">
    Catagory
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContant" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="block block-rounded">
                <div class="block-content">

                    <asp:ScriptManager ID="ModalScriptManager" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="ModalUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                        <ContentTemplate>
                            <asp:LinkButton runat="server" ID="lbtnAddCatagory" Text="Add" CssClass="btn btn-primary" data-toggle="modal" data-target="#add-contact" />
                            <asp:LinkButton runat="server" ID="lbtnEditCatagory" Text="Edit"
                                CssClass="btn btn-warning" data-toggle="modal" data-target="#add-contact" />
                            <asp:LinkButton runat="server" ID="lbtnDeleteCatagory" Text="Delete" CssClass="btn btn-danger" OnClick="lbtnDeleteCatagory_Click" />
                            <br />
                            <br />

                            <div id="add-contact" class="modal fade in" tabindex="-1" role="dialog"
                                aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title" id="myModalLabel">Add / Edit Catagory</h4>
                                            <button type="button" class="close" data-dismiss="modal"
                                                aria-hidden="true">
                                                ×</button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-horizontal  form-material">
                                                <div class="form-group">
                                                    <asp:HiddenField runat="server" ID="hfCatagoryID" />
                                                    <div class="col-md-12 m-b-20" style="padding-top: 25px;">
                                                        <asp:TextBox runat="server" ID="txtCatagoryName" CssClass="form-control" placeholder="Enter Catagory Name" />
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvCatagoryName" ControlToValidate="txtCatagoryName" Display="Dynamic" CssClass="text-danger" ErrorMessage="Please Enter Catagory" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-12 m-b-20" style="padding-top: 25px;">
                                                        <asp:RadioButtonList runat="server" ID="rbCatagoryType" RepeatDirection="Horizontal" CellPadding="5">
                                                            <asp:ListItem Value="Income" Selected="True">  Income</asp:ListItem>
                                                            <asp:ListItem Value="Expense"> Expense</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <div class="col-md-12 m-b-20" style="padding-top: 25px;">
                                                        <asp:TextBox runat="server" ID="txtDescripation" CssClass="form-control" placeholder="Descripation" TextMode="MultiLine" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click" ValidationGroup="Save" />
                                            <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger waves-effect" Text="Cancel" data-dismiss="modal" />
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            <!-- end Contact Popup Model -->
                            <script>

                                function setvalue(el) {
                                    $('input[type="checkbox"]').on('change', function () {
                                        $('input[type="checkbox"]').not(this).prop('checked', false);
                                    });

                                    $("#PageContant_lbtnAddCatagory").click(function () {
                                        $("#PageContant_hfCatagoryID").val(null);
                                        $("#PageContant_txtCatagoryName").val(null);
                                        $("#PageContant_rbCatagoryType_0").prop('checked', true);
                                        $("#PageContant_txtDescripation").val(null);
                                    });

                                    $("#PageContant_lbtnEditCatagory").click(function () {

                                            $("#PageContant_hfCatagoryID").val($(el).parent().find("#hlCatagory").val());
                                            $("#PageContant_txtCatagoryName").val($(el).parent().find("#hlCategoryName").val());

                                            if ($(el).parent().find("#hlCategoryType").val() == 'Income') {
                                                $("#PageContant_rbCatagoryType_0").prop('checked', true);
                                            }
                                            else {
                                                $("#PageContant_rbCatagoryType_1").prop('checked', true);
                                            }
                                            $("#PageContant_txtDescripation").val($(el).parent().find("#hlCategoryDescripation").val());
 
                                    });
                                }
                            </script>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="alert alert-success " id="divMessage" runat="server" visible="false">
                                        <asp:Label runat="server" ID="lblErrorMessage" />
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvCatagory" runat="server" AutoGenerateColumns="false" DataKeyNames="CatagoryID"
                                            CssClass="table table-borderless table-striped search-table v-middle" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="n-chk align-self-center text-center">
                                                            <div class="checkbox checkbox-info">
                                                                <asp:HiddenField runat="server" ID="hlCatagory" ClientIDMode="Static" Value='<%# Eval("CatagoryID") %>' />
                                                                <asp:HiddenField runat="server" ID="hlCategoryName" ClientIDMode="Static" Value='<%# Eval("CatagoryName") %>' />
                                                                <asp:HiddenField runat="server" ID="hlCategoryType" ClientIDMode="Static" Value='<%# Eval("CatagoryType") %>' />
                                                                <asp:HiddenField runat="server" ID="hlCategoryDescripation" ClientIDMode="Static" Value='<%# Eval("CatagoryDescripation") %>' />
                                                                <asp:CheckBox runat="server" ID="chkCatagory" onclick='javascript:setvalue(this)' />
                                                                <asp:Label runat="server" ID="lblchackbox" AssociatedControlID="chkCatagory"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CatagoryName" HeaderText="Name" HeaderStyle-CssClass="text-dark font-weight-bold" />
                                                <asp:BoundField DataField="CatagoryType" HeaderText="Type" HeaderStyle-CssClass="text-dark font-weight-bold" />
                                                <asp:BoundField DataField="CatagoryDescripation" HeaderText="Descripation" HeaderStyle-CssClass="text-dark font-weight-bold" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lbtnAddCatagory" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnDeleteCatagory" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnEditCatagory" EventName="Click" />
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

