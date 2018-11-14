<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinalizareComanda.aspx.cs" Inherits="BicicleteWeb.FinalizareComanda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        function schimbaCuloareaR()
        {
            var tbSelectat = document.getElementById("TextBox1").style.backgroundColor;
            document.getElementById("tbCuloare").style.backgroundColor = tbSelectat;
            return false;
        }
          function schimbaCuloareaB()
        {
              var tbSelectat = document.getElementById("TextBox2").style.backgroundColor;
              document.getElementById("tbCuloare").style.backgroundColor = tbSelectat;
            return false;
        }
          function schimbaCuloareaG()
        {
            var tbSelectat = document.getElementById("TextBox3").style.backgroundColor;
            document.getElementById("tbCuloare").style.backgroundColor = tbSelectat;
            return false;
        }
          function schimbaCuloareaY()
        {
            var tbSelectat = document.getElementById("TextBox4").style.backgroundColor;
            document.getElementById("tbCuloare").style.backgroundColor = tbSelectat;
            return false;
        }
    </script>
    <style>
        th {
            text-align: center;
            text-decoration: solid;
            background-color: aquamarine;
        }

        td {
            text-align: center;
            background-color: aliceblue;
        }
         th.p {
            text-align: center;
            text-decoration: solid;
            background-color:#D09E86;
        }

        td.p {
            text-align: center;
            background-color: #EBCEC0;
        }
        .marginAuto {
            margin: 0 auto;
            align-content: center;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .btnAdauga {
            float: right
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 150px">
            <asp:Button ID="btnBack" runat="server" Text="Home Page" BackColor="White" Font-Size="20px" Font-Overline="False" ForeColor="#000066" BorderStyle="None" Font-Underline="True" Height="30px" OnClick="btnBack_Click" />
            <asp:Button ID="btnAdaugaProduse" runat="server" Text="Adauga noi produse in cos!" BackColor="White" Font-Size="20px" Font-Overline="False" ForeColor="#000066" BorderStyle="None" Font-Underline="True" Height="30px" CssClass="btnAdauga" OnClick="btnAdaugaProduse_Click" />
            <asp:Label ID="lbFinalizareComanda" runat="server" Text="Verifica comanda si finalizeaza cumparaturile!" ForeColor="#009999" Font-Bold="True" Font-Underline="True" Font-Size="30px" CssClass="marginAuto"></asp:Label>
        </div>
        <div style="margin: 50px 400px">
            <asp:Repeater ID="repeater" runat="server">
                <HeaderTemplate>
                    <table border="1">
                        <tr>
                            <th style="width: 100px">ID</th>
                            <th style="width: 120px">Denumire</th>
                            <th style="width: 120px">Producator</th>
                            <th style="width: 120px">Pret$</th>
                            <th style="width: 120px">Culoare</th>
                            <th style="width: 120px">Cantitate</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lbId" runat="server" Text='<%#Eval("ProdusId")%>' />
                        </td>
                        <td>
                            <asp:Label ID="lbDenumire" runat="server" Text='<%#Eval("Denumire")%>' />
                        </td>
                        <td>
                            <asp:Label BackColor="" ID="lbProducator" runat="server" Text='<%#Eval("Producator")%>' />
                        </td>
                        <td>
                            <asp:Label ID="lbPret" runat="server" Text='<%#Eval("Pret")%>' />
                        </td>
                        <td>
     
                            <asp:TextBox ID="lbCuloare" runat="server" Width="20px" Text="" BackColor='<%# System.Drawing.Color.FromName(Convert.ToInt32(Eval("Culoare"))== 1 ? "red" :(Convert.ToInt32(Eval("Culoare"))== 2 ? "green" :(Convert.ToInt32(Eval("Culoare"))== 3 ? "blue": (Convert.ToInt32(Eval("Culoare"))== 4 ? "yellow" :"red"))))%>' ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lbCantitate" runat="server" Text='<%#Eval("Cantitate")%>' CssClass="marginAuto" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete" OnClientClick="return confirm('Doriti sa stergeti acest produs din cos?');" />
                            <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" OnClick="OnUpdate" />
                        </td>
                    </tr>                   
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <br />
            <div style="margin: 0 auto;">
                <asp:Label ID="lbModificaComanda" runat="server" Text="Modifica aceasta comanda:" Visible="false"></asp:Label>
                
                <table id="tabelUpdate" runat="server" style="margin: 0 auto; border:1px solid; visibility:hidden">
                    <tr>
                        <th class="p">Produs
                        </th>
                        <th class="p">ID
                        </th>
                        <th class="p">Denumire
                        </th>
                        <th class="p">Producator
                        </th>
                        <th class="p">Pret
                        </th>
                        <th class="p">  Culoare  
                        </th>
                        <th class="p">Cantitate
                        </th>
                    </tr>
                    <tr>
                        <td class="p">
                            <asp:DropDownList ID="ddlProduse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProduse_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td class="p">
                            <asp:TextBox ID="tbId" runat="server" ReadOnly="true" ></asp:TextBox>
                        </td>
                        <td class="p">
                            <asp:TextBox ID="tbDenumire" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td class="p">
                            <asp:TextBox ID="tbProducator" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td class="p">
                            <asp:TextBox ID="tbPret" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td class="p">
                            <asp:TextBox ID="tbCuloare" Width="60px" runat="server"></asp:TextBox>
                        </td>
                        <td class="p">
                            <asp:TextBox ID="tbCantitate" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnModificaComanda" runat="server" Text="Modifica" Visible="false" BackColor="#C98362" Font-Size="16px" OnClick="btnModificaComanda_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                         <td></td>
                         <td></td>
                         <td></td>
                         <td></td>
                         <td>
                             <asp:TextBox ID="TextBox1" Width="5px" runat="server" BackColor="Red"  onclick="schimbaCuloareaR()"></asp:TextBox>
                             <asp:TextBox ID="TextBox2" Width="5px" runat="server" BackColor="blue" onclick="schimbaCuloareaB()"></asp:TextBox>
                             <asp:TextBox ID="TextBox3" Width="5px" runat="server" BackColor="Green" onclick="schimbaCuloareaG()"></asp:TextBox>
                             <asp:TextBox ID="TextBox4" Width="5px" runat="server" BackColor="Yellow" onclick="schimbaCuloareaY()"></asp:TextBox>
                         </td>
                         <td></td>
                         <td></td>
                    </tr>
                </table>
            </div>
                <br />
                <br />
                <br />
            <div style="margin: 0 auto;">
                <asp:Button ID="btnFinalizareComanda"  runat="server" Text="Finalizare Comanda" BackColor="White"  Font-Bold="True" Font-Size="20px" CssClass="marginAuto" OnClick="btnFinalizareComanda_Click" Style="height: 36px" />
                <asp:Label ID="lbFinalizare" Visible="false" Font-Bold="True" Font-Size="20px" CssClass="marginAuto" runat="server" Text="S-a finalizat comanda!" ForeColor="#3333CC"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
