<?php
 $link = new PDO("mysql:host=localhost;dbname=books;charset=utf8", "root", "");

if (isset($_POST)) {
	$request = "DELETE FROM author  WHERE id = :id";
	$sth = $link->prepare($request);
	$sth->bindValue(":id", $_POST["id"]);
	$sth->execute();
}

?>