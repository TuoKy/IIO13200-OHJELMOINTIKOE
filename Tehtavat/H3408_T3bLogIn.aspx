<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3408_T3bLogIn.aspx.cs" Inherits="Tehtavat_H3408_T3bLogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>PuolipilkunViilaajat</h1>
        <asp:Image ID="Image1" ImageUrl="http://www.thedistractionnetwork.com/images/programming-fail-008-200x200.png" runat="server" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Käyttis"></asp:Label><asp:TextBox ID="nimi" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="nimi" ErrorMessage="Missä nimi?"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Passu"></asp:Label><asp:TextBox ID="passu" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="passu" ErrorMessage="Missä passu?"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="logIn" runat="server" Text="Logga in" OnClick="logIn_Click" />
    </div>
    </form>
</body>
</html>
