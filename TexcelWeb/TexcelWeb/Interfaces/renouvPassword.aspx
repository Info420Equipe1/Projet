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
			<div class="full_w">
				<form runat="server" action="#" method="post">
					<label for="login">Mot de passe:</label>
                    <asp:TextBox ID="txtMotPasse" runat="server" Width="294px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Champ vide" ForeColor="Red" ControlToValidate="txtMotPasse"></asp:RequiredFieldValidator>
					<label for="pass">Ressaisir mot de passe:</label>
                    <asp:TextBox ID="txtMotPasse2" runat="server" Width="294px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Camp vide" ForeColor="Red" ControlToValidate="txtMotPasse2"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Le mot de passe n'est pas identique" ControlToValidate="txtMotPasse" ControlToCompare="txtMotPasse2" ForeColor="Red"></asp:CompareValidator>
					<div class="sep"></div>
                    <asp:Button ID="btnEnregistrer" Text="Enregistrer" runat="server" OnClick="btnEnregistrer_Click"></asp:Button>
				</form>
			</div>
		</div>
	</div>
</div>
</body>
</html>


