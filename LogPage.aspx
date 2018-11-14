<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogPage.aspx.cs" Inherits="BicicleteWeb.LogPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function openCreareContPage(url, name) {
            var strWindowFeatures = "menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes,width=800,height=600";
            var windowObjectReference = window.open(url, name, strWindowFeatures);
        }

    </script>
    <style>
        table, th, td {
            border: 1px solid #91BFF1;
            text-align: center;
            color: #2D2E68;
            border-collapse:collapse;
        }
    </style>
</head>
<body id="page_body">
    <form runat="server">
        <div style="margin-left: 30px;">
            <asp:DropDownList ID="dllCulture" runat="server" Style="position: relative; left: 30px; top: 20px" OnSelectedIndexChanged="dllCulture_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="ro" Selected="True">Romana</asp:ListItem>
                <asp:ListItem Value="en-US">English</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <br />

        <p style="margin: auto; text-align: center; font-size: 50px; padding: 10px; height: 80px; width: 500px; color: #2D2E68;">
            <asp:Label ID="lbWelcome" runat="server" Text="Bine ai venit!"></asp:Label>
        </p>
        <br />
        <br />
        <div style="margin: auto; text-align: center; font-size: 20px; padding: 20px;">
            <table style="margin: 0 auto; width:350px;height:150px ">
                <tr>
                    <th colspan="3">
                        <asp:Label ID="lbAutentificare" runat="server" Text="Autentificare"></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbUsername" runat="server" Text="Nume"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNume" runat="server" ErrorMessage="Numele!" ForeColor="Red" ControlToValidate="tbUsername"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPassword" runat="server" Text="Parola"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvParola" runat="server" ErrorMessage="Parola!" ForeColor="Red" ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lbValidation" runat="server" Text="Datele sunt incorecte sau contul nu a fost aprobat/activat!Reincercati!" Visible="false" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnLogin" runat="server" Text="Autentificare" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 0 auto; height: 50px; width: 800px; text-align: center">
            <p style="text-decoration: underline; font-size: 18px; color: #2D2E68;" onclick="openCreareContPage('http://localhost:58241/CreeazaCont','CreareCont');return false;">
                <asp:Label ID="lbCreazaCont" runat="server" Text="Nu ai cont?Creeaza-ti unul!"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>

