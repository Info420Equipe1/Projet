<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCasdeTest.aspx.cs" Inherits="AspNetInterfaces.frmCasdeTest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" runat="server" type="text/css" href="~/StyleCasdeTest.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server" />
        <div id="CasTestInfo">
            <div id="lblColumn1">
                <div class="info">
                    <asp:Label runat="server" Text="Code: " CssClass="lblColum1" />
                    <asp:TextBox runat="server" ID="txtCode" CssClass="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Nom: " CssClass="lblColum1"/>
                <asp:TextBox runat="server" ID="txtNom" CssClass="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Difficulté: " CssClass="lblColum1"/>
                    <asp:DropDownList runat="server" ID="txtDifficulté" CssClass="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Priorité: " CssClass="lblColum1"/>
                    <asp:DropDownList runat="server" ID="txtPriorité" CssClass="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Date Création " CssClass="lblColum1"/>
                    <asp:TextBox ID="txtDateCreation" runat="server"/>
                    <cc1:CalendarExtender ID="txtDateCreation_CalendarExtender" runat="server" TargetControlID="txtDateCreation" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </div>
                <div class="info">
                    <asp:Label runat="server" Text="Date Livraison: " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtDateLivraison" CssClass="txtColum1"/>
                    <cc1:CalendarExtender ID="txtDateLivraison_CalendarExtender" runat="server" TargetControlID="txtDateLivraison" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </div>  
                <div class="info">
                    <asp:Label runat="server" Text="Type de test: " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtTypeTest" CssClass="txtColum1"/>
                </div>      
            </div>
            <div id="CasTestObj">
                <asp:Label runat="server" Text="Objectif: " CssClass="lblColum2"/>
                <asp:TextBox runat="server" ID="rtxtObjectif" TextMode="MultiLine" CssClass="txtColum2"/>
            </div>
        </div>
        <div id="CasTestDesc">
            <asp:Label runat="server" Text="Description: " CssClass="lblColum2"/>
            <asp:TextBox runat="server" ID="rtxtDescription" TextMode="MultiLine" CssClass="txtColum2"/>
        </div>
        <div id="CasTestDiv">
            <asp:Label runat="server" Text="Divers: " CssClass="lblColum2"/>
            <asp:TextBox runat="server" ID="rtxtDivers" TextMode="MultiLine" CssClass="txtColum2"/>
        </div>
        <div id="DataGridBillet">
            <asp:DataGrid id="DataGridBilletTravail" runat="server">
                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Top" BackColor="SaddleBrown" ForeColor="Ivory" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" BackColor="Beige" ForeColor="Brown" />
            </asp:DataGrid>
        </div>
        <div id="btnCopierEnregistrerAnnuler">
            <asp:Button runat="server" ID="btnCopier" Text="Copier" />
            <asp:Button runat="server" ID="btnEnregistrer" Text="Enregistrer" />
            <asp:Button runat="server" ID="btnAnnuler" Text="Annuler" />
        </div>    
    </form>
</body>
</html>
