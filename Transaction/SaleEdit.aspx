<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleEdit.aspx.cs" Inherits="Supermarket.Transaction.SaleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <script type="text/javascript" src="/Scripts/jquery-1.12.4.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" action="/Transaction/SaleSend.aspx" method="post" target="rightFrame">
    <div class="p30">
        <div class="breadCrumb">
            <a href="/home.aspx" target="rightFrame">首页</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<a href="/Basic/GoodsList.aspx" target="rightFrame">销售管理</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<span>商品编辑</span>
        </div>

        <div class="mt10">
            <asp:Literal ID="SaleIdInput" runat="server"></asp:Literal>
            <asp:Literal ID="SaleNumberInput" runat="server"></asp:Literal>
            <table class="formTable">
                <colgroup>
                    <col style="width:150px;" />
                    <col style="width:auto;" />
                </colgroup>
                <tr class="tbg0"><th colspan="2">销售信息</th></tr>
                <tr>
                    <th class="tr">商品名称</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-select transactionGoods">
                                    <select id="formSortId" name="formSortId">
                                        <option value="">请选择</option>
                                        <asp:Literal ID="FormSortIdSelect" runat="server"></asp:Literal>
                                    </select>
                                    <select id="formGoodsId" name="formGoodsId" disabled="disabled">
                                        <option price="" value="">-</option>
                                        <asp:Literal ID="FormGoodsIdSelect" runat="server"></asp:Literal>
                                    </select>
                                </div>
                            </div>
                            <div class="formMsg">请选择商品名称</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th class="tr">售价</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-text">
                                    <input type="text" id="formSalePrice" name="formSalePrice" placeholder="请输入价格" value="" />
                                </div>
                            </div>
                            <div class="formMsg">请输入价格</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th class="tr">数量</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-text">
                                    <input type="text" id="formSaleCount" name="formSaleCount" placeholder="请输入数量" value="" />
                                </div>
                            </div>
                            <div class="formMsg">请输入数量</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th class="tr">单位</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-select">
                                    <select id="formSaleUnit" name="formSaleUnit">
                                        <option value="">请选择</option>
                                        <option value="包">包</option>
                                        <option value="瓶">瓶</option>
                                        <option value="袋">袋</option>
                                        <option value="个">个</option>
                                    </select>
                                </div>
                            </div>
                            <div class="formMsg">请输入价格</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th class="tr">销售日期</th>
                    <td>
                        <div class="formList">
                            <div class="formItem">
                                <div class="formItem-select transactionSelct">
                                    <div><select id="formSaleYear" name="formSaleYear"><option value="">请选择</option></select><span>年</span></div>
                                    <div><select id="formSaleMonth" name="formSaleMonth" disabled="disabled"><option value="">-</option></select><span>月</span></div>
                                    <div><select id="formSaleDay" name="formSaleDay" disabled="disabled"><option value="">-</option></select><span>日</span></div>
                                    <div><select id="formSaleHours" name="formSaleHours"><option value="">请选择</option></select><span>时</span></div>
                                    <div><select id="formSaleMinutes" name="formSaleMinutes"><option value="">请选择</option></select><span>分</span></div>
                                    <div><select id="formSaleSecond" name="formSaleSecond"><option value="">请选择</option></select><span>秒</span></div>
                                </div>
                            </div>
                            <div class="formMsg">请选择时间</div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td class="formTableBtn"><input type="submit" id="formSubmit" value="提交" /><input type="button" onclick="javascript:window.location='/Transaction/SaleList.aspx'" value="返回" /></td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var formSortId = $("#formSortId");
            var formGoodsId = $("#formGoodsId");
            var formSalePrice = $("#formSalePrice");
            var formSaleCount = $("#formSaleCount");
            var formSaleUnit = $("#formSaleUnit");
            var formSaleYear = $("#formSaleYear");
            var formSaleMonth = $("#formSaleMonth");
            var formSaleDay = $("#formSaleDay");
            var formSaleHours = $("#formSaleHours");
            var formSaleMinutes = $("#formSaleMinutes");
            var formSaleSecond = $("#formSaleSecond");

            formGoodsId.children(":gt(0)").hide();
            formSortId.change(function () {
                var selectValue = $(this).val();
                formGoodsId.children("option[selected='selected']").removeAttr("selected");
                formGoodsId.children(":first").attr("selected", "selected");
                formGoodsId.children(":gt(0)").hide();
                if (selectValue != "") {
                    formGoodsId.removeAttr("disabled");
                    formGoodsId.children("option[sortTag='" + selectValue + "']").show();
                } else formGoodsId.attr("disabled", "disabled");
            });
            formGoodsId.change(function () {
                var price;
                var id = $(this).val();
                formGoodsId.children(":gt(0)").each(function () {
                    if ($(this).attr("value") == id) price = $(this).attr("price");
                });
                formSalePrice.val(price);
            });
            formSalePrice.blur(function () {
                var value = parseFloat($(this).val());
                $(this).val(value.toFixed(2));
            });
            formSaleCount.blur(function () {
                var value = parseInt($(this).val());
                if (isNaN(value)) $(this).val("");
                else $(this).val(value);
            });
            var currentTime = new Date();
            var currentYear = currentTime.getFullYear();
            for (var i = 2018; i <= currentYear; i++) {
                formSaleYear.append("<option value='" + i + "'>" + i + "</option>");
            }
            for (var j = 1; j <= 12; j++) {
                formSaleMonth.append("<option value='" + j + "'>" + j + "</option>");
            }
            for (var k = 1; k <= 31; k++) {
                formSaleDay.append("<option value='" + k + "'>" + k + "</option>");
            }
            for (var l = 0; l < 24; l++) {
                formSaleHours.append("<option value='" + l + "'>" + l + "</option>");
            }
            for (var m = 0; m < 60; m++) {
                formSaleMinutes.append("<option value='" + m + "'>" + m + "</option>");
            }
            for (var n = 0; n < 60; n++) {
                formSaleSecond.append("<option value='" + n + "'>" + n + "</option>");
            }
            var year;
            formSaleYear.change(function () {
                year = $(this).val();
                formSaleDay.children("option[selected='selected']").removeAttr("selected");
                formSaleDay.children(":first").attr("selected", "selected");
                formSaleDay.children(":gt(0)").hide();
                formSaleDay.attr("disabled", "disabled");
                formSaleMonth.children("option[selected='selected']").removeAttr("selected");
                formSaleMonth.children(":first").attr("selected", "selected");
                formSaleMonth.children(":gt(0)").hide();
                if (year != "") {
                    formSaleMonth.children(":gt(0)").show();
                    formSaleMonth.removeAttr("disabled");
                } else {
                    formSaleMonth.attr("disabled", "disabled");
                }
            });
            formSaleMonth.change(function () {
                var month = $(this).val();
                var leapyear = true;
                formSaleDay.children("option[selected='selected']").removeAttr("selected");
                formSaleDay.children(":first").attr("selected", "selected");
                formSaleDay.children(":gt(0)").hide();
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {
                    formSaleDay.children(":gt(0)").show();
                    formSaleDay.removeAttr("disabled");
                } else if (month == 4 || month == 6 || month == 9 || month == 11) {
                    formSaleDay.children(":lt(31)").show();
                    formSaleDay.removeAttr("disabled");
                } else if (month == 2) {
                    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) leapyear = true;
                    else leapyear = false;
                    if (leapyear) {
                        formSaleDay.children(":lt(30)").show();
                        formSaleDay.removeAttr("disabled");
                    } else {
                        formSaleDay.children(":lt(29)").show();
                        formSaleDay.removeAttr("disabled");
                    }
                } else formSaleDay.attr("disabled", "disabled");
            });

            $("#formSubmit").click(function () {
                var submit = true;
                if (formGoodsId.val() == "") {
                    formGoodsId.parents(".formItem").next().show();
                    submit = false;
                } else formGoodsId.parents(".formItem").next().hide();
                if (formSalePrice.val() == "") {
                    formSalePrice.parents(".formItem").next().show();
                    submit = false;
                } else formSalePrice.parents(".formItem").next().hide();
                if (formSaleCount.val() == "") {
                    formSaleCount.parents(".formItem").next().show();
                    submit = false;
                } else formSaleCount.parents(".formItem").next().hide();
                if (formSaleUnit.val() == "") {
                    formSaleUnit.parents(".formItem").next().show();
                    submit = false;
                } else formSaleUnit.parents(".formItem").next().hide();
                if (formSaleDay.val() == "" || formSaleHours.val() == "" || formSaleMinutes.val() == "" || formSaleSecond.val() == "") {
                    formSaleDay.parents(".formItem").next().show();
                    submit = false;
                } else formSaleDay.parents(".formItem").next().hide();
                return submit;
            });

            <% if(frontSaleId>0){ %>
            var dal_sortId=<%=frontSortId %>;
            var dal_goodsId=<%=frontGoodsId %>;
            var dal_salePrice=<%=frontSalePrice %>;
            var dal_saleCount=<%=frontSaleCount %>;
            var dal_saleUnit="<%=frontSaleUnit %>";
            var dal_saleDateYear=<%=frontSaleDate.Year %>;
            var dal_saleDateMonth=<%=frontSaleDate.Month %>;
            var dal_saleDateDay=<%=frontSaleDate.Day %>;
            var dal_saleDateHour=<%=frontSaleDate.Hour %>
            var dal_saleDateMinute=<%=frontSaleDate.Minute %>
            var dal_saleDateSecond=<%=frontSaleDate.Second %>
            var dal_saleDate=new Date(<%=frontSaleDate.Year %>,<%=frontSaleDate.Month %>-1,<%=frontSaleDate.Day %>,<%=frontSaleDate.Hour %>,<%=frontSaleDate.Minute %>,<%=frontSaleDate.Second %>);
            formSortId.children(":gt(0)").each(function(){
                //console.log($(this).val());
                if($(this).val()==dal_sortId) {
                    $(this).attr("selected","selected");
                    formGoodsId.removeAttr("disabled");
                    formGoodsId.children("option[sortTag='"+dal_sortId+"']").show();
                    formGoodsId.children(":gt(0)").each(function(){
                        if($(this).val()==dal_goodsId) $(this).attr("selected","selected");
                    });
                }

            });
            formSalePrice.val(dal_salePrice.toFixed(2));
            formSaleCount.val(dal_saleCount);
            formSaleUnit.val(dal_saleUnit);
            formSaleYear.val(dal_saleDateYear);
            formSaleMonth.removeAttr("disabled");
            formSaleMonth.val(dal_saleDateMonth);
            var runnian=true;
            if (dal_saleDateMonth == 1 || dal_saleDateMonth == 3 || dal_saleDateMonth == 5 || dal_saleDateMonth == 7 || dal_saleDateMonth == 8 || dal_saleDateMonth == 10 || dal_saleDateMonth == 12) {
                formSaleDay.children(":gt(0)").show();
                formSaleDay.removeAttr("disabled");
            } else if (dal_saleDateMonth == 4 || dal_saleDateMonth == 6 || dal_saleDateMonth == 9 || dal_saleDateMonth == 11) {
                formSaleDay.children(":lt(31)").show();
                formSaleDay.removeAttr("disabled");
            } else if (month == 2) {
                if ((dal_saleDateYear % 4 == 0 && dal_saleDateYear % 100 != 0) || dal_saleDateYear % 400 == 0) runnian = true;
                else runnian = false;
                if (runnian) {
                    formSaleDay.children(":lt(30)").show();
                    formSaleDay.removeAttr("disabled");
                } else {
                    formSaleDay.children(":lt(29)").show();
                    formSaleDay.removeAttr("disabled");
                }
            }
            formSaleDay.val(dal_saleDateDay);
            formSaleHours.val(dal_saleDateHour);
            formSaleMinutes.val(dal_saleDateMinute);
            formSaleSecond.val(dal_saleDateSecond);
            <% } %>
        });
    </script>
    </form>
</body>
</html>
