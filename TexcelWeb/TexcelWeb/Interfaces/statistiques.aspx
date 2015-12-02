<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="statistiques.aspx.cs" Inherits="TexcelWeb.Interfaces.statistiques" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Texcel - Statistiques</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/statistiques.css" media="screen" />
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
					<li class="b1"><a class="icon page" href="creerProjet.aspx">Ajouter</a></li>
                    <li class="b1"><a class="icon page" href="projetEquipe.aspx">Gestion des equipes</a></li>			
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de test</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="creerCasTest.aspx">Ajouter</a></li>
				</ul>
			</div>
            <div class="box">
				<div class="h_title">&#8250; Billet de travail</div>
				<ul>
                    <li class="b1"><a class="icon page" href="gestionBillets.aspx">Gestion des billets</a></li>
				</ul>
			</div>     
        </div>
	    <div id="main">
			<div class="full_w">
				<div class="h_title" id="Titre" runat="server">Statistiques des projets</div>
                <form runat="server">
                    <asp:label runat="server">Projet:</asp:label>
                    <asp:DropDownList ID="ddlProjets" runat="server"></asp:DropDownList><br />
                    <asp:Panel ID="pnlGeneral" runat="server" GroupingText="Général">
                        <div id="general" class="panel">
                            <asp:label runat="server">Nom du projet:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Nb. Équipe:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Nb. Testeur:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Nb. Cas de test:</asp:label>
                            <asp:label runat="server"></asp:label><br /><br />
                            <asp:label runat="server">Temps Estimé:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Temps investi:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Nb. Cas de test urgent:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlBillets" runat="server" GroupingText="Billets">
                        <div id="billets" class="panel">
                            <asp:label runat="server">Cas de test:</asp:label>
                            <asp:DropDownList ID="ddlCasTest" runat="server"></asp:DropDownList><br />
                            <asp:label runat="server">Priorité:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Difficulté:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Type de test:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Nb. Billets:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Temps estimé:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Temps investi:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Nb. Billets urgents:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Temps estimé pour billets urgents:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                            <asp:label runat="server">Nb. Billets critiques:</asp:label>
                            <asp:label runat="server"></asp:label><br />
                        </div>
                    </asp:Panel>
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
