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
<div class="wrap">
	<div id="header">
		<div id="top">
			<div class="left">
				<p>Bienvenue, <strong id="txtCurrentUserName" runat="server">Marcel L.</strong> [ <a href="#">deconnection</a> ]</p>
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
				<ul id="home">
					<li class="b1"><a class="icon page" href="#">Ajouter</a></li>
					<!-- <li class="b2"><a class="icon report" href="">Reports</a></li>
					<li class="b1"><a class="icon add_page" href="">Add new page</a></li>
					<li class="b2"><a class="icon config" href="">Site config</a></li> -->
				</ul>
			</div>		
			<div class="box">
				<div class="h_title">&#8250; Cas de tests</div>
				<ul>
					<li class="b1"><a class="icon page" href="#">Ajouter</a></li>
					<!-- <li class="b2"><a class="icon add_page" href="">Add new page</a></li>
					<li class="b1"><a class="icon photo" href="">Add new gallery</a></li>
					<li class="b2"><a class="icon category" href="">Categories</a></li> -->
				</ul>
			</div>
			<!-- <div class="box">
				<div class="h_title">&#8250; Users</div>
				<ul>
					<li class="b1"><a class="icon users" href="">Show all users</a></li>
					<li class="b2"><a class="icon add_user" href="">Add new user</a></li>
					<li class="b1"><a class="icon block_users" href="">Lock users</a></li>
				</ul>
			</div>
			<div class="box">
				<div class="h_title">&#8250; Settings</div>
				<ul>
					<li class="b1"><a class="icon config" href="">Site configuration</a></li>
					<li class="b2"><a class="icon contact" href="">Contact Form</a></li>
				</ul>
			</div> -->
		</div>
	    <div id="main">
			<!-- <div class="half_w half_left">
				<div class="h_title">Visits statistics</div>
					<script src="js/highcharts_init.js"></script>
					<div id="container" style="min-width: 300px; height: 180px; margin: 0 auto"></div>
					<script src="js/highcharts.js"></script>
			</div>
			<div class="half_w half_right">
				<div class="h_title">Site statistics</div>
				<div class="stats">
					<div class="today">
						<h3>Today</h3>
						<p class="count">2 349</p>
						<p class="type">Visits</p>
						<p class="count">96</p>
						<p class="type">Comments</p>
						<p class="count">9</p>
						<p class="type">Articles</p>
					</div>
					<div class="week">
						<h3>Last week</h3>
						<p class="count">12 931</p>
						<p class="type">Visits</p>
						<p class="count">521</p>
						<p class="type">Comments</p>
						<p class="count">38</p>
						<p class="type">Articles</p>
					</div>
				</div>
			</div> 
			
			<div class="clear"></div> -->
			
			<!-- <div class="full_w">
				<div class="h_title">Paragraph, headers, lists, notify</div>
				<h1>Level 1 header</h1>
				<p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumyeirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diamvoluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takim</p>
				<h2>Level 2 header</h2>
				<p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumyeirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diamvoluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumyeirmod tempor i</p>
				<h3>Level 3 header</h3>
				<p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumyeirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diamvolupt</p>
				<h3>Unordered list</h3>
				<ul>
					<li>first list item, Lorem ipsum dolor sit amet, consete</li>
					<li>second list item, Lorem ipsum dolor sit amet, consete</li>
					<li>third list item, Lorem ipsum dolor sit amet, consete</li>
					<li>fourth list item, Lorem ipsum dolor sit amet, consete</li>
				</ul>
				<h3>Ordered list</h3>
				<ol>
					<li>first list item, Lorem ipsum dolor sit amet, consete</li>
					<li>second list item, Lorem ipsum dolor sit amet, consete</li>
					<li>third list item, Lorem ipsum dolor sit amet, consete</li>
					<li>fourth list item, Lorem ipsum dolor sit amet, consete</li>
				</ol>
                <div class="n_warning"><p>Attention notification. Lorem ipsum dolor sit amet, consetetur, sed diam nonumyeirmod tempor.</p></div>
				<div class="n_ok"><p>Success notification. Lorem ipsum dolor sit amet, consetetur, sed diam nonumyeirmod tempor.</p></div>
				<div class="n_error"><p>Error notification. Lorem ipsum dolor sit amet, consetetur, sed diam nonumyeirmod tempor.</p></div>		
			</div> -->
			
			<div class="full_w">
				<div class="h_title">Créer un projet</div>
                <form id="FrmProjet" runat="server">
                    
                    <div id="ProjetInfo">
                        <div id="lblColumn1">
                            <div class="info">
                                <asp:Label runat="server" Text="Code: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtCodeProjet" CssClass="txtColum1"/>
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Nom: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtNomProjet" CssClass="txtColum1"/>
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Chef de projet: " CssClass="lblColum1"/>
                                <asp:DropDownList runat="server" ID="txtChefProjet" CssClass="txtColum1" style="width:71%"/>
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Date création: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtDateCreationProjet" CssClass="txtColum1" Style="width: 125px" />                                                         
                            <asp:ScriptManager  ID="ScriptManager1" runat="server"> </asp:ScriptManager>                                                       
                               <cc1:CalendarExtender ID="txtDateCreation_CalendarExtender" runat="server" TargetControlID="txtDateCreationProjet" Format="yyyy/MM/dd" DefaultView="Days"  CssClass="calendrier"/> 
                                <asp:Label runat="server" Text="Date livraison: " CssClass="lblColum1" style="margin-left:-30px"/>
                                <asp:TextBox runat="server" ID="txtDateLivraisonProjet" CssClass="txtColum1" style="width:125px"/>
                                <cc1:CalendarExtender ID="txtDateLivraisonProjet_CalendarExtender" runat="server" TargetControlID="txtDateLivraisonProjet" Format="yyyy/MM/dd"/>
                            </div>
                            <div class="info">
                                <asp:Label runat="server" Text="Version du jeu: " CssClass="lblColum1"/>
                                <asp:TextBox runat="server" ID="txtVersionJeuProjet" CssClass="txtColum1"/>
                            </div>
                        </div>  
                        <div id="CasTestObj">
                            <asp:Label runat="server" Text="Objectif: " /><br />
                            <asp:TextBox runat="server" ID="rtxtObjectifProjet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div><br /><br />
                        <div id="CasTestDesc">
                            <asp:Label runat="server" Text="Description: "/><br />
                            <asp:TextBox runat="server" ID="rtxtDescriptionProjet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div>
                        <div id="CasTestDiv">
                            <asp:Label runat="server" Text="Divers: "/><br />
                            <asp:TextBox runat="server" ID="rtxtDiversProjet" TextMode="MultiLine" CssClass="richtextbox"/>
                        </div>
                    </div>
                    <table id="dataGridListeCasTest">
					    <thead>
						    <tr>
							    <th scope="col">Code</th>
							    <th scope="col">Nom</th>
							    <th scope="col" style="width: 85px;">Date livraison</th>
							    <th scope="col">Priorité</th>
							    <th scope="col">Difficulté</th>
							    <th scope="col" style="width: 65px;">Modification</th>
						    </tr>
					    </thead>						
					    <tbody>
						    <tr>
							    <td class="align-center">ASU</td>
							    <td>AssassinsCreedUnity</td>
							    <td class="align-center">2015-10-29</td>
							    <td class="align-center">Modérée</td>
							    <td class="align-center">Élevée</td>
							    <td class="align-center">
								    <a href="#" class="table-icon edit" title="Modifier"></a>
								    <a href="#" class="table-icon delete" title="Supprimer"></a>
							    </td>
						    </tr>
                            <tr>
							    <td class="align-center">CODAW</td>
							    <td>CallofDutyAdvancedWarfare</td>
							    <td class="align-center">2015-10-30</td>
							    <td class="align-center">Faible</td>
							    <td class="align-center">Modérée</td>
							    <td class="align-center">
								    <a href="#" class="table-icon edit" title="Modifier"></a>
								    <a href="#" class="table-icon delete" title="Supprimer"></a>
							    </td>
						    </tr>
                            <tr>
							    <td class="align-center">GHWT</td>
							    <td>GuitarHeroWorldTour</td>
							    <td class="align-center">2015-11-02</td>
							    <td class="align-center">Modérée</td>
							    <td class="align-center">Élevée</td>
							    <td class="align-center">
								    <a href="#" class="table-icon edit" title="Modifier"></a>
								    <a href="#" class="table-icon delete" title="Supprimer"></a>
							    </td>
						    </tr>
                            <tr>
							    <td class="align-center">GTA5</td>
							    <td>GrandTheftAuto5</td>
							    <td class="align-center">2015-11-03</td>
							    <td class="align-center">Faible</td>
							    <td class="align-center">Modérée</td>
							    <td class="align-center">
								    <a href="#" class="table-icon edit" title="Modifier"></a>
								    <a href="#" class="table-icon delete" title="Supprimer"></a>
							    </td>
						    </tr>
                            <tr>
							    <td class="align-center">LOL</td>
							    <td>LeagueOfLegends</td>
							    <td class="align-center">2015-11-04</td>
							    <td class="align-center">Faible</td>
							    <td class="align-center">Modérée</td>
							    <td class="align-center">
								    <a href="#" class="table-icon edit" title="Modifier"></a>
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
                        <asp:Button runat="server" ID="btnCopier" Text="Copier" CssClass="button"/>
                        <asp:Button runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="btnDroit button" />
                        <asp:Button runat="server" ID="btnAnnuler" Text="Annuler" CssClass="btnDroit button" />
                    </div>
                </form>
				<!-- <form action="" method="post">
					<div class="element">
						<label for="name">Page title <span class="red">(required)</span></label>
						<input id="name" name="name" class="text err" />
					</div>
					<div class="element">
						<label for="category">Category <span class="red">(required)</span></label>
						<select name="category" class="err">
							<option value="0">-- select category</option>
							<option value="1">Category 1</option>
							<option value="2">Category 4</option>
							<option value="3">Category 3</option>
						</select>
					</div>
					<div class="element">
						<label for="comments">Comments</label>
						<input type="radio" name="comments" value="on" checked="checked" /> Enabled <input type="radio" name="comments" value="off" /> Disabled
					</div>
					<div class="element">
						<label for="attach">Attachments</label>
						<input type="file" name="attach" />
					</div>
					<div class="element">
						<label for="content">Page content <span>(required)</span></label>
						<textarea name="content" class="textarea" rows="10"></textarea>
					</div>
					<div class="entry">
						<button type="submit">Preview</button> <button type="submit" class="add">Save page</button> <button class="cancel">Cancel</button>
					</div>
				</form> -->
			</div>
			
			<!-- <div class="full_w">
				<div class="h_title">Manage pages - table</div>
				<h2>Lorem ipsum dolor sit ame</h2>
				<p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumyeirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diamvolupt</p>
				
				<div class="entry">
					<div class="sep"></div>
				</div>
				<table>
					<thead>
						<tr>
							<th scope="col">ID</th>
							<th scope="col">Title</th>
							<th scope="col">Author</th>
							<th scope="col">Date</th>
							<th scope="col">Category</th>
							<th scope="col" style="width: 65px;">Modify</th>
						</tr>
					</thead>
						
					<tbody>
						<tr>
							<td class="align-center">2</td>
							<td>Home</td>
							<td>Paweł B.</td>
							<td>22-03-2012</td>
							<td>-</td>
							<td>
								<a href="#" class="table-icon edit" title="Edit"></a>
								<a href="#" class="table-icon archive" title="Archive"></a>
								<a href="#" class="table-icon delete" title="Delete"></a>
							</td>
						</tr>
						<tr>
							<td class="align-center">3</td>
							<td>Our offer</td>
							<td>Paweł B.</td>
							<td>22-03-2012</td>
							<td>-</td>
							<td>
								<a href="#" class="table-icon edit" title="Edit"></a>
								<a href="#" class="table-icon archive" title="Archive"></a>
								<a href="#" class="table-icon delete" title="Delete"></a>
							</td>
						</tr>
							
						<tr>
							<td class="align-center">5</td>
							<td>About</td>
							<td>Admin</td>
							<td>23-03-2012</td>
							<td>-</td>
							<td>
								<a href="#" class="table-icon edit" title="Edit"></a>
								<a href="#" class="table-icon archive" title="Archive"></a>
								<a href="#" class="table-icon delete" title="Delete"></a>
							</td>
						</tr>
							
						<tr>
							<td class="align-center">12</td>
							<td>Contact</td>
							<td>Admin</td>
							<td>25-03-2012</td>
							<td>-</td>
							<td>
								<a href="#" class="table-icon edit" title="Edit"></a>
								<a href="#" class="table-icon archive" title="Archive"></a>
								<a href="#" class="table-icon delete" title="Delete"></a>
							</td>
						</tr>						
						<tr>
							<td class="align-center">114</td>
							<td>Portfolio</td>
							<td>Paweł B.</td>
							<td>22-03-2012</td>
							<td>-</td>
							<td>
								<a href="#" class="table-icon edit" title="Edit"></a>
								<a href="#" class="table-icon archive" title="Archive"></a>
								<a href="#" class="table-icon delete" title="Delete"></a>
							</td>
						</tr>
							
						<tr>
							<td class="align-center">116</td>
							<td>Clients</td>
							<td>Admin</td>
							<td>23-03-2012</td>
							<td>-</td>
							<td>
								<a href="#" class="table-icon edit" title="Edit"></a>
								<a href="#" class="table-icon archive" title="Archive"></a>
								<a href="#" class="table-icon delete" title="Delete"></a>
							</td>
						</tr>
							
						<tr>
							<td class="align-center">131</td>
							<td>Customer reviews</td>
							<td>Admin</td>
							<td>25-03-2012</td>
							<td>-</td>
							<td>
								<a href="#" class="table-icon edit" title="Edit"></a>
								<a href="#" class="table-icon archive" title="Archive"></a>
								<a href="#" class="table-icon delete" title="Delete"></a>
							</td>
						</tr>
					</tbody>
				</table>
				<div class="entry">
					<div class="pagination">
						<span>« First</span>
						<span class="active">1</span>
						<a href="">2</a>
						<a href="">3</a>
						<a href="">4</a>
						<span>...</span>
						<a href="">23</a>
						<a href="">24</a>
						<a href="">Last »</a>
					</div>
					<div class="sep"></div>		
					<a class="button add" href="">Add new page</a> <a class="button" href="">Categories</a> 
				</div>
			</div> -->
		</div>  
		<!-- <div class="clear"></div> -->
	</div>

	<div id="footer">
		<div class="left">
			<p>Design: <a href="#">Équipe 1</a> <!--| Admin Panel: <a href=""></a> --></p>
		</div>
		<!-- <div class="right">
			<p><a href="">Example link 1</a> | <a href="">Example link 2</a></p>
		</div> -->
	</div>
</div>

</body>
</html>
