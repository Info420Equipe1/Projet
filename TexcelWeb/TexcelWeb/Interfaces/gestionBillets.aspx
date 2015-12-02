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
    <style type="text/css">
        #lblColumn1 {
            width: 1185px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="wrap">
	        <div id="header">
		        <div id="top">
			        <div class="left">
				        <p>Bienvenue, <strong id="txtCurrentUserName" runat="server">Marcel L.</strong> [ <a href="login.aspx">deconnection</a> ]</p>
			        </div>
		        </div>
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

        <div class="div_1">
            <div id="div_1a">
                <div class="lblInfo">
                    <asp:Label runat="server" Text="Projet : " />
                    <asp:DropDownList runat="server" ID="ddlProjet" CssClass="txtColum1" style="width:250px"/> <br /><br />               
                </div>
                <div class="lblInfo">
                    <asp:Label  runat="server" Text="Équipe :" />
                    <asp:DropDownList runat="server" ID="ddlEquipe" CssClass="txtColum1" style="width:250px"/> <br /><br />
                </div>
                <div class="lblInfo">
                    <asp:Label  runat="server" Text="Testeur :" />
                    <asp:DropDownList runat="server" ID="ddlTesteur" CssClass="txtColum1" style="width:250px" />
                </div>
            </div>
                
            <div class="div_1b">
                    <div class="info">
                        <asp:Label class="lblinfo" runat="server" Text="Nb cas Test : " />
                        <asp:TextBox runat="server" ID="txtCodeProjet" CssClass="txtColum1"/>
                    </div>
                    <div class="info">
                        <asp:Label  class="lblinfo" runat="server" Text="Nb billet: " />
                        <asp:TextBox runat="server" ID="txtNbBillet" CssClass="txtColum1"/>
                    </div>
                    <div class="info">
                        <asp:Label class="lblinfo" runat="server" Text="Nb billet(en cours): " />
                        <asp:TextBox runat="server" ID="txtNbBilletEnCours" CssClass="txtColum1"/>
                    </div>                      
                    <div class="info">
                        <asp:Label class="lblinfo" runat="server" Text="Nb billet(terminé) : " />
                        <asp:TextBox runat="server" ID="txtNbBilletTermine" CssClass="txtColum1"/>
                    </div>                          
            </div>
           <div class="div_1b">
                <div class="info">
                    <asp:Label class="lblinfo" runat="server" Text="Nb billet(urgent): " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtNbBilletUrgent" CssClass="txtColum1"/>
                </div>
                <div class="info">
                    <asp:Label class="lblinfo" runat="server" Text="Temps estimé: " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtTempsEstime" CssClass="txtColum1"/>           
                </div>
                <div class="info">
                    <asp:Label class="lblinfo" runat="server" Text="Temps estimé(globale): " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtTempsTotal" CssClass="txtColum1"/>      
                </div>              
                <div class="info">
                    <asp:Label class="lblinfo" runat="server" Text="Temps investie : " CssClass="lblColum1"/>
                    <asp:TextBox runat="server" ID="txtTempInvestie" CssClass="txtColum1"/>
                </div>                         
          </div>

            <div id="div_1c">
                <asp:GridView ID="dgvBillets" runat="server" AutoGenerateColumns="False" PageSize="5" Visible="true" Width="1261px" OnRowDataBound="dgvBillets_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Cocher" >
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkBox" runat="server"  AutoPostBack="true"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ItemStyle-Width="200px" DataField="TitreBillet" HeaderText="Titre" >
                            <ItemStyle CssClass="boundfieldElement"  />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Priorité">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlPriorite" DataSourceID="dsPriorite" CssClass="ddlGV" runat="server" AutoPostBack="true" DataTextField="nomProjet" DataValueField="codeProjet" OnSelectedIndexChanged="ddlPriorite_SelectedIndexChanged"></asp:DropDownList>
                                <asp:EntityDataSource ID="dsPriorite" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="AllProjet" Select="it.[codeProjet], it.[nomProjet], it.[chefProjet], it.[dateCreation], it.[dateLivraison]"></asp:EntityDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Statut" >
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlStatut" DataSourceID="dsStatut" CssClass="ddlGV" runat="server" AutoPostBack="true" DataTextField="nomCasTest" DataValueField="codeCasTest" OnSelectedIndexChanged="ddlStatut_SelectedIndexChanged"></asp:DropDownList>
                                <asp:EntityDataSource ID="dsStatut" runat="server" ConnectionString="name=dbProjetE1Entities" DefaultContainerName="dbProjetE1Entities" EnableFlattening="False" EntitySetName="tblCasTest" EntityTypeFilter="CasTest" Select="it.[codeCasTest], it.[nomCasTest], it.[dateCreation], it.[dateLivraison], it.[codeProjet]"></asp:EntityDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type de Test" >
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlTypeTest" CssClass="ddlGV" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTypeTest_SelectedIndexChanged"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>      
                        <asp:TemplateField HeaderText="Durée">
                            <ItemTemplate> 
                                <asp:TextBox ID="txtDuree" runat="server"  Type="Number" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Testeur">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlTesteur" CssClass="ddlGV" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTesteur_SelectedIndexChanged"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ItemStyle-Width="85px" ItemStyle-CssClass="align-center" DataField="CasTest" HeaderText="Cas de Test" >
                            <ItemStyle CssClass="boundfieldElement"/>
                        </asp:BoundField>            
                    </Columns>
                </asp:GridView>	                   
            </div>
        </div>
    
   </form>

    <div id="footer">
		<div class="left">
			<p>Design: <a href="#">Équipe 1</a> <!--| Admin Panel: <a href=""></a> --></p>
		</div>
	</div>

</body>
</html>
