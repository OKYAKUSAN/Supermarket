<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sortlist.aspx.cs" Inherits="Supermarket.Basic.sortlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <script type="text/javascript" src="/Scripts/jquery-1.12.4.min.js"></script>
    <title></title>
</head>
<body>
    <div class="p30">
        <div class="breadCrumb">
            <a href="/home.aspx" target="rightFrame">首页</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<span>分类管理</span>
        </div>

        <div class="listTable-topControl">
            <a href="/Basic/SortEdit.aspx" target="rightFrame">添加分类</a>&nbsp;&nbsp;|&nbsp;&nbsp;
        </div>
        <div class="listTable mt10">
            <table>
                <colgroup>
                    <col style="width:15%;" />
                    <col style="width:70%;" />
                    <col style="width:15%;" />
                </colgroup>
                <tr class="tbg0">
                    <th>名称</th><th></th><th>操作</th>
                </tr>
                <asp:Literal ID="SortListTable" runat="server"></asp:Literal>
            </table>
        </div>
        <div class="pageNumControl">
            <asp:Literal ID="SortPageNum" runat="server"></asp:Literal>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $(".listTable tr:gt(0)").mouseenter(function () {
                $(this).addClass("tbg3");
            }).mouseleave(function () {
                $(this).removeClass("tbg3");
            });
        });
    </script>
</body>
</html>
