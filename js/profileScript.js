var chosenCupon;
var affectedId;
var hider = [];
var theNoice;

function profileTogle() {
	if ($('#profileArea').css('visibility') != "visible") {
		$("#profileArea").css("visibility", "visible");
		hider.push("#profileArea");
	}
}

function getCoupons() {
	var url = "https://kolonial.martinwahlberg.no/pages/getCoupons.php?mail=" + mail;
	console.log(url)
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			//Kode
			var jsonTx = this.responseText;
			makeCoupons(jsonTx);
		}
	};
	xhttp.open("GET", url, true);
	xhttp.send();
}

function makeCoupons(jsonRx) {
	console.log(jsonRx)
	var obj = JSON.parse(jsonRx);
	for (var i = 1; i < 4; i++) {
		var som = i - 1;
		$("#imgC" + i).css("background-image", "url(" + obj.tilbud[som].imgurl + ")");
		$("#headC" + i).html(obj.tilbud[som].tilbud);
		$("#disC" + i).html(obj.tilbud[som].fordel);
		$("#pynt" + i).attr('onclick', 'useCoupon("' + obj.tilbud[som].id + '",' + i + ')');
		$("#btnC" + i).attr('onclick', 'useCoupon("' + obj.tilbud[som].id + '",' + i + ')');
		$("#btnC" + i).html("Få kupong(1p)");
		$("#pynt" + i).css("background-image", "url(../img/hel.png)");
	}
	$("#couponArea").css("visibility", "visible");
	hider.push("#couponArea");
	$("#profileHeaderArea1").html("Få tilbudskupponger");
}

function hideSomething() {
	console.log(hider.length - 1);
	var del = hider.length - 1;
	console.log(hider[del])
	$(hider[del]).css("visibility", "hidden");
	hider.pop();
	if (hider[hider.length - 1] == "#profileArea") {
		$("#profileHeaderArea1").html("Hovedmeny");
	}
}

function useCoupon(idHer, aff) {
	if(idHer != "ugyldig"){
	affectedId = aff;
	chosenCupon = idHer;
	takePoints(1);
}
}

function takePoints(minus) {
	var url = "https://kolonial.martinwahlberg.no/pages/takePoints.php?token=" + token + "&num=" + minus;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			//Kode
			var checkchack = this.responseText;
			if (checkchack == "yes") {
				sendCoupon(chosenCupon);
			}
		}
	};
	xhttp.open("GET", url, true);
	xhttp.send();
}

function sendCoupon(kup) {
	var url = "https://kolonial.martinwahlberg.no/pages/userCoupons.php?mail=" + mail + "&kup=" + kup;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			//Kode
			couponSendt(kup);
		}
	};
	xhttp.open("GET", url, true);
	xhttp.send();
}

function couponSendt(idslutt) {
	$("#btnC" + affectedId).html("Aktivert Gyldig 24t");
	$("#pynt" + affectedId).css("background-image", "url(../img/revet.png)");
	$("#pynt" + affectedId).attr('onclick', 'alert("Du har brukt denne!")');
	$("#btnC" + affectedId).attr('onclick', 'alert("Du har brukt denne!")');
	$('#paperSound')[0].play();
	callPoints();
}

function getMyC() {
	$("#couponsArea").css("visibility", "visible");
	hider.push("#couponsArea");
	$("#profileHeaderArea1").html("Mine tilbudskupponger");
	var url = "https://kolonial.martinwahlberg.no/pages/myCoup.php?mail=" + mail;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			//Kode
			var jsonTx = this.responseText;
			showCoupons(jsonTx);
		}
	};
	xhttp.open("GET", url, true);
	xhttp.send();
}

function showCoupons(jsonRx) {
	 try {
	var obj = JSON.parse(jsonRx);
}
catch (e) {
	$("#tabellen").html('<h1 style="text-align:center; lineHeight:10vw;">Ingen aktive kuponger</h1>')
	return;
}
	var tr = $("<tr>");
	var td = $("<td>");
	$("#tabellen").html("<tr><th>Produkt</th><th>Fordel</th></tr>")
	for (var i = 0; i < obj.mine.length - 1; i++) {
		$("#tabellen").append("<tr><td>" + obj.mine[i].tilbud + "</td><td>" + obj.mine[i].fordel + "</td></tr>");
	}
	console.log(jsonRx)
	hider.push("#couponsArea");
}

function showLottery() {
	$("#lotteryArea").css("visibility", "visible");
	hider.push("#lotteryArea");
	$("#profileHeaderArea1").html("Delta i lotteriet");
}

function makeSomeNoice(noice) {
	var tall = $("#theInput").val();
	tall = parseInt(tall);
	if (noice == "min") {
		tall = tall - 1;
	}
	if (noice == "plus") {
		tall = tall + 1;
	}
	if (tall < 0) {
		tall = 0;
	}
	$("#theInput").val(tall);
	noiceWasHere();
}

function noiceWasHere() {
	theNoice = $("#theInput").val();
	theNoice = parseInt(theNoice);
	$("#buttonPush").html("Få " + theNoice + " lodd!");
	callPoints();
}

function getMeTickets() {
	var numberPhile = $("#theInput").val();
	numberPhile = parseInt(numberPhile);
	takeLodPoints(numberPhile);
}

function takeLodPoints(minus) {
	console.log("init")
	var url = "https://kolonial.martinwahlberg.no/pages/takePoints.php?token=" + token + "&num=" + minus;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			//Kode
			var checkchack = this.responseText;
			console.log("resp")
			if (checkchack == "yes") {
				addLottery(minus);
				console.log("yes")
			}
		}
	};
	xhttp.open("GET", url, true);
	xhttp.send();
}

function addLottery(add) {
	console.log("add")
	var url = "https://kolonial.martinwahlberg.no/pages/getTickets.php?mail=" + mail + "&many=" + add;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			//Kode
			var checkchack = this.responseText;
			console.log("resp")
			if (checkchack == "Yes") {
				alert("Du er nå med i trekningen med " + add + " lodd!")
				console.log("yes")
			}
		}
	};
	xhttp.open("GET", url, true);
	xhttp.send();
}
