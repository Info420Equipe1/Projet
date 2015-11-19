<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creerProjetCopier.aspx.cs" Inherits="TexcelWeb.creerProjetCopier" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Texcel - Creer un projet</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/projet.css" media="screen" />
<script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>
<script type="text/javascript">
$(function(){
	$(".box .h_title").not(this).next("ul").hide("normal");
	$(".box .h_title").not(this).next("#home").show("normal");
	$(".box").children(".h_title").click( function() { $(this).next("ul").slideToggle(); });
});
</script>
</head>
<body>
<div class="wrap">
	<div id="header">
		<div id="top">
			<div class="left">
				<p>Bienvenue, <strong id="txtCurrentUserName" runat="server">Marcel L.</strong> [ <a href="#">deconnection</a> ]</p>
			</div>
			<div class="right">
				<div class="align-right">
					<p>Dernière connexion: <strong id="txtDerniereConnexion" runat="server">28-10-2015</strong></p>
				</div>
			</div>
		</div>
	</div>
	
	<div id="content">
		<div id="sidebar">
			<div class="box">
				<div class="h_title">&#8250; Projets</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="/Interfaces/creerProjet.aspx">Ajouter</a></li>
					<li class="b2"><a class="icon report" href="/Interfaces/projetEquipe.aspx">Gestion des equipes</a></li>
					<!--<li class="b1"><a class="icon add_page" href="">Add new page</a></li>
					<li class="b2"><a class="icon config" href="">Site config</a></li> -->
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de tests</div>
				<ul>
					<li class="b1"><a class="icon page" href="/Interfaces/creerCasTest.aspx">Ajouter</a></li>
					<!-- <li class="b2"><a class="icon add_page" href="">Add new page</a></li>
					<li class="b1"><a class="icon photo" href="">Add new gallery</a></li>
					<li class="b2"><a class="icon category" href="">Categories</a></li> -->
				</ul>
			</div>
		</div>
	    <div id="main">
			<div class="full_w">
				<div class="h_title">Créer un projet</div>
                <form id="FrmProjet" runat="server">
                    <asp:ScriptManager ID="ToolkitScriptManager" runat="server"></asp:ScriptManager>
                    <div id="ProjetInfo">
                        <div id="lblColumn1">
                            <div class="info">
                                <asp:Label runat="server" Text="Code: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtCodeProjet" CssClass="txtColum1"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodeProjet" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Nom: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtNomProjet" CssClass="txtColum1"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNomProjet" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Chef de projet: " CssClass="lblColum1"/>
                                <asp:DropDownList runat="server" ID="txtChefProjet" CssClass="txtColum1" style="width:71.5%" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtChefProjet" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Date création: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtDateCreationProjet" CssClass="txtColum1 txtDate" type="date" />     
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDateCreationProjet" Display="dynamic" Text="*" ForeColor="Red" />                                                                                                          
                                <asp:Label runat="server" Text="Date livraison: " CssClass="lblColum1 lblDate" />
                                <asp:TextBox runat="server" ID="txtDateLivraisonProjet" CssClass="txtColum1 txtDate" type="date" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDateLivraisonProjet" Display="dynamic" Text="*" ForeColor="Red" />   
                            </div>
                            <asp:UpdatePanel ID="updatePanelVersionJeu" runat="server">
                                <ContentTemplate>
                                    <div class="info">
                                        <asp:Label runat="server" Text="Jeu: " CssClass="lblColum1"/>
                                        <asp:DropDownList runat="server" ID="txtJeuProjet" CssClass="txtColum1 txtDate1" style="width:71.5%" OnSelectedIndexChanged="txtJeuProjet_SelectedIndexChanged" AutoPostBack="true"/>
                                    </div>
                                    <div class="info">
                                        <asp:Label runat="server" Text="Version du jeu: " CssClass="lblColum1"/>
                                        <asp:DropDownList runat="server" ID="txtVersionJeuProjet" CssClass="txtColum1 txtDate1" style="width:71.5%" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtVersionJeuProjet" Display="dynamic" Text="*" ForeColor="Red" />   
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtJeuProjet" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>  
                        <div id="CasTestObj">
                            <asp:Label runat="server" Text="Objectif: " /><br />
                            <asp:TextBox runat="server" ID="rtxtObjectifProjet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div><br /><br />
                        <div id="CasTestDesc">
                            <asp:Label runat="server" Text="Description: "/><br />
                            <asp:TextBox runat="server" ID="rtxtDescriptionProjet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div>
                        <div id="CasTestDiv">
                            <asp:Label runat="server" Text="Divers: "/><br />
                            <asp:TextBox runat="server" ID="rtxtDiversProjet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="updatePanelGridView" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dataGridLstCasTest" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="dataGridLstCasTest_PageIndexChanging" PageSize="5" Visible="false">
                                <Columns>
                                    <asp:BoundField ItemStyle-Width="50px" DataField="CodeCasTest" HeaderText="Code" />
                                    <asp:BoundField ItemStyle-Width="150px" DataField="NomCasTest" HeaderText="Nom Cas de Test" />
                                    <asp:BoundField ItemStyle-Width="50px" DataField="DateLivraisonCasTest" HeaderText="Date livraison" />
                                    <asp:BoundField ItemStyle-Width="150px" DataField="PrioriteCasTest" HeaderText="Priorité" />
                                    <asp:BoundField ItemStyle-Width="150px" DataField="DifficulteCasTest" HeaderText="Difficulté" />
                                </Columns>
                            </asp:GridView>	
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="dataGridLstCasTest" EventName="PageIndexChanging" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <div id="dataGridPagination" class="pagination" runat="server"  visible="false">
						<span>« Première</span>
						<span class="active">1</span>
						<a href="#">2</a>
						<a href="#">3</a>
						<a href="#">4</a>
						<span>...</span>
						<a href="#">23</a>
						<a href="#">24</a>
						<a href="#">Dernière »</a>
					</div> 

                    <div id="btnCopierEnregistrerAnnuler">
                        <asp:LinkButton runat="server" ID="btnCopier" Text="Copier" CssClass="button"/>
                        <asp:LinkButton runat="server" ID="btnAnnuler" Text="Annuler" CssClass="btnDroit button cancel" OnClick="btnAnnuler_Click" />
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="btnDroit button add" OnClick="btnEnregistrer_Click" />
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
