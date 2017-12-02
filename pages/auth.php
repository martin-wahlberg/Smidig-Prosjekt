<?php
$loginMail = $_GET['mail'];
$loginPw = $_GET['pw'];
$loginMail = urldecode($loginMail);
$loginPw = urldecode($loginPw);
// Get cURL resource
$ch = curl_init();

// Set url
curl_setopt($ch, CURLOPT_URL, 'https://kolonial.no/api/v1/user/login/?q=epok');

// Set method
curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'POST');

// Set options
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);

// Set headers
curl_setopt($ch, CURLOPT_HTTPHEADER, [
  "User-Agent: MartinWahlberg_Test",
  "X-Client-Token: q3RZo6Njwxzb4VKiOXZdcJiq82dnn05aq3eYC3B5ewrzfHsZzx",
  "Cookie: front-group=web04; csrftoken=o9Sbh5AdJEZ1H3l3U1XDpmvTkilcFFT0paBEFY5zlrGfg5LZhfrK9sxOZIyYvb3S; sessionid=14fsl6sckslbdhhxmxg8q8fvurihs2jk",
  "Content-Type: application/json",
  "Accept: application/json",
 ]
);
// Create body
$json_array = [
            "username" => $loginMail,
            "password" => $loginPw
        ];
$body = json_encode($json_array);

// Set body
curl_setopt($ch, CURLOPT_POST, 1);
curl_setopt($ch, CURLOPT_POSTFIELDS, $body);

// Send the request & save response to $resp
$resp = curl_exec($ch);

if(!$resp) {
  die('Error: "' . curl_error($ch) . '" - Code: ' . curl_errno($ch));
} else {

}

// Close request to clear up some resources
curl_close($ch);

//Dekoder json resultet
$decoded = json_decode($resp);
$auth = (string)$decoded->{'is_authenticated'};
$id = (string)$decoded->{'sessionid'};
$user = $decoded->user;
$firstName = (string)$user->{'first_name'};
$lastName = (string)$user->{'last_name'};
$uEmail = (string)$user->{'email'};
?>


  <?php
  echo "{";
  echo "\"auth\":\"$auth\", ";
  echo "\"id\":\"$id\", ";
  echo "\"firstName\":\"$firstName\", ";
  echo "\"lastName\":\"$lastName\", ";
  echo "\"mail\":\"$uEmail\"";
  echo "}";
  ?>
