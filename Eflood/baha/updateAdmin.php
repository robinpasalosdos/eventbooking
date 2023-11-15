<?php
include "db_conn.php";
$name = mysqli_real_escape_string($con,$_POST['name']);
$uname = mysqli_real_escape_string($con,$_POST['username']);
$pass = mysqli_real_escape_string($con,$_POST['password']);
$contNo = mysqli_real_escape_string($con,$_POST['contactNo']);

$id= mysqli_real_escape_string($con,$_POST['id']);

if ($uname != "" && $pass != ""){
    
    $queryUpdate = "UPDATE details SET name = '$name', username = '$uname', password = '$pass', contactNo = '$contNo' WHERE id = $id";
    $sqlUpdate = mysqli_query($con, $queryUpdate);
    echo 0;

}