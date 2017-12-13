<?php
include('connection.php');
$intention = $_GET['intention'];
$authToken = $_GET['authToken'];
$userEmail = $_GET['userEmail'];
$userFName = $_GET['userFName'];
$userLName = $_GET['userLName'];
$cookie_name = "userInfo";

if(!isset($_COOKIE[$cookie_name])) {

} else {
  $json = $_COOKIE[$cookie_name];
  $obj = json_decode($json);
  $cookieToken = $obj[3];
  $cookieEmail = $obj[2];
  $userEmail = $obj[2];
}



$conn = mysqli_connect($servername, $username, $password, $dbname);
// Check connection
if (!$conn) {
    die("Connection failed: " . mysqli_connect_error());
}

$sql = "SELECT emailUser, token FROM auth";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
    // output data of each row
    while($row = mysqli_fetch_assoc($result)) {
         $emailCheck = $row["emailUser"];
         if($emailCheck == $userEmail){
           $continuer = true;
           $sqlEmail = $row["emailUser"];
           $sqlAuth = $row["token"];
         }
    }
} else {
    $continuer = false;
}
  $conn->close();

if($intention == "login"){

if($continuer == true){
  $conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "UPDATE auth SET token='$authToken' WHERE emailUser='$userEmail'";

if ($conn->query($sql) === TRUE) {
    echo "yes";
} else {
    echo "no" . $conn->error;
}

$conn->close();
}
else{

  $conn = new mysqli($servername, $username, $password, $dbname);
  // Check connection
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  $sql = "INSERT INTO user (userEmail, userFName, userLName)
  VALUES ('$userEmail', '$userFName', '$userLName')";

  if ($conn->query($sql) === TRUE) {
    echo "yes";
  } else {
    echo "no" . $conn->error;
  }
  $sql = "INSERT INTO auth (token, emailUser)
  VALUES ('$authToken', '$userEmail')";

  if ($conn->query($sql) === TRUE) {
    echo "yes";
  } else {
    echo "no" . $conn->error;
  }

  $conn->close();

}
}
else{
  $sidenavn = basename($_SERVER['PHP_SELF']);
  if($cookieToken == $sqlAuth || $cookieEmail == $sqlEmail){
    if($sidenavn == "index.php"){
    echo '<script>window.location.href = "https://kolonial.martinwahlberg.no/pages/spill.php";</script>';
  }
}
else{
  echo '<script>window.location.href = "https://kolonial.martinwahlberg.no";</script>';

}
}

?>
