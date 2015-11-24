<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="renouvPassword.aspx.cs" Inherits="TexcelWeb.Interfaces.renouvPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>Texcel - Connexion</title>
<link rel="stylesheet" type="text/css" href="../css/login.css" media="screen" />
</head>
<body>
<div class="wrap">
	<div id="content">
		<div id="main">
            <div>
                <p style="font-size : 12px; color: #575757; font-weight:bold">Vous avez été redirigé vers cette page car le mot de passe de votre compte utilisateur est expiré.</p><br />
                <p style="font-size : 12px; color: #575757; font-weight:bold">Pour des raisons de sécurité, veuillez inscrire un nouveau mot de passe dans l'espace réservé à cet effet.</p><br />
            </div>
			<div class="full_w" style="height:180px">
				<form runat="server" action="#" method="post">
					<label for="login">Mot de passe:</label>
                    <asp:TextBox ID="txtMotPasse" onpaste="return false;" oncopy="return false" oncut="return false" runat="server" Width="294px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Champ vide" ForeColor="Red" ControlToValidate="txtMotPasse"></asp:RequiredFieldValidator>
					<label for="pass">Ressaisir mot de passe:</label>
                    <asp:TextBox ID="txtMotPasse2" onpaste="return false;" oncopy="return false" oncut="return false" runat="server" Width="294px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Champ vide" ForeColor="Red" ControlToValidate="txtMotPasse2"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Le mot de passe n'est pas identique" ControlToValidate="txtMotPasse2" ControlToCompare="txtMotPasse" ForeColor="Red"></asp:CompareValidator>
					<div class="sep"></div>
                    <asp:Button ID="btnEnregistrer" Text="Enregistrer" runat="server" OnClick="btnEnregistrer_Click" CssClass="btnDroit button add"></asp:Button>
				</form>
			</div>
		</div>
	</div>
</div>
</body>
</html>


