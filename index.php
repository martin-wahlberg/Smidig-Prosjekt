<!DOCTYPE html>
<html>
<?php

?>
<head>
  <title>Kolonial.no</title>
    <meta charset="utf-8">
    <link rel="stylesheet" href="./css/commonStyle.css">
    <link rel="stylesheet" href="./css/indexStyle.css">
    <link rel="shortcut icon" href="../favicon.ico">
    <script src="./js/commonScript.js"></script>
    <script src="../js/index.js"></script>
</head>
<body onload="onLoadFunctions()">
  <div class="container" id="conTainer">
  <div class="headerArea">
  <div class="topHeader">
  <div class="leftArea">
  <div class="logoArea" id="logoArea">
    <img src="./img/logo.png" id="logo" alt="Smiley face" width="176px" height="21px" style="position:absolute; top:35%;">
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
    <a target="_blank" href="https://kolonial.no/bruker/registrer/"><div class="realLKBtn" style="color:white; text-align:center; line-height:35px;" onclick="gameWinTrue()">Lag konto</div></a>
  </div>
  </div>
</div>
<div class="bottomHeader"></div>
</div>
<div class="imageBox">
<div class="loginContainer" id="gCS">
  <p id="headerIn">VELKOMMEN!</p>
  <input type="text" placeholder="E-post" id="mailIn">
  <input type="password" placeholder="Passord" id="pwIn">
  <input type="button" value="Logg Inn" id="btnIn" onclick="loggInn()">
</div>
</div>
</div>
<script>


</script>

</body>

</html>
