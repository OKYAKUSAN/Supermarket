<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Supermarket.home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <title></title>
</head>
<body>
    <div class="p30">
        <div class="homeTable">
            <table>
                <colgroup>
                    <col style="width:25%;" />
                    <col style="width:25%;" />
                    <col style="width:25%;" />
                    <col style="width:25%;" />
                </colgroup>
                <tr>
                    <th>总商品数量</th>
                    <td>123</td>
                    <th>在售商品数量</th>
                    <td>121</td>
                </tr>
            </table>
        </div>
        <div class="achievement">
        </div>
    </div>
</body>
</html>
