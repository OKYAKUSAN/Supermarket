<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="Supermarket.Frame.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <script type="text/javascript" src="/Scripts/jquery-1.12.4.min.js"></script>
    <title></title>
</head>
<body style=" background-color:#eef1f8;">
    <form id="form1" runat="server">
    <div class="leftNav">
        <ul>
            <li>
                <div class="leftNav-item">基础数据<span></span></div>
                <div class="leftNav-subNav">
                    <a href="/Basic/sortlist.aspx" target="rightFrame">分类管理</a>
                    <a href="/Basic/GoodsList.aspx" target="rightFrame">商品管理</a>
                </div>
            </li>
            <li>
                <div class="leftNav-item">导航菜单<span></span></div>
                <div class="leftNav-subNav">
                    <a href="rightFrame" target="rightFrame">子导航菜单</a>
                    <a href="rightFrame" target="rightFrame">子导航菜单</a>
                    <a href="rightFrame" target="rightFrame">子导航菜单</a>
                </div>
            </li>
            <li>
                <div class="leftNav-item">导航菜单<span></span></div>
                <div class="leftNav-subNav">
                    <a href="rightFrame" target="rightFrame">子导航菜单</a>
                    <a href="rightFrame" target="rightFrame">子导航菜单</a>
                    <a href="rightFrame" target="rightFrame">子导航菜单</a>
                </div>
            </li>
        </ul>
    </div>
    <script type="text/javascript">
        $(function () {
            var listItem = $(".leftNav-item");
            var clickIndex;
            var currentIndex;
            listItem.click(function () {
                clickIndex = listItem.index($(this));
                //console.log(listItem.filter(".sel").length);
                if (listItem.filter(".sel").length > 0) {
                    //console.log("-1");
                    currentIndex = listItem.index(listItem.filter(".sel"));
                    if (clickIndex == currentIndex) {
                        $(this).removeClass("sel");
                        $(this).next().slideUp("fast");
                    } else {
                        listItem.filter(".sel").next().hide();
                        listItem.filter(".sel").removeClass("sel");
                        $(this).addClass("sel");
                        $(this).next().slideDown("fast");
                    }
                } else {
                    $(this).addClass("sel");
                    $(this).next().slideDown("fast");
                }
            });

            var listSubItem = $(".leftNav-subNav a");
            listSubItem.click(function () {
                listSubItem.filter(".sel").removeClass("sel");
                $(this).addClass("sel");
            });
        });
    </script>
    </form>
</body>
</html>
