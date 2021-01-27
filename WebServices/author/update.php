<?php
 $link = new PDO("mysql:host=localhost;dbname=books;charset=utf8", "root", "");

if (isset($_POST)) {
	$request = "UPDATE author SET firstname = :firstname, lastname = :lastaname WHERE id = :id";
	$sth = $link->prepare($request);
	$sth->bindValue(":firstname", $_POST["firstname"]);
	$sth->bindValue(":lasstname", $_POST["lasstname"]);
	$sth->bindValue(":id", $_POST["id"]);
	$sth->execute();
	echo "Updated";
}

?>