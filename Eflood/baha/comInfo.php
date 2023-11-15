<?php 
    session_start();
    if(!$_SESSION){
        header("location: login.php");
    }
?>
<!DOCTYPE html>
<html>
  <head>
    <title>COM INFO</title>
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
        .button{
          width: 100px;
          margin-bottom: 2px;
          height: 30px;
          font-size: small;
        }
        table tr th{
          width: 150px;
        }
        table tr td{
          text-align: center;
        }
        table tr th{
          text-align: center;
        }
    </style>
  <body>
    <div class="container-fluid m-12 bg-white">
      <nav class="navbar navbar-expand-sm bg-primary navbar-dark">
        <div class="navbar-link">
          <ul class="navbar-nav">
            <img class="logo" src="round_logo.png">
            <li class="nav-item"><a class="navbar-brand" href="home.php">Home</a></li>
            <li class="nav-item"><a class="navbar-brand text-secondary" href="#">Community Information</a></li>
            <li class="nav-item"><a class="navbar-brand" href="waterLevel.php">Water Level Monitoring</a></li>
            <li class="nav-item"><a class="navbar-brand" href="admin.php?pass=h">Admin</a></li>
            <li class="nav-item"><a class="navbar-brand" onclick="logout()" href="#">Log Out</a></li>
            </li>
          </ul>
        </div>
      </nav>
      <a class="btn btn-success mb-2 mt-2" href="addMemberMenu.php">Add Member</a>
      <?php require("./readMember.php");?>
      <table class="table">
        <tr>
          <th><a href="?column=id&sort=<?php echo $sort ?>">ID</a></th>
          <th><a href="?column=name&sort=<?php echo $sort ?>">NAME</a></th>
          <th><a href="?column=address&sort=<?php echo $sort ?>">ADDRESS</a></th>
          <th><a href="?column=contactNo&sort=<?php echo $sort ?>">CONTACT NO.</a></th>
          <th><a href="?column=contactNo&sort=<?php echo $sort ?>">EMAIL</a></th>
          <th><a class="text-primary">ACTIONS</a></th>
        </tr>
        <?php while($results = mysqli_fetch_array($sqlAccounts)) { ?>
          <tr>
            <td><p><?php echo $results['id']; ?></p></td>
            <td><p><?php echo $results['name']; ?></p></td>
            <td><p><?php echo $results['address']; ?></p></td>
            <td><p><?php echo $results['contactNo']; ?></p></td>
            <td><p><?php echo $results['email']; ?></p></td>
            <td>
              <form action="updateMemberMenu.php" method="post">
                <input class="btn btn-success button" type="submit" name="edit" value="EDIT" />
                <input type="hidden" name="editId" value="<?php echo $results['id']; ?>" />
                <input type="hidden" name="editName" value="<?php echo $results['name']; ?>" />
                <input type="hidden" name="editAddress" value="<?php echo $results['address']; ?>" />
                <input type="hidden" name="editContactNo" value="<?php echo $results['contactNo']; ?>" />
                <input type="hidden" name="editEmail" value="<?php echo $results['email']; ?>" />
              </form>
              <form action="deleteMember.php" method="post">
                <input class="btn btn-danger button" type="submit" name="delete" id="delete" value="DELETE" />
                <input type="hidden" name="deleteId" id="deleteId" value="<?php echo $results['id']; ?>"/>
              </form>
            </td>
          </tr>
        <?php } ?>
      </table>
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