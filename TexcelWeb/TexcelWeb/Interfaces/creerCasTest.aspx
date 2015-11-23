﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creerCasTest.aspx.cs" Inherits="TexcelWeb.CreerCasTest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="author" content="Paweł 'kilab' Balicki - kilab.pl" />
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
				<p>Bienvenue, <strong id="txtCurrentUserName" runat="server">Marcel L.</strong> [ <a href="/Interfaces/login.aspx">deconnection</a> ]</p>
			</div>
			<!-- <div class="right">
				<div class="align-right">
					<p>Dernière connexion: <strong>28-10-2015</strong></p>
				</div>
			</div> -->
        </div>
	</div>	
	<div id="content">
		<div id="sidebar">
			<div class="box">
                <div class="h_title">&#8250; Recherche</div>
                <ul>
                    <li class="b1"><a class="icon page" href="/Interfaces/recherche.aspx">Recherche</a></li>
                </ul>   
			</div>
            <div class="box">
				<div class="h_title">&#8250; Projets</div>
				<ul>
					<li class="b1"><a class="icon page" href="/Interfaces/creerProjet.aspx">Ajouter</a></li>
                    <li class="b1"><a class="icon page" href="/Interfaces/projetEquipe.aspx">Gestion des equipes</a></li>			
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de test</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="/Interfaces/creerCasTest.aspx">Ajouter</a></li>
				</ul>
			</div>
        </div>
	    <div id="main">
			<div class="full_w">
				<div class="h_title">Créer un cas de test</div>
                <form id="FrmCasTest" runat="server">      
                    <div id="CasTestInfo">
                        <div id="lblColumn1">
                            <div class="info">
                                <asp:Label runat="server" Text="Code: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtCodeCasTest" CssClass="txtColum1"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodeCasTest" Display="dynamic" Text="*" ForeColor="Red" />
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Nom: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtNomCasTest" CssClass="txtColum1"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodeCasTest" Display="dynamic" Text="*" ForeColor="Red" />
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
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="NotEqual" ControlToValidate="txtDateLivraisonCasTest" ValueToCompare="aaaa-mm-jj" Text="*"></asp:CompareValidator>
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Type de test: " CssClass="lblColum1"/>
                                <asp:DropDownList runat="server" ID="dropDownTypeTestCasTest" CssClass="txtColum1"/>
                            </div>
                        </div>  
                        <div id="CasTestObj">
                             <asp:Label runat="server" Text="Objectif: " />
                            <asp:TextBox runat="server" ID="rtxtObjectifProjet" TextMode="MultiLine" CssClass="richtextbox" Height="201px" Width="430px"/>
                        </div><br /><br />
                        <div id="CasTestDesc">
                            <asp:Label runat="server" Text="Description: "/><br />
                            <asp:TextBox runat="server" ID="rtxtDescriptionCasTest" TextMode="MultiLine" CssClass="richtextbox" Height="156px" Width="439px"/>
                        </div>
                        <div id="CasTestDiv">
                            <asp:Label runat="server" Text="Divers: "/>
                            <asp:TextBox runat="server" ID="rtxtDiversProjet" TextMode="MultiLine" CssClass="richtextbox" Height="146px" Width="428px"/>
                        </div>
                    </div>
                <div id="btnCopierEnregistrerAnnuler">
                        <asp:LinkButton runat="server" ID="btnCopier" Text="Copier" CssClass="button" OnClick="btnCopier_Click" OnClientClick="window.open('recherche.aspx', 'recherche');"/>      
                        <asp:LinkButton runat="server" ID="btnAnnuler" Text="Annuler" CssClass="btnDroit button cancel"/>
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="btnDroit button add" OnClick="btnEnregistrer_Click" PostBackUrl="~/Interfaces/creerCasTest.aspx" />                       
                    <br />
                    <br />
                </div>
                <div>         
                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    <hr />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded">
                        <Columns>
                            <asp:BoundField DataField="File Name" HeaderText="File Name" />
                            <asp:BoundField DataField="Extansion" HeaderText="Extansion" />
                            <asp:BoundField DataField="Taille" HeaderText="Taille" />
                            <asp:BoundField DataField="Derniere modification" HeaderText="Derniere modification" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDownload" Text = "Download"  runat="server" CommandArgument='<%# Eval("File Name") %>' OnClick="lnkDownload_Click"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID = "lnkDelete" Text = "Delete"  runat = "server" CommandArgument='<%# Eval("File Name") %>' OnClick="lnkDelete_Click"/>
                                </ItemTemplate>
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
