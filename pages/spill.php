<?php
include('policy.php');

?>
<html>
<head>
  <META HTTP-EQUIV="Pragma" CONTENT="no-cache">
   <META HTTP-EQUIV="Expires" CONTENT="-1">
   <script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>
  <script src="../js/spillScript.js"></script>
  <script src="../js/profileScript.js"></script>
  <script src="../js/commonScript.js"></script>
  <meta charset="utf-8">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
   <link rel="shortcut icon" href="../favicon.ico">
   <link rel="stylesheet" href="../GameBuildWeb/TemplateData/style.css">
   <script src="../GameBuildWeb/TemplateData/UnityProgress.js"></script>
   <script src="../GameBuildWeb/Build/UnityLoader.js"></script>
   <script>
     var gameInstance = UnityLoader.instantiate("gameContainer", "../GameBuildWeb/Build/GameBuildWeb.json", {onProgress: UnityProgress});
   </script>
    <link rel="stylesheet" href="../css/commonStyle.css">
    <link rel="stylesheet" href="../css/spillStyle.css">
    <link rel="stylesheet" href="../css/profilStyle.css">


  <title>Kolonial.no</title>
</head>
<body onload="onLoadFunctions()">
  <div class="container" id="conTainer">
  <div class="headerArea">
  <div class="topHeader">
  <div class="leftArea">
    <div class="logoArea" id="logoArea">
      <img src="../img/logo.png" id="logo" alt="Smiley face" width="100%" height="37%" style="position:absolute; top:35%;">
  </div>
  <div class="searchArea">
    <input type="text" placeholder="Søk i 6000 varer!" style="position:absolute;height:100%;width:100%;">
  </div>
  </div>
  <div class="rightArea">
  <div class="buttonArea" id="varer">
  <img src="../img/icons/groceries.png" width="25px" height="27px" style="position:absolute; left:10%; top:30%;">
  <div style="position:absolute; right:0; top:35%;">Varer</div>
  </div>
  <div class="buttonArea" id="oppskrifter">
    <img src="../img/icons/cutlery.png" width="20px" height="25px" style="position:absolute; left:2%; top:30%;">
    <div style="position:absolute; right:0; top:35%;">Oppskrifter</div>
  </div>
  <div class="buttonArea" id="lagKonto">
    <button class="realLKBtn" style="color:white; text-align:center; line-height:35px;" onclick="profileTogle()">Vis profil</button>
  </div>
  <div class="buttonArea" id="loggInn">
  <div class="realLKBtn" style="color:#675f6b; text-align:center; line-height:35px; border:0px; background-color:white;">Lag konto</div></div>
  <div class="buttonArea" id="handlekurv" onclick="gameWinTrue()">
    <img src="../img/icons/cart.png" width="28px" height="24px" style="position:absolute; top:25%;">
  </div>
  <div class="buttonArea" id="expand"><div style="font-size:20px;line-height:60px;"><b></b></div></div>
  </div>
</div>
<div class="bottomHeader">
  <div class="textArea" id="tA1"></div>
  <div class="textArea" id="tA2"></div>
</div>
</div>
<div class="gameContainerC" id="gCS">
  <div class="webgl-content">
        <div id="gameContainer" style="width: 0%; height:0%;"></div>
         </div>

         <div id="profileArea">
           <div id="profileHeaderArea">
             <div id="profileHeaderArea1">
             Hovedmeny
           </div>
             <div id="exitP" onclick="hideSomething()"></div>
           </div>
           <button class="profileBtn" id="pBtn1" onclick="getCoupons()">Bytt inn poeng i tilbudskupponger</button>
           <button class="profileBtn" id="pBtn2" onclick="showLottery()">Delta i hovedlotteri</button>
           <button class="profileBtn" id="pBtn3" onclick="getMyC()">Mine kupponger</button>
           <div id="couponArea">
               <div class="couponThing" id="cT1">
                 <div class="imageplace" id="imgC1"></div>
                 <div class="headerAreaCoupon" id="headC1"></div>
                 <div class="discountAreaCoupon" id="disC1"></div>
                 <div class="pyntDiscount" id="pynt1"></div>
                 <div class="dividerArea"></div>
                 <button class="buttonAreaCoupon" id="btnC1" >Løs inn(1p)</button>
               </div>
               <div class="couponThing" id="cT2">
                 <div class="imageplace" id="imgC2"></div>
                 <div class="headerAreaCoupon" id="headC2"></div>
                 <div class="discountAreaCoupon" id="disC2"></div>
                 <div class="pyntDiscount" id="pynt2"></div>
                 <div class="dividerArea"></div>
                 <button class="buttonAreaCoupon" id="btnC2">Løs inn(1p)</button>
               </div>
               <div class="couponThing" id="cT3">
                 <div class="imageplace" id="imgC3"></div>
                 <div class="headerAreaCoupon" id="headC3"></div>
                 <div class="discountAreaCoupon" id="disC3"></div>
                 <div class="pyntDiscount" id="pynt3"></div>
                 <div class="dividerArea"></div>
                 <button class="buttonAreaCoupon" id="btnC3">Løs inn(1p)</button>
               </div>
           </div>
         </div>

         <div id="couponsArea">
           <table id="tabellen">
</table>
         </div>
         <div id="lotteryArea">
           <div id="lotteryImage"></div>
           <div id="lotteryMachine">
             <div id="overskriftoverskriftLodd">Lever innen søndag kl.18 for å delta</div>
             <div id="overskriftLodd">Vinn gavekort 1000kr!<br>Få lodd for poeng.</div>
             <div id="underskriftLodd">Du får mail på søndag om du vinner.</div>
             <div id="inputATxt">Antall lodd:</div>
             <div id="numInPlace">
             <button id="minusIBtn" onclick="makeSomeNoice('min')"></button>
             <input type="number" id="theInput" value="0" min="1" onchange="noiceWasHere()">
             <button id="plusIBtn" onclick="makeSomeNoice('plus')"></button>
             </div>
             <button id="buttonPush" onclick="getMeTickets()">Velg antall lodd</button>
           </div>

</div>
</div>
</div>




<script>

</script>
<audio style="visibility:hidden;" id="paperSound">
  <source src="../paper.mp3" type="audio/mpeg">
  Your browser does not support the audio element.
</audio>
</body>
</html>
