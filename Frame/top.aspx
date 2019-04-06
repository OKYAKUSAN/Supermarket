<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Supermarket.Frame.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="topFrame">
        <img src="/images/admin_logo.png" alt="" />
    </div>
    </form>
</body>
</html>
