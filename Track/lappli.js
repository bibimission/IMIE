
$(".lang-fr").show();
$(".lang-en").hide();

var jsonFR =[
	{name : "Google",image :"google.png",color : "green",iconColor : "#FFFFFF",value : 0.05,content : "<div>Selon les chiffres de Google</div>",actual:0, label:"Nombre de recherches effectuées ",tip:"<ul><li>Mettez vos sites préférés en favoris.</li><li>Apprenez à faire des recherches plus efficaces.</li><li>Priviliégiez les dictionaires et encyclopédies papier si possible.</li></ul>"},
	{name : "Youtube",image :"youtube.png",color : "red",iconColor : "#FF0000",value : 8.7,content : "<div>Selon les chiffres de Google et estimation</div>",actual:0, label:"Nombre de minutes passées",tip:"<ul><li>Pour la musique, privilégiez les services d'écoute de musique.</li><li>Désactivez la lecture automatique.</li><li>Boycottez les vidéos de plus d'une heure, qui sont des gouffres à éléctricité.</li></ul>"},
	{name : "Netflix",image :"netflix.png",color : "black",iconColor : "#000000",value : 20.35,content : "<div>Selon les chiffres de Netflix, EDF et estimations</div>",actual:0, label:"Nombre de minutes passées",tip:"<ul><li>Désactivez la lecture automatique.</li><li>Privilegiez les supports physiques (disque dur, DVD)</li><li>Limitez l'utilisation de la HD 3 fois plus polluante !</li></ul>"},
	{name : "Cloud",image :"cloud.png",color : "blue",iconColor : "#FFFFFF",value : 8.6,content : "<div>Selon les chiffres de Microsoft</div>",actual:0, label:"Quantité de fichiers stockés (Mo)",tip:"<ul><li>Utilisez les services de cloud éphémère pour les partages à durée déterminée.</li><li>Limiter les échanges de petits fichiers.</li></ul>"},
	{name : "Telephone",image :"phone.png",color : "yellow",iconColor : "#FFFFFF",value : 57,content : "<div>Selon les chiffres de l'ADEME</div>",actual:0, label:"Minutes d'appel",tip:"<ul><li>Bloquer les appels indésirables.</li><li>Envoyer des SMS.</li></ul>"},
	{name : "Mail",image :"mail.png",color : "brown",iconColor : "#528491",value : 0.6,content : "<div>Le poids moyen d'un mail est de 500 Ko</div>",actual:0, label:"Nombre de mails envoyés",tip:"<ul><li>Vider les boîtes mail. 30 mails stockés consomment autant qu'une ampoule !</li><li>Evitez les mails groupés à des utilisateurs pas concernés.</li><li>Instaurez des filtres anti-spam.</li></ul>"},
	{name : "Jeux videos",image :"steam.png",color : "grey",iconColor : "#FFFFFF",value : 1.26,content : "<div>Basé sur la consommation électrique de la console Xbox One.</div>",actual:0, label:"Nombre minutes passées à jouer",tip:"<ul><li>Ne pas laisser un jeu allumé en arrière-plan.</li></ul>"},
	{name : "Streaming",image :"twitch.png",color : "purple",iconColor : "#FFFFFF",value : 35,content : "<div>Estimé en fonction des chiffres de Netflix</div>",actual:0, label:"Nombre de minutes passées",tip:"<ul><li>Baissez la qualité de la vidéo.</li><li>Désactivez les lectures automatiques.</li></ul>"},
	{name : "Deezer",image :"deezer.png",color : "orange",iconColor : "#000000",value : 1.17,content : "<div>Chiffre utilisé, Deezer en version gratuite</div>",actual:0, label:"Nombre de minutes d'écoute",tip:"<ul><li>Stockez vos musiques sur un disque externe.</li><li>Ecoutez la radio.</li></ul>"},
	{name : "Instagram",image :"instagram.png",color : "pink",iconColor : "#000000",value : 0.12,content : "<div>Le poids moyen d'une photo est de 100Ko</div>",actual:0, label:"Nombre de photos partagées",tip:"<ul><li>Consultez le compte <a href='https://www.instagram.com/insta_repeat/?hl=fr'>insta_repeat</a> et demandez-vous si votre photo vaut bien le coup d'être partagée.</li><li>Privilégiez les réseaux de partage éphémères.</li></ul>"}
	];

var formBlock = $("#formBlock");
var formValidBlock = $("#formValidBlock");
var statBlock = $("#statBlock");
var tipsBlock = $("#tipsBlock");

statBlock.hide();
tipsBlock.hide();

document.getElementById("formValidButton").onclick=function(){
	formBlock.fadeOut();
	formValidBlock.fadeOut();
	statBlock.fadeIn();
	tipsBlock.fadeIn();
};

document.getElementById("cancelButton").onclick=function(){
	formBlock.fadeIn();
	formValidBlock.fadeIn();
	statBlock.fadeOut();
	tipsBlock.fadeOut();
};

refresh();



function fillContent(){
	var appList = document.getElementById("appList");
	appList.innerHTML="";
	var data = jsonFR;
	var tipList = document.getElementById("tipList");
	tipList.innerHTML="";
	data.forEach(function(e){
		// Screen
		var template = document.querySelector("#appIconTemplate");
		var clone = document.importNode(template.content,true);
		
		clone.getElementById("iconImage").src="images/"+e.image;
		clone.getElementById("innerIconDiv").style.backgroundColor=e.iconColor;
		clone.getElementById("formActual").innerHTML=e.actual;
		clone.getElementById("iconDiv").onclick = function(){
			document.getElementById("modalBody").innerHTML=e.content;
			document.getElementById("modalTitle").innerHTML=e.name;
			document.getElementById("input").value = e.actual;
			document.getElementById("label").innerHTML = e.label;
			document.getElementById("okButton").onclick=function(){
					jsonFR.filter(word => word.name == e.name)[0].actual=document.getElementById("input").value; 
					refresh();
				};
		};
		appList.appendChild(clone);
		
		// Tip List
		var tipTemplate =  document.querySelector("#tipTemplate");
		var tipClone = document.importNode(tipTemplate.content,true);
		tipClone.getElementById("iconImage").src="images/"+e.image;
		tipClone.getElementById("tiptext").innerHTML=e.tip;
		tipList.appendChild(tipClone);
	});
}

function refresh(){
	fillContent();
	buildGauge(jsonFR);
	setText(calculateCarbon(jsonFR));
}

function buildGauge(infos){
	
	var chartData={labels:[],datasets:[{label:"Dataset",backgroundColor:[],borderColor:'#fff',data:[]}]};
	infos.forEach(function(e){
		if(e.actual!=0){
			chartData.labels.push(e.name);
			chartData.datasets[0].backgroundColor.push(e.color);
			chartData.datasets[0].data.push(e.actual*e.value);
		}
	});
	
	var ctx = document.getElementById('myChart').getContext('2d');
    var chart = new Chart(ctx, {
        // The type of chart we want to create
        type: 'doughnut',

        // The data for our dataset
        data: chartData,

        // Configuration options go here
        options: {
            circumference: 1 * Math.PI,
            rotation: 1 * Math.PI,
            cutoutPercentage: 90
        }
    });
}

function calculateCarbon(infos){
	var total = 0;
	infos.forEach(function(e){
		total+=e.value*e.actual;
	});
	return total;
}

function setText(carbonValue){
	document.getElementById("total").innerHTML = (carbonValue).toFixed(3) + " g de CO2";
	document.getElementById("carValue").innerHTML = (carbonValue/220).toFixed(3);
	document.getElementById("phoneValue").innerHTML = (carbonValue/17.65).toFixed(0);
	document.getElementById("lightValue").innerHTML = (carbonValue/5.41).toFixed(0);
}