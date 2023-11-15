<?php
include "db_conn.php";
$name = mysqli_real_escape_string($con,$_POST['name']);
$address = mysqli_real_escape_string($con,$_POST['address']);
$contNo = mysqli_real_escape_string($con,$_POST['contactNo']);
$email = mysqli_real_escape_string($con,$_POST['email']);
if ($name != ""){

    $sql = "SELECT contactNo FROM user WHERE contactNo ='$contNo' LIMIT 1";

        $result = mysqli_query($con, $sql);

        if (mysqli_num_rows($result) === 1) {

            $row = mysqli_fetch_assoc($result);
            echo 1;
        }
        else{
            $query = "INSERT INTO user (name, address, contactNo, email) VALUES('$name', '$address', '$contNo', '$email')";
            mysqli_query($con, $query);
            echo 0;
        }
}