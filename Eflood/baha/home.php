<?php 
    session_start();
    if(!$_SESSION){
        header("location: login.php");
    }
?>
<!DOCTYPE html>
<html>
    <head>
        <title>HOME</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" integrity="sha384-zCbKRCUGaJDkqS1kPbPd7TveP5iyJE0EjAuZQTgFLD2ylzuqKfdKlfG/eSrtxUkn" crossorigin="anonymous">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.2/font/bootstrap-icons.css">
    </head>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <style>
        body{
        background-image: url("th.jpg");
        background-size: cover;
        background-repeat: no-repeat;
        }
        .logo{
        width: 80px;
        }

        .sub-container{
        width: 470px;
        }
        label{
        font-size: larger;
        }
        p{
        font-size: larger;
        }
        .btn{
        font-size: large;
        }
        .navbar-link li a {
        width: 240px;
        font-size: 20px;
        color: black;
        text-align: center;
        padding-top: 20px;
        }
        .navbar-link li{
        color: black;
        }
    </style>
    <body>
        <div class="container-fluid m-12 bg-white">
            <nav class="navbar navbar-expand-sm bg-primary navbar-dark">
                <div class="navbar-link">
                    <ul class="navbar-nav">
                        <img class="logo" src="round_logo.png">
                        <li class="nav-item"><a class="navbar-brand text-secondary" href="#">Home</a></li>
                        <li class="nav-item"><a class="navbar-brand" href="comInfo.php">Community Information</a></li>
                        <li class="nav-item"><a class="navbar-brand" href="waterLevel.php">Water Level Monitoring</a></li>
                        <li class="nav-item"><a class="navbar-brand" href="admin.php?pass=h">Admin</a></li>
                        <li class="nav-item"><a class="navbar-brand" onclick="logout()" href="#">Log Out</a></li>
                        </li>
                    </ul>
                </div>
            </nav>
            <div class="d-flex justify-content-center mt-5 home">
                <div class="row-1 justify-content-center">
                    <div class="col">
                        <h1>IFlood of Barangay San Antonio II Noveleta Cavite</h1>
                    </div>
                    <div class="col">
                        <div class="d-flex justify-content-center mt-5 mb-5">
                            <img src="round_logo.png">
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </body>
</html>
<script>
    function logout(){
        if (confirm("Do you want to log out?")){
            $.ajax({
                url:'logout.php',
                type:'post'
            });
            window.location = "login.php";
        }
    }
</script>
