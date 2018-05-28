var chosenCupon;
var affectedId;
var hider = [];
function profileTogle(){
  if( $('#profileArea').css('visibility') != "visible" )  {
    $( "#profileArea").css( "visibility", "visible" );
    hider.push("#profileArea");
}

}




function getCoupons(){
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
    $( "#imgC1").css( "background-image", "url(" + obj.tilbud[0].imgurl + ")" );
    $( "#headC1").html(obj.tilbud[0].tilbud);
    $( "#disC1").html(obj.tilbud[0].fordel);
    $( "#btnC1" ).attr('onclick', 'useCoupon("' + obj.tilbud[0].id + '",1)');


    $( "#imgC2").css( "background-image", "url(" + obj.tilbud[1].imgurl + ")" );
    $( "#headC2").html(obj.tilbud[1].tilbud);
    $( "#disC2").html(obj.tilbud[1].fordel);
    $( "#btnC2" ).attr('onclick', 'useCoupon("' + obj.tilbud[1].id + '",2)');


    $( "#imgC3").css( "background-image", "url(" + obj.tilbud[2].imgurl + ")" );
    $( "#headC3").html(obj.tilbud[2].tilbud);
    $( "#disC3").html(obj.tilbud[2].fordel);
    $( "#btnC3" ).attr('onclick', 'useCoupon("' + obj.tilbud[2].id + '",3)');

    $( "#couponArea").css( "visibility", "visible" );
   hider.push("#couponArea");

  }

function hideSomething(){
  console.log(hider.length - 1);
  var del = hider.length - 1;
  console.log(hider[del])
  $(hider[del]).css( "visibility", "hidden" );
  hider.pop();
}


function useCoupon(idHer, aff){
  affectedId = aff;
  chosenCupon = idHer;
  takePoints(1);

}

function takePoints(minus){
  var url = "https://kolonial.martinwahlberg.no/pages/takePoints.php?token=" + token + "&num=" + minus;
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function() {
  if (this.readyState == 4 && this.status == 200) {
  //Kode
 var checkchack = this.responseText;
 if(checkchack == "yes"){
  sendCoupon(chosenCupon);
}
  }
  };
  xhttp.open("GET", url, true);
  xhttp.send();
}

function sendCoupon(kup){
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
function couponSendt(idslutt){
  $( "#btnC" + affectedId ).css( "background-color", "#90EE90" );
  $( "#btnC" + affectedId ).css( "color", "black" );
  $( "#btnC" + affectedId ).html("Aktivert Gyldig 24t");
}

function getMyC(){
  $( "#couponsArea").css( "visibility", "visible" );
  hider.push("#couponsArea");

  var url = "https://kolonial.martinwahlberg.no/pages/myCoup.php?mail=" + mail;
  console.log(url)
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
  var obj = JSON.parse(jsonRx);
  var tr = $("<tr>");
  var td = $("<td>");
  for (var i = 0; i < obj.mine.length - 1; i++) {
    $("#tabellen").append("<tr><td>"+obj.mine[i].tilbud+"</td><td>"+obj.mine[i].fordel+"</td><td>"+obj.mine[i].id+"</td></tr>");

  }

  console.log(jsonRx)
  obj.mine[0].tilbud
  hider.push("#couponsArea");

  }
