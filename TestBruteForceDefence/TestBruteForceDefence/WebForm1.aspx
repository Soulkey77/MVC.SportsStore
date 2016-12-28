<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestBruteForceDefence.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblTime"></asp:Label>
        <br />
        L: <asp:TextBox runat="server" ID="txtLogin"></asp:TextBox>
        <br />
        P: <asp:TextBox runat="server" ID="txtPass" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btnValidate" Text="Enter" OnClick="btnValidate_Click" />
    </div>
    </form>
</body>
</html>
