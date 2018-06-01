var chosenCupon;
var affectedId;
var hider = [];
var theNoice;
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
    $( "#pynt1" ).attr('onclick', 'useCoupon("' + obj.tilbud[0].id + '",1)');
    $( "#btnC1" ).attr('onclick', 'useCoupon("' + obj.tilbud[0].id + '",1)');


    $( "#imgC2").css( "background-image", "url(" + obj.tilbud[1].imgurl + ")" );
    $( "#headC2").html(obj.tilbud[1].tilbud);
    $( "#disC2").html(obj.tilbud[1].fordel);
    $( "#pynt2" ).attr('onclick', 'useCoupon("' + obj.tilbud[1].id + '",2)');
    $( "#btnC2" ).attr('onclick', 'useCoupon("' + obj.tilbud[1].id + '",2)');


    $( "#imgC3").css( "background-image", "url(" + obj.tilbud[2].imgurl + ")" );
    $( "#headC3").html(obj.tilbud[2].tilbud);
    $( "#disC3").html(obj.tilbud[2].fordel);
    $( "#pynt3" ).attr('onclick', 'useCoupon("' + obj.tilbud[2].id + '",3)');
    $( "#btnC3" ).attr('onclick', 'useCoupon("' + obj.tilbud[2].id + '",3)');

    $( "#couponArea").css( "visibility", "visible" );
    hider.push("#couponArea");
    $( "#profileHeaderArea1").html("Få tilbudskupponger");

  }

function hideSomething(){
  console.log(hider.length - 1);
  var del = hider.length - 1;
  console.log(hider[del])
  $(hider[del]).css( "visibility", "hidden" );
  hider.pop();
  if(hider[hider.length - 1] == "#profileArea"){

    $( "#profileHeaderArea1").html("Hovedmeny");
  }
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
  $( "#pynt" + affectedId ).css( "background-image", "url(../img/revet.png)" );
  $( "#pynt" + affectedId ).attr('onclick', 'alert("Du har brukt denne!")');
  $( "#btnC" + affectedId ).attr('onclick', 'alert("Du har brukt denne!")');

}

function getMyC(){
  $( "#couponsArea").css( "visibility", "visible" );
  hider.push("#couponsArea");
  $( "#profileHeaderArea1").html("Mine tilbudskupponger");

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
  $("#tabellen").html("<tr><th>Produkt</th><th>Fordel</th></tr>")
  for (var i = 0; i < obj.mine.length - 1; i++) {
    $("#tabellen").append("<tr><td>"+obj.mine[i].tilbud+"</td><td>"+obj.mine[i].fordel+"</td></tr>");

  }
  console.log(jsonRx)
  hider.push("#couponsArea");

  }

  function showLottery(){
    $( "#lotteryArea").css( "visibility", "visible" );
    hider.push("#lotteryArea");
    $( "#profileHeaderArea1").html("Delta i lotteriet");
  }
  function makeSomeNoice(noice){
    var tall = $( "#theInput").val();
    tall = parseInt(tall);
    if(noice == "min"){
      tall = tall - 1;
    }
    if(noice == "plus"){
      tall = tall + 1;
    }
    if(tall < 0){
      tall = 0;
    }
    $( "#theInput").val(tall);
    noiceWasHere();

  }
  function noiceWasHere(){
    theNoice = $( "#theInput").val();
    theNoice = parseInt(theNoice);
    $( "#buttonPush").html("Få " + theNoice + " lodd!");
  }

  function getMeTickets(){
    var numberPhile = $( "#theInput").val();
    numberPhile = parseInt(numberPhile);
    takeLodPoints(numberPhile);
  }

  function takeLodPoints(minus){
    console.log("init")
    var url = "https://kolonial.martinwahlberg.no/pages/takePoints.php?token=" + token + "&num=" + minus;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
    //Kode
   var checkchack = this.responseText;
   console.log("resp")
   if(checkchack == "yes"){
    addLottery(minus);
    console.log("yes")
  }
    }
    };
    xhttp.open("GET", url, true);
    xhttp.send();
  }
  function addLottery(add){
  console.log("add")
  var url = "https://kolonial.martinwahlberg.no/pages/getTickets.php?mail=" + mail + "&many=" + add;
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function() {
  if (this.readyState == 4 && this.status == 200) {
  //Kode
 var checkchack = this.responseText;
 console.log("resp")
 if(checkchack == "Yes"){
   alert("Du er nå med i trekningen med " + add + " lodd!")
  console.log("yes")
}
  }
  };
  xhttp.open("GET", url, true);
  xhttp.send();
  }
