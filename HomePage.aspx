<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BicicleteWeb.HomePage" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-3.3.1.js"></script>
    <script>
        function functie(param) {
            $.ajax({
                type: "POST",
                url: "HomePage.aspx/PopUpDetaliiComanda",
                contentType: "application/json; charset=utf-8",
                data: '{param:"' + param + '"}',
                dataType: "json"
            }).done(function (msg) {
                (document).getElementById("divAjaxValues").innerHTML = "";
                var i = msg.d.length;
                for (var contor = 0; contor < i; contor++) {
                    var json = JSON.parse(msg.d[contor]);
                    (document).getElementById("divAjaxValues").innerHTML += "*[Bicicleta:" + json.Denumire + ", Producator:" + json.Producator + ", Cantitate:" + json.Cantitate + ", Pret$:" + json.Pret + ", Total$:" + json.Total + "]</br></br>";
                }
                (document).getElementById("divAjax").style.visibility = "visible";
                (document).getElementById("divAjaxValues").style.visibility = "visible";

            }).fail(function (msg) {
                alert("Data Saved: " + msg.responseText);
            });
            return false;
        }
        //Preluare nr comenzi pt cos
        $(function () {
            $.ajax({
                type: "POST",
                url: "HomePage.aspx/ComenziCos",
                contentType: "application/json; charset=utf-8",
                data: "",
                dataType: "json"
            }).done(function (msg) {
                var parsedJson = JSON.parse(msg.d);
                document.getElementById("lbNrComenzi").innerHTML = parsedJson;
            }).fail(function (msg) {
                alert("Data Saved: " + msg.responseText);
            });
            // return false;
        });
        ////Afisare Caseta pe btn FCT
        $(function () {
            $('.popupClick').click(function (e) {
                e.preventDefault();
                var pos = $(this).offset();
                var width = $(this).outerWidth();
                $('#divAjax').css({
                    position: "absolute",
                    top: (pos.top + 10) + "px",
                    left: (pos.left + width + 20) + "px"
                }).show();
            });
        });
        //Buton de Close
        function closeFunction() {
            (document).getElementById("divAjax").style.visibility = "hidden";
            (document).getElementById("divAjaxValues").style.visibility = "hidden";
        }
        //Functie deschidere pagina Finalizare Comanda
        function openFinalizareComanda() {
            window.location.href="FinalizareComanda.aspx";
            return false;
        }

        function thisBtn(param) {
            __doPostBack(param)
        }
    </script>
    <style>
        .gridView {
            margin: 0 auto;
            align-content: center;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .gV {
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 0 auto; height: 50px; background-color:cornflowerblue">
            <div style="float: right; display: inline-block">
                <div style="float: right; display: inline-block;" onclick="return openFinalizareComanda();">
                    <asp:Label ID="lbNrComenzi" runat="server" Font-Size="32px" ForeColor="DarkBlue" BackColor="CornflowerBlue"></asp:Label>
                    <asp:Image ID="imgCos" runat="server" ImageUrl="~/Content/Pictures/Cos.png" />
                </div>
                <asp:Button ID="btnAdaugaComanda" BackColor="CornflowerBlue" runat="server" Text="Adauga O Noua Comanda" BorderStyle="None" ForeColor="White" Font-Size="20px" Font-Underline="true" OnClick="btnAdaugaComanda_Click" />
                <asp:Button ID="btnAdministreazaConturi" runat="server" Text="Administreaza Conturi" BorderStyle="None" BackColor="CornflowerBlue" ForeColor="White" Font-Size="20px" Font-Underline="true" OnClick="btnAdministreazaConturi_Click" />
                <asp:Button ID="btnLogOut" runat="server" Text="Log out!" OnClick="btnLogOut_Click" BorderStyle="None" BackColor="CornflowerBlue" ForeColor="White" Font-Size="20px" Font-Underline="true" />
                <asp:Label ID="lbNuAdmin" runat="server" Text="Nu sunteti administrator!" ForeColor="Red" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>

            </div>
        </div>
        <br />
        <br />
        <div style="margin: 0 auto;">
            <asp:Label ID="lbNuExistaComenzi" runat="server" Text="Nu exista nicio comanda efectuata" Visible="false" CssClass="gridView" Font-Size="25px"></asp:Label>
            <asp:GridView ID="gvComenzi" runat="server" CssClass="gV" AutoGenerateColumns="False" OnRowDataBound="gvComenzi_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ComandaId" HeaderText="ID">
                        <HeaderStyle BackColor="#6699FF" />
                        <ItemStyle BackColor="#CCFFCC" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Data" HeaderText="Data" DataFormatString="{0:MMMM d, yyyy}">
                        <HeaderStyle BackColor="#6699FF" />
                        <ItemStyle BackColor="#CCFFFF" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Valoare" HeaderText="Valoare Comanda" DataFormatString="{0:C}">
                        <HeaderStyle BackColor="#6699FF" />
                        <ItemStyle BackColor="#CCFFFF" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Detalii">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDetalii" runat="server" CssClass="popupClick">Detalii</asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#6699FF" />
                        <ItemStyle BackColor="#CCFFCC" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnMaiMult" runat="server" Text="...mai mult"  CssClass="gridView" BackColor="#CCFFCC" BorderColor="#FFFF99" ForeColor="#000066" BorderStyle="Dotted" OnClientClick="return thisBtn('btnMaiMult');" UseSubmitBehavior="false"  />
        </div>
        <div id="divAjax" style="visibility: hidden; border: dotted; border-width: thin; border-color: blue; background-color: lightsteelblue; color: black; z-index: 10000; position: absolute;">
            <div id="divAjaxValues" style="visibility: hidden; float: left;">
            </div>
            <a style="color: darkblue; float: left" onclick="return closeFunction();">[x Close]</a>
        </div>
        <br />
        <br />
        <div>
        </div>
    </form>
</body>
</html>
