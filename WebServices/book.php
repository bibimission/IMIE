<?php

 $link = new PDO("mysql:host=localhost;dbname=books;charset=utf8", "root", "");

if (isset($_GET)) {
	if (isset($_GET["action"])) {
		if ($_GET["action"] == "insert") {
			$request = "INSERT INTO book (name) VALUES (:name)";
			$sth = $link->prepare($request);
			$sth->bindValue(":name", $_GET["name"]);
			$sth->execute();
			echo '{ "lastInsertId" : '. $link->lastInsertId() .' }';
		} else if($_GET["action"] == "update"){
			$request = "UPDATE book SET name = :name WHERE id = :id";
			$sth = $link->prepare($request);
			$sth->bindValue(":name", $_GET["name"]);
			$sth->bindValue(":id", $_GET["id"]);
			$sth->execute();
		} else {
			if (isset($_GET["id"])) {
				$query = "SELECT name FROM book WHERE id = " . $_GET["id"];
				$statement = $link->query($query);
				$results = $statement->fetchAll(PDO::FETCH_ASSOC);
				$json = json_encode($results);
				echo $json;
			}
		}
		print_r($sth->errorInfo());
	}
}


?>