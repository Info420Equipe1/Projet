<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionBillets.aspx.cs" Inherits="TexcelWeb.Interfaces.gestionBillets" %>

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
                                    <asp:Label CssClass="lblinfo" runat="server" Text="Projet : " />                              
                                    <asp:DropDownList runat="server" ID="ddlProjet" CssClass="txtColum1" AutoPostBack="True" style="width:250px"></asp:DropDownList> 
                                    <br /><br />               
                                </div>
                                <div class="lblInfo">
                                    <asp:Label CssClass="lblinfo" runat="server" Text="Équipe :" />
                                    <asp:DropDownList runat="server"  ID="ddlEquipe" CssClass="txtColum1" AutoPostBack="true" style="width:250px" Visible="False"/> <br /><br />
                                </div>
                                <div class="lblInfo">
                                    <asp:Label CssClass="lblinfo" runat="server" Text="Testeur :" />
                                    <asp:DropDownList runat="server" ID="ddlTesteur" CssClass="txtColum1" AutoPostBack="true" style="width:250px" Visible="False" />
                                </div>
                            </div>
                        </div>     
                        <div class="div_1bb">
                            <div class="div_1b">
                                <div class="info">
                                    <asp:Label CssClass="lblinfo" runat="server" Text="Nb cas Test : " />
                                    <asp:TextBox runat="server" ID="txtCodeProjet" CssClass="txtColum1"/>
                                </div>
                                <div class="info">
                                    <asp:Label  CssClass="lblinfo" runat="server" Text="Nb billet: " />
                                    <asp:TextBox runat="server" ID="txtNbBillet" CssClass="txtColum1"/>
                                </div>
                                <div class="info">
                                    <asp:Label CssClass="lblinfo" runat="server" Text="Nb billet(en cours): " />
                                    <asp:TextBox runat="server" ID="txtNbBilletEnCours" CssClass="txtColum1"/>
                                </div>                      
                                <div class="info">
                                    <asp:Label CssClass="lblinfo" runat="server" Text="Nb billet(terminé) : " />
                                    <asp:TextBox runat="server" ID="txtNbBilletTermine" CssClass="txtColum1"/>
                                </div>                          
                            </div> 
                            <div class="div_1b">
                                <div class="info">
                                    <asp:Label CssClass="lblinfo lblColum1" runat="server" Text="Nb billet(urgent): " />
                                    <asp:TextBox runat="server" ID="txtNbBilletUrgent" CssClass="txtColum1"/>
                                </div>
                                <div class="info">
                                    <asp:Label CssClass="lblinfo lblColum1" runat="server" Text="Temps estimé: " />
                                    <asp:TextBox runat="server" ID="txtTempsEstime" CssClass="txtColum1"/>           
                                </div>
                                <div class="info">
                                    <asp:Label CssClass="lblinfo lblColum1" runat="server" Text="Temps estimé(globale): " />
                                    <asp:TextBox runat="server" ID="txtTempsTotal" CssClass="txtColum1"/>      
                                </div>              
                                <div class="info">
                                    <asp:Label CssClass="lblinfo lblColum1" runat="server" Text="Temps investie : " />
                                    <asp:TextBox runat="server" ID="txtTempInvestie" CssClass="txtColum1" />
                                </div>                         
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="content2">
                <div id="main2">					
		            <div class="gridView">
                        <asp:GridView ID="dgvBillets" runat="server" AutoGenerateColumns="False" OnRowDataBound="dgvBillets_RowDataBound" DataSourceID="edsBilletsTravail">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBox" runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Titre" DataField="Titre" ></asp:BoundField>
                                <asp:TemplateField HeaderText="Priorité">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPriorite" runat="server" DataSourceID="edsPriorite" DataTextField="nomNivPri" DataValueField="nomNivPri" SelectedValue='<%# Bind("Priorité") %>'>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsPriorite" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="NiveauPriorite" EntityTypeFilter="NiveauPriorite" Select="it.[nomNivPri]">
                                        </asp:EntityDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Difficulté" >
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlDifficulte" runat="server" DataSourceID="edsDifficulte" DataTextField="nomDiff" DataValueField="nomDiff" SelectedValue='<%# Bind("Difficulté") %>'>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsDifficulte" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="Difficulte" Select="it.[nomDiff]">
                                        </asp:EntityDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Statut" >
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlStatut" runat="server" DataSourceID="edsStatut" DataTextField="nomStatut" DataValueField="nomStatut" SelectedValue='<%# Bind("Statut") %>'>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsStatut" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="Statut" Select="it.[nomStatut]">
                                        </asp:EntityDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type de Test" >
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTypeTest" runat="server" DataSourceID="edsTypeTest" DataTextField="nomTest" DataValueField="nomTest" SelectedValue='<%# Bind("Type_de_Test") %>'>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsTypeTest" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="TypeTest" EntityTypeFilter="TypeTest" Select="it.[nomTest]">
                                        </asp:EntityDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>      
                                <asp:TemplateField HeaderText="Durée">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDuree" runat="server" Text='<%# Bind("Durée") %>' Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Testeur">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTesteur" runat="server" DataSourceID="edsTesteurs" DataTextField="nomComplet" DataValueField="nomComplet" SelectedValue='<%# Bind("Testeur") %>'>
                                        </asp:DropDownList>
                                        <asp:EntityDataSource ID="edsTesteurs" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllTesteurs" EntityTypeFilter="AllTesteurs" Select="it.[nomComplet]">
                                        </asp:EntityDataSource>                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CasTest" HeaderText="Cas de Test" />       
                                <asp:BoundField DataField="Date_Livraison" HeaderText="Date de livraison">
                                <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Jours_Restant" HeaderText="Nb.Jours" />
                            </Columns>
                        </asp:GridView>
                        <asp:EntityDataSource ID="edsBilletsTravail" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllBilletsTravail" EntityTypeFilter="AllBilletsTravail"></asp:EntityDataSource>       
                    </div>
                </div>
            </div>
        </form>
        <div id="footer">
		    <div class="left">
			    <p>Design: <a href="#">Équipe 1</a> <!--| Admin Panel: <a href=""></a> --></p>
		    </div>
	    </div>
    </div>

</body>
</html>
