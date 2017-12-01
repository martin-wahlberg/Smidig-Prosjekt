function onLoadFunctions(){
  setSize();
}
function setSize(){
  var clientHeight = document.getElementById('gCS').clientHeight;
  var clientWidth = document.getElementById('gCS').clientWidth;
  document.getElementById("gameContainer").style.height = clientHeight;
  document.getElementById("gameContainer").style.width = clientWidth;
}

function gameWinTrue(){
  document.getElementById("conTainer").style.backgroundColor = "lime";
}
