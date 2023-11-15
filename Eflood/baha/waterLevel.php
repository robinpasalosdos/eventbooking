<?php 
    session_start();
    if(!$_SESSION){
        header("location: login.php");
    }
?>
<!DOCTYPE html>
<html>
    <head>
        <title>WATER</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" integrity="sha384-zCbKRCUGaJDkqS1kPbPd7TveP5iyJE0EjAuZQTgFLD2ylzuqKfdKlfG/eSrtxUkn" crossorigin="anonymous">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.2/font/bootstrap-icons.css">
    </head>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
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
                        <li class="nav-item"><a class="navbar-brand" href="home.php">Home</a></li>
                        <li class="nav-item"><a class="navbar-brand" href="comInfo.php">Community Information</a></li>
                        <li class="nav-item"><a class="navbar-brand text-secondary" href="#">Water Level Monitoring</a></li>
                        <li class="nav-item"><a class="navbar-brand" href="admin.php?pass=h">Admin</a></li>
                        <li class="nav-item"><a class="navbar-brand" onclick="logout()" href="#">Log Out</a></li>
                        </li>
                    </ul>
                </div>
            </nav>
            <div class="d-flex justify-content-center mt-5 home">
                <div class="row-1 justify-content-center">
                    <div class="col">
                      <div class="d-flex justify-content-center mt-5 mb-5">
                        <h1>Water Level Monitoring</h1>
                      </div>
                    </div>
                    <div class="col">
                        <div class="d-flex justify-content-center mt-5 mb-5">
                            <button class="btn btn-success" id="view" onclick="view()">View Water Levels</button>
                            <canvas id="myChart" style="width:600px;display: none;"></canvas>
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
var xValues = ["05/26 01:00","05/26 02:00","05/26 03:00","05/26 04:00","05/26 05:00","05/26 06:00","05/26 08:00","05/26 09:00","05/26 10:00","05/26 11:00"];
var viewBtn = document.getElementById("view");
var chart = document.getElementById("myChart");
var notify = document.getElementById("notify");
function view() {
  chart.style.display = "block";
  chart.style.width = "600px";
  chart.style.maxWidth = "1000px";
  viewBtn.style.display = "none"
  notify.style.display = "block";
}
new Chart("myChart", {
  type: "line",
  data: {
    labels: xValues,
    datasets: [{ 
      data: [0.8454,0.9892,0.9521,0.7524,0.7321,0.8124,1.0234,1.1243,1.265,1.1465],
      borderColor: "blue",
      fill: false}]
  },
  options: {
    legend: {display: false}
  }
});
</script>