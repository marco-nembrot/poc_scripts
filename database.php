<?php
header ('Content-Type: text/html; charset=UTF-8');
require 'config.php';

var_dump($_POST);
if ($_POST['action'] == 'paragraphe') {
    $niveau = $_POST['niveau'];
    
    $sql = "SELECT position, texte FROM paragraphe WHERE niveau = '$niveau';";
    $req = $PDO->prepare($sql);
    $req->execute();
    
    $return = array();
    $data = $req->fetchAll(PDO::FETCH_ASSOC);
    foreach ($data AS $index => $value) {
        $position = intval($value['position']);
        $return[$position] = utf8_encode($value['texte']);
    }    
    
    //recherche du niveau suivant si existant
    $sqlNext = 
        "SELECT nom_poc FROM niveau WHERE ordre = (" .
            "SELECT ordre FROM niveau WHERE nom = '$niveau'" .
        ") + 1;";
    $reqNext = $PDO->prepare($sqlNext);
    $reqNext->execute();
    $dataNext = $reqNext->fetch(PDO::FETCH_ASSOC);
    
    $return['nextLevel'] = $dataNext['nom_poc'];
    /*
    $handle = fopen("databASe.txt", "w+");
    fwrite($handle, json_encode($return));
    fclose($handle);
    //*/
    echo json_encode($return);
    


} elseif ($_POST['action'] == 'results') {
    extract($_POST);
    
    if ($onPlay == -1) {
        $onPlay = 
            "(SELECT id FROM onPlay " . 
            "WHERE reglages = '$reglages' " .
            "AND difficulte = '$difficulte')";
    }
    
    $sql = "INSERT INTO resultat " .
            "(connexion, niveau, score, note, duree, date, type, onPlay) VALUES " .
            "($connexion, '$niveau', $score, '$note', $duree,  NOW(), '$type', $onPlay);";
    $req = $PDO->prepare($sql);
    echo $req->execute();
    
    $resultat = intval($PDO->lastInsertId());
    if (!empty($personnage)) {
        $uSql = 
            "UPDATE resultat " .
            "SET personnage = '$personnage' " .
            "WHERE id = $resultat;";
        $uReq = $PDO->prepare($uSql);
        echo $uReq->execute();
    }
    if (!empty($plateforme)) {
        $uSql = 
            "UPDATE resultat " .
            "SET plateforme = '$plateforme' " .
            "WHERE id = $resultat;";
        $uReq = $PDO->prepare($uSql);
        echo $uReq->execute();
    }

    
    
} elseif ($_POST['action'] == 'success') {
    $niveau = $_POST['niveau'];
    $connexion = $_POST['connexion'];
    
    $temp = $_POST['liste'];
    $values = explode(";", $temp);
    foreach ($values as $pos) {
        $tSql = 
            "(SELECT id FROM paragraphe " .
            "WHERE niveau = '$niveau' AND position = $pos)";
        $uSql = 
            "INSERT INTO onSuccess " .
            "(connexion, paragraphe) VALUES " .
            "($connexion, $tSql);";
        $uReq = $PDO->prepare($uSql);
        echo $uReq->execute();
    }

    
    
} elseif ($_POST['action'] == 'concours') {
    $format = "%d-%m-%Y %T";
    $sql = "SELECT id, nom, description, maxAttempts, " . 
                "DATE_FORMAT(dateStart, '$format') AS dateS, " .
                "DATE_FORMAT(dateEnd, '$format') AS dateE " . 
            "FROM concours " .
            "WHERE NOW() BETWEEN dateStart AND dateEnd;";
    $req = $PDO->prepare($sql);
    $req->execute();
    $data = $req->fetch(PDO::FETCH_ASSOC);
    
    $alias = $_POST['alias'];
    $sqlU = "SELECT count(*) AS userCounts " . 
            "FROM onCompetition " .
            "WHERE alias = $alias;";
    $reqU = $PDO->prepare($sqlU);
    $reqU->execute();
    
    
    $data = array_merge($data, $reqU->fetch(PDO::FETCH_ASSOC));
    echo json_encode($data);
}



$PDO = null;
?>