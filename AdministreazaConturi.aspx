<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministreazaConturi.aspx.cs" Inherits="BicicleteWeb.AdministreazaConturi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .gridView {
            margin: 0 auto;
        }

        .btnActiuni {
            color: mediumblue;
            background-color: azure;
            font-family: 'Times New Roman', Times, serif;
            font-size: 15px;
            text-decoration: solid;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 0 auto; width: 600px; height: 70px; margin-top: 40px;text-align:center">
            <p style="margin: 0 auto; font-size: 40px; text-decoration: solid; color:darkblue;text-align:center">
                <asp:Label ID="lbGestionareUseri" runat="server" Text="Gestionati cererile userilor!"></asp:Label>
            </p>
        </div>
        <div style="margin: 0 auto; width: 850px; height: 100px; color: darkcyan; font-size: 20px;">
            <asp:Label ID="lbFiltreazaGridView" runat="server" Text="Filtre:"></asp:Label>
            <br />
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="filters" Text="Inactivi" AutoPostBack="true" OnCheckedChanged="RadioButton1_CheckedChanged"/>
            <asp:RadioButton ID="RadioButton2" runat="server"  GroupName="filters" Text="Neaprobati" AutoPostBack="true" OnCheckedChanged="RadioButton2_CheckedChanged"/>
            <asp:RadioButton ID="RadioButton3" runat="server"  GroupName="filters" Text="Inactivi si neaprobati" AutoPostBack="true" OnCheckedChanged="RadioButton3_CheckedChanged" />
           <asp:RadioButton ID="RadioButton4" runat="server"  GroupName="filters" Text="Toti Utilizatorii" AutoPostBack="true" OnCheckedChanged="RadioButton4_CheckedChanged"/>
        </div>
        <br />
        <div style="margin: 0 auto;">
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" BackColor="#CCFFFF" CssClass="gridView" OnRowCommand="gvUsers_RowCommand" OnRowDataBound="gvUsers_RowDataBound ">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="ID">
                    <HeaderStyle BackColor="#3399FF" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nume" HeaderText="Nume">
                        <HeaderStyle BackColor="#3399FF" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Parola" HeaderText="Parola">
                        <HeaderStyle BackColor="#3399FF" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Email" HeaderText="Email">
                        <HeaderStyle BackColor="#3399FF" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Data" HeaderText="Data">
                        <HeaderStyle BackColor="#3399FF" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Activ" HeaderText="Activ" NullDisplayText="NULL">
                        <HeaderStyle BackColor="#3399FF" />
                        <ItemStyle Font-Italic="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Aprobat" HeaderText="Aprobat" NullDisplayText="NULL">
                        <HeaderStyle BackColor="#3399FF" />
                        <ItemStyle Font-Italic="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Admin" HeaderText="Admin" NullDisplayText="NULL">
                        <HeaderStyle BackColor="#3399FF" />
                        <ItemStyle Font-Italic="True" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Actiuni">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnActiv" runat="server" CssClass="btnActiuni" Text="Activ" BackColor="#99FFCC" CommandName="Activ"  Visible='<%# Convert.ToString(Eval("Aprobat")) == "True" || Convert.ToString(Eval("Aprobat")) == string.Empty ? true : false %>'/>
                            <asp:LinkButton ID="btnInactiv" runat="server" CssClass="btnActiuni" Text="Inactiv" BackColor="#99FFCC" CommandName="Inactiv" Visible='<%# Convert.ToString(Eval("Aprobat")) == "True" || Convert.ToString(Eval("Aprobat")) == string.Empty? true : false %>'/>
                            <asp:LinkButton ID="btnAprobat" runat="server" CssClass="btnActiuni" Text="Aprobat" BackColor="#99FFCC" CommandName="Aprobat"  Visible='<%# Convert.ToString(Eval("Aprobat")) == string.Empty ? true : false %>' />
                            <asp:LinkButton ID="btnRespins" runat="server" CssClass="btnActiuni" Text="Respins" BackColor="#99FFCC" CommandName="Respins"  Visible='<%# Convert.ToString(Eval("Aprobat")) == string.Empty ? true : false %>'/>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#3399FF" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
