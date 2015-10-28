<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCasTest.aspx.cs" Inherits="AspNetInterfaces.bonjours" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" runat="server" type="text/css" href="~/StyleCreerProjet.css" />
    <title><asp:Literal runat="server" Text="<%$ Resources:Resource1, titre_bonjours %>" /></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div id="CasTestInfo">
            <div id="lblColumn1">
                <div class="info">
                    <asp:Label runat="server" Text="Code: " class="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtCodeCasTest" class="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Nom: " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtNomCasTest" CssClass="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Chef de projet: " CssClass="lblColum1"/>
                    <asp:DropDownList runat="server" ID="txtChefProjetCasTest" CssClass="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Date Création: " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtDateCreationCasTest" CssClass="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Date Livraison: " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtDateLivraisonCasTest" CssClass="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Version du jeu: " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtVersionJeuCasTest" CssClass="txtColum1"/>
                </div>        
            </div>
            <div id="CasTestObj">
                <asp:Label runat="server" Text="Objectif: " CssClass="lblColum2"/>
                <asp:TextBox runat="server" ID="rtxtObjectifCasTest" TextMode="MultiLine" CssClass="txtColum2" Height="180px" Width="730px"/>
            </div>
            <div id="CasTestDesc">
                <asp:Label runat="server" Text="Description: " CssClass="lblColum2"/>
                <asp:TextBox runat="server" ID="rtxtDescriptionCasTest" TextMode="MultiLine" CssClass="txtColum2" Height="180px" Width="730px"/>
            </div>
            <div id="CasTestDiv">
                <asp:Label runat="server" Text="Divers: " CssClass="lblColum2"/>
                <asp:TextBox runat="server" ID="rtxtDiversCasTest" TextMode="MultiLine" CssClass="txtColum2" Height="180px" Width="730px"/>
            </div>
            <asp:DataGrid id="DataGrid" runat="server"></asp:DataGrid>
            
        </div>
        <div id="btnCopierEnregistrerAnnuler">
            <div id="btnCentre">
                <asp:Button runat="server" ID="btnCopier" Text="Copier" />
            </div>
            <div id="btnDroit">
                <asp:Button runat="server" ID="btnEnregistrer" Text="Enregistrer" />
                <asp:Button runat="server" ID="btnAnnuler" Text="Annuler" />
            </div>
        </div>    
    </form>
</body>
</html>
