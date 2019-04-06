<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Supermarket.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<frameset rows="100,*,30" cols="*" frameborder="no" border="0" framespacing="0">
    <frame src="/Frame/top.aspx" id="topFrame" name="topFrame" noresize="noresize" scrolling="no"></frame>
    <frameset cols="200,*" id="middleFrame" frameborder="no" border="0" framespacing="0">
        <frame src="/Frame/left.aspx" id="leftFrame" name="leftFrame" noresize="noresize" scrolling="no"></frame>
        <frame src="home.aspx" id="rightFrame" name="rightFrame" noresize="noresize"></frame>
    </frameset>
    <frame src="/Frame/bottom.html" id="bottomFrame" name="bottomFrame" noresize="noresize" scrolling="no"></frame>
</frameset>
<body>
</body>
</html>
