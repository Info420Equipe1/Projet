﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recherche.aspx.cs" Inherits="TexcelWeb.recherche" %>
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
     
          <div>
            <asp:ListView ID="lvRecherche" runat="server" DataKeyNames="Id" EnableModelValidation="True" OnLoad="lvRecherche_Load"> 

            <ItemTemplate>
                <tr>
                    <td class="firstcol">
                        <input id='Checkbox<%# Eval("Id") %>' type="checkbox" />
                    </td>

                     <td class="firstcol">
                        <input id="col2"  type="text"/>
                    </td>

                    <td class="firstcol">
                        <input id="col3"  type="text"/>
                    </td>

                    <td class="firstcol">
                        <input id="col4"  type="text"/>
                    </td>


                </tr>
            </ItemTemplate>

            <LayoutTemplate>
               <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th width="50" scope="col" class="firstcol"> </th>
                    </tr>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>

                <asp:Button ID="btnCharger" runat="server" Text="Charger" Height="26px" />

            </LayoutTemplate>
        </asp:ListView>

          </div>              





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