<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleList.aspx.cs" Inherits="Supermarket.Transaction.SaleList" %>

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
            <a href="/home.aspx" target="rightFrame">首页</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<span>销售管理</span>
        </div>
        
        <div class="listTable-topControl">
            <a href="/Transaction/SaleEdit.aspx" target="rightFrame">添加记录</a>&nbsp;&nbsp;|&nbsp;&nbsp;
        </div>
        <div class="listTable mt10">
            <table>
                <colgroup>
                    <col style="width:15%;" />
                    <col style="width:20%;" />
                    <col style="width:10%;" />
                    <col style="width:10%;" />
                    <col style="width:10%;" />
                    <col style="width:10%;" />
                    <col style="width:15%;" />
                    <col style="width:10%;" />
                </colgroup>
                <tr class="tbg0">
                    <th>单号</th><th>商品名称</th><th>分类</th><th>单价（元）</th><th>数量</th><th>单位</th><th>销售时间</th><th>操作</th>
                </tr>
                <!--
                <tr class="tbg1">
                    <td>SA20190415100500</td>
                    <td>白沙（软）</td>
                    <td>烟</td>
                    <td>7.00</td>
                    <td>1</td>
                    <td>包</td>
                    <td>2019-04-15 10:05:00</td>
                    <td><a href="#" target="rightFrame">编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="#" target="rightFrame">删除</a></td>
                </tr>
                -->
                <asp:Literal ID="SaleListTable" runat="server"></asp:Literal>
            </table>
        </div>
        <div class="pageNumControl">
            <asp:Literal ID="SalePageNum" runat="server"></asp:Literal>
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
