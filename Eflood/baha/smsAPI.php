<?php
    require("./db_conn.php");
    use PHPMailer\PHPMailer\PHPMailer;
    require 'vendor/phpmailer/phpmailer/src/Exception.php';
    require 'vendor/phpmailer/phpmailer/src/PHPMailer.php';
    require 'vendor/phpmailer/phpmailer/src/SMTP.php';
    require 'vendor/autoload.php';

    $mail = new PHPMailer();
    $subject = 'OTP';
    $email = mysqli_real_escape_string($con,$_POST['email']);
    $otp = mysqli_real_escape_string($con,$_POST['randOtp']);
    $message = "Your OTP: $otp";
    $emailStr = strval($email);
    $messageStr = strval($message);
    
    $mail->IsSMTP();
    $mail->Mailer = "smtp";
    $mail->SMTPDebug  = 1;  
    $mail->SMTPAuth   = TRUE;
    $mail->SMTPSecure = "tls";
    $mail->Port       = 587;
    $mail->Host       = "smtp.gmail.com";
    $mail->Username   = "eflood1003@gmail.com";
    $mail->Password   = "rwdrurhphpftvjsj";
    $mail->IsHTML(true);
    $mail->AddAddress("$emailStr", "You");
    $mail->SetFrom("eflood1003@gmail.com", "IFlood");
    $mail->Subject = $subject;
    $mail->MsgHTML($messageStr); 
    if(!$mail->Send()) {
        echo "0";
    } else {
        echo "1";
    }


    
?>

    