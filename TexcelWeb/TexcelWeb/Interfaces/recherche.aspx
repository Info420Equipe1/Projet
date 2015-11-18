<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recherche.aspx.cs" Inherits="TexcelWeb.recherche" enableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de tests</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="#">Ajouter</a></li>
				</ul>
			</div>
		</div>
	    <div id="main">					
			<div class="full_w">
                <form id="FrmCasTest" runat="server">                          
                    <div id="recherche">
                        <asp:TextBox ID="txtChampRecherche" runat="server" Width="210px" />
                        <asp:DropDownList ID="ddlFiltre" runat="server" OnSelectedIndexChanged="ddlFiltre_SelectedIndexChanged">
                            <asp:ListItem>Projet</asp:ListItem>
                            <asp:ListItem>CasTest</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" />
                    </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UPGridView" runat="server">        
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlFiltre" />
                        </Triggers>
                        <ContentTemplate>              
                            <asp:GridView ID="gvRecherche" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />                     
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>  
                    <asp:EntityDataSource ID="EntityDataSource" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="tblProjet" EntityTypeFilter="cProjet" Select="it.[codeProjet], it.[nomProjet], it.[chefProjet], it.[dateCreation], it.[dateLivraison]"></asp:EntityDataSource>
                    <div class="pagination">
					    <span>« Première</span>
					    <span class="active">1</span>
					    <a href="#">2</a>
					    <a href="#">3</a>
					    <a href="#">4</a>
					    <span>...</span>
					    <a href="#">23</a>
					    <a href="#">24</a>
					    <a href="#">Dernière »</a>
				    </div>
                    <div id="btnCopierEnregistrerAnnuler">
                        <asp:LinkButton runat="server" ID="btnCopier" Text="Copier" CssClass="button"/>      
                        <asp:LinkButton runat="server" ID="btnAnnuler" Text="Annuler" CssClass="btnDroit button cancel"/>
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="btnDroit button add" />
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
