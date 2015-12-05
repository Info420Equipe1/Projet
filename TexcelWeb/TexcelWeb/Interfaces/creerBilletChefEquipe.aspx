<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creerBilletChefEquipe.aspx.cs" Inherits="TexcelWeb.creerBilletChefEquipe" %>
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
                <form id="FrmCasTest" runat="server">                         
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UPRecherche" runat="server">
                        <ContentTemplate>
                            <div id="recherche">
                                <asp:Label runat="server" Text="Projet: " />
                                <asp:DropDownList ID="cmbProjet" runat="server" Width="210px" AutoPostBack="true" OnSelectedIndexChanged="cmbProjet_SelectedIndexChanged" /><br />
                                <asp:Label runat="server" Text="Équipe: " />
                                <asp:DropDownList ID="cmbEquipe" runat="server" Width="210px" />
                                <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" OnClick="btnRechercher_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UPGridView" runat="server">
                        <ContentTemplate>              
                            <asp:GridView ID="dataGridCasTest" runat="server" AutoGenerateColumns="False" AllowSorting="true" OnDataBound="dataGridCasTest_DataBound">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="85px" ItemStyle-CssClass="align-center" DataField="CodeCasTest" HeaderText="Code" >
                            <ItemStyle CssClass="align-center" Width="85px" />
                            </asp:BoundField>
                            <asp:BoundField ItemStyle-Width="200px" DataField="NomCasTest" HeaderText="Nom Cas de Test" >
                            <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField ItemStyle-Width="85px" ItemStyle-CssClass="align-center" DataField="DateLivraisonCasTest" HeaderText="Date livraison" >
                            <ItemStyle CssClass="align-center" Width="85px" />
                            </asp:BoundField>
                            <asp:BoundField ItemStyle-Width="85px" ItemStyle-CssClass="align-center" DataField="PrioriteCasTest" HeaderText="Priorité" >
                            <ItemStyle CssClass="align-center" Width="85px" />
                            </asp:BoundField>
                            <asp:BoundField ItemStyle-Width="85px" ItemStyle-CssClass="align-center" DataField="DifficulteCasTest" HeaderText="Difficulté" >
                            <ItemStyle CssClass="align-center" Width="85px" />
                            </asp:BoundField>  
                            <asp:TemplateField HeaderText="Options" HeaderStyle-Width="65px" ControlStyle-CssClass="align-center">
                                <ItemTemplate>
                                    <a id="btnAjouterBilletCasTest" runat="server" class="table-icon add" title="Ajouter un Cas de test pour ce billet" ></a>
                                    <a id="btnConsulterCasTest" runat="server" class="table-icon info" title="Consulter le Cas de test" ></a>  
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>	
                        </ContentTemplate>                      
                    </asp:UpdatePanel>  
                    <div id="dataGridPagination" class="pagination" runat="server"  visible="false"></div>          
                    <div>
                        <asp:LinkButton runat="server" ID="btnCreerBillet" Text="Creer un billet de travail" CssClass="btnDroit button add" OnClick="btnCreerBillet_Click" />
                    </div><br /><br />
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
