<?php
use PHPMailer\PHPMailer\PHPMailer;

function sendOTP($email, $message)
{
    require 'vendor/phpmailer/phpmailer/src/Exception.php';
    require 'vendor/phpmailer/phpmailer/src/PHPMailer.php';
    require 'vendor/phpmailer/phpmailer/src/SMTP.php';
    require 'vendor/autoload.php';
    $mail = new PHPMailer();
    $subject = 'EFlood';
    
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
    $mail->AddAddress("$email", "EFlood");
    $mail->SetFrom("eflood1003@gmail.com", "EFlood");
    $mail->Subject = $subject;
    $mail->MsgHTML($message); 
    if(!$mail->Send()) {
        echo "0";
    } else {
        echo "1";
    }
}