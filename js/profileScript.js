var chosenCupon
function profileTogle(){
  $( "#profileArea" ).fadeToggle();
}

function useCoupon(idHer){
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
  $( "#" + idslutt ).css( "background-color", "#90EE90" );
  $( "#" + idslutt ).css( "color", "black" );
  $( "#" + idslutt ).html("Aktivert Gyldig 24t");
}
