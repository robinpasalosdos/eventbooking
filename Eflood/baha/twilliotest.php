<?php

require __DIR__ . '/twilio-php-main/src/Twilio/autoload.php';
    use Twilio\Rest\Client;
    // Your Account SID and Auth Token from twilio.com/console
    $account_sid = 'ACae9cb54f3071391fca14ce5f40a7f68c';
    $auth_token = '81bce62212cda66b6de6d1ca9bd8e070';
    // In production, these should be environment variables. E.g.:
    // $auth_token = $_ENV["TWILIO_ACCOUNT_SID"]
    // A Twilio number you own with SMS capabilities
    $twilio_number = "+12055256358";
    $client = new Client($account_sid, $auth_token);
    $client->messages->create(
        // Where to send a text message (your cell phone?)
        '+12055256358',
        array(
            'from' => $twilio_number,
            'body' => 'hello from twillio'
        )
    );