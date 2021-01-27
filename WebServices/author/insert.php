<?php
 $link = new PDO("mysql:host=localhost;dbname=books;charset=utf8", "root", "");

if (isset($_POST)) {
	$request = "INSERT INTO author (firstname, lastname) VALUES (:firstname, :lastname)";
	$sth = $link->prepare($request);
	$sth->bindValue(":firstname", $_POST["firstname"]);
	$sth->bindValue(":lastname", $_POST["lastname"]);
	$sth->execute();
	echo '{ "lastInsertId" : '. $link->lastInsertId() .' }';
}

?>