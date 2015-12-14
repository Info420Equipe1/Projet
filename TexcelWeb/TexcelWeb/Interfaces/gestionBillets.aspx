﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionBillets.aspx.cs" Inherits="TexcelWeb.Interfaces.gestionBillets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Texcel - Gestion des Billets</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/gestionBillet.css" media="screen" />
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
                <div class="right">
                    <p><asp:Image ID="imgLogo" runat="server" ImageUrl="../img/logo_texcel.png"/></p>
                </div>
		    </div>
	    </div>
        <form id="form1" runat="server">
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
                        <div class="div_1">
                            <div id="div_1a">
                                <div class="lblInfo">
                                    <asp:Label runat="server" Text="Projet : " />                              
                                    <asp:DropDownList runat="server" ID="ddlProjet" CssClass="txtColum1" AutoPostBack="True" style="width:250px" OnSelectedIndexChanged="ddlProjet_SelectedIndexChanged"></asp:DropDownList> 
                                    <br /><br />               
                                </div>
                                <div class="lblInfo">
                                    <asp:Label runat="server" Text="Équipe :" />
                                    <asp:DropDownList runat="server"  ID="ddlEquipe" CssClass="txtColum1" AutoPostBack="true" style="width:250px" Enabled="False" OnSelectedIndexChanged="ddlEquipe_SelectedIndexChanged" /> <br /><br />
                                </div>
                                <div class="lblInfo">
                                    <asp:Label runat="server" Text="Testeur :" />
                                    <asp:DropDownList runat="server" ID="ddlTesteur" CssClass="txtColum1" AutoPostBack="true" style="width:250px" Enabled="False" OnSelectedIndexChanged="ddlTesteur_SelectedIndexChanged" />
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlStats" runat="server" GroupingText="Statistiques du projet"> 
                            <div class="div_1bb">
                                <div class="div_1b">
                                    <div class="info">
                                        <asp:Label CssClass="lblinfo lblColum1" runat="server" Text="Nb cas Test : " />
                                        <asp:Label ID="lblNbCasTest" CssClass="txtColum1" runat="server" Text="" />
                                    </div>
                                    <div class="info">
                                        <asp:Label  CssClass="lblinfo lblColum1" runat="server" Text="Nb billet : " />
                                        <asp:Label ID="lblNbBillet" CssClass="txtColum1" runat="server" Text="" />
                                    </div>
                                    <div class="info">
                                        <asp:Label CssClass="lblinfo lblColum1" runat="server" Text="Nb billet en cours : " />
                                        <asp:Label ID="lblNbBilletEnCours" CssClass="txtColum1" runat="server" Text="" />
                                    </div>                      
                                    <div class="info">
                                        <asp:Label CssClass="lblinfo lblColum1" runat="server" Text="Temps estimé des billets en cours : " />
                                        <asp:Label ID="lblTempsEstime" CssClass="txtColum1" runat="server" Text="" />      
                                    </div>                          
                                </div> 
                                <div class="div_1b">
                                    <div class="info">
                                        <asp:Label CssClass="lblinfo lblColum2" runat="server" Text="Nb billet urgent : " />
                                        <asp:Label ID="lblNbBilletUrgent" CssClass="txtColum1" runat="server" Text="" />
                                    </div>
                                    <div class="info">
                                        <asp:Label CssClass="lblinfo lblColum2" runat="server" Text="Nb billet terminé : " />
                                        <asp:Label ID="lblNbBilletTermine" CssClass="txtColum1" runat="server" Text="" />
                                    </div>
                                    <div class="info">
                                        <asp:Label CssClass="lblinfo lblColum2" runat="server" Text="Temps estimé total : " />
                                        <asp:Label ID="lblTempsTotal" CssClass="txtColum1" runat="server" Text="" />  
                                    </div>              
                                    <div class="info">
                                        <asp:Label CssClass="lblinfo lblColum2" runat="server" Text="Temps investi : " />
                                        <asp:Label ID="lblTempsInvesti" CssClass="txtColum1" runat="server" Text="" />
                                    </div>                         
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:LinkButton ID="btnEnregistrer" runat="server" Text="Enregistrer" CssClass="button" OnClick ="btnEnregistrer_Click" />  
                    </div>
                </div>
            </div>
            <div id="content2">
                <div id="main2">					
		            <div class="gridView">
                        <asp:GridView ID="dgvBillets" runat="server" AutoGenerateColumns="False" OnRowDataBound="dgvBillets_RowDataBound" AllowSorting="True">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBox" runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Titre" DataField="Titre" SortExpression="Titre" ></asp:BoundField>
                                <asp:TemplateField HeaderText="Priorité" SortExpression="nomNivPri">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPriorite" runat="server" DataSourceID="edsPriorite" DataTextField="nomNivPri" DataValueField="nomNivPri" SelectedValue='<%# Bind("Priorité") %>'>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsPriorite" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="NiveauPriorite" EntityTypeFilter="NiveauPriorite" Select="it.[nomNivPri]">
                                        </asp:EntityDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Difficulté" SortExpression="nomDiff" >
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlDifficulte" runat="server" DataSourceID="edsDifficulte" DataTextField="nomDiff" DataValueField="nomDiff" SelectedValue='<%# Bind("Difficulté") %>'>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsDifficulte" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="Difficulte" Select="it.[nomDiff]">
                                        </asp:EntityDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Statut" SortExpression="nomStatut" >
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlStatut" runat="server" DataSourceID="edsStatut" DataTextField="nomStatut" DataValueField="nomStatut" SelectedValue='<%# Bind("Statut") %>'>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsStatut" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="Statut" Select="it.[nomStatut]">
                                        </asp:EntityDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type de Test" SortExpression="nomTest" >
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTypeTest" runat="server" DataSourceID="edsTypeTest" DataTextField="nomTest" DataValueField="nomTest" SelectedValue='<%# Bind("Type_de_Test") %>'>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsTypeTest" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="TypeTest" EntityTypeFilter="TypeTest" Select="it.[nomTest]">
                                        </asp:EntityDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>      
                                <asp:TemplateField HeaderText="Durée" SortExpression="Durée">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDuree" runat="server" Text='<%# Bind("Durée") %>' Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Testeur" SortExpression="nomComplet">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTesteur" runat="server" DataSourceID="edsTesteurs" DataTextField="nomComplet" DataValueField="nomComplet" SelectedValue='<%# Eval("Testeur") %>' AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="">(aucun)</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsTesteurs" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllTesteurs" EntityTypeFilter="AllTesteurs" Select="it.[nomComplet]">
                                        </asp:EntityDataSource>                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CasTest" HeaderText="Cas de Test" SortExpression="CasTest" />       
                                <asp:BoundField DataField="Date_Livraison" HeaderText="Livraison" SortExpression="Date_Livraison">
                                <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Jours_Restant" HeaderText="Nb.Jours" SortExpression="Jours_Restant" />
                            </Columns>
                        </asp:GridView>
                        <asp:EntityDataSource ID="edsBilletsTravail" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllBilletsTravail" EntityTypeFilter="AllBilletsTravail" Select="it.[Titre], it.[CasTest], it.[Type_de_Test], it.[Statut], it.[Priorité], it.[Difficulté], it.[Durée], it.[Testeur], it.[Date_Livraison], it.[Jours_Restant]"></asp:EntityDataSource>       
                    </div>
                </div>
            </div>
        </form>
        <div id="footer">
		    <div class="left">
			    <p>Design: <a href="#">Marcel Leblond, Benoit Simard, Sébastien Tremblay, Jérémie Tremblay, Louis-Alexandre Munger</a> <!--| Admin Panel: <a href=""></a> --></p>
		    </div>
	    </div>
    </div>

</body>
</html>
