<?php
include "db_conn.php";
$name = mysqli_real_escape_string($con,$_POST['name']);
$uname = mysqli_real_escape_string($con,$_POST['username']);
$pass = mysqli_real_escape_string($con,$_POST['password']);
$pos = mysqli_real_escape_string($con,$_POST['position']);
$contNo = mysqli_real_escape_string($con,$_POST['contactNo']);
$email = mysqli_real_escape_string($con,$_POST['email']);

if ($uname != "" && $pass != ""){

    $sql = "SELECT username, contactNo FROM details WHERE username ='$uname' OR contactNo ='$contNo' LIMIT 1";

        $result = mysqli_query($con, $sql);

        if (mysqli_num_rows($result) === 1) {

            $row = mysqli_fetch_assoc($result);

            if ($row['username'] === $uname){
                echo 1;
            }else if ($row['contactNo'] === $contNo) {
                echo 2;
            }    
        }
        else{
            $query = "INSERT INTO details (name, username, password, contactNo, email, position) VALUES('$name', '$uname', '$pass','$contNo','$email','$pos')";
            mysqli_query($con, $query);
            echo 0;
        }
}