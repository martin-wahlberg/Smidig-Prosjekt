<?php
$t = 0;
echo '{"tilbud":[';
include('connection.php');
$userEmail = $_GET['mail'];

$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT kupongId FROM kuponger WHERE mailC = '$userEmail'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
    $kupongId = $row["kupongId"];
    $sql = "SELECT tilbud, id, fordel, imgurl FROM tilbud WHERE NOT id = '$kupongId'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      echo '{ "tilbud":"'. $row["tilbud"]. '" , "id":"'. $row["id"]. '" , "fordel":"'. $row["fordel"]. '" , "imgurl":"'. $row["imgurl"]. '" },';
        $t++;
    }
} else {
    echo "0 resultas";
}
    }
} else {
  $sql = "SELECT tilbud, id, fordel, imgurl FROM tilbud";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo '{ "tilbud":"'. $row["tilbud"]. '" , "id":"'. $row["id"]. '" , "fordel":"'. $row["fordel"]. '" , "imgurl":"'. $row["imgurl"]. '" },';
      $t++;
  }
} else {
  echo "0 results";
}
}
$conn->close();
echo "{}]}";
?>
