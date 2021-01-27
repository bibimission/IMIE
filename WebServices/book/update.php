<?php
 $link = new PDO("mysql:host=localhost;dbname=books;charset=utf8", "root", "");

if (isset($_POST)) {
	$request = "UPDATE book SET name = :name WHERE id = :id";
	$sth = $link->prepare($request);
	$sth->bindValue(":name", $_POST["name"]);
	$sth->bindValue(":id", $_POST["id"]);
	$sth->execute();
	echo "Updated";
}

?>