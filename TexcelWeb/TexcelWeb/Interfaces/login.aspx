<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TexcelWeb.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>Texcel - Connexion</title>
<link rel="stylesheet" type="text/css" href="../css/style.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../css/login.css" media="screen" />
<link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
        
</head>
<body>
<div class="wrap">
	<div id="content">
		<div id="main">
			<div class="full_w">
                <img id="logo" src="../img/logo_texcel.png" />
				<form runat="server" action="#" method="post">
					<label for="login">Nom d'utilisateur:</label>
                    <input id="txtNomUtilisateur" name="txtNomUtilisateur" class="text" runat="server"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nom d'utilisateur manquant*" ForeColor="Red" ControlToValidate="txtNomUtilisateur"></asp:RequiredFieldValidator>
					<label for="pass">Mot de passe:</label>
					<input id="txtMotPasse" name="txtMotPasse" type="password" onpaste="return false;" oncopy="return false" oncut="return false" class="text" runat="server"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Mot de passe manquant*" ForeColor="Red" ControlToValidate="txtMotPasse"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnConnexion" Text="Connexion" CssClass="btnDroit button" runat="server"></asp:Button>
				</form>
			</div>
		</div>
	</div>
</div>
</body>
</html>

