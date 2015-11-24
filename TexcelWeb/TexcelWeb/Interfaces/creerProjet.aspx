<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creerProjet.aspx.cs" Inherits="TexcelWeb.creerProjet" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Texcel - Creer un projet</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/projet.css" media="screen" />

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
    <div>
        <script type="text/javascript" src='<%= ResolveUrl("~/js/JavaScript1.js") %>'></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
    </div>
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
				<div id="txtForm" runat="server" class="h_title">Créer un projet</div>
                <form id="FrmProjet" runat="server">
                    <asp:ScriptManager ID="ToolkitScriptManager" runat="server"></asp:ScriptManager>
                    <div id="ProjetInfo">
                        <div id="lblColumn1">
                            <div class="info">
                                <asp:Label runat="server" Text="Code: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtCodeProjet" CssClass="txtColum1"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodeProjet" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Nom: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtNomProjet" CssClass="txtColum1"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNomProjet" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Chef de projet: " CssClass="lblColum1"/>
                                <asp:DropDownList runat="server" ID="txtChefProjet" CssClass="txtColum1" style="width:71.5%" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtChefProjet" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Date création: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtDateCreationProjet" CssClass="txtColum1 txtDate" type="date" />     
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDateCreationProjet" Display="dynamic" Text="*" ForeColor="Red" />                                                                                                          
                                <asp:Label runat="server" Text="Date livraison: " CssClass="lblColum1 lblDate" />
                                <asp:TextBox runat="server" ID="txtDateLivraisonProjet" CssClass="txtColum1 txtDate" type="date" />   
                            </div>
                            <asp:UpdatePanel ID="updatePanelVersionJeu" runat="server">
                                <ContentTemplate>
                                    <div class="info">
                                        <asp:Label runat="server" Text="Jeu: " CssClass="lblColum1"/>
                                        <asp:DropDownList runat="server" ID="txtJeuProjet" CssClass="txtColum1 txtDate1" style="width:71.5%" OnSelectedIndexChanged="txtJeuProjet_SelectedIndexChanged" AutoPostBack="true"/>
                                    </div>
                                    <div class="info">
                                        <asp:Label runat="server" Text="Version du jeu: " CssClass="lblColum1"/>
                                        <asp:DropDownList runat="server" ID="txtVersionJeuProjet" CssClass="txtColum1 txtDate1" style="width:71.5%" /> 
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtJeuProjet" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>  
                        <div id="CasTestObj">
                            <asp:Label runat="server" Text="Objectif: " />
                            <asp:TextBox runat="server" ID="rtxtObjectifProjet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div><br /><br />
                        <div id="CasTestDesc">
                            <asp:Label runat="server" Text="Description: "/>
                            <asp:TextBox runat="server" ID="rtxtDescriptionProjet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div>
                        <div id="CasTestDiv">
                            <asp:Label runat="server" Text="Divers: "/>
                            <asp:TextBox runat="server" ID="rtxtDiversProjet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div>
                    </div>
                    <div id="btnCopierEnregistrerAnnuler">
                        <asp:LinkButton runat="server" ID="btnCopier" Text="Copier" CssClass="button" OnClick="btnCopier_Click"/>
                        <asp:LinkButton runat="server" ID="btnAnnuler" Text="Annuler" CausesValidation="false" CssClass="btnDroit button cancel" OnClick="btnAnnuler_Click" />
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="btnDroit button add" OnClick="btnEnregistrer_Click" />
                    </div>
                    <asp:GridView ID="dataGridLstCasTest" runat="server" AutoGenerateColumns="False" PageSize="5" Visible="False">
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
                            <asp:TemplateField HeaderText="Options" HeaderStyle-Width="65px" ItemStyle-CssClass="align-center">
                                <ItemTemplate>
                                    <a id="btnModifierGridView" runat="server" class="table-icon edit" title="Modifier" ></a>                                      
                                </ItemTemplate>
                                <ControlStyle Width="85px" />
                                <HeaderStyle Width="65px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>	
                    <div id="dataGridPagination" class="pagination" runat="server"  visible="false"></div> 
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
