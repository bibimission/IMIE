<?php
 $link = new PDO("mysql:host=localhost;dbname=books;charset=utf8", "root", "");

if (isset($_GET)) {
	if(isset($_GET['id'])){
		$query = "SELECT * FROM author WHERE id = " . $_GET["id"];
		$statement = $link->query($query);
		$results = $statement->fetchAll(PDO::FETCH_ASSOC);
		$json = json_encode($results);
		echo $json;
	}else{
		$query = "SELECT * FROM author";
		$statement = $link->query($query);
		$results = $statement->fetchAll(PDO::FETCH_ASSOC);
		$json = json_encode($results);
		echo $json;
	}
}

?>