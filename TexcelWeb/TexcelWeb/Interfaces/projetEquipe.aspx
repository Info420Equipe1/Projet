<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projetEquipe.aspx.cs" Inherits="TexcelWeb.Interfaces.projetEquipe" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
<link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div class="wrap">
	<div id="header">
		<div id="top">
			<div class="left">
				<p>Bienvenue, <strong id="txtCurrentUserName" runat="server">Marcel L.</strong> [ <a href="login.aspx">deconnection</a> ]</p>
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
                <div class="h_title">&#8250; Recherche</div>
                <ul>
                    <li class="b1"><a class="icon page" href="recherche.aspx">Recherche</a></li>
                </ul>   
			</div>
            <div class="box">
				<div class="h_title">&#8250; Projets</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="creerProjet.aspx">Ajouter</a></li>
                    <li class="b1"><a class="icon page" href="projetEquipe.aspx">Gestion des cas de test</a></li>			
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
				<div class="h_title">Associer des cas de test à une équipe</div>
                <form id="frmProjetEquipe" runat="server">
                    <asp:ScriptManager ID="ToolkitScriptManager" runat="server"></asp:ScriptManager>
                    <div id="projetEquipe">
                        <asp:UpdatePanel ID="updatePanelProjet" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:Label runat="server" Text="Mes projets" /><br />
                                    <asp:ListBox runat="server" ID="lsbProjets" OnSelectedIndexChanged="lsbProjets_SelectedIndexChanged" AutoPostBack="true" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <div>
                            <asp:UpdatePanel ID="updatePanelEquipe" runat="server">
                                <ContentTemplate>
                                    <div style="float:left;height:185px">
                                        <asp:Label runat="server" Text="Équipes du projet" /><br />
                                        <asp:ListBox runat="server" ID="lsbEquipes" OnSelectedIndexChanged="lsbEquipes_SelectedIndexChanged" AutoPostBack="true" />
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
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <br />
                        <asp:UpdatePanel ID="updatePanelCasTestProjet" runat="server">
                            <ContentTemplate>
                                <div> 
                                    <div class="tableCell">
                                        <asp:Label runat="server" Text="Cas de test du projet" /><asp:CheckBox ID="chkCasTestNonAssocier" runat="server" style="padding-left:200px" Checked="false" AutoPostBack="true" OnCheckedChanged="chkCasTestNonAssocier_CheckedChanged" /><asp:Label runat="server" Text="Cas de test non-associer" style="padding-left:5px" /> <br />
                                        <asp:ListBox runat="server" ID="lsbCasTestProjet" SelectionMode="Multiple" />
                                    </div>
                                    <div id="colButton" class="tableCell"><br /><br /><br /><br /><br />
                                        <asp:LinkButton runat="server" ID="btnAllRight" Text=">>" CssClass="button btnFleches" OnClick="btnAllRight_Click" /><br /><br />
                                        <asp:LinkButton runat="server" ID="btnRight" Text=">" CssClass="button btnFleches" OnClick="btnRight_Click" /><br /><br />
                                        <asp:LinkButton runat="server" ID="btnLeft" Text="<" CssClass="button btnFleches" OnClick="btnLeft_Click" /><br /><br />
                                        <asp:LinkButton runat="server" ID="btnAllLeft" Text="<<" CssClass="button btnFleches" OnClick="btnAllLeft_Click" /> 
                                    </div>
                                    <div class="tableCell">
                                        <asp:Label runat="server" Text="Cas de test de l'équipe" /><br />
                                        <asp:ListBox runat="server" ID="lsbCasTestEquipe" SelectionMode="Multiple" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </div>
                    <br />
                    <div id="btnEnregistrerAnnuler">  
                        <asp:LinkButton runat="server" ID="btnAnnuler" Text="Annuler" CssClass="button btnDroit cancel" OnClick="btnAnnuler_Click"/> 
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="button btnDroit add" OnClick="btnEnregistrer_Click"/>                             
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
