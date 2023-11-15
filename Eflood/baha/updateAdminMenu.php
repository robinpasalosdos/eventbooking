<?php 
  require('./db_conn.php');
  if (isset($_POST["edit"])) {
    $editId = $_POST['editId'];
    $editName = $_POST['editName'];
    $editUsername = $_POST['editUsername'];
    $editPassword = $_POST['editPassword'];
    $editPosition = $_POST['editPosition'];
    $editContactNo = $_POST['editContactNo'];
    $editEmail = $_POST['editEmail'];
  }
?>
<html lang="en">
    <head>
        <title>UPDATE</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" integrity="sha384-zCbKRCUGaJDkqS1kPbPd7TveP5iyJE0EjAuZQTgFLD2ylzuqKfdKlfG/eSrtxUkn" crossorigin="anonymous">
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
            margin-top: 10px;
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
        <div class="container bg-white main-container">
            <div class="d-flex justify-content-center">
                <img class="logo" src="logo.png">
            </div>
            <div class="container sub-container">
                <div class="row-1 justify-content-center">
                    <div class="col">
                        <div class="d-flex mt-4 justify-content-center">
                            <h3>Update Admin</h3>
                        </div>
                        <div class="form-group mt-3">
                            <label class="form-label" >Name:</label>
                            <input class="form-control" type="text" name="name" id="name" value="<?php echo $editName ?>" autocomplete="off" required>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Username:</label>
                            <input class="form-control" type="text" name="username" id="username" value="<?php echo $editUsername ?>" autocomplete="off" required disabled>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Password:</label>
                            <input class="form-control" type="password" name="password" id="password" value="<?php echo $editPassword ?>" autocomplete="off" required>
                        </div>
                        <div class="form-group">
                            <label for="position" class="form-label">Position:</label>
                            <select class="form-control" name="position" id="position" required disabled>
                                <option selected="selected" disabled value="<?php echo $editPosition ?>"><?php echo $editPosition ?></option>
                                <option value="Resident">Resident</option>
                                <option value="Barangay Official">Barangay Official</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Contact No:</label>
                            <input class="form-control" type="text" name="contactNo" id="contactNo" value="<?php echo $editContactNo ?>" autocomplete="off" required>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Email:</label>
                            <input class="form-control" type="text" name="email" id="email" value="<?php echo $editEmail ?>" autocomplete="off" required disabled>
                        </div>
                        <div class="d-flex flex-column justify-content-center mt-4">
                            <button class="btn btn-success mb-5 mt-2" id="update" name="update">Update</button>
                        </div>
                        <input type="hidden" name="id" id="id" value="<?php echo $editId ?>" />
                    </div>
                </div>
            </div>
        </div>
    </body>
</html>
<script>

    $(document).ready(function(){
    $("#update").click(function(){
        var name = $("#name").val().trim();
        var username = $("#username").val().trim();
        var password = $("#password").val().trim();
        var contactNo = $("#contactNo").val().trim();
        var id = $("#id").val().trim();

        if( username != "" && password != "" ){
            $.ajax({
                url:'updateAdmin.php',
                type:'post',
                data:{name:name,username:username,password:password,id:id,contactNo,contactNo},
                success:function(response){
                    if(response == 0){
                        alert('Successfully Updated!')
                        window.location = "admin.php";
                    }
                }
            });
        }
    });
});
</script>