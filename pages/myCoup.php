<?php
echo '{"mine":[';
include('connection.php');
$userEmail = $_GET['mail'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT kupongId FROM kuponger WHERE mailC = '$userEmail' ";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      $kupongId = $row["kupongId"];
      $sql = "SELECT tilbud, id, fordel, imgurl FROM tilbud WHERE id = '$kupongId'";
    $results = $conn->query($sql);

    if ($results->num_rows > 0) {
      // output data of each row
      while($row = $results->fetch_assoc()) {
        echo '{ "tilbud":"'. $row["tilbud"]. '" , "id":"'. $row["id"]. '" , "fordel":"'. $row["fordel"]. '" , "imgurl":"'. $row["imgurl"]. '" },';
          $t++;
      }
    } else {
      echo "Ikkje?";
    }
    }
} else {
    echo "0 results";
}
/*
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT kupongId FROM kuponger WHERE mailC = '$userEmail'";
$result = $conn->query($sql);

//Her blir det sjekket om alle kupponger er innafor 2 ganger så det blir sendt ut uansett om den er brukt siden de brukte blir sjekket først så blir de ikke husket.
if ($result->num_rows > 0) {
    // output data of each row
    $kupongId = $row["kupongId"];
    echo $kupongId;
    echo "hallo";
    $sql = "SELECT tilbud, id, fordel, imgurl FROM tilbud WHERE id = '$kupongId'";
  $results = $conn->query($sql);

  if ($results->num_rows > 0) {
    // output data of each row
    while($row = $results->fetch_assoc()) {
      echo '{ "tilbud":"'. $row["tilbud"]. '" , "id":"'. $row["id"]. '" , "fordel":"'. $row["fordel"]. '" , "imgurl":"'. $row["imgurl"]. '" },';
        $t++;
    }
  } else {
    echo "Ikkje?";
  }

} else {
  //Kode
}
$conn->close();
*/
echo "{}]}";
?>
