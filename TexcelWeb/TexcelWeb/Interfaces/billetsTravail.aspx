﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="billetsTravail.aspx.cs" Inherits="TexcelWeb.Interfaces.billetsTravail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Texcel - Billets de travail</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/billetsTravail.css" media="screen" />
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
					<li class="b1"><a class="icon page" href="creerBilletTravail.aspx">Ajouter</a></li>
				</ul>
			</div>
        </div>
	    <div id="main">
			<div class="full_w">
				<div class="h_title" id="Titre" runat="server">Billets de travail</div>
                <form runat="server">
                    <asp:Panel ID="pnlStats" runat="server" GroupingText="Statistiques"></asp:Panel>      
                    <div id="billets">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="File Name" HeaderText="File Name" HtmlEncode="false"/>
                                <asp:BoundField DataField="Extansion" HeaderText="Extansion" />
                                <asp:BoundField DataField="Taille" HeaderText="Taille" />
                                <asp:BoundField DataField="Derniere modification" HeaderText="Derniere modification" />
                            </Columns>
                        </asp:GridView>
                        <div>
                            <asp:LinkButton runat="server" ID="btnCopier" Text="Visualiser" CssClass="button"/>
                        </div>
                    </div>
                    <div id="dataGridPagination" class="pagination" runat="server"></div>
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
