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
		<div id="sidebar">
			<div class="box">
                <div id="menuRecherche" runat="server" class="h_title">&#8250; Recherche</div>
                <ul id="home">
                    <li class="b1"><a class="icon page" href="recherche.aspx">Recherche</a></li>
                </ul>   
			</div>
            <div class="box">
				<div class="h_title">&#8250; Projets</div>
				<ul>
					<li class="b1"><a class="icon page" href="creerProjet.aspx">Ajouter</a></li>
                    <li class="b1"><a class="icon page" href="projetEquipe.aspx">Gestion des equipes</a></li>			
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de test</div>
				<ul>
					<li class="b1"><a class="icon page" href="creerCasTest.aspx">Ajouter</a></li>
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
                                <asp:DropDownList ID="ddlFiltre" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltre_SelectedIndexChanged">
                                    <asp:ListItem>Projet</asp:ListItem>
                                    <asp:ListItem>CasTest</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" OnClick="btnRechercher_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UPGridView" runat="server">
                        <ContentTemplate>              
                            <asp:GridView ID="gvRecherche" runat="server" OnSelectedIndexChanged="gvRecherche_SelectedIndexChanged" OnRowCreated="gvRecherche_RowCreated" AllowSorting="true">
                            </asp:GridView>
                        </ContentTemplate>                      
                    </asp:UpdatePanel>  
                    <asp:EntityDataSource ID="edsProjet" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllProjet" Select="it.[codeProjet], it.[nomProjet], it.[chefProjet], it.[dateCreation], it.[dateLivraison]">
                    </asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsCasTest" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="tblCasTest" EntityTypeFilter="CasTest" Select="it.[codeCasTest], it.[nomCasTest], it.[dateCreation], it.[dateLivraison], it.[codeProjet]"></asp:EntityDataSource>
                    <div id="dataGridPagination" class="pagination" runat="server"  visible="false">
                        

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
