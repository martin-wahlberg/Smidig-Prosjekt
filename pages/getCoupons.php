<?php
$t = 0;
$a=array();
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

//Her blir det sjekket om alle kupponger er innafor 2 ganger så det blir sendt ut uansett om den er brukt siden de brukte blir sjekket først så blir de ikke husket.
if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
    $kupongId = $row["kupongId"];
    array_push($a, "$kupongId");
    $something = "done";
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
if (isset($something)) {
   $sql = "SELECT tilbud, id, fordel, imgurl FROM tilbud WHERE NOT id = '$x_value'";
   $result = $conn->query($sql);

   if ($result->num_rows > 0) {
       // output data of each row
       while($row = $result->fetch_assoc()) {
         $chickChack = "false";
         foreach($a as $x => $x_value) {
           if ($row["id"] === $x_value) {
             $chickChack = "true";
           }
         }
         if ($chickChack ==="false") {
           echo '{ "tilbud":"'. $row["tilbud"]. '" , "id":"'. $row["id"]. '" , "fordel":"'. $row["fordel"]. '" , "imgurl":"'. $row["imgurl"]. '" },';
         }
       }
   } else {

   }

}

$conn->close();
echo "{}]}";
?>
