<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comanda.aspx.cs" Inherits="BicicleteWeb.Comanda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-3.3.1.js"></script>
    <script type="text/javascript">
        function getSelectedLi(param) {
            var objthis = this.context;
            $.ajax({
                type: "POST",
                url: "Comanda.aspx/SelectedColor",
                contentType: "application/json; charset=utf-8",
                data: '{param:"' + param + '"}',
                dataType: "json",
                context: this,
            }).done(function () {
                (document).getElementById("id1").style.border = "white solid";
                (document).getElementById("id2").style.border = "white solid";
                (document).getElementById("id3").style.border = "white solid";
                (document).getElementById("id4").style.border = "white solid";
                var id = "id" + param;
                (document).getElementById(id).style.border = "black solid";
            }).fail(function (msg) {
                alert("Data Saved: " + msg.responseText);
            });
        }

        function cresteCantitate() {
            document.getElementById('text').style.visibility = "visible";
            var value = parseInt(document.getElementById('text').value, 10);
            value = isNaN(value) ? 0 : value;
            value++;
            document.getElementById('text').value = value;
            return false;
        }

        function scadeCantitate() {
            document.getElementById('text').style.visibility = "visible";
            var value = parseInt(document.getElementById('text').value, 10);
            value = isNaN(value) ? 0 : value;
            value--;
            document.getElementById('text').value = value;
            return false;
        }
    </script>
    <style>
        .aliniere {
            margin: 0 auto;
            vertical-align: central;
            text-align: center;
            align-content: center;
        }

        .auto-style1 {
            width: 447px;
            height: 90px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
         <asp:Button ID="btnBack" runat="server" Text="Home Page" BackColor="White" Font-Size="20px" Font-Overline="False" ForeColor="#000066" BorderStyle="None" Font-Underline="True" Height="30px" OnClick="btnBack_Click" UseSubmitBehavior="false" />
        <div style="margin-left: 450px; margin-top: 0px; width: 1000px">
            <div style="display: inline-block; margin: 80px; margin-top: 5px">
                <asp:Label ID="lbCautaProdus" runat="server" Text="Cauta Produs:" BackColor="White" Font-Size="18px" Font-Italic="True" Font-Bold="True" ForeColor="#000066"></asp:Label>
                <asp:TextBox ID="tbAutocomplete" runat="server" Width="170px" ></asp:TextBox>
                <ajaxToolkit:AutoCompleteExtender
                    ID="autocompleteExtender"
                    ServiceMethod="GetCompletionList"
                    MinimumPrefixLength="1"
                    CompletionInterval="10"
                    EnableCaching="false"
                    CompletionSetCount="1"
                    TargetControlID="tbAutocomplete"
                    runat="server"
                    FirstRowSelected="false">
                </ajaxToolkit:AutoCompleteExtender>
                <asp:Button ID="btnAutocomplete" runat="server" Text="Search" OnClick="btnAutocomplete_Click" />
                
            </div>
        </div>
        <div style="top: 180px; margin-left: 300px">           
               <%if (dt != null)
                { %>
            <img style="float: left; width: 380px; height: 430px" src='<%=dt.Rows[0]["Url"].ToString()%>' />
            <%} %>
            <div style="margin: 60px; padding: 60px;">
                <asp:Label ID="lDenumire" runat="server" Text="Produs: " Font-Size="25px" CssClass="lb" Visible="false"></asp:Label>
                <asp:Label ID="lbDenumire" runat="server" Font-Size="25px" CssClass="lb" ForeColor="Red" Font-Italic="True"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lProducator" runat="server" Text="Producator: " Font-Size="25px" CssClass="lb" Visible="false"></asp:Label>
                <asp:Label ID="lbProducator" runat="server" Font-Size="25px" CssClass="lb" ForeColor="Red" Font-Italic="True"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lPret" runat="server" Text="Pret $: " Font-Size="25px" CssClass="lb" Visible="false"></asp:Label>
                <asp:Label ID="lbPret" runat="server" Font-Size="25px" CssClass="lb" ForeColor="Red" Font-Italic="True"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lCantitate" runat="server" Text="Cantitate: " Font-Size="25px" CssClass="lb" Visible="false"></asp:Label>
                <input id="text" type="text" runat="server" value="0" style="visibility: hidden; width: 50px" />
                <asp:Button ID="btnCresteCantitate" UseSubmitBehavior="False" runat="server" Text="+" Visible="false" BackColor="#FFFFCC" OnClientClick="return cresteCantitate();" />
                <asp:Button ID="btnScadeCantitate" UseSubmitBehavior="False" runat="server" Text="-" Visible="false" BackColor="#FFFFCC" OnClientClick="return scadeCantitate();" />
                <br />
                <br />
                <asp:Label ID="lCuloare" runat="server" Text="Culoare: " Font-Size="25px" CssClass="lb" Visible="false"></asp:Label>
                <br />
                <br />
                <p>
                    <%=stringBuilder %>
                </p>
            </div>
            <div style="display: inline-block; margin-left: 300px">
                <asp:Button ID="btnAdauga" runat="server" Text="Adauga in cos" OnClick="btnAdauga_Click" Visible="false" BackColor="#FFFF99" Font-Italic="False" Font-Size="20px" Font-Bold="True" />
                <asp:Label ID="lbSalvareSucces" runat="server" Text="Produs adaugat in cos!" Visible="False" Font-Size="20px" ForeColor="#009900"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
