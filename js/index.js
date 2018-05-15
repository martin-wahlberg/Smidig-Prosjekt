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
  var points = obj.points;
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
