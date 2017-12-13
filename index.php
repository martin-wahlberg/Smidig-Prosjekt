<!DOCTYPE html>
<html>
<?php
include './pages/policy.php';

?>
<head>
  <title>Kolonial.no</title>
    <meta charset="utf-8">
    <link rel="stylesheet" href="./css/commonStyle.css">
    <link rel="stylesheet" href="./css/indexStyle.css">
    <link rel="shortcut icon" href="../favicon.ico">
    <script src="./js/commonScript.js"></script>
</head>
<body onload="onLoadFunctions()">
  <div class="container" id="conTainer">
  <div class="headerArea">
  <div class="topHeader">
  <div class="leftArea">
  <div class="logoArea" id="logoArea">
    <img src="./img/logo.png" id="logo" alt="Smiley face" width="176px" height="21px" style="position:absolute; top:35%;">
  </div>
  <div class="searchArea">
    <input id="search" type="text" placeholder="Søk i 6000 varer!" style="position:absolute;height:100%;width:100%; border:1px solid grey;">
  </div>
  </div>
  <div class="rightArea">
  <div class="buttonArea" id="varer">
  <img src="./img/icons/groceries.png" width="25px" height="27px" style="position:absolute; left:10%; top:30%;">
  <div style="position:absolute; right:0; top:35%;">Varer</div>
  </div>
  <div class="buttonArea" id="oppskrifter">
    <img src="./img/icons/cutlery.png" width="20px" height="25px" style="position:absolute; left:2%; top:30%;">
    <div style="position:absolute; right:0; top:35%;">Oppskrifter</div>
  </div>
  <div class="buttonArea" id="lagKonto">
    <div class="realLKBtn" style="color:white; text-align:center; line-height:35px;" onclick="gameWinTrue()">Lag konto</div>
  </div>
  <div class="buttonArea" id="loggInn">
  <div class="realLKBtn" style="color:#675f6b; text-align:center; line-height:35px; border:0px; background-color:white;">Lag konto</div></div>
  <div class="buttonArea" id="handlekurv" onclick="gameWinTrue()">
    <img src="./img/icons/cart.png" width="28px" height="24px" style="position:absolute; top:25%;">
  </div>
  <div class="buttonArea" id="expand"><div style="font-size:20px;line-height:60px;"><b><</b></div></div>
  </div>
</div>
<div class="bottomHeader"></div>
</div>
<div class="imageBox">
<div class="loginContainer" id="gCS">
  <p id="headerIn">VÆLKØMMIN!</p>
  <input type="text" placeholder="E-post" id="mailIn">
  <input type="password" placeholder="Passord" id="pwIn">
  <input type="button" value="Logg Inn" id="btnIn" onclick="loggInn()">
</div>
</div>
</div>
<script>
var usrName;
var usrPw;
var url;
var url2;
var userInfo=[];
function loggInn(){
  usrName = document.getElementById('mailIn').value;
  usrPw = document.getElementById('pwIn').value;

  usrName = encodeURIComponent(usrName);
  usrPw = encodeURIComponent(usrPw);
  url = "https://kolonial.martinwahlberg.no/pages/auth.php?mail=" + usrName + "&pw=" + usrPw;
  loadJson();
}

function loadJson() {
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function() {
  if (this.readyState == 4 && this.status == 200) {
  var jsonTx = this.responseText;
  parseJson(jsonTx);
  }
  };
  xhttp.open("GET", url, true);
  xhttp.send();
}

function parseJson(jsonRx) {
  var obj = JSON.parse(jsonRx);
  var auth = obj.auth;
  var id = obj.id;
  var firstName = obj.firstName;
  var lastName = obj.lastName;
  var mail = obj.mail;
  if(auth == "1"){
    userInfo.push(firstName);
    userInfo.push(lastName);
    userInfo.push(mail);
    userInfo.push(id);

    url2 = "https://kolonial.martinwahlberg.no/pages/policy.php?intention=login&userEmail=" + mail + "&userFName=" + firstName + "&userLName=" + lastName + "&authToken=" + id;
    logInHTTP();

  }
  else{
    window.alert("Ugyldig brukernavn/passord!")
  }
}

function loginSteps(){

  var userInfoString = JSON.stringify(userInfo);
  document.cookie = "userInfo=" + userInfoString;
 window.location.href = "https://kolonial.martinwahlberg.no/pages/spill.php";
}

function logInHTTP() {
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function() {
  if (this.readyState == 4 && this.status == 200) {
  var jsonTx = this.responseText;
  loginSteps();

  }
  };
  xhttp.open("GET", url2, true);
  xhttp.send();
}



</script>

</body>

</html>
