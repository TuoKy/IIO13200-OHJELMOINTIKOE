<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3408_T3bDestination.aspx.cs" Inherits="Tehtavat_H3408_T3bDestination" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Onnellisten koodaajien työmerkinnät</h1>
        <asp:GridView ID="koodiTaulu" runat="server"></asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Näytä vain omat" OnClick="Button1_Click" /><asp:Label ID="tunnit" runat="server" Text="..."></asp:Label>
        <h2>Lisää merkintä</h2>
        <asp:Label ID="Label1" runat="server" Text="Nimi"></asp:Label><asp:TextBox ID="nimi" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="nimi" ErrorMessage="Missä nimi?"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Päivämäärä"></asp:Label><asp:TextBox ID="paiva" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="paiva" ErrorMessage="Missä paivä?"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Aika, muotoa hh:mm"></asp:Label><asp:TextBox ID="aika" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ControlToValidate="aika" ErrorMessage="Missä tunnit?"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="lisaa" runat="server" Text="Lisää merkintä" OnClick="lisaa_Click" />

    </div>
    </form>
</body>
</html>
