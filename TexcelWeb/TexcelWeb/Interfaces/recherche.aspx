<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recherche.aspx.cs" Inherits="TexcelWeb.recherche" %>
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
				<div class="h_title">Rechercher</div>
                <form id="FrmCasTest" runat="server">
                    
                    <div id="recherche">
                        <asp:TextBox ID="txtChampRecherche" runat="server" Width="210px"></asp:TextBox>
                        <asp:DropDownList ID="dDLFiltre" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" />
                        <br />
                    </div>
                   
                    <table id="tblRecherche" runat="server">
					<thead>
						<tr>
							<th scope="col" id="col1" style="width:200px">1</th>
							<th scope="col" id="col2" style="width:40px;text-align:center">2</th>
							<th scope="col" id="col3" style="width:40px;text-align:center">3</th>
							<th scope="col" id="col4" style="width:150px">4</th>
							<th scope="col" id="col5" style="width:90px">5</th>
							<th scope="col" id="col6" style="width:65px;">6</th>
						</tr>
					</thead>					
					<tbody>
						<tr>
							<td>Documentation</td>
							<td>.txt</td>
							<td>180 mb</td>
							<td>Marcel Leblond</td>
							<td>22-03-2012</td>
							<td class="align-center">
								<a href="#" class="table-icon edit" title="Modifier"></a>
								<a href="#" class="table-icon archive" title="Emplacement du document"></a>
								<a href="#" class="table-icon delete" title="Supprimer"></a>
							</td>
						</tr>
							
						<tr>
							<td>VisualParadigmDoc</td>
							<td>.vpp</td>
							<td>150 mb</td>
							<td>Louis-Alexandre Munger</td>
							<td>23-03-2012</td>
							<td class="align-center">
								<a href="#" class="table-icon edit" title="Modifier"></a>
								<a href="#" class="table-icon archive" title="Emplacement du document"></a>
								<a href="#" class="table-icon delete" title="Supprimer"></a>
							</td>
						</tr>					
						<tr>
							<td>Documentation2</td>
							<td>.txt</td>
							<td>160 mb</td>
							<td>Jérémie Tremblay</td>
							<td>22-03-2012</td>
							<td class="align-center">
								<a href="#" class="table-icon edit" title="Modifier"></a>
								<a href="#" class="table-icon archive" title="Emplacement du document"></a>
								<a href="#" class="table-icon delete" title="Supprimer"></a>
							</td>
						</tr>
						
						<tr>
							<td>ReadME</td>
							<td>.txt</td>
							<td>170 mb</td>
							<td>Benoit Simard</td>
							<td>25-03-2012</td>
							<td class="align-center">
								<a href="#" class="table-icon edit" title="Modifier"></a>
								<a href="#" class="table-icon archive" title="Emplacement du document"></a>
								<a href="#" class="table-icon delete" title="Supprimer"></a>
							</td>
						</tr>
                        <tr>
							<td>ReadME</td>
							<td>.txt</td>
							<td>170 mb</td>
							<td>Benoit Simard</td>
							<td>25-03-2012</td>
							<td class="align-center">
								<a href="#" class="table-icon edit" title="Modifier"></a>
								<a href="#" class="table-icon archive" title="Emplacement du document"></a>
								<a href="#" class="table-icon delete" title="Supprimer"></a>
							</td>
						</tr>
					</tbody>
				</table>
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
                        <asp:LinkButton runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="btnDroit button add" PostBackUrl="~/Interfaces/creerCasTest.aspx" />
                       
                    <br />
                    <br />
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
