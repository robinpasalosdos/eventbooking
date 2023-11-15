<?php 
  require("./db_conn.php");
  
  $name = 'name';

  if (isset($_GET['name'])) {
    $name = $_GET['name'];
  }

  $queryAccounts = "SELECT * FROM details";
  $sqlAccounts = mysqli_query($con, $queryAccounts);
?>