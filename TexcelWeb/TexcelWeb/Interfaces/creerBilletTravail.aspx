<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creerBilletTravail.aspx.cs" Inherits="TexcelWeb.Interfaces.creerBilletTravail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Texcel - Creer un cas de test</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/billetTravail.css" media="screen" />
<script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>
<script type="text/javascript">
$(function(){
	$(".box .h_title").not(this).next("ul").hide("normal");
	$(".box .h_title").not(this).next("#home").show("normal");
	$(".box").children(".h_title").click( function() { $(this).next("ul").slideToggle(); });
});
</script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
<link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div class="wrap">
	<div id="header">
		<div id="top">
			<div class="left">
				<p>Bienvenue, <strong id="txtCurrentUserName" runat="server">Marcel L.</strong> [ <a href="login.aspx">deconnection</a>]</p>
			</div>
        </div>
	</div>	
	<div id="content">
		<div id="sidebar">
			<div class="box">
                <div class="h_title">&#8250; Recherche</div>
                <ul>
                    <li class="b1"><a class="icon page" href="recherche.aspx">Recherche</a></li>
                </ul>   
			</div>
            <div class="box">
				<div class="h_title">&#8250; Projets</div>
				<ul>
					<li class="b1"><a class="icon page" href="creerProjet.aspx">Ajouter un Projet</a></li>
                    <li class="b1"><a class="icon page" href="projetEquipe.aspx">Gestion des Équipes</a></li>			
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de test</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="creerCasTest.aspx">Ajouter un Cas de test</a></li>
				</ul>
			</div>
            <div class="box">
				<div class="h_title">&#8250; Billet de travail</div>
				<ul>
                    <li class="b1"><a class="icon page" href="creerBilletChefEquipe.aspx">Ajouter des Billets de travail</a></li>
                    <li class="b1"><a class="icon page" href="gestionBillets.aspx">Gestion des Billets</a></li>
				</ul>
			</div>     
        </div>
	    <div id="main">
			<div class="full_w">
				<div class="h_title" id="txtForm" runat="server">Créer un Billet de travail</div>
                <form id="FrmBilletTravail" runat="server">     
                    <asp:ScriptManager ID="ToolkitScriptManager" runat="server"></asp:ScriptManager>
                    <p>Informations sur le Cas de test</p>
                    <div id="CasTestInfo" >
                        <div id="CenterLbl">
                            <asp:Label runat="server" Text="Projet: " CssClass="lblTop"/>
                            <asp:TextBox runat="server" ID="txtProjetCasTest" Enabled="false"/>
                            <asp:Label runat="server" Text="Cas de test: " CssClass="lblTop"/>
                            <asp:TextBox runat="server" ID="txtNomCasTest" Enabled="false"/>
                            <asp:Label runat="server" Text="Type de test: " CssClass="lblTop"/>
                            <asp:TextBox runat="server" ID="txtNomTypeTest" Enabled="false"/>
                            <asp:Label runat="server" Text="Difficulté: " CssClass="lblTop"/>
                            <asp:TextBox runat="server" ID="txtDifficulte" Enabled="false"/>
                        </div>
                    </div>
                    <div id="pAjouterBillet">
                        <p id="lblAjouterBillet">Informations sur le Billet</p>
                        <br />
                    </div>
                    <div id="BilletInfo">
                        <div >
                            <div class="info">
                                <div class="lblColum1">
                                    <asp:Label runat="server" Text="Équipe: "/>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="txtEquipe" OnSelectedIndexChanged="txtEquipe_SelectedIndexChanged" AutoPostBack="true"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="lblColum1" >
                                    <asp:Label runat="server" Text="Titre du Billet: "/>
                                </div>
                                <asp:TextBox runat="server" ID="txtTitreBillet"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitreBillet" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Durée(Min): " CssClass="lblColum1" />
                                <asp:TextBox type="number" runat="server" ID="txtDureeBillet" MaxLength="3" Step="10.0" />
                                <p id="DureeTexte">(Approximative)</p>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDureeBillet" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Date Livraison: " CssClass="lblColum1" />
                                <asp:TextBox type="date" runat="server" ID="txtDateLivraisonBillet" CssClass="txtColum1 txtDate2" />
                                <asp:Label ID="lblDateCreation" runat="server" Text="Date Création: " CssClass="lblColum1 lblDate2"/>
                                <asp:TextBox type="date" runat="server" ID="txtDateCreationBillet" CssClass="txtColum1 txtDate2" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDateCreationBillet" Display="dynamic" Text="*" ForeColor="Red" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="NotEqual" ControlToValidate="txtDateLivraisonBillet" ValueToCompare="aaaa-mm-jj" Text="*"></asp:CompareValidator>
                            </div>
                            <asp:UpdatePanel ID="updatePanelStatutDateTerminaison" runat="server">
                                <ContentTemplate>
                                    <div class="info">
                                        <asp:Label runat="server" Text="Testeur: " CssClass="lblColum1"/>
                                        <asp:DropDownList runat="server" ID="cmbTesteurBillet" CssClass="txtColum1"/>
                                    </div>
                                    <div class="info">
                                        <asp:Label runat="server" Text="Statut: " CssClass="lblColum1" />
                                        <asp:DropDownList runat="server" ID="cmbStatutBillet" CssClass="txtColum1 txtDate1" AutoPostBack="true" OnSelectedIndexChanged="cmbStatutBillet_SelectedIndexChanged"/>
                                        <asp:Label runat="server" Text="Priorité: " CssClass="lblColum1 lblDate1" />
                                        <asp:DropDownList runat="server" ID="cmbPrioriteBillet" CssClass="txtColum1 txtDate1" />
                                    </div>
                                    <div id="dateTerminaisonBillet" runat="server" class="info">
                                        <asp:Label runat="server" Text="Terminé le: " CssClass="lblColum1"/>
                                        <asp:TextBox type="date" runat="server" ID="txtDateTerminaison" CssClass="txtColum1 txtDate2" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div> <br />
                        <div id="CasTestDesc">
                            <asp:Label runat="server" Text="Description: "/><br />
                            <asp:TextBox runat="server" ID="rtxtDescriptionBillet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div>
                    </div>
                <div id="btnEnregistrerAnnuler">    
                        <asp:LinkButton runat="server" ID="btnFermer" Text="Fermer" CssClass="btnDroit button cancel" CausesValidation="false" OnClick="btnAnnuler_Click"/>
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="btnDroit button add" OnClick="btnEnregistrer_Click" />                  
                    <br />
                    <br />
                </div>
                </form>
			</div>
		</div>  
	</div>
	<div id="footer">
		<div class="left">
			<p>Design: <a href="#">Équipe 1</a> <!--| Admin Panel: <a href=""></a> --></p>
		</div>
	</div>
</div>
</body>
</html>
