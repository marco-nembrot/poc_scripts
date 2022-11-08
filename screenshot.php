<?php
ini_set('error_reporting', E_ALL);
require 'config.php';
/*
$handle = fopen("files.txt", "a");
foreach($_FILES as $i => $v) {
    fwrite($handle, $i . " ~ " . $v . "\n");
    foreach($v as $index => $value) {
        fwrite($handle, "\t" . $index . " ~ " . $value . "\n");
    }
}
fclose($handle);
//*/
//var_dump($_POST);
$alias = $_POST['alias'];
$email = $_POST['email'];
$niveau = $_POST['level'];
$autosave = $_POST['autosave'];
$concoursId = $_POST['concoursId'];

$prefix = "";
$flag = false;
if ($_POST['serversaveF'] == "False") {
    $prefix .= "_D_";
    $flag = true;
}
if ($_POST['concoursF'] == "True") {
    $prefix .= "_C_";
    $flag = true;
    
    //ajout de la participation au concours
    $sql = "INSERT INTO onCompetition " .
            "(concours, alias, date) VALUES " .
            "($concoursId, $alias, NOW());";
    $req = $PDO->prepare($sql);
    echo $req->execute();
}

$file = "../screenshots/" .$email. "/";
if (!file_exists($file)) {
    mkdir($file, 0777);
}
$imgPath = $_FILES['fileUpload']['name'];
$img = $file . $prefix . $imgPath;
echo move_uploaded_file($_FILES['fileUpload']['tmp_name'], $img);

date_default_timezone_set("Europe/Paris");
//envoi du mail contenant l'image
if ($autosave == "True") {
    $to = $email;
    $subject = 'POC|Screenshot';
    $boundary = md5(uniqid(microtime(), TRUE));

    // Headers
    $headers = 'From: POC PM <poc@nembrot.club>'."\r\n";
    $headers .= 'Mime-Version: 1.0'."\r\n";
    $headers .= 'Content-Type: multipart/mixed;boundary='.$boundary."\r\n";
    $headers .= "\r\n";

    // Message
    $msg = 'Texte affiché par des clients mail ne supportant pas le type MIME.'."\r\n\r\n";

    // Message HTML
    $msg .= '--'.$boundary."\r\n";
    $msg .= 'Content-type: text/html; charset=utf-8'."\r\n\r\n";
    $msg .= '
    <div style="padding:10px; text-align:center;">
	<div>
            <a href="http://www.presentationdemarie.org/">
                <img src="http://nembrot.club/POC/PM_bandeau.jpg" alt="Présentation de Marie" width="600" />
            </a>
	</div>
	<div style="font-size:14pt">
            <h2 style="color:#274E9C; font-size:18pt">Imprim-écran depuis POC</h2>
            <strong>' .date('r'). '</strong>
            <br />
            Image prise depuis l\'interface du niveau ' .$niveau. '.
	</div>
	<div style="margin-top:20px; font-size:10pt;">
            <strong>POC © ' .date('Y'). '</strong> est présent sur <a href="https://www.facebook.com/PmPocPage">Facebook</a>. <br />
            N\'hésite pas à venir poster tes images du jeu !
	</div>
    </div>'."\r\n";

    //image sauvegardée en pièce jointe
    if (file_exists($img)){
        $file_type = filetype($img);
        $file_size = filesize($img);

        $handle = fopen($img, 'r') or die('File '.$img.' can t be open');
        $content = fread($handle, $file_size);
        $content = chunk_split(base64_encode($content));
        $f = fclose($handle);

        $msg .= '--'.$boundary."\r\n";
        $msg .= 'Content-type:'.$file_type.';name='.$img."\r\n";
        $msg .= 'Content-transfer-encoding:base64'."\r\n\r\n";
        $msg .= $content."\r\n";
    }
    
    $msg .= '--'.$boundary."\r\n";
    echo mail($to, $subject, $msg, $headers);
}


//envoi du mail contenant l'image
if ($flag) {
    $to = 'i.nembrot@laposte.net';
    $subject = 'POC|Screenshot ' . $prefix;
    $boundary = md5(uniqid(microtime(), TRUE));

    // Headers
    $headers = 'From: POC User <poc@nembrot.club>'."\r\n";
    $headers .= 'Mime-Version: 1.0'."\r\n";
    $headers .= 'Content-Type: multipart/mixed;boundary='.$boundary."\r\n";
    $headers .= "\r\n";

    // Message
    $msg = 'Texte affiché par des clients mail ne supportant pas le type MIME.'."\r\n\r\n";

    // Message HTML
    $msg .= '--'.$boundary."\r\n";
    $msg .= 'Content-type: text/html; charset=utf-8'."\r\n\r\n";
    $msg .= '
    <div style="padding:10px; text-align:center;">
	<div>
            <h2 style="color:#274E9C;">Image prise depuis POC</h2>
            <strong>' .date('r'). '</strong>
            <br />
            <u>' .$email. '</u> a récupéré la photo <' .$imgPath. '> depuis le niveau ' .$niveau. ' avec le préfixe "'. $prefix . '".
	</div>
    </div>'."\r\n";

    //image sauvegardée en pièce jointe
    if (file_exists($img)){
        $file_type = filetype($img);
        $file_size = filesize($img);

        $handle = fopen($img, 'r') or die('File '.$img.' can t be open');
        $content = fread($handle, $file_size);
        $content = chunk_split(base64_encode($content));
        $f = fclose($handle);

        $msg .= '--'.$boundary."\r\n";
        $msg .= 'Content-type:'.$file_type.';name='.$img."\r\n";
        $msg .= 'Content-transfer-encoding:base64'."\r\n\r\n";
        $msg .= $content."\r\n";
    }
    
    $msg .= '--'.$boundary."\r\n";
    echo mail($to, $subject, $msg, $headers);
}



$PDO = null;
?>