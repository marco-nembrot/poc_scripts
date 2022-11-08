<?php
header ('Content-Type: text/html; charset=UTF-8');
require 'config.php';

if ($_POST['action'] == 'GET') {
    $email = $_POST['user'];
    
    $sql = "SELECT c.id, a.id as alias, pseudo FROM alias a " .
            "JOIN connexion c ON a.connexion = c.id " .
            "WHERE email = '$email' " . 
            "AND active = 1;";
    $req = $PDO->prepare($sql);
    $req->execute();

    $data = $req->fetch(PDO::FETCH_ASSOC);
    echo json_encode($data);
    
    
    $uSql = 
        "UPDATE connexion " .
        "SET dateLastVisit = NOW(), countVisits = countVisits + 1 " .
        "WHERE id = " . $data['id'];
    $uReq = $PDO->prepare($uSql);
    $uReq->execute();
    
    
} else if ($_POST['action'] == 'SET') {
    $email = $_POST['user'];
    $pseudo = $_POST['pseudo'];
    $onPlay = $_POST['onPlay'];
    $reglages = $_POST['reglages'];
    $difficulte = $_POST['difficulte'];
    
    
    $iSql = "INSERT INTO connexion " .
            "(pseudo, dateCreation, dateLastVisit, countVisits) VALUES " .
            "('$pseudo', NOW(), NOW(), 1);";
    $req = $PDO->prepare($iSql);
    echo $req->execute();
    $userId = intval($PDO->lastInsertId());

    
    $iSqlA = "INSERT INTO alias " .
            "(connexion, email) VALUES " .
            "($userId, '$email');";
    $reqA = $PDO->prepare($iSqlA);
    if ($reqA->execute()) {
        $userAlias = intval($PDO->lastInsertId());
        if ($onPlay == -1) {
            $onPlay = 
                "(SELECT id FROM onPlay " . 
                "WHERE reglages = '$reglages' " .
                "AND difficulte = '$difficulte')";
        }
        $iSqlP = "INSERT INTO profil " .
                "(connexion, onPlay) VALUES " .
                "($userId, $onPlay);";
        $reqP = $PDO->prepare($iSqlP);
        echo $reqP->execute();
    } else {
        $userAlias = 0;
        $dSql = "DELETE FROM connexion WHERE id = $userId";
        $dReq = $PDO->prepare($dSql);
        echo $dReq->execute();   
    }
    
    
    $return = array();
    $return['id'] = $userId;    
    $return['alias'] = $userAlias;

    
    echo json_encode($return);

    
    
} else if ($_POST['action'] == 'profil') {
    $connexion = $_POST['connexion'];
    
    $sql = "SELECT p.* FROM profil p " .
            "WHERE connexion = $connexion;";
    $req = $PDO->prepare($sql);
    $req->execute();
    $data = $req->fetch(PDO::FETCH_ASSOC);
    unset($data['id']);
    unset($data['connexion']);
    
    
    $onPlay = $data['onPlay'];
    $sqlD = "SELECT * FROM difficulte d  " .
            "JOIN onPlay op ON d.nom = op.difficulte " .
            "WHERE op.id = $onPlay;";
    $req = $PDO->prepare($sqlD);
    $req->execute();
    $temp = $req->fetch(PDO::FETCH_ASSOC);
    unset($temp['id']);
    unset($temp['nom']);
    unset($temp['description']);
    $data = array_merge($data, $temp);
    
    $sqlR = "SELECT * FROM reglages r  " .
            "JOIN onPlay op ON r.nom = op.reglages " .
            "WHERE op.id = $onPlay;";
    $req = $PDO->prepare($sqlR);
    $req->execute();
    $temp = $req->fetch(PDO::FETCH_ASSOC);
    unset($temp['id']);
    unset($temp['nom']);
    unset($temp['description']);
    
    
    $data = array_merge($data, $temp);
    echo json_encode($data);
    
    
    
} else if ($_POST['action'] == 'parametres') {
    $data = [];
    
    extract($_POST);
    $onPlay = 
        "(SELECT id FROM onPlay " . 
        "WHERE reglages = '$reglages' " .
        "AND difficulte = '$difficulte')";
    
    $uSql = 
        "UPDATE profil " .
        "SET soundOn = $soundOn, effectsOn = $effectsOn, " .
        "onPlay = $onPlay " .
        "WHERE connexion  = $connexion;";
    $uReq = $PDO->prepare($uSql);
    $data["updateAudio"] = $uReq->execute();
    

    if (!empty($personnage)) {
        $uSql = 
            "UPDATE profil " .
            "SET personnage = '$personnage' " .
            "WHERE connexion = $connexion;";
        $uReq = $PDO->prepare($uSql);
        $data["updateCharacter"] = $uReq->execute();
    }
    if (!empty($plateforme)) {
        $uSql = 
            "UPDATE profil " .
            "SET plateforme = '$plateforme' " .
            "WHERE connexion = $connexion;";
        $uReq = $PDO->prepare($uSql);
        $data["updatePlateforme"] = $uReq->execute();
    }
    
    
    echo json_encode($data);
    
     
    
} else if ($_POST['action'] == 'sauvegarde') {
    extract($_POST);
    $onPlay = 
        "(SELECT id FROM onPlay " . 
        "WHERE reglages = '$reglages' " .
        "AND difficulte = '$difficulte')";
    
    $uSql = 
        "UPDATE profil " .
        "crossCollected = $crossCollected, crossUsed = $crossUsed, " .         
        "ideaMet = $ideaMet, ideaDestroyed = $ideaDestroyed, " .     
        "gourdMet = $gourdMet, waterPtMet = $waterPtMet, waterPtConsumed = $waterPtConsumed, " .
        "faithCurrentAmount = $faithCurrentAmount, faithMaxAmount = $faithMaxAmount, faithCombinedAmount = $faithCombinedAmount, " .
        "rosario = $rosario, unitedSouls = $unitedSouls," .
        "onPlay = $onPlay " .
        "WHERE connexion  = $connexion;";
    $uReq = $PDO->prepare($uSql);
    echo $uReq->execute();
    

    if (!empty($personnage)) {
        $uSql = 
            "UPDATE profil " .
            "SET personnage = '$personnage' " .
            "WHERE connexion = $connexion;";
        $uReq = $PDO->prepare($uSql);
        echo $uReq->execute();
    }
    if (!empty($plateforme)) {
        $uSql = 
            "UPDATE profil " .
            "SET plateforme = '$plateforme' " .
            "WHERE connexion = $connexion;";
        $uReq = $PDO->prepare($uSql);
        echo $uReq->execute();
    }
}



$PDO = null;
?>