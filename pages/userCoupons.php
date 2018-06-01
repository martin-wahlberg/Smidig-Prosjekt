<?php
$mailSite = $_GET['mail'];
$mailSite = urldecode($mailSite);
$kupongIdSite = $_GET['kup'];
$kupongIdSite = urldecode($kupongIdSite);
$kupongNameSite = $_GET['kupN'];
$kupongNameSite = urldecode($kupongNameSite);
$benefitSite = $_GET['ben'];
$benefitSite = urldecode($benefitSite);
include('connection.php');

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "INSERT INTO kuponger (MailC, kupongId)
VALUES ('$mailSite', '$kupongIdSite')";

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>
