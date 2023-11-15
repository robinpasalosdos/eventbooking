<?php 
  require("./db_conn.php");
  
  $sort = 'ASC';
  $column = 'id';

  if (isset($_GET['column']) && isset($_GET['sort'])) {
    $column = $_GET['column'];
    $sort = $_GET['sort'];

    // Opposite
    $sort == 'ASC' ? $sort = 'DESC' : $sort = 'ASC'; 
  }

  $queryAccounts = "SELECT * FROM user ORDER BY $column $sort";
  $sqlAccounts = mysqli_query($con, $queryAccounts);
?>