<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TexcelWeb.login" %>

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
					<label for="login">Username:</label>
                    <input id="txtNomUtilisateur" name="txtNomUtilisateur" class="text" />
					<label for="pass">Password:</label>
					<input id="txtMotPasse" name="txtMotPasse" type="password" class="text" />
					<div class="sep"></div>
                    <asp:Button ID="btnConnexion" Text="Connexion" runat="server"></asp:Button>
				</form>
			</div>
		</div>
	</div>
</div>
</body>
</html>

