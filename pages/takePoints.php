<?php
include('connection.php');
$theToken = $_GET['token'];
$theNumber = $_GET['num'];
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT emailUser FROM auth WHERE token = '$theToken'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        $theUser = $row["emailUser"];
    }
} else {
    echo "no";
}

if (isset($theUser)) {
  $conn = new mysqli($servername, $username, $password, $dbname);
  // Check connection
  if ($conn->connect_error) {
      die("Connection failed: " . $conn->connect_error);
  }

  $sql = "SELECT totalPoints FROM points WHERE pointMail = '$theUser'";
  $result = $conn->query($sql);

  if ($result->num_rows > 0) {
      // output data of each row
      while($row = $result->fetch_assoc()) {
          $thePoints = $row["totalPoints"];
      }
  } else {
      echo "no";
  }
}
if (isset($thePoints)) {
  $thePoints = intval($thePoints);
  $theNumber = intval($theNumber);
  $theNewPoints = $thePoints - $theNumber;
  if ($theNewPoints >= 0) {
    // Create connection
  $conn = new mysqli($servername, $username, $password, $dbname);
  // Check connection
  if ($conn->connect_error) {
      die("Connection failed: " . $conn->connect_error);
  }

  $sql = "UPDATE points SET totalPoints=$theNewPoints WHERE pointmail='$theUser' ";

  if ($conn->query($sql) === TRUE) {
      echo "Record updated successfully";
  } else {
      echo "Error updating record: " . $conn->error;
  }
  }
  else {
    echo "under";
  }
}
$conn->close();
?>
