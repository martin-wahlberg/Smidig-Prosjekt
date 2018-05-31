<?php
include('connection.php');
$loginMail = $_GET['mail'];
$howMany = $_GET['many'];
$howMany = intval($howMany);

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}



for ($i=0; $i < $howMany; $i++) {
  // code...
  $time = time();
  $time = $time + $i;
  $sql = "INSERT INTO lodd (userM, lotteryInfo)
  VALUES ('$loginMail', '$time')";

  if ($conn->query($sql) === TRUE) {
      $doneDeal = true;
  } else {
      echo "Error: " . $sql . "<br>" . $conn->error;
  }

}
$conn->close();
if (isset($doneDeal)) {
  echo "Yes";
}
?>
