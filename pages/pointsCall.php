<?php
include('connection.php');
$points = 1;
$authToken = $_GET['authToken'];
$userEmail = $_GET['userEmail'];
$userExsists = false;
$points = (int)$points;
$userEmail = urldecode($userEmail);

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

  if($sqlEmail == $userEmail && $sqlAuth == $authToken){
    $conn = mysqli_connect($servername, $username, $password, $dbname);
    // Check connection
    if (!$conn) {
        die("Connection failed: " . mysqli_connect_error());
    }

    $sql = "SELECT pointMail, totalPoints FROM points";
    $result = mysqli_query($conn, $sql);

    if (mysqli_num_rows($result) > 0) {
        // output data of each row
        while($row = mysqli_fetch_assoc($result)) {
             $emailCheck = $row["pointMail"];
             if($emailCheck == $userEmail){
               $userExsists = true;
               $pointEmail = $row["pointMail"];
               $pointPoints = $row["totalPoints"];
             }
        }
    } else {
        $userExsists = false;
    }
      $conn->close();


  if($userExsists){
      echo "points=$pointPoints  ";
    $pointPoints = (int)$pointPoints;
    $pointPoints = $pointPoints + $points;
    echo "points=$pointPoints  ";
    $conn = new mysqli($servername, $username, $password, $dbname);
  // Check connection
  if ($conn->connect_error) {
      die("Connection failed: " . $conn->connect_error);
  }

  $sql = "UPDATE points SET totalPoints='$pointPoints' WHERE pointMail='$pointEmail'";

  if ($conn->query($sql) === TRUE) {
      echo "yes1";
  } else {
      echo "no1" . $conn->error;
  }

  $conn->close();

  }

  else{

    $conn = new mysqli($servername, $username, $password, $dbname);
    // Check connection
    if ($conn->connect_error) {
      die("Connection failed: " . $conn->connect_error);
    }
    $sql = "INSERT INTO points (pointMail, totalPoints)
    VALUES ('$userEmail', $points)";

    if ($conn->query($sql) === TRUE) {
      echo "yes2";
    } else {
      echo "no2" . $conn->error;
    }

    $conn->close();

  }
  }
?>
