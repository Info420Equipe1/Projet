<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creerCasTest.aspx.cs" Inherits="TexcelWeb.CreerCasTest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="author" content="Paweł 'kilab' Balicki - kilab.pl" />
<title>Texcel - Gérer les équipes du projet</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<!-- <link rel="stylesheet" type="text/css" href="../css/casTest.css" media="screen" /> -->
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
				<ul>
					<li class="b1"><a class="icon page" href="#">Ajouter</a></li>
					<!-- <li class="b2"><a class="icon report" href="">Reports</a></li>
					<li class="b1"><a class="icon add_page" href="">Add new page</a></li>
					<li class="b2"><a class="icon config" href="">Site config</a></li> -->
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de tests</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="#">Ajouter</a></li>
					<!-- <li class="b2"><a class="icon add_page" href="">Add new page</a></li>
					<li class="b1"><a class="icon photo" href="">Add new gallery</a></li>
					<li class="b2"><a class="icon category" href="">Categories</a></li> -->
				</ul>
			</div>
		</div>
	    <div id="main">
			<!-- <div class="half_w half_left">
				<div class="h_title">Visits statistics</div>
					<script src="js/highcharts_init.js"></script>
					<div id="container" style="min-width: 300px; height: 180px; margin: 0 auto"></div>
					<script src="js/highcharts.js"></script>
			</div>
			<div class="half_w half_right">
				<div class="h_title">Site statistics</div>
				<div class="stats">
					<div class="today">
						<h3>Today</h3>
						<p class="count">2 349</p>
						<p class="type">Visits</p>
						<p class="count">96</p>
						<p class="type">Comments</p>
						<p class="count">9</p>
						<p class="type">Articles</p>
					</div>
					<div class="week">
						<h3>Last week</h3>
						<p class="count">12 931</p>
						<p class="type">Visits</p>
						<p class="count">521</p>
						<p class="type">Comments</p>
						<p class="count">38</p>
						<p class="type">Articles</p>
					</div>
				</div>
			</div> 
			
			<div class="clear"></div> -->
			
            <!-- <div class="n_warning"><p>Attention notification. Lorem ipsum dolor sit amet, consetetur, sed diam nonumyeirmod tempor.</p></div>
			<div class="n_ok"><p>Success notification. Lorem ipsum dolor sit amet, consetetur, sed diam nonumyeirmod tempor.</p></div>
			<div class="n_error"><p>Error notification. Lorem ipsum dolor sit amet, consetetur, sed diam nonumyeirmod tempor.</p></div> -->
			
			<div class="full_w">
				<div class="h_title">Créer un cas de test</div>
                <form id="frmProjetEquipe" runat="server">
                    <div id="projetEquipe">
                        <div>
                            <asp:Label runat="server" Text="Mes projets" /><br />
                            <asp:ListBox runat="server" ID="lsbProjets" style="width:100%;height:150px" />
                        </div>
                        <br />
                        <div>
                            <div style="display:inline">
                                <asp:Label runat="server" Text="Équipes du projet (untel)" /><br />
                                <asp:ListBox runat="server" ID="lsbEquipes" style="width:40%;vertical-align:top" />
                            </div>
                            <div style="display:inline">
                                <div>
                                    <asp:Label runat="server" Text="Nom de l'équipe:" />
                                    <asp:TextBox runat="server" ID="txtNomEquipe" /><br />
                                </div>
                                <div>
                                    <asp:Label runat="server" Text="Chef d'équipe:" />
                                    <asp:TextBox runat="server" ID="txtChefEquipe" />
                                </div>
                                <div>
                                    <asp:Label runat="server" Text="Nb. Testeurs:" />
                                    <asp:TextBox runat="server" ID="txtNbTesteurs" />
                                </div>
                            </div>
                        </div>
                        <div>
                            <div style="display:inline">
                                <asp:Label runat="server" Text="Cas de test du projet (untel)" /><br />
                                <asp:ListBox runat="server" ID="lbsCasTestProjet" />
                            </div>
                            <div style="display:inline;vertical-align:text-top">
                                <asp:LinkButton runat="server" ID="btnAllRight" Text=">>" CssClass="button"/>
                                <asp:LinkButton runat="server" ID="btnRight" Text=">" CssClass="button"/>
                                <asp:LinkButton runat="server" ID="btnLeft" Text="<" CssClass="button"/>
                                <asp:LinkButton runat="server" ID="btnAllLeft" Text="<<" CssClass="button"/>    
                            </div>
                            <div>
                                <asp:Label runat="server" Text="Cas de test de l'équipe (untel)" /><br />
                                <asp:ListBox runat="server" ID="lsbCasTestEquipe" />
                            </div>
                        </div>
                    </div>
                <div id="btnEnregistrerAnnuler">  
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="button"/>
                        <asp:LinkButton runat="server" ID="btnAnnuler" Text="Annuler" CssClass="button"/>                       
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
		<!-- <div class="right">
			<p><a href="">Example link 1</a> | <a href="">Example link 2</a></p>
		</div> -->
	</div>
</div>
</body>
</html>
