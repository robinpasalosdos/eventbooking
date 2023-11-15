<?php 
  require('./db_conn.php');
  if (isset($_POST["delete"])) {
    $deleteId = $_POST['deleteId'];
    $queryDelete = "DELETE FROM user WHERE id = $deleteId";
    $sqlDelete = mysqli_query($con, $queryDelete);
    echo '<script>window.location.href = "/baha/comInfo.php"</script>';
  }
?>