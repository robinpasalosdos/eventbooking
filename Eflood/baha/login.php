<?php 
    session_start();
    if($_SESSION){
        header("location: home.php");
    }
?>

<!DOCTYPE html>
<html>
    <head>
        <title>LOGIN</title>
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
            width: 700px;
        }
        .main-container{
            width: 700px;
            margin-top: 20px;
        }
        .sub-container{
            width: 450px;
        }
        label{
            font-size: larger;
            color: black;
        }
        p{
            font-size: large;
        }
        .btn{
            font-size: large;
        }
    </style>
    <body>
        <div class="container m-12 bg-white main-container">
            <div class="d-flex justify-content-center">
                <img class="logo" src="logo.png">
            </div>
            <div class="container sub-container">
                <div class="row-1 justify-content-center">
                        <div class="col">
                            <div class="d-flex mt-4 justify-content-center">
                                <h2>Login</h2>
                            </div>
                            <form>
                                <div class="form-group mt-3">
                                    <label class="form-label">User Name:</label>
                                    <input class="form-control" type="text" name="username" id="username" autocomplete="off" required>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Password:</label><br>
                                    <input class="form-control" type="password" name="password" id="password" autocomplete="off" required>
                                </div>
                                <div class="d-flex flex-column justify-content-center mt-4">
                                    <button class="btn btn-success" name="login" id="login">Login</button>
                                    <p class="text-center mt-3 mb-5">Not a admin? <a href="signup.php">Sign Up</a></p>
                                </div>
                            </form>
                        </div>
                </div>
            </div>
        </div>
    </body>
</html>
<script>
    $(document).ready(function(){
    $("#login").click(function(){
        var username = $("#username").val().trim();
        var password = $("#password").val().trim();

        if( username != "" && password != "" ){
            $.ajax({
                url:'checkUser.php',
                type:'post',
                data:{username:username,password:password},
                success:function(response){
                    var msg = "";
                    if(response == 1){
                        window.location = "home.php";
                        console.log('Login Successfully')
                    }else{
                        alert('Invalid username or password!')
                    }
                }
            });
        }
    });
});
</script>
