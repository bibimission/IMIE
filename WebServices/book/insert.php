<?php
 $link = new PDO("mysql:host=localhost;dbname=books;charset=utf8", "root", "");

if (isset($_POST)) {
	$request = "INSERT INTO book (name, id_author) VALUES (:name, :id_author)";
	$sth = $link->prepare($request);
	$sth->bindValue(":name", $_POST["name"]);
	$sth->bindValue(":id_author", $_POST["id_author"]);
	$sth->execute();
	echo '{ "lastInsertId" : '. $link->lastInsertId() .' }';
}

?>