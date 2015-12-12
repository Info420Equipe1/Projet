<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="copierCasTest.aspx.cs" Inherits="TexcelWeb.Interfaces.copierCasTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Texcel - Creer un cas de test</title>
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
			<div class="right">
                <p><asp:Image ID="imgLogo" runat="server" ImageUrl="../img/logo_texcel.png"/></p>
            </div>
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
                                <asp:DropDownList ID="ddlFiltre" runat="server" AutoPostBack="true">
                                    <asp:ListItem>CasTest</asp:ListItem>
                                    <asp:ListItem>Projet</asp:ListItem>
                                </asp:DropDownList>
                                <asp:LinkButton runat="server" ID="btnRechercher"  Text="Rechercher" CssClass="button" onCLick="btnRechercher_Click"/>
                                <br />
                                <asp:LinkButton runat="server" ID="btnCocher" Text="Sélectionner tout" CssClass="button" onClick="btnCocher_Click" autopostback="true"/> 
                                <asp:LinkButton runat="server" ID="btnDecocher" Text="Déselectionner tout" CssClass="button" onClick="btnDechocher_Click" autopostback="true"/> 
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UPGridView" runat="server">
                        <ContentTemplate>              
                            <asp:GridView ID="gvCopierCasTest" runat="server"  selectedindex="0" >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBox" runat="server"  AutoPostBack="true"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>  
                    <asp:EntityDataSource ID="edsProjet" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="Projet" EntityTypeFilter="cProjet" Select="it.[codeProjet], it.[nomProjet], it.[chefProjet], it.[dateCreation], it.[dateLivraison]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsCasTest" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="CasTest" EntityTypeFilter="CasTest" Select="it.[codeCasTest], it.[nomCasTest],it.[codeProjet], it.[dateCreation],it.[dateLivraison]"></asp:EntityDataSource>
                    <div id="dataGridPagination" class="pagination" runat="server"  visible="false"></div>
                    <div style="height: 42px">
                        <asp:LinkButton ID="btnCopier" runat="server" Text="Copier mes sélections" CssClass="button" Width="200px" OnClick ="btnCopierMesSelections_Click" /> 
                    </div>
                       
                </form>    
			</div>   
		</div>    
	</div>
	<div id="footer">
		<div class="left">
			<p>Design: <a href="#">Marcel Leblond, Benoit Simard, Sébastien Tremblay, Jérémie Tremblay, Louis-Alexandre Munger</a> <!--| Admin Panel: <a href=""></a> --></p>
		</div>	
	</div>
</div>
</body>
</html>