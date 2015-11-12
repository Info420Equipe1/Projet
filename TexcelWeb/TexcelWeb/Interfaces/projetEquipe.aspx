﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projetEquipe.aspx.cs" Inherits="TexcelWeb.Interfaces.projetEquipe" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="author" content="Paweł 'kilab' Balicki - kilab.pl" />
<title>Texcel - Gérer les équipes des projets</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/projetEquipe.css" media="screen" />
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
				<p>Bienvenue, <strong>Marcel L.</strong> [ <a href="#">deconnection</a> ]</p>
			</div>
			<div class="right">
				<div class="align-right">
					<p>Dernière connexion: <strong>28-10-2015</strong></p>
				</div>
			</div>
		</div>
	</div>	
	<div id="content">
		<div id="sidebar">
			<div class="box">
				<div class="h_title">&#8250; Projets</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="#">Ajouter</a></li>
					<li class="b2"><a class="icon page" href="#">Gérer les équipes</a></li>
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de tests</div>
				<ul>
					<li class="b1"><a class="icon page" href="#">Ajouter</a></li>
				</ul>
			</div>
        </div>
	    <div id="main">			
			<div class="full_w">
				<div class="h_title">Gérer les équipes des projets</div>
                <form id="frmProjetEquipe" runat="server">
                    <div id="projetEquipe">
                        <div>
                            <asp:Label runat="server" Text="Mes projets" /><br />
                            <asp:ListBox runat="server" ID="lsbProjets" OnSelectedIndexChanged="lsbProjets_SelectedIndexChanged" />
                        </div>
                        <br />
                        <div>
                            <div style="float:left;height:185px">
                                <asp:Label runat="server" Text="Équipes du projet (untel)" /><br />
                                <asp:ListBox runat="server" ID="lsbEquipes" />
                            </div>
                            <div id="infoEquipe" style="float:left">
                                <div class="lblInfo">
                                    <asp:Label runat="server" Text="Nom de l'équipe:" />
                                    <asp:TextBox runat="server" ID="txtNomEquipe" CssClass="textBox" Enabled="false" /><br /><br />
                                </div>
                                <div class="lblInfo">
                                    <asp:Label ID="lblChefEquipe" runat="server" Text="Chef d'équipe:" />
                                    <asp:TextBox runat="server" ID="txtChefEquipe" CssClass="textBox" Enabled="false" /><br /><br />
                                </div>
                                <div class="lblInfo">
                                    <asp:Label ID="lblNbTesteurs" runat="server" Text="Nb. Testeurs:" />
                                    <asp:TextBox runat="server" ID="txtNbTesteurs" CssClass="textBox" Enabled="false" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div> 
                            <div class="tableCell">
                                <asp:Label runat="server" Text="Cas de test du projet (untel)" /><br />
                                <asp:ListBox runat="server" ID="lsbCasTestProjet" />
                            </div>
                            <div id="colButton" class="tableCell"><br /><br /><br /><br /><br />
                                <asp:LinkButton runat="server" ID="btnAllRight" Text=">>" CssClass="button btnFleches" /><br /><br />
                                <asp:LinkButton runat="server" ID="btnRight" Text=">" CssClass="button btnFleches" /><br /><br />
                                <asp:LinkButton runat="server" ID="btnLeft" Text="<" CssClass="button btnFleches" /><br /><br />
                                <asp:LinkButton runat="server" ID="btnAllLeft" Text="<<" CssClass="button btnFleches" /> 
                            </div>
                            <div class="tableCell">
                                <asp:Label runat="server" Text="Cas de test de l'équipe (untel)" /><br />
                                <asp:ListBox runat="server" ID="lsbCasTestEquipe" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div id="btnEnregistrerAnnuler">  
                        <asp:LinkButton runat="server" ID="btnAnnuler" Text="Annuler" CssClass="button btnDroit cancel"/> 
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="button btnDroit add"/>                             
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
