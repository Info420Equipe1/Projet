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
        <div id="content">       
		    <div id="sidebar">
			    <div class="box">
                    <div class="h_title bottomMargin">&#8250; Recherche</div>
                    <ul>
                        <li class="b1 bottomMargin"><a class="icon page" href="recherche.aspx">Recherche</a></li>
                    </ul>   
			    </div>
                <div class="box">
				    <div class="h_title">&#8250; Projets</div>
				    <ul>
					    <li class="b1"><a class="icon page" href="creerProjet.aspx">Ajouter un Projet</a></li>
                        <li class="b1"><a class="icon page" href="projetEquipe.aspx">Gestion des Équipes</a></li>			
				    </ul>
			    </div>		
			    <div class="box">
				    <div class="h_title">&#8250; Cas de test</div>
				    <ul id="home">
					    <li class="b1"><a class="icon page" href="creerCasTest.aspx">Ajouter un Cas de test</a></li>
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
                    <form id="form1" runat="server">
                        <div class="div_1">
                            <div id="div_1a">
                                <div class="lblInfo">
                                    <asp:Label CssClass="lblinfo" runat="server" Text="Projet : " />
                                    
                                    <asp:DropDownList runat="server" ID="ddlProjet" CssClass="txtColum1" AutoPostBack="True" OnSelectedIndexChanged="ddlProjet_SelectedIndexChanged" style="width:250px">                                                                          
                                   </asp:DropDownList> 
                                    <br /><br />               
                                </div>
                                <div class="lblInfo">
                                    <asp:Label CssClass="lblinfo" runat="server" Text="Équipe :" />
                                    <asp:DropDownList runat="server"  ID="ddlEquipe" CssClass="txtColum1" AutoPostBack="true" OnSelectedIndexChanged="ddlEquipe_SelectedIndexChanged" style="width:250px" Visible="False"/> <br /><br />
                                </div>
                                <div class="lblInfo">
                                    <asp:Label CssClass="lblinfo" runat="server" Text="Testeur :" />
                                    <asp:DropDownList runat="server" ID="ddlTesteur" CssClass="txtColum1" AutoPostBack="true" OnSelectedIndexChanged="ddlTesteur_SelectedIndexChanged" style="width:250px" Visible="False" />
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
                        <div id="div_1c">
                            <asp:GridView ID="dgvBillets" runat="server" AutoGenerateColumns="False" PageSize="5" OnRowDataBound="dgvBillets_RowDataBound" DataSourceID="edsBilletsTravail"  >
                                <Columns>
<asp:TemplateField><ItemTemplate>
                                            <asp:CheckBox ID="ChkBox" runat="server"  AutoPostBack="true"/>
                                        
</ItemTemplate>
    <ItemStyle CssClass="noMargin" />
</asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="200px" HeaderText="Titre" DataField="Titre" >
                                        <ItemStyle CssClass="boundfieldElement"  />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Priorité">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlPriorite" runat="server" DataSourceID="edsPriorite" DataTextField="nomNivPri" DataValueField="nomNivPri" SelectedValue='<%# Bind("Priorité") %>'>
                                            </asp:DropDownList>
                                            <asp:EntityDataSource ID="edsPriorite" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="NiveauPriorite" EntityTypeFilter="NiveauPriorite" Select="it.[nomNivPri]">
                                            </asp:EntityDataSource>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="noMargin" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" >
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Statut" >
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type de Test" >
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlStatut" runat="server" DataSourceID="edsStatut" DataTextField="nomStatut" DataValueField="nomStatut" SelectedValue='<%# Bind("Statut") %>'></asp:DropDownList>
                                            <asp:EntityDataSource ID="edsStatut" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="Statut" Select="it.[nomStatut]">
                                            </asp:EntityDataSource>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="noMargin" />
                                    </asp:TemplateField>      
                                    <asp:TemplateField HeaderText="Durée">
                                        <ItemTemplate> 
                                            <asp:DropDownList ID="ddlTypeTest" runat="server" CssClass="ddlGV" DataSourceID="edsTypeTest" DataTextField="nomTest" DataValueField="nomTest" OnSelectedIndexChanged="ddlTypeTest_SelectedIndexChanged" SelectedValue='<%# Bind("Type_de_Test") %>'>
                                            </asp:DropDownList>
                                            <asp:EntityDataSource ID="edsTypeTest" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="TypeTest" EntityTypeFilter="TypeTest" Select="it.[nomTest]">
                                            </asp:EntityDataSource>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="noMargin" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Testeur">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDuree" runat="server" Text='<%# Bind("Durée") %>' Type="Number" Width="35px" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="noMargin" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlTesteur" runat="server" AutoPostBack="True" CssClass="ddlGV" DataSourceID="edsTesteurs" DataTextField="nomComplet" DataValueField="nomComplet" OnSelectedIndexChanged="ddlTesteur_SelectedIndexChanged" SelectedValue='<%# Bind("Testeur") %>'>
                                            </asp:DropDownList>
                                            <asp:EntityDataSource ID="edsTesteurs" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllTesteurs" EntityTypeFilter="AllTesteurs" Select="it.[nomComplet]">
                                            </asp:EntityDataSource>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="noMargin" />
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="85px" ItemStyle-CssClass="align-center" DataField="CasTest" HeaderText="Cas de Test" >
                                        <ItemStyle CssClass="boundfieldElement"/>
                                    </asp:BoundField>            
                                    <asp:BoundField DataField="Date_Livraison" HeaderText="Date_Livraison" SortExpression="Date_Livraison" />
                                    <asp:BoundField DataField="Jours_Restant" HeaderText="Jours_Restant" SortExpression="Jours_Restant" />
                                </Columns>
                                <RowStyle Wrap="True" CssClass="noMargin" />
                            </asp:GridView>
                            <asp:EntityDataSource ID="edsBilletsTravail" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllBilletsTravail" EntityTypeFilter="AllBilletsTravail"></asp:EntityDataSource>       
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
