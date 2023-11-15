<?php
include "db_conn.php";
$name = mysqli_real_escape_string($con,$_POST['name']);
$address = mysqli_real_escape_string($con,$_POST['address']);
$contNo = mysqli_real_escape_string($con,$_POST['contactNo']);
$id= mysqli_real_escape_string($con,$_POST['id']);

if ($name != ""){
    
    $queryUpdate = "UPDATE user SET name = '$name', address = '$address', contactNo = '$contNo' WHERE id = $id";
    $sqlUpdate = mysqli_query($con, $queryUpdate);
    echo 0;

}