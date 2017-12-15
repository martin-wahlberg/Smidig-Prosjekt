<?php
include('connection.php');
$loginMail = $_GET['mail'];
$loginMail = urldecode($loginMail);
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT totalPoints FROM points WHERE pointMail = '$loginMail'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo $row["totalPoints"];
    }
} else {
    echo 0;
}
$conn->close();
?>
