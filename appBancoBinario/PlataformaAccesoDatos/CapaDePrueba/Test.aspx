﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Plataforma.CapaDePrueba.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    
    </div>
    <p>
        <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
        <textarea id="TextArea1" cols="20" name="S1" rows="2"></textarea><asp:Label 
            ID="lblTest2" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
