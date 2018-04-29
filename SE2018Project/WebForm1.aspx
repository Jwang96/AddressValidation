<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SE2018Project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>

<body style="height: 469px; width: 418px">
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            USPS Address Verification
        </div>
        <p>
            <asp:TextBox ID="Address" placeholder="Enter Address" runat="server" Style="margin-left: 3px" OnTextChanged="Address_TextChanged" Width="367px"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="ApptNum" placeholder="Apartment/Suit #" runat="server" Style="margin-left: 3px" OnTextChanged="ApptNum_TextChanged" Width="367px"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="City" placeholder="*City" runat="server" Style="margin-left: 0px" Width="125px"></asp:TextBox>
            <asp:TextBox ID="State" placeholder="*State" runat="server" Style="margin-left: 6px" Width="58px"></asp:TextBox>
            <asp:TextBox ID="ZipCode" placeholder="*Zip5 Code" runat="server" Style="margin-left: 3px" Width="82px" OnTextChanged="ZipCode_TextChanged1"></asp:TextBox>
            <asp:TextBox ID="ZipCode4" placeholder="Zip4 Code" runat="server" OnTextChanged="TextBox2_TextChanged" Width="74px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Validate" runat="server" OnClick= "Validate_Click" Text="Validate"/>
        </p>
        <asp:TextBox ID="TextBox1" runat="server" Height="108px" OnTextChanged="TextBox1_TextChanged" Width="370px" TextMode="MultiLine"></asp:TextBox>
    </form>
</body>
</html>