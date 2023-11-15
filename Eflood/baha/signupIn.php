
<!doctype html>
<html lang="en">
    <head>
        <title>SIGNUP</title>
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
                                <h3>Admin Registration Info</h3>
                            </div>
                                <div class="form-group mt-3">
                                    <label class="form-label" >Name:</label>
                                    <input class="form-control" type="text" name="name" id="name" autocomplete="off" required>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Username:</label>
                                    <input class="form-control" type="text" name="username" id="username" autocomplete="off" required>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Password:</label>
                                    <input class="form-control" type="password" name="password" id="password" autocomplete="off" required>
                                </div>
                                <div class="form-group">
                                    <label for="position" class="form-label">Position:</label>
                                    <select class="form-control" name="position" id="position" required>
                                        <option selected="selected" disabled value=""></option>
                                        <option value="Resident">Resident</option>
                                        <option value="Barangay Official">Barangay Official</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Contact No:</label>
                                    <input class="form-control" type="text" name="contactNo" id="contactNo" autocomplete="off" required>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Email:&nbsp;&emsp;</label>
                                    <div class="input-group">
                                        <input class="form-control" type="text" name="email" id="email" autocomplete="off" required>
                                        <div class="input-group-append">
                                            <button class="btn btn-success" id="getOTP" onclick="otpInputReveal()">Get OTP</button>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label" id="otpLabel">OTP:</label>
                                    <label class="form-label text-danger justify-content-end" id="otpLabelError"></label>
                                    <div class="input-group">
                                        <input class="form-control" type="text" name="otp" id="otpInput" autocomplete="off" required disabled>
                                        <div class="input-group-append">
                                            <button class="btn btn-success" id="verify" onclick="verifyOtp()" disabled>Verify</button>
                                        </div>
                                    </div>
                                </div>
                                <div class="d-flex flex-column justify-content-center mt-4">
                                    <button class="btn btn-success mb-5 mt-2" id="signup" name="signup" id="signup" disabled>Sign Up</button>
                                </div>
                        </div>

                </div>
            </div>
        </div>
    </body>
</html>
<script>
    var randOtpNum = Math.floor(Math.random() * 899999 ) + 100000;
    var randOtp = randOtpNum.toString();
    var otp = document.getElementById("otpInput");
    function otpInputReveal() {
        var input = document.getElementById("otpInput");
        var getOTPBtn = document.getElementById("getOTP");
        var verify = document.getElementById("verify");
        var name = document.getElementById("name").value;
        var username = document.getElementById("username").value;
        var password = document.getElementById("password").value;
        var position = document.getElementById("position").value;
        var contactNo = document.getElementById("contactNo").value;
        var email = document.getElementById("email").value;
        if (name !== "" && username !== "" && password !== "" && position !== "" && contactNo  !== "" && email  !== ""){
            otp.disabled = false;
            verify.disabled = false;
            email.disabled = true;
        }
    }
    function verifyOtp() {
        var otpLabelError = document.getElementById("otpLabelError");
        var signupBtn = document.getElementById("signup");
        email.innerHTML = randOtp;
        if (otp.value === randOtp){
            signupBtn.disabled = false;
            otpLabelError.innerHTML = ""
        }else{
            otpLabelError.innerHTML = "&nbsp;Invalid OTP";
        }
    }
    $(document).ready(function(){
    $("#getOTP").click(function(){

        var email = $("#email").val().trim();

        if( email != ""){
            $.ajax({
                url:'smsAPI.php',
                type:'post',
                data:{randOtp:randOtp,email:email},
                success:function(response){
                    if(response == 0){
                        alert('OTP sent!')
                    }
                }
            });
        }
    });
});

    $(document).ready(function(){
    $("#signup").click(function(){
        var name = $("#name").val().trim();
        var username = $("#username").val().trim();
        var password = $("#password").val().trim();
        var position = $("#position").val().trim();
        var contactNo = $("#contactNo").val().trim();
        var email = $("#email").val().trim();

        if( username != "" && password != "" ){
            $.ajax({
                url:'addAdmin.php',
                type:'post',
                data:{name:name,username:username,password:password,position:position,contactNo:contactNo,email:email},
                success:function(response){
                    var msg = "";
                    if(response == 0){
                        window.location = "admin.php";
                        alert('Successfully Created!')
                    }else if(response == 1){
                        alert('Username already exists!')
                    }else if(response == 2){
                        alert('Contact number already exists!')
                    }
                }
            });
        }
    });
});
</script>
