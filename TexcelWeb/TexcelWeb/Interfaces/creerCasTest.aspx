<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creerCasTest.aspx.cs" Inherits="TexcelWeb.CreerCasTest" %>
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
				<div class="h_title" id="Titre" runat="server">Créer un cas de test</div>
                <form id="FrmCasTest" runat="server">      
                    <div id="CasTestInfo">
                        <div id="lblColumn1">
                            <div class="info">
                                <asp:Label runat="server" Text="Code: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtCodeCasTest"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodeCasTest" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Nom: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtNomCasTest" CssClass="txtColum1"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNomCasTest" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Projet: " CssClass="lblColum1" />
                                <asp:DropDownList runat="server" ID="dropDownProjet" CssClass="txtColum1" style="width:71.5%" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Difficulté: " CssClass="lblColum1" />
                                <asp:DropDownList runat="server" ID="dropDownDifficulteCasTest" CssClass="txtColum1 txtDate1">
                                    <asp:ListItem Selected="True" Text="Faible" Value="Faible"></asp:ListItem>
                                    <asp:ListItem Text="Modérée" Value="Modorée"></asp:ListItem>
                                    <asp:ListItem Text="Élevée" Value="Élevée"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label runat="server" Text="Priorité: " CssClass="lblColum1 lblDate1" />
                                <asp:DropDownList runat="server" ID="dropDownPrioritéCasTest" CssClass="txtColum1 txtDate1">
                                    <asp:ListItem Selected="True" Text="Faible" Value="Faible"></asp:ListItem>
                                    <asp:ListItem Text="Modérée" Value="Modorée"></asp:ListItem>
                                    <asp:ListItem Text="Élevée" Value="Élevée"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Date Création: " CssClass="lblColum1"/>
                                <asp:TextBox type="date" runat="server" ID="txtDateCreationCasTest" CssClass="txtColum1 txtDate2" />
                                <asp:Label runat="server" Text="Date Livraison: " CssClass="lblColum1 lblDate2" />
                                <asp:TextBox type="date" runat="server" ID="txtDateLivraisonCasTest" CssClass="txtColum1 txtDate2" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="GreaterThan" ControlToValidate="txtDateLivraisonCasTest" ControlToCompare="txtDateCreationCasTest" ValueToCompare="aaaa-mm-jj" Text="*"></asp:CompareValidator>
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Type de test: " CssClass="lblColum1"/>
                                <asp:DropDownList runat="server" ID="dropDownTypeTestCasTest" CssClass="txtColum1"/>
                            </div>
                        </div>  
                        <div id="CasTestObj">
                             <asp:Label runat="server" Text="Objectif: " /><br />
                            <asp:TextBox runat="server" ID="rtxtObjectifCastest" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div><br /><br />
                        <div id="CasTestDesc">
                            <asp:Label runat="server" Text="Description: "/><br />
                            <asp:TextBox runat="server" ID="rtxtDescriptionCasTest" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div>
                        <div id="CasTestDiv">
                            <asp:Label runat="server" Text="Divers: " ID="lblDivers"/><br />
                            <asp:TextBox runat="server" ID="rtxtDiversCasTest" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div>
                    </div>
                <div id="btnCopierEnregistrerAnnuler">
                        <asp:LinkButton runat="server" ID="btnCopier" Text="Ajouter des fichiers existants" CssClass="button" OnClick="btnCopier_Click" AutoPostBack="true"/>      
                        <asp:LinkButton runat="server" ID="btnAnnuler" Text="Annuler" CssClass="btnDroit button cancel" OnClick="btnAnnuler_Click" CausesValidation="false"/>
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="btnDroit button add" OnClick="btnEnregistrer_Click" PostBackUrl="~/Interfaces/creerCasTest.aspx" />                       
                        <asp:LinkButton runat="server" ID="btnAjouter" Text="Ajouter fichiers" CssClass="btnDroit button add" PostBackUrl="~/Interfaces/creerCasTest.aspx" OnClick="btnAjouter_Click"/>                       
                    <br />
                    <br />
                </div>
                <div>         
                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
                    <asp:Button ID="btnUpload" runat="server" Text="Envoyez" OnClick="btnUpload_Click" />
                    <div style="height: 32px">
                        <asp:LinkButton runat="server" ID="btnSupprimer" Text="Supprimer fichiers" CssClass="btnDroit button cancel" CausesValidation="false"  OnClick="btnSupprimer_Click"/>
                        <asp:LinkButton runat="server" ID="btnFermer" Text="Fermer" CssClass="btnDroit button cancel" OnClick="btnFermer_Click" CausesValidation="false" Visible="False"/>
                        </div>
                    <hr />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText = "No files uploaded" >
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
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDownload" runat="server" CommandArgument='<%# Eval("File Name") %>' OnClick="lnkDownload_Click" CssClass="addonly"/>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("File Name") %>' OnClick="lnkDelete_Click" CssClass="cancelonly" />
                                    <asp:LinkButton ID="lnkFile" runat="server" CommandArgument='<%# Eval("File Name") %>' CssClass="file" OnClick="lnkOpen_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div id="dataGridPagination" class="pagination" runat="server"  visible="false"></div>
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