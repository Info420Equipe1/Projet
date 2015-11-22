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
				<p>Bienvenue, <strong>BASS</strong> [ <a href="#">deconnection</a> ]</p>
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
                <div class="h_title" ><a href="/Interfaces/recherche.aspx">&#8250;Recherche</a></div>
				<div class="h_title">&#8250; Projets</div>
				<ul>
					<li class="b1"><a class="icon page" href="/Interfaces/creerProjet.aspx">Ajouter</a></li>
                    <li class="b2"><a class="icon report" href="/Interfaces/projetEquipe.aspx">Gestion des equipes</a></li>			
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de tests</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="/Interfaces/creerCasTest.aspx">Ajouter</a></li>
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
                                <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" onCLick="btnRechercher_Click"/>
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
                    <asp:EntityDataSource ID="edsProjet" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="tblProjet" EntityTypeFilter="cProjet" Select="it.[codeProjet], it.[nomProjet], it.[chefProjet], it.[dateCreation], it.[dateLivraison]"></asp:EntityDataSource>
                    <asp:EntityDataSource ID="edsCasTest" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="tblCasTest" EntityTypeFilter="CasTest" Select="it.[codeCasTest], it.[nomCasTest], it.[dateCreation], it.[dateLivraison], it.[codeProjet]"></asp:EntityDataSource>
                    <div id="dataGridPagination" class="pagination" runat="server"  visible="false">
				    </div>

                       <asp:Button ID="btnCopier" runat="server" Text="Copier mes sélections" onCLick="btnCopier_Click"/>    
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