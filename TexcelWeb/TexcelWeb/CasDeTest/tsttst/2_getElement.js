function init()
{	
	info = document.getElementById("zoneinfo");
}

function demo_getElementById()
{
	var x = document.getElementById("p12");
	alert(x.innerHTML);
}
		
function demo_getElementsByName()
{
	var collection = document.getElementsByName("unpar");
	for (var i = 0;i < collection.length; i++)
	{
		alert("Contenu de l'élément de nom unpar numéro " + i + " :\n" + collection[i].innerHTML); 
	}
}

function demo_getElementsByClassName()
{
	var collection = document.getElementsByClassName("maclasse");
	for (var i = 0; i < collection.length; i++)
	{
		alert("Contenu de l'élément avec la classe " + i + " :\n" + collection[i].innerHTML); 
	}
}


function demo_getElementsByTagName()
{
	var collection = document.getElementsByTagName("h2");
	for (var i = 0; i < collection.length; i++)
	{
		alert("Contenu de l'élément balisé h2 numéro " + i + " :\n" + collection[i].innerHTML); 
	}
}

function information(message)
{
	info.innerHTML = message;
}

function choix_demo()
{
	var demo = document.getElementById("select1").value;

	switch (demo)
	{
		case "id" : 		information("Démonstration de la méthode <code>getElementById<" + "/code>");
							demo_getElementById();
							break;
		case "name"	: 		information("Démonstration de la méthode <code>getElementsByName<" + "/code>");
							demo_getElementsByName();
							break;
		case "classname" :	information("Démonstration de la méthode <code>getElementsByClassName<" + "/code>");
							demo_getElementsByClassName();
							break;
		case "tagname": 	information("Démonstration de la méthode <code>getElementsByTagName<" + "/code>");
							demo_getElementsByTagName();
							break;
		default : 			alert("Erreur dans l'appel");break;
	}
}