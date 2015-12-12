<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="billetsTravail.aspx.cs" Inherits="TexcelWeb.Interfaces.billetsTravail"  EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Texcel - Billets de travail</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/navi.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/billetTravail.css" media="screen" />
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
            <div class="right">
                <p><asp:Image ID="imgLogo" runat="server" ImageUrl="../img/logo_texcel.png"/></p>
            </div>
        </div>
	</div>	
	<div id="content">
        <%--<div id="sidebar">
			<div class="box">
                <div class="h_title">&#8250; Recherche</div>
                <ul>
                    <li class="b1"><a class="icon page" href="recherche.aspx">Recherche</a></li>
                </ul>   
			</div>
            <div class="box">
				<div class="h_title">&#8250; Projets</div>
				<ul>
					<li class="b1"><a class="icon page" href="creerProjet.aspx">Ajouter</a></li>
                    <li class="b1"><a class="icon page" href="projetEquipe.aspx">Gestion des equipes</a></li>			
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de test</div>
				<ul id="home">
					<li class="b1"><a class="icon page" href="creerCasTest.aspx">Ajouter</a></li>
				</ul>
			</div>
            <div class="box">
				<div class="h_title">&#8250; Billet de travail</div>
				<ul>
					<li class="b1"><a class="icon page" href="creerBilletTravail.aspx">Ajouter</a></li>
				</ul>
			</div>
        </div>--%>
	</div>
	    <div id="main">
			<div class="full_w">
				<div class="h_title" id="Titre" runat="server">Billets de travail</div>
                <div id="StatDiv">
                <form runat="server">
                    <asp:Panel ID="pnlStats" runat="server" GroupingText="Statistiques">
                        <asp:Label ID="StatLbl1" runat="server" Text="Nombre de billet urgent: "></asp:Label>
                        <asp:Label ID="lblNbrBillet" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="Label2" runat="server" Text="Nombre de billet personnel: "></asp:Label>
                        <asp:Label ID="lblNbrBilletPersonnel" runat="server" Text="" ></asp:Label><br /><br />         
                    </asp:Panel>    
                      </div>
                    <div id="billets">
                        <div>

                        </div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" AllowSorting="True" OnSorting="GridView1_Sorting" Width="1367px">
                            <Columns>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Titre" HeaderText="Titre" HtmlEncode="false" SortExpression="Titre"/>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Priorite" HeaderText="Priorité" SortExpression="Priorite"/>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Difficulte" HeaderText="Difficulté" SortExpression="Difficulte"/>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="DateLivraison" HeaderText="Date de livraison" SortExpression="DateLivraison"/>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="TypeTest" HeaderText="Type de test" SortExpression="TypeTest"/>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Duree" HeaderText="Durée" SortExpression="Duree"/>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Projet" HeaderText="Projet" SortExpression="Projet"/>
                               
                                
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Sélectionné">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CBSelec" runat="server" AutoPostBack="true" Checked="false" ViewStateMode="Enabled" OnCheckedChanged="CBSelec_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Terminé">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CBTer" runat="server" AutoPostBack="true" Checked="false" ViewStateMode="Enabled" OnCheckedChanged="CBTer_CheckedChanged"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cas de test">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkCasDeTest" runat="server" CssClass="loupe" CommandArgument='<%# Eval("Titre") %>' OnClick="lnkCasDeTest_Click" ForeColor="Blue"/>
                                    
                                    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Billet de trevail">
                                <ItemTemplate>
                                    
                                    <asp:LinkButton ID="lnkBilletTravail" runat="server" CssClass="loupe" ForeColor="Blue" CommandArgument='<%# Eval("Titre") %>' OnClick="lnkBilletTravail_Click"/>
                                    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                        <div>
                        </div>
                    </div>
                    <div id="dataGridPagination" class="pagination" runat="server"></div>
                </form>
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
