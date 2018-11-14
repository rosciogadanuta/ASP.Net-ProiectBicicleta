<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreeazaCont.aspx.cs" Inherits="BicicleteWeb.AdimistratorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table, th, td {
            /*border: 1px solid #91BFF1;*/
            text-align: center;
            color: green;
            padding: 10px;
            vertical-align:central;
        }
    </style>
    <div style="margin: 0 auto; height: 50px; text-align: center; margin-top: 30px; border:medium;background-color:palegreen;width:400px">
        <p style="font-size: 20px; color: darkgreen;text-align:center">
            <asp:Label ID="lbIntroducereDate" runat="server" Text="Introduceti datele pentru crearea contului!"></asp:Label>
        </p>
    </div>
    <div  style="margin: auto; text-align: center; font-size: 20px; padding: 20px;">
        <table style="margin:0 auto">
            <tr>
                <td>
                    <asp:Label ID="lbNume" runat="server" Text="Nume"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbNume" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvNume" runat="server" ErrorMessage="Numele!" ForeColor="Red" ControlToValidate="tbNume"></asp:RequiredFieldValidator>
                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbParola" runat="server" Text="Parola"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbParola" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvParola" runat="server" ErrorMessage="Parola!" ForeColor="Red" ControlToValidate="tbParola"></asp:RequiredFieldValidator>
                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbConfirmareParola" runat="server" Text="Confirmare Parola"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbConfirmareParola" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvConfirmareParola" runat="server" ErrorMessage="Parola!" ForeColor="Red" ControlToValidate="tbConfirmareParola"></asp:RequiredFieldValidator>
                   
                </td>
                <td>
                     <asp:CompareValidator ID="compareValidatorParola" runat="server" ErrorMessage="Parola nu corespunde!" ForeColor="#CC0000" ControlToValidate="tbConfirmareParola" ControlToCompare="tbParola" Type="String" Operator="Equal"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbEmail" runat="server" Text="Adresa email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbEmail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
               <td>
                   <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Adresa Email!" ForeColor="Red" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
               </td>
                <td>

                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnSalvareCont" runat="server" Text="Salvare Cont" OnClick="btnSalvareCont_Click" BackColor="PaleGreen" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lbInregistrare" runat="server" Text="Inregistrare cu succes!" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
