<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsEdit.aspx.cs" Inherits="Supermarket.Basic.GoodsEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <script type="text/javascript" src="/Scripts/jquery-1.12.4.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" action="/Basic/GoodsSend.aspx" method="post" target="rightFrame">
    <div class="p30">
        <div class="breadCrumb">
            <a href="/home.aspx" target="rightFrame">首页</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<a href="/Basic/GoodsList.aspx" target="rightFrame">商品管理</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<span>商品编辑</span>
        </div>
        
        <div class="mt10">
            <asp:Literal ID="GoodsIdInput" runat="server"></asp:Literal>
            <table class="formTable">
                <colgroup>
                    <col style="width:150px;" />
                    <col style="width:auto;" />
                </colgroup>
                <tr class="tbg0"><th colspan="2">商品信息</th></tr>
                <tr>
                    <th class="tr">商品名称</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-text">
                                    <input type="text" id="formGoodsName" name="formGoodsName" placeholder="请输入分类名称" value="" />
                                </div>
                            </div>
                            <div class="formMsg">请输入商品名称</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th class="tr">所属分类</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-select">
                                    <select id="formSortId" name="formSortId">
                                        <option value="">请选择</option>
                                        <asp:Literal ID="SortListSelect" runat="server"></asp:Literal>
                                    </select>
                                </div>
                            </div>
                            <div class="formMsg">请选择分类</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th class="tr">默认售价（元）</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-text">
                                    <input type="text" id="formGoodsPrice" name="formGoodsPrice" placeholder="请输入默认售价" value="0.00" />
                                </div>
                            </div>
                            <div class="formMsg">请输入商品售价</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th class="tr">默认进价（元）</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-text">
                                    <input type="text" id="formGoodsCost" name="formGoodsCost" placeholder="请输入默认进价" value="0.00" />
                                </div>
                            </div>
                            <div class="formMsg">请输入商品进价</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th class="tr">是否在售</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-radio">
                                    <div>
                                        <input type="radio" id="formGoodsOnsaleTrue" name="formGoodsOnsale" value="1" />
                                        <label for="formGoodsOnsaleTrue">是</label>
                                    </div>
                                    <div>
                                        <input type="radio" id="formGoodsOnsaleFalse" name="formGoodsOnsale" value="0" />
                                        <label for="formGoodsOnsaleFalse">否</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td class="formTableBtn"><input type="submit" id="formSubmit" value="提交" /><input type="button" onclick="javascript:window.location='/Basic/GoodsList.aspx'" value="返回" /></td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var goodsName = $("#formGoodsName");
            var sortId = $("#formSortId");
            var goodsPrice = $("#formGoodsPrice");
            var goodsCost = $("#formGoodsCost");
            //var goodsOnsale = $("#formGoodsOnsale");
            var goodsOnsaleTrue = $("#formGoodsOnsaleTrue");
            var goodsOnsaleFalse = $("#formGoodsOnsaleFalse");

            <%
            if(goodsId>0)
            {
             %>
             var _goodsName = "<%=goodsName %>";
             var _sortId = <%=sortId %>;
             var _goodsPrice = "<%=goodsPrice %>";
             var _goodsCost = "<%=goodsCost %>";
             <% if(goodsOnsales){ %>
             var _goodsOnsale =true;
             <% }else{ %>
             var _goodsOnsale =false;
             <% } %>
             goodsName.val(_goodsName);
             sortId.find("option:gt(0)").each(function(){
                if($(this).val()==_sortId) $(this).attr("selected","selected");
             });
             goodsPrice.val(_goodsPrice);
             goodsCost.val(_goodsCost);
             if(_goodsOnsale) goodsOnsaleTrue.attr("checked","checked");
             else goodsOnsaleFalse.attr("checked","checked");
             <%
             }
              %>

            goodsPrice.blur(function () {
                var value = parseFloat($(this).val()).toFixed(2);
                if (!isNaN(value)) $(this).val(value);
                else $(this).val("0.00");
            });
            goodsCost.blur(function () {
                var value = parseFloat($(this).val()).toFixed(2);
                if (!isNaN(value)) $(this).val(value);
                else $(this).val("0.00");
            });

            $("#formSubmit").click(function () {
                var submit = true;
                if (goodsName.val() == "") {
                    goodsName.parents(".formItem").next().show();
                    submit = false;
                } else goodsName.parents(".formItem").next().hide();
                if (sortId.val() == "") {
                    sortId.parents(".formItem").next().show();
                    submit = false;
                } else sortId.parents(".formItem").next().hide();
                return submit;
            });
        });
    </script>
    </form>
</body>
</html>
