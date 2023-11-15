<?php 
  require('./db_conn.php');
  if (isset($_POST["delete"])) {
    $deleteId = $_POST['deleteId'];
    $queryDelete = "DELETE FROM details WHERE id = $deleteId";
    $sqlDelete = mysqli_query($con, $queryDelete);
    echo '<script>window.location.href = "/baha/admin.php"</script>';
  }
?>