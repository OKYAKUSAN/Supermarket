<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SortEdit.aspx.cs" Inherits="Supermarket.Basic.SortEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <script type="text/javascript" src="/Scripts/jquery-1.12.4.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" action="/Basic/SortSend.aspx" method="post" target="rightFrame">
    <div class="p30">
        <div class="breadCrumb">
            <a href="/home.aspx" target="rightFrame">首页</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<a href="/Basic/sortlist.aspx" target="rightFrame">分类管理</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<span>分类编辑</span>
        </div>

        <div class="mt10">
            <asp:Literal ID="SortIdInput" runat="server"></asp:Literal>
            <table class="formTable">
                <colgroup>
                    <col style="width:150px;" />
                    <col style="width:auto;" />
                </colgroup>
                <tr class="tbg0"><th colspan="2">分类信息</th></tr>
                <tr>
                    <th class="tr">名称</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-text">
                                    <input type="text" id="formSortName" name="formSortName" placeholder="请输入分类名称" value="<%=sortName %>" />
                                </div>
                            </div>
                            <div class="formMsg">请输入分类名称</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td class="formTableBtn"><input type="submit" id="formSubmit" value="提交" /><input type="button" onclick="javascript:window.location='/Basic/sortlist.aspx'" value="返回" /></td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var sortName = $("#formSortName");
            sortName.val(<%=sortName %>);
            $("#formSubmit").click(function () {
                var submit = true;
                if (sortName.val() == "") {
                    sortName.parents(".formItem").next().show();
                    submit = false;
                } else sortName.parents(".formItem").next().hide();
                return submit;
            });
        });
    </script>
    </form>
</body>
</html>
