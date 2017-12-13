<?php
include './connection.php';
$intention = $_GET['intention'];
$authToken = $_GET['authToken'];
$userEmail = $_GET['userEmail'];
$userFName = $_GET['userFName'];
$userLName = $_GET['userLName'];
if($intention == "login"){



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
           }
      }
  } else {
      $continuer = false;
  }


  $conn->close();
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

?>
