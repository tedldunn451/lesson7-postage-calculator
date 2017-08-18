<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lesson7_postage_calculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Text="Postal Calculator"></asp:Label>
            <br />
            <br />
            Width:&nbsp;&nbsp;
            <asp:TextBox ID="widthTextBox" runat="server" AutoPostBack="True" OnTextChanged="widthTextBox_TextChanged" Width="35px"></asp:TextBox>
            <br />
            Height:&nbsp;
            <asp:TextBox ID="heightTextBox" runat="server" AutoPostBack="True" OnTextChanged="heightTextBox_TextChanged" Width="35px"></asp:TextBox>
            <br />
            Length:&nbsp;
            <asp:TextBox ID="lengthTextBox" runat="server" AutoPostBack="True" OnTextChanged="lengthTextBox_TextChanged" Width="35px"></asp:TextBox>
            <br />
            <br />
            <asp:RadioButton ID="groundRadioButton" runat="server" AutoPostBack="True" Checked="True" GroupName="shippingGroup" OnCheckedChanged="groundRadioButton_CheckedChanged" Text="Ground" />
            <br />
            <asp:RadioButton ID="airRadioButton" runat="server" AutoPostBack="True" GroupName="shippingGroup" OnCheckedChanged="airRadioButton_CheckedChanged" Text="Air" />
            <br />
            <asp:RadioButton ID="nextDayRadioButton" runat="server" AutoPostBack="True" GroupName="shippingGroup" OnCheckedChanged="nextDayRadioButton_CheckedChanged" Text="Next Day" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
