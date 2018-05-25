var userInfo = [];
var firstName;
var lastName;
var mail;
var url;
var token;
var points;
mail = encodeURIComponent(mail);
function onLoadFunctions(){
  setGameSize();
  setBottomHeaderSizes();
  restoreArray();
  callPoints();
}
function setGameSize(){
  var clientHeight = document.getElementById('gCS').clientHeight;
  var clientWidth = document.getElementById('gCS').clientWidth;
  document.getElementById("gameContainer").style.height = clientHeight;
  document.getElementById("gameContainer").style.width = clientWidth;
}
function gameWinTrue(points){
  window.alert(points);
  document.getElementById("conTainer").style.backgroundColor = "lime";
  url = "https://kolonial.martinwahlberg.no/pages/pointsCall.php?points=" + points + "&authToken=" + token + "&userEmail=" + mail;
  sendPoints();
  callPoints();
}


function setBottomHeaderSizes(){
  var clientHeight = document.getElementById('tA1').clientHeight;
  document.getElementById("tA1").style.lineHeight = clientHeight + "px";
  var clientHeight = document.getElementById('tA2').clientHeight;
  document.getElementById("tA2").style.lineHeight = clientHeight + "px";
}
function restoreArray(){
  var jsonUserInfo = getCook('userInfo');
  userInfo = JSON.parse(jsonUserInfo);
  firstName = userInfo[0];
  lastName = userInfo[1];
  mail = userInfo[2];
  token = userInfo[3];
  document.getElementById("tA1").innerHTML = "Hei, " + firstName + " " + lastName + "!";
}
function callPoints(){
  var url = "https://kolonial.martinwahlberg.no/pages/getPoints.php?mail=" + mail;
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function() {
  if (this.readyState == 4 && this.status == 200) {
  var jsonTx = this.responseText;
  document.getElementById("tA2").innerHTML = "Du har " + jsonTx + " poeng!";
  }
  };
  xhttp.open("GET", url, true);
  xhttp.send();
}
function getCook(cookiename) {
	// Get name followed by anything except a semicolon
	let cookiestring = RegExp("" + cookiename + "[^;]+").exec(document.cookie);
	// Return everything after the equal sign, or an empty string if the cookie name not found
	return decodeURIComponent(!!cookiestring ? cookiestring.toString().replace(/^[^=]+./, "") : "");
}

function sendPoints(){
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function() {
  if (this.readyState == 4 && this.status == 200) {
  var jsonTx = this.responseText;
//Callback her
  }
  };
  xhttp.open("GET", url, true);
  xhttp.send();
}
