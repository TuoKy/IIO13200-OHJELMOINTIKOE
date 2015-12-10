<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3408_T2ASP.aspx.cs" Inherits="Tehtavat_H3408_T2ASP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="OrjaTaulu" runat="server"></asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Näytä Vakituiset" OnClick="Button1_Click" /><asp:Button ID="Button4" runat="server" Text="Määräaikaiset" OnClick="Button4_Click" /> <asp:Button ID="Button5" runat="server" Text="Muut" OnClick="Button5_Click" /><asp:Button ID="Button6" runat="server" Text="Kaikki" OnClick="Button6_Click"/>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Laske työntekijöiden määrä" OnClick="Button2_Click" /><asp:Button ID="Button7" runat="server" Text="Vakituiset" OnClick="Button7_Click" /><asp:Button ID="Button8" runat="server" Text="ääräaikaiset" OnClick="Button8_Click" /><asp:Button ID="Button9" runat="server" Text="Muut" OnClick="Button9_Click" />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Kaikkien palkat" OnClick="Button3_Click" /> <asp:Button ID="Button10" runat="server" Text="Vakituisten palkat" OnClick="Button10_Click" /> <asp:Button ID="Button11" runat="server" Text="Määräaiakisten palkat" OnClick="Button11_Click" /> <asp:Button ID="Button12" runat="server" Text="Muitten palkat" OnClick="Button12_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Valittujen määrä: "></asp:Label><asp:Label ID="valitut" runat="server" Text="..."></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Valittujen palkkasumma: "></asp:Label><asp:Label ID="valitutPalkat" runat="server" Text="..."></asp:Label>
    </div>
        
    </form>
</body>
</html>
