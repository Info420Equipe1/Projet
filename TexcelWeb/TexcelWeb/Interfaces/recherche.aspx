<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recherche.aspx.cs" Inherits="TexcelWeb.recherche" enableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Texcel - Recherche</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/casTest.css" media="screen" />
<script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>
<script type="text/javascript">
$(function(){
	$(".box .h_title").not(this).next("ul").hide("normal");
	$(".box .h_title").not(this).next("#home").show("normal");
	$(".box").children(".h_title").click( function() { $(this).next("ul").slideToggle(); });
});
</script>
<style>
a {color:white; text-decoration:none}
</style>
</head>
<body>
<div class="wrap">
	<div id="header">
		<div id="top">
			<div class="left">
				<p>Bienvenue, <strong id="txtCurrentUserName" runat="server"></strong> [ <a href="login.aspx">deconnection</a> ]</p>
			</div>
			<!-- <div class="right">
				<div class="align-right">
					<p>Dernière connexion: <strong id="txtDerniereConnexion" runat="server">28-10-2015</strong></p>
				</div>
			</div> -->
		</div>
	</div>
	<div id="content">
		<div id="sidebar" runat="server">
			<div id="boxRecherche" runat="server" class="box">
                <div id="menuRecherche" runat="server" class="h_title">&#8250; Recherche</div>
                <ul id="home">
                    <li id="lienRecherche" runat="server" class="b1"><a class="icon page" href="recherche.aspx">Recherche</a></li>
                </ul>   
			</div>
            <div id="boxProjet" runat="server" class="box">
				<div id="menuProjet" runat="server" class="h_title">&#8250; Projets</div>
				<ul>
					<li id="lienAjouterProjet" runat="server" class="b1"><a class="icon page" href="creerProjet.aspx">Ajouter un Projet</a></li>
                    <li id="lienProjetEquipe" runat="server" class="b1"><a class="icon page" href="projetEquipe.aspx">Gestion des Équipes</a></li>			
				</ul>
			</div>		
			<div id="boxCasTest" runat="server" class="box">
				<div id="menuCasTest" runat="server" class="h_title">&#8250; Cas de test</div>
				<ul>
					<li id="lienCasTest" runat="server" class="b1"><a class="icon page" href="creerCasTest.aspx">Ajouter un Cas de test</a></li>
				</ul>
			</div>
            <div id="boxBilletTravail" runat="server" class="box">
				<div id="menuBilletTravail" runat="server" class="h_title">&#8250; Billet de travail</div>
				<ul>
                    <li id="lienBilletChefEquipe" runat="server" class="b1"><a class="icon page" href="creerBilletChefEquipe.aspx">Ajouter des Billets de travail</a></li>
                    <li id="lienGestionBillets" runat="server" class="b1"><a class="icon page" href="gestionBillets.aspx">Gestion des Billets</a></li>
				</ul>
			</div>     
		</div>
	    <div id="main">					
			<div class="full_w">
                <form id="FrmCasTest" runat="server">                         
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UPRecherche" runat="server">
                        <ContentTemplate>
                            <div id="recherche">
                                <asp:TextBox ID="txtChampRecherche" runat="server" Width="210px" />
                                <asp:DropDownList ID="ddlFiltre" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltre_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" OnClick="btnRechercher_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UPGridView" runat="server">
                        <ContentTemplate>              
                            <asp:GridView ID="gvRecherche" runat="server" OnSelectedIndexChanged="gvRecherche_SelectedIndexChanged" OnRowCreated="gvRecherche_RowCreated" AllowSorting="true" OnDataBound="gvRecherche_DataBound">
                            </asp:GridView>
                        </ContentTemplate>                      
                    </asp:UpdatePanel>  
                    <asp:EntityDataSource ID="edsProjet" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllProjet" Select="it.[codeProjet], it.[nomProjet], it.[chefProjet], it.[dateCreation], it.[dateLivraison]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsCasTest" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllCasTest" EntityTypeFilter="AllCasTest" Select="it.[codeCasTest], it.[nomCasTest], it.[dateCreation], it.[dateLivraison], it.[codeProjet]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsJeuProjet" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllJeuProjet" Select="it.[nomProjet], it.[nomJeu], it.[nomVersionJeu]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsProjetGenre" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllProjetGenre" EntityTypeFilter="AllProjetGenre" Select="it.[nomProjet], it.[nomGenre]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsProjetTheme" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllProjetTheme" Select="it.[nomProjet], it.[nomTheme]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsProjetClassification" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllProjetClassification" Select="it.[nomProjet], it.[codeClassification], it.[nomClassification]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsProjetEquipe" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllProjetEquipe" Select="it.[nomEquipe], it.[nomProjet], it.[nomChefProjet]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsEmployeEquipe" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllEmployeEquipe" Select="it.[nomEmploye], it.[nomEquipe], it.[nomChefEquipe]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsEmployeTypeTest" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllEmployeTypeTest" Select="it.[nomEmploye], it.[nomTest]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsEmployeBilletTravail" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllEmployeBilletTravail" Select="it.[nomEmploye], it.[titreBilletTravail]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsBilletTravailPriorite" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllBilletTravailPriorite" Select="it.[titreBilletTravail], it.[nomNivPri]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsBilletTravailStatut" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllBilletTravailStatut" Select="it.[titreBilletTravail], it.[nomStatut]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsProjetCasTest" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllProjetCasTest" Select="it.[nomProjet], it.[nomCasTest]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsCasTestBilletTravail" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllCasTestBilletTravail" Select="it.[nomCasTest], it.[titreBilletTravail]"></asp:EntityDataSource>
                    <div id="dataGridPagination" class="pagination" runat="server"  visible="false"></div>                   
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
